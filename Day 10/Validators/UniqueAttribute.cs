using System;
using System.ComponentModel.DataAnnotations;
using Day_10.Context;
using Day_10.Models;

namespace Day_10.Validators
{
	public class UniqueAttribute : ValidationAttribute
	{
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
			Student student = (Student) validationContext.ObjectInstance;

			string name = value as string;
			SchoolContext s = new SchoolContext();
			if (student.Id == 0)
			{
				var stu = s.Students.FirstOrDefault(x => x.name == name);
				if (stu == null)
				{
					return ValidationResult.Success;
				}
				return new ValidationResult("Student's Name Already Exists");
			}
			else
            {
                return ValidationResult.Success;
            }
        }
     
	}
}

