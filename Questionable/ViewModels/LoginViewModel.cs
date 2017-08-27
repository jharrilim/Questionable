﻿using System.ComponentModel.DataAnnotations;

namespace Questionable.ViewModels
{
	public class LoginViewModel
    {
		[Required]
		public string Username { get; set; }

		[Required, DataType(DataType.Password)]
		public string Password { get; set; }

		[Display(Name = "Remember Me")]
		public bool RememberMe { get; set; }

		public string ReturnUrl { get; set; }
	}
}
