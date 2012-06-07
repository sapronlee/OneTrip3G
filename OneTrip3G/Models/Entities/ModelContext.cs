using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace OneTrip3G.Models.Entities
{
    class ModelContext : DbContext
    {
        public DbSet<Place> Places { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Setting> Settings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PlaceDBConfiguration());
            modelBuilder.Configurations.Add(new UserDBConfiguration());
            modelBuilder.Configurations.Add(new SettingDBConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }

    class PlaceDBConfiguration : EntityTypeConfiguration<Place>
    {
        public PlaceDBConfiguration() : base()
        {
            Property(p => p.Name).IsRequired().HasMaxLength(20);
            Property(p => p.EnglishName).IsRequired().HasMaxLength(40);
            Property(p => p.Keywords).IsOptional().HasMaxLength(40);
            Property(p => p.Description).IsOptional().HasMaxLength(100);
            Property(p => p.VideoFile).IsOptional().HasMaxLength(200);
            Property(p => p.VideoSize).IsOptional();
            Property(p => p.MapFile).IsOptional().HasMaxLength(200);
            Property(p => p.MapSize).IsOptional();
        }
    }

    class UserDBConfiguration : EntityTypeConfiguration<User>
    {
        public UserDBConfiguration() : base()
        {
            Property(u => u.Name).IsRequired().HasMaxLength(20);
            Property(u => u.Password).IsRequired().HasMaxLength(32);
        }
    }

    class SettingDBConfiguration : EntityTypeConfiguration<Setting>
    {
        public SettingDBConfiguration() : base()
        {
            Property(s => s.Name).IsRequired().HasMaxLength(50);
            Property(s => s.DisplayName).IsRequired().HasMaxLength(200);
            Property(s => s.Description).IsRequired();
            Property(s => s.Value).IsOptional();
        }
    }
}
