using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkeletorDAL.Model
{
	public class CreateHorseModel
	{
		[Required(ErrorMessage = "Input required.")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Input required. (yyyy-mm-dd)")]
		public DateTime Birthday { get; set; }
		[Required(ErrorMessage = "Input required. (Pony)")]
		public string Race { get; set; }
		[Required(ErrorMessage = "Input required. (centimeter)")]
		public int Withers { get; set; }
		[Required(ErrorMessage = "Input required.")]
		public string Awards { get; set; }

		public string Description { get; set; }
		public string Medicine { get; set; }
		public string FamilyTree { get; set; }
		[Required(ErrorMessage = "Input required.")]
		public bool IsForSale { get; set; }
		[Required(ErrorMessage = "Input required.")]
		public string Price { get; set; }
		public string ImagePath { get; set; }
		public bool IsActive { get; set; }
	}
}
