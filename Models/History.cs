using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectF.Models
{
    public class History
    {
        [Key]
		[Display(Name = "ID")]
        [Required]
		public int HistoryID { get; set; }

		[Required]
		[ForeignKey("operationID")]
		[Display(Name = "operationID")]
		public int operationID { get; set; }

        [Required]
		[Display(Name = "operationName")]
		[DataType(DataType.Text)]
		public string operationName { get; set; }

        [Required]
		[Display(Name = "operationDate")]
		[DataType(DataType.DateTime)]
		public DateTime operationDate { get; set; }

        [Required]
		[Display(Name = "EgPrice")]
		[DataType(DataType.Currency)]
		public Double egyPrice { get; set; }

		[Required]
		[Display(Name = "dollerPrice")]
		[DataType(DataType.Currency)]
		public Double dollarPrice { get; set; }

		[Display(Name = "clientID")]
		public int clientID { get; set; }

		[Required]
		[ForeignKey("employeeID")]
		[Display(Name = "employeeID")]
		public int employeeID { get; set; }
        public Employee employee { get; set; }  
        public operations operation { get; set; }


    }
}
