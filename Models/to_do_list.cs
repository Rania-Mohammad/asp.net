using MessagePack;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectF.Models
{
    public class to_do_list
    {
        [Required]
		[Display(Name = "ID")]
		public int to_do_listID {get; set;}

        [Required]
		[Display(Name = "taskID")]
		public int taskID { get; set; }


        [Required]
		[Display(Name = "taskName")]
        [DataType(DataType.Text)]
		public string taskName { get; set; }
        [Required]
		[Display(Name = "employeeID")]
        [ForeignKey("employeeID")]
		public int employeeID { get; set; }
		[Required]
		[Display(Name = "Deadline")]
		[DataType(DataType.DateTime)]
		public DateTime deadline { get; set; }
		[Required]
        public bool state { get; set; }
        public Employee employee { get; set; }



    }
}
