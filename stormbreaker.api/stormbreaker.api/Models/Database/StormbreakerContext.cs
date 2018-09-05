using Microsoft.EntityFrameworkCore;
using stormbreaker.api.Models.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stormbreaker.api.Models.Database
{
    public class StormbreakerContext : DbContext
    {
        public StormbreakerContext(DbContextOptions<StormbreakerContext> options) : base(options)
        { }

        public DbSet<User> Users { get; set; }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Transaction> Transactions { get; set; }
    }
}
