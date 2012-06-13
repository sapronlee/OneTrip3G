using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OneTrip3G.IRepositories;
using OneTrip3G.Models.Entities;
using OneTrip3G.Infrastructure;

namespace OneTrip3G.Repositories
{
    class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        { }
    }
}
