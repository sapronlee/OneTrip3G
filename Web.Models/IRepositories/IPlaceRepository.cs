using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Web.Models.Entities;

namespace Web.Models.IRepositories
{
    public interface IPlaceRepository
    {
        /// <summary>
        /// 通过指定的Id获取景点
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>一个景点</returns>
        Place GetById(int id);
        /// <summary>
        /// 通过指定的英文名获取景点
        /// </summary>
        /// <param name="englishName">英文名</param>
        /// <returns>一个景点</returns>
        Place getByEnglishName(string englishName);
        /// <summary>
        /// 创建或者更改指定的景点
        /// </summary>
        /// <param name="place">景点</param>
        /// <returns>成功返回true,失败返回false</returns>
        bool CreateOrChange(Place place);
        /// <summary>
        /// 通过指定的景点对象删除景点
        /// </summary>
        /// <param name="place">景点</param>
        /// <returns>成功返回true,失败返回false</returns>
        bool Delete(Place place);
        /// <summary>
        /// 通过指定的Id删除景点
        /// </summary>
        /// <param name="id">景点</param>
        /// <returns>成功返回true,失败返回false</returns>
        bool Delete(int id);
    }
}
