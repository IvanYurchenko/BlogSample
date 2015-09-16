using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BlogSample.Extentions
{
	public static class EnumExtentions
	{
		public static IEnumerable<SelectListItem> ToSelectListItems<TEnum>(this TEnum enumClass)
			where TEnum : struct
		{
			IEnumerable<SelectListItem> selectListItems = from TEnum e in Enum.GetValues(typeof(TEnum))
						 select new SelectListItem()
						 {
							 Value = e.ToString(),
							 Text = e.ToString(),
							 Selected = e.ToString() == enumClass.ToString()
						 };

			return selectListItems;
		}  
	}
}