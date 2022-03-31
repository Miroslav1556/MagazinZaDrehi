using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagazinZaDrehi.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }  
        public DbSet<Articul> Articul { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Order> Order { get; set; }

    }
}
