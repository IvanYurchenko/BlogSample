using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using BlogSample.Enums;

namespace BlogSample.ViewModels
{
	public class PostViewModel
	{
		[Required]
		[StringLength(50)]
		public string Username { get; set; }

		[Required]
		[DataType(DataType.Date)]
		public DateTime Date { get; set; }

		[Required]
		public Gender Gender { get; set; }

		[HiddenInput]
		public IEnumerable<SelectListItem> GendersList { get; set; }
			
		[Required]
		[StringLength(2000)]
		[DataType(DataType.MultilineText)]
		public string Body { get; set; }
	}
}