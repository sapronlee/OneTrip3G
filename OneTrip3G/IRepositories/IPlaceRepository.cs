using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OneTrip3G.Models.Entities;
using System.Linq.Expressions;

namespace OneTrip3G.IRepositories
{
    public interface IPlaceRepository : IRepository<Place>
    {
        //扩展PlaceRepository特定方法
    }
}
