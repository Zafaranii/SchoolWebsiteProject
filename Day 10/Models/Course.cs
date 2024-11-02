using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day_10.Models
{
	public class Course
	{
		public int Id { get; set; }
        [DisplayName("Name")]
        public string name { get; set; }
		public double minDegree { get; set; }


        [ForeignKey("Department")]
        public int? dept_id { get; set; }
        public Department? Department { get; set; }

		public ICollection<crsResult> crsResults { get; set; } = new List<crsResult>();
		public ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();


		public Course()
		{
		}
	}
}

