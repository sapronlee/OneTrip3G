using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OneTrip3G.IRepositories;
using OneTrip3G.Models.Entities;

namespace OneTrip3G.Repositories
{
    class SettingRepository : ISettingRepository
    {

        public IList<Setting> GetSettings()
        {
            using (var db = new ModelContext())
            {
                return db.Settings.ToList();
            }
        }

        public void Save(IEnumerable<Setting> settings)
        {
            using (var db = new ModelContext())
            {
                foreach (var setting in settings)
                {
                    var dbSetting = db.Settings.FirstOrDefault(m => m.Name.Equals(setting.Name));
                    if (dbSetting == null)
                    {
                        db.Settings.Add(setting);
                    }
                    else
                    {
                        dbSetting = setting;
                        db.Entry<Setting>(dbSetting).State = System.Data.EntityState.Modified;
                    }
                }
                db.SaveChanges();
            }
        }
    }
}
