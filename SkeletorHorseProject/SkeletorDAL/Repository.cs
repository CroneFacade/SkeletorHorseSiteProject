﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkeletorDAL.Helpers;
using SkeletorDAL.Model;
using SkeletorDAL.POCO;
namespace SkeletorDAL
{
    public static class Repository
    {
        public static string GetAdminEmail()
        {
            using (var context = new HorseContext())
            {
                return
                    (from u in context.Users
                     where u.AdminLevel == 1
                     select u.EmailAdress).FirstOrDefault();
            }
        }
        public static void RegisterAdmin(RegisterAdminModel model)
        {
            using (var context = new HorseContext())
            {
                var newAdmin = new User()
                {
                    Username = model.Username,
                    Password = model.Password.SuperHash(),
                    AdminLevel = model.AdminLevel,
                    IsActive = true,
                };

                context.Users.Add(newAdmin);
                context.SaveChanges();
            }
        }
        public static List<Horse> GetAllHorses()
        {
            using (var context = new HorseContext())
            {
                return (from h in context.Horses
                        select h).ToList();
            }
        }

        public static HorseModel GetSpecificHorseById(int id)
        {
            using (var context = new HorseContext())
            {
                return (from h in context.Horses
                        where h.ID == id
                        select new HorseModel()
                        {
                            Name = h.Name,
                            Race = h.Race,
                            Withers = h.Withers,
                            Birthday = h.Birthday,
                            Description = h.Description,
                            Medicine = h.Medicine,
                            FamilyTree = h.FamilyTree,
                            Awards = h.Awards
                        
                        }).FirstOrDefault();
            }
        }

        public static List<HorseModel> GetHorsesDependingOnNavigation(int navigationId)
        {

            using (var context = new HorseContext())
            {
                List<HorseModel> horseList = new List<HorseModel>();
                switch (navigationId)
                {
                    case 1:
                        horseList = (from h in context.Horses
                                     select new HorseModel()
                                     {
                                         Awards = h.Awards,
                                         Birthday = h.Birthday,
                                         ID = h.ID,
                                         IsActive = h.IsActive,
                                         IsForSale = h.IsForSale,
                                         Name = h.Name,
                                         Price = h.Price,
                                         Race = h.Race,
                                         Withers = h.Withers,
                                         IsSold = h.IsSold,
                                         State = "All horses"
                                     }).ToList();
                        break;

                    case 2:
                        horseList = (from h in context.Horses
                                     where h.IsForSale == true
                                     select new HorseModel()
                                     {
                                         Awards = h.Awards,
                                         Birthday = h.Birthday,
                                         ID = h.ID,
                                         IsActive = h.IsActive,
                                         IsForSale = h.IsForSale,
                                         Name = h.Name,
                                         Price = h.Price,
                                         Race = h.Race,
                                         Withers = h.Withers,
                                         IsSold = h.IsSold,
                                         State = "Horses for sale"

                                     }).ToList();
                        break;
                    case 3:
                        horseList = (from h in context.Horses
                                     where h.IsSold == true
                                     select new HorseModel()
                                     {
                                         Awards = h.Awards,
                                         Birthday = h.Birthday,
                                         ID = h.ID,
                                         IsActive = h.IsActive,
                                         IsForSale = h.IsForSale,
                                         Name = h.Name,
                                         Price = h.Price,
                                         Race = h.Race,
                                         Withers = h.Withers,
                                         IsSold = h.IsSold,
                                         State = "Sold horses"

                                     }).ToList();
                        break;
                }
                return horseList;
            }

        }
        public static AboutReadOnlyModel AboutReadOnly()
        {
            using (var contex = new HorseContext())
            {

                return (from a in contex.Abouts
                        select new AboutReadOnlyModel()
                        {
                            Header1 = a.Header1,
                            Header2 = a.Header2,
                            Textfield1 = a.Textfield1,
                            Textfield2 = a.Textfield2
                        }).ToList().LastOrDefault();

            }
        }
        public static bool AuthenticateAdminLogin(string username, string password)
        {
            using (var context = new HorseContext())
            {
                return
                    (from a in context.Users
                     where a.Username == username && a.Password == password
                     select a).Any();
            }
        }
        public static List<HorseSaleModel> GetHorsesForSale()
        {
            using (var context = new HorseContext())
            {
                return
                    (from h in context.Horses
                     where h.IsForSale
                     select new HorseSaleModel
                     {
                         ID = h.ID,
                         Birthday = h.Birthday,
                         Name = h.Name,
                         Prices = h.Price,
                         Race = h.Race,
                         Withers = h.Withers,
                         IsForSale = h.IsForSale
                     }).ToList();
            }
        }


	    public static void AddHorse(Horse newHorse)
	    {
		    using (var context = new HorseContext())
		    {
			    context.Horses.Add(newHorse);
			    context.SaveChanges();
		    }
	    }

        public static List<ImageModel> GetAllGalleryImages()
        {
            using (var context = new HorseContext())
            {
                return (from i in context.GalleryImages
                        where i.Active == true
                        select (new ImageModel
                        {
                            ID = i.ID,
                            Active = i.Active,
                            ImagePath = i.ImagePath,
                            FileName = i.FileName
                        })).ToList();
            }
        }

        public static void AddNewFile(string fileName)
        {
            using (var context = new HorseContext())
            {
                context.GalleryImages.Add(new GalleryImage()
                {
                FileName = fileName,
                ImagePath = "~/Images/" + fileName,
                Active = true
                }
                    );
                context.SaveChanges();
            }
        }
    }
}

