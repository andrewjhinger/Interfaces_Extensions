using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Interfaces_Extensions.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Interfaces_Extensions.IE_Context
{
    public class InterfacesContext : DbContext
    {
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Students> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}