using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using webapi.Mapping;

namespace webapi.DAL
{
    public class AccountContext:DbContext
    {
        public AccountContext() : base("AccountContext")
        {
            
        }

        public DbSet<User> UserList { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
        }
    }
}