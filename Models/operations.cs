
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectF.Models
{
    public class operations
    {
		[Required]
		[Display(Name = "Name")]
		[DataType(DataType.Text)]
		public string operationName { get; set; }

		[Key]
		[Required]
		[Display(Name = "ID")]
		public int operationsID { get; set; }


		[Required]
		[Display(Name ="statrtDate")]
		[DataType(DataType.DateTime)]
		public DateTime startDate { get; set; }

		[Required]
		[Display(Name = "endDate")]
		[DataType(DataType.DateTime)]
		public DateTime endDate { get; set; }
		[Required]
		[Display(Name = "clientID")]
		[ForeignKey("clientID")]
		public int clientID { get; set; }
		public client client { get; set; }

		[Required]
		[Display(Name = "financeID")]
		[ForeignKey("financeID")]
		public int financeID { get; set; }
        public ICollection<History>Historys { get; set; }   
        //public finance finance { get; set; }

	}
}
