using System;
using Day_10.Models;
using Microsoft.EntityFrameworkCore;

namespace Day_10.Context
{
	public class SchoolContext: DbContext
	{
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = .; Database = School ; User Id=SA; Password=MyStrongPass123; Encrypt = False");
        }

        public SchoolContext()
		{
		}
		public DbSet<Student> Students { get; set; }
		public DbSet<Instructor> Instructors { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<crsResult> crsResults { get; set; }
		public DbSet<Department> Departments { get; set; }

	}
}

