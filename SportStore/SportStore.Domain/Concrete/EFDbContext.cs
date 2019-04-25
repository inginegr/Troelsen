﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SportStore.Domain.Entities;

namespace SportStore.Domain.Concrete
{
    class EFDbContext : DbContext
    {
        public EFDbContext(): base("name=EFDbContext") { }

        public DbSet<Product> Products { get; set; }
    }
}
