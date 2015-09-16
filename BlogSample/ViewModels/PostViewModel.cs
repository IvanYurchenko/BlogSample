﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using BlogSample.Enums;

namespace BlogSample.ViewModels
{
	public class PostViewModel
	{
		[HiddenInput]
		[DisplayName("Id")]
		public int Id { get; set; }

		[Required]
		[StringLength(50)]
		[DisplayName("User Name")]
		public string Username { get; set; }

		[Required]
		[DisplayName("Date")]
		[DataType(DataType.Date)]
		public DateTime Date { get; set; }

		[Required]
		[DisplayName("Gender")]
		public Gender Gender { get; set; }

		[HiddenInput]
		public IEnumerable<SelectListItem> GendersList { get; set; }

		[Required]
		[DisplayName("Body")]
		[StringLength(2000)]
		[DataType(DataType.MultilineText)]
		public string Body { get; set; }
	}
}