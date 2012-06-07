using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OneTrip3G.Enums;

namespace OneTrip3G.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SettingStorageAttribute : Attribute
    {
        private readonly StorageLocation location;
        private readonly string key;

        public SettingStorageAttribute(StorageLocation location)
            : this(location, null)
        {
        }

        public SettingStorageAttribute(StorageLocation location, string key)
        {
            this.location = location;
            this.key = key;
        }

        public StorageLocation Location
        {
            get { return location; }
        }

        public string Key
        {
            get { return key; }
        }
    }
}
