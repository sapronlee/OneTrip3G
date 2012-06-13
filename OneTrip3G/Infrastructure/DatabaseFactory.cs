using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OneTrip3G.Models.Entities;

namespace OneTrip3G.Infrastructure
{
    class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private ModelContext dataContext;

        public ModelContext Get()
        {
            return dataContext ?? (dataContext = new ModelContext());
        }

        protected override void DisposeCore()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }
    }
}
