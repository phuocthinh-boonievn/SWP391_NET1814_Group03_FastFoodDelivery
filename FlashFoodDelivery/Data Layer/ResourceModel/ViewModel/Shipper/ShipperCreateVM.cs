﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.ResourceModel.ViewModel.Shipper
{
	public class ShipperCreateVM
	{
		[Required(ErrorMessage = "Username is required")]
		public string Username { get; set; }
		[Required(ErrorMessage = "FullName is required")]
		public string FullName { get; set; }
		[Required(ErrorMessage = "Password is required")]
		[MinLength(6)]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required(ErrorMessage = "Confirm is required")]
		[DataType(DataType.Password)]
		[Display(Name = "Confirm Password")]
		[Compare("Password", ErrorMessage = "Password and confirmation password does not match, please try again!")]
		public string ConfirmPassword { get; set; }
	}
}
