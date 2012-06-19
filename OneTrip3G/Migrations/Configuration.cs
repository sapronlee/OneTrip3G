using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using OneTrip3G.Models.Entities;
using System.Web.Security;

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
            //add admin user
            using (var db = new ModelContext())
            {
                var admin = db.Users.FirstOrDefault(m => m.Name.ToLower().Equals("admin"));
                if (admin == null)
                {
                    var user = new User
                    {
                        Name = "admin",
                        Password = FormsAuthentication.HashPasswordForStoringInConfigFile("admin", "MD5")
                    };
                    db.Users.Add(user);
                    db.SaveChanges();
                }
            }
        }
    }
}
