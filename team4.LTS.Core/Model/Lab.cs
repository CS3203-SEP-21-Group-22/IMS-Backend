﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace team4.LTS.Core.Model
{
	public class Lab
	{
		[Key]
		public int LabId { get; set; }
		[Required]
		public int LabCode { get; set; }
		public string? ImageURL { get; set; } 
		[RegularExpression(@"^(Computer Lab|Embeded System Lab|IoT Lab)$", ErrorMessage = "ADD ERROR MESSAGE")]
		public string? LabName { get; set; }
		public Boolean IsActive { get; set; }
	}
}
