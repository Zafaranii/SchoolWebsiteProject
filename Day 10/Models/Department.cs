using System;
using System.ComponentModel;

namespace Day_10.Models
{
	public class Department
	{
		public int Id { get; set; }
        [DisplayName("Name")]
        public string name { get; set; }
		public string Manager { get; set; }


		public ICollection<Student> Students { get; set; } = new List<Student>();
		public ICollection<Course> Courses { get; set; } = new List<Course>();
		public ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();

		public Department()
		{
		}
	}
}

