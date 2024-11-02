using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Day_10.Validators;
using Microsoft.AspNetCore.Mvc;

namespace Day_10.Models
{
	public class Student
	{
		[Key]
		public int  Id { get; set; }
		[DisplayName("Name")]
		[MinLength(3, ErrorMessage = "Name cannot be less than 3 chars ")]
		[MaxLength(23,ErrorMessage ="Name cannot exceed 23 chars ")]
		[Unique]
		public string name { get; set; }
        [DisplayName("Age")]
		//[Range(3,22)]
		[Remote("TestAge", "Student", ErrorMessage ="Age must be between 3 and 25")]
        public int age { get; set; }
        [DisplayName("Parent's Number")]
		//[RegularExpression("{010|011|012}")]
		public int parentNum { get; set; }
        [DisplayName("Image")]
        public string? image { get; set; }
		[ForeignKey("Department")]
		public int? dept_id { get; set; }
		public Department? Department { get; set; }

		public ICollection<crsResult> crsResults { get; set; } = new List<crsResult>();


	}
}

