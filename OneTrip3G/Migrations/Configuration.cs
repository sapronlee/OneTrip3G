using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using OneTrip3G.Models.Entities;

namespace OneTrip3G.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ModelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ModelContext context)
        {
            
        }
    }
}
