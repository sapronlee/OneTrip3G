using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using OneTrip3G.IServices;
using OneTrip3G.IRepositories;
using OneTrip3G.Attributes;
using OneTrip3G.Models.Entities;
using OneTrip3G.Enums;

namespace OneTrip3G.Services
{
    public class SettingService : ISettingService
    {
        private readonly object @lock = new object();
        private readonly ISettingRepository repository;
        private readonly Dictionary<Type, ISetting> settingsStore = new Dictionary<Type, ISetting>();

        public SettingService(ISettingRepository repository)
        {
            this.repository = repository;
        }

        public T GetSettings<T>() where T : ISetting
        {
            //先检查Store里面是否存在，如果不存在在去读取
            var settingType = typeof(T);
            if (!settingsStore.ContainsKey(settingType))
            {
                lock (@lock)
                {
                    if (!settingsStore.ContainsKey(settingType))
                    {
                        LoadSetting<T>();
                    }
                }
            }
            return (T)settingsStore[settingType];
        }

        public void SaveSettings<T>(T globalSetting) where T : ISetting
        {
            var settingType = typeof(T);

            //缓存处理
            if (settingsStore.ContainsKey(settingType))
                settingsStore[settingType] = globalSetting;
            else
                settingsStore.Add(settingType, globalSetting);

            var settingMetadatas = ReadGlobalSettingMetadata<T>();
            var settings = repository.GetSettings();

            foreach (var setting in settingMetadatas)
            {
                switch (setting.Storage.Location)
                {
                    case StorageLocation.Database:
                        var value = setting.Read(globalSetting);
                        var dbSetting = settings.FirstOrDefault(x => x.Name.Equals(setting.Storage.Key));
                        if (dbSetting != null)
                        {
                            dbSetting.Value = value ?? setting.DefaultValue as string ?? string.Empty;
                        }
                        else 
                        {
                            settings.Add(new Setting
                            {
                                Name = setting.Storage.Key,
                                Description = setting.Description,
                                DisplayName = setting.DisplayName,
                                Value = value ?? setting.DefaultValue as string ?? string.Empty
                            });
                        }
                        break;
                    case StorageLocation.Xml:
                        //写入到Xml文件中（未实现）
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            repository.Save(settings);

        }

        private void LoadSetting<T>() where T : ISetting
        {
            //创建实例
            var instance = Activator.CreateInstance<T>();
            //添加到缓存
            settingsStore.Add(typeof(T), instance);
            //从仓库中获取数据
            var settings = repository.GetSettings();
            //获取所有的属性元数据
            var settingMetadatas = ReadGlobalSettingMetadata<T>();

            foreach (var setting in settingMetadatas)
            {
                //初始化所有属性
                setting.Write(instance, setting.DefaultValue);

                switch (setting.Storage.Location)
                {
                    case Enums.StorageLocation.Database:
                        //从数据库中读取
                        var dbSetting = settings.FirstOrDefault(d => d.Name.Equals(setting.Storage.Key));
                        if (dbSetting != null)
                        {
                            //填充属性
                            setting.Write(instance, dbSetting.Value);
                        }
                        break;
                    case Enums.StorageLocation.Xml:
                        //从Xml中读取（未实现）
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private static IEnumerable<SettingDescriptor> ReadGlobalSettingMetadata<T>()
        {
            return typeof(T).GetProperties()
                .Where(x => x.GetCustomAttributes(true).OfType<SettingStorageAttribute>().Any())
                .Select(x => new SettingDescriptor(x))
                .ToArray();
        }


        private class SettingDescriptor
        {
            private readonly PropertyInfo property;
            private object defaultValue;
            private string description;
            private string displayName;
            private SettingStorageAttribute storage;

            public SettingDescriptor(PropertyInfo property)
            {
                this.property = property;
                displayName = property.Name;

                ReadAttribute<DisplayNameAttribute>(a => displayName = a.DisplayName);
                ReadAttribute<DescriptionAttribute>(a => description = a.Description);
                ReadAttribute<DefaultValueAttribute>(a => defaultValue = a.Value);
                ReadAttribute<SettingStorageAttribute>(a => storage = a);
            }

            public object DefaultValue
            {
                get { return defaultValue; }
            }

            public string Description
            {
                get { return description; }
            }

            public string DisplayName
            {
                get { return displayName; }
            }

            public SettingStorageAttribute Storage
            {
                get { return storage; }
            }

            public void Write(ISetting setting, object value)
            {
                if (value != null)
                {
                    var converted = Convert.ChangeType(value, property.PropertyType);
                    property.SetValue(setting, converted, null);
                }
            }

            public string Read(ISetting setting)
            {
                return (property.GetValue(setting, null) ?? string.Empty).ToString();
            }

            private void ReadAttribute<TAttribute>(Action<TAttribute> callback)
            {
                var instances = property.GetCustomAttributes(typeof(TAttribute), true).OfType<TAttribute>();
                foreach (var instance in instances)
                {
                    callback(instance);
                }
            }
        }
        
    }
}
