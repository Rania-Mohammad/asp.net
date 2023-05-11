
using MessagePack;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace projectF.Models
{
    public class client
    {
		[Display(Name = "ID")]
		[Required]
		public int clientID{ get; set; }


		[Required]
		[DataType(DataType.Text)]
		[Display(Name = "Name")]
		public string clientName { get; set; }


		[ForeignKey("operationID")]
		[Required]
		[Display(Name = "operationID")]
		public int operationID { get; set; }

	
		[DataType(DataType.Text)]
		[Display(Name = "operationName")]
		public string operationName { get; set; }
		public ICollection<operations> operationss { get; set; }

	}
}
