using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneTrip3G.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
