using Microsoft.EntityFrameworkCore;
using PatikaOdev3.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaOdev3.DataAccess.Contexts
{
    public class OdevDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;database=PatikaOdev3;Trusted_Connection=True;");
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Role> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
