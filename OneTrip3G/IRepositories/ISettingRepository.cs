using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OneTrip3G.Models.Entities;

namespace OneTrip3G.IRepositories
{
    public interface ISettingRepository
    {
        /// <summary>
        /// 获取所有设置
        /// </summary>
        /// <returns>IQueryable</returns>
        IList<Setting> GetSettings();
        /// <summary>
        /// 保存所有设置
        /// </summary>
        /// <param name="settings">IEnumerable</param>
        void Save(IEnumerable<Setting> settings);
    }
}
