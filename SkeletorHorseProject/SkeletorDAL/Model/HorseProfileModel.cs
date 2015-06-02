using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using SkeletorHorseProject.Controllers;

namespace SkeletorDAL.Model
{
    public class HorseProfileModel
    {
        public int ID { get; set; }
        public string Breeding { get; set; }
        public string Gender { get; set; }
        public string Name { get; set; }
        [DisplayName("Is for rent")]
        public bool Rent { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }
        public string Race { get; set; }
        public int Withers { get; set; }
        public string Awards { get; set; }
        public bool IsActive { get; set; }
        [DisplayName("For sale")]
        public bool IsForSale { get; set; }
        public string Price { get; set; }
        [DisplayName("Sold")]
        public bool IsSold { get; set; }
        public string State { get; set; }
        public string Description { get; set; }
        public string Medicine { get; set; }
        public string FamilyTree { get; set; }
        public string ImagePath { get; set; }
        public string FacebookPath { get; set; }
        public BlogModel Blog { get; set; }
        public List<int> AdminId { get; set; }
        public HorseProfileModel()
        {
            
        }
    }
}
