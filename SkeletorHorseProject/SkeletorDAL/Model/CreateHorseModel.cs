using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SkeletorDAL.Model
{
	public class CreateHorseModel
	{
		[Required(ErrorMessage = "What is the name of the horse?")]
		public string Name { get; set; }
		[Required(ErrorMessage = "(yyyy-mm-dd)")]
		[DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
		public DateTime Birthday { get; set; }
		[Required(ErrorMessage = "Pony, Camargue etc.")]
		public string Race { get; set; }
		[Required(ErrorMessage = "Wither in Centimeters. (mankhöjd)")]
        [Display(Name = "Withers(cm)")]
		public int Withers { get; set; }
		public string Awards { get; set; }
		public string Description { get; set; }
		[DisplayName("Health")]
		public string Medicine { get; set; }
		public string FamilyTree { get; set; }
		public bool IsForSale { get; set; }
		public string Price { get; set; }
		[DisplayName("Facebook path")]
		public string FacebookPath { get; set; }
		[DisplayName("Sold")]
		public bool IsSold { get; set; }
		[DisplayName("Delete horse")]
		public bool IsActive { get; set; }
		[DisplayName("Last updated")]
		public DateTime LastUpdated { get; set; }
		public bool Breeding { get; set; }
        [Required(ErrorMessage = "Must pick gender")]
		public string Gender { get; set; }
		[DisplayName("Is for rent")]
		public bool Rent { get; set; }

		public CreateHorseModel()
		{
			LastUpdated = DateTime.Now;
		}
	}
}
