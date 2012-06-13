using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OneTrip3G.IRepositories;
using OneTrip3G.Models.Entities;
using System.Linq.Expressions;
using OneTrip3G.Infrastructure;

namespace OneTrip3G.Repositories
{
    class PlaceRepository : RepositoryBase<Place>, IPlaceRepository
    {
        public PlaceRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        { }
    }
}
