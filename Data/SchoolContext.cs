using EF10_LeftJoin_RightJoin_Sample.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF10_LeftJoin_RightJoin_Sample.Data
{
    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Department> Departments { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=SchoolDB;User Id=sa;Password=Luiscoco123456;TrustServerCertificate=True;");
        }
    }
}
