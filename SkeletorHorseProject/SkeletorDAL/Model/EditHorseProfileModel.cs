using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkeletorDAL.Model
{
	public class EditHorseProfileModel
	{
		public int ID { get; set; }
		[Required(ErrorMessage = "What is the name of the horse?")]
		public string Name { get; set; }
		[Required(ErrorMessage = "(yyyy-mm-dd)")]
		public DateTime Birthday { get; set; }
		[Required(ErrorMessage = "Pony, Camargue etc.")]
		public string Race { get; set; }
		[Required(ErrorMessage = "Wither in Centimeters. (mankhöjd)")]
		public int Withers { get; set; }
		[Required(ErrorMessage = "Has the horse won any awards.")]
		public string Awards { get; set; }
		[Required(ErrorMessage = "Write something about the horse.")]
		public string Description { get; set; }
		[Required(ErrorMessage = "Does the horse need any medicine?")]
		public string Medicine { get; set; }
		[Required(ErrorMessage = "Write something about the family tree."), DisplayName("Family tree")]
		public string FamilyTree { get; set; }
		[Required(ErrorMessage = "Is the horse for sale?"), DisplayName("For sale")]
		public bool IsForSale { get; set; }
		[Required(ErrorMessage = "What is the price of the horse?")]
		public string Price { get; set; }
		[DisplayName("Facebook path")]
	    public string FacebookPath { get; set; }
        [DisplayName("Sold")]
        public bool IsSold { get; set; }
        [DisplayName("Delete horse")]
        public bool IsActive { get; set; }
        [DisplayName("Last updated")]
        public DateTime LastUpdated { get; set; }
        public string Breeding { get; set; }
        public string Gender { get; set; }
        [DisplayName("Is for rent")]
        public bool Rent { get; set; }
	}
}
