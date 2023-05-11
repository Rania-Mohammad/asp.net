using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectF.Models
{
	//public enum gender { male, female };
	public class Employee
    {
        [Key]
		[Display(Name = "ID")]
		public int employeeID { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [DataType(DataType.Text)]
		[Display(Name = "Name")]
		public string employeeName { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [DataType(DataType.Text)]
		[Display(Name = "emailAddress")]
		//[RegularExpression(@"^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Phone number must be in the format xxx-xxx-xxxx")]
		public string Email { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [DataType(DataType.Password)]
		[Display(Name = "password")]
		public string password { get; set; }
		[DataType(DataType.Text)]
		[Display(Name = "Image")]
		[System.ComponentModel.DataAnnotations.Required]
		public string employeeimage { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
		// [DataType(DataType.Text)]
		[Range(22,60)]
		[Display(Name = "age")]
		public int age { get; set; }
		[System.ComponentModel.DataAnnotations.Required]
		[DataType(DataType.Text)]
		[Display(Name = "state")]
		public string state { get; set; }
		// public string gender { get; set; }
		[System.ComponentModel.DataAnnotations.Required]
		//[DataType(DataType.Text)]
		[Display(Name = "Salary")]
		public double salary { get; set; }
        public ICollection<to_do_list> to_do_list { get; set; }
        public ICollection<History> history { get; set; }

    }

}
