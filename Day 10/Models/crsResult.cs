using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day_10.Models
{
	public class crsResult
	{
		public int Id { get; set; }
        [Range(0, 100)]
        public double degree { get; set; }


        [ForeignKey("Student")]
        public int? student_id { get; set; }
        public Student? Student { get; set; }

        [ForeignKey("Course")]
        public int? course_id { get; set; }
        public Course? Course { get; set; }

        public crsResult()
		{
		}
	}
}

