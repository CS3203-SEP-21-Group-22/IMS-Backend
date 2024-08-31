﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.ApplicationCore.DTO
{
	internal class UserDTO
	{
		public int UserId { get; set; }
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public string? Email { get; set; }
		[RegularExpression(@"^(Clerk|Technician|Student|AcademicStaff|SystemAdmin)$", ErrorMessage = "ADD ERROR MESSAGE")]
		public string? Role { get; set; }
		public Boolean IsActive { get; set; }
	}
}
