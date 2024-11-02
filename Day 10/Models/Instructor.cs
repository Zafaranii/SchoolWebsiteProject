using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day_10.Models
{
	public class Instructor
	{
		public int Id { get; set; }
        [DisplayName("Name")]
        [MinLength(3)]
        [MaxLength(23)]
        public string name { get; set; }
        [DisplayName("Image")]
        public string? image { get; set; }
        [DisplayName("Salary")]
        public int salary { get; set; }
        [DisplayName("Address")]
        public string address { get; set; }


        [ForeignKey("Department")]
        public int? dept_id { get; set; }
        public Department? Department { get; set; }

        [ForeignKey("Course")]
        public int? course_id { get; set; }
        public Course? Course { get; set; }


        public Instructor()
		{
		}
	}
}

