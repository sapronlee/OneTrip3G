using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace Web.Models.Entities
{
    class ModelContext : DbContext
    {
        /// <summary>
        /// 用户数据集
        /// </summary>
        public DbSet<User> Users { get; set; }
        /// <summary>
        /// 景点数据集
        /// </summary>
        public DbSet<Place> Places { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
