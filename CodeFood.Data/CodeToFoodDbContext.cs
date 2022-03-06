using CodeFood.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFood.Data
{
    public class CodeToFoodDbContext : DbContext
    {
        public CodeToFoodDbContext(DbContextOptions<CodeToFoodDbContext> options): base(options)
        {

        }
        public DbSet<Resturant> Resturants { get; set; }
    }
}
