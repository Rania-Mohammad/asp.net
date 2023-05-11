using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectF.Models
{
	public class login
	{
		[Key]
		[Display(Name ="Email")]
		[Required]
		[EmailAddress]
		public string email { get; set; }
		[Display(Name = "password")]
		[Required]
		[DataType(DataType.Password)]
		public string password { get; set; }
		[Required]
		[DataType(DataType.Text)]
		public string state { get; set; }

        public bool Remember { get; set; }
    }
}
