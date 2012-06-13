using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OneTrip3G.Models.Entities;

namespace OneTrip3G.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        ModelContext Get();
    }
}
