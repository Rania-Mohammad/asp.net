
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectF.Models
{
    public class finance
    {
		[Display(Name = "Amount")]
		[Required]
		public double operationAmount { get; set; }

		[Required]
		[Display(Name = "Total")]
		public double totalAmount { get; set; }

        [Required]
		[Display(Name = "Taxes")]
		public double taxes { get; set; }

		[Required]
		[Display(Name = "state")]
		[DataType(DataType.Text)]
		public string state { get; set;}

		[Required]
		[Display(Name = "maintance")]
		public double maintenanceAmount { get; set; }
		[Required]
		[ForeignKey("operationID")]
		[Display(Name = "operationID")]
		public int operationID { get; set; }
        [Key]
		[Required]
		[Display(Name = "ID")]
		public int financeID { get; set; }
        //public operations operations { get; set; }
       


    }
}
