using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Xml.Schema;
using SkeletorDAL.Helpers;
using SkeletorDAL.Model;
using SkeletorDAL.POCO;
using SkeletorHorseProject.Controllers;

namespace SkeletorDAL
{
    public static class Repository
    {

        public static FamilyTreeModel GetFamilyTree(int id)
        {
            using (var context = new HorseContext())
            {
                var horse = (from c in context.Horses
                    where c.ID == id
                    select new FamilyTreeModel()
                    {
                        Father = new ParentModel() {Name = c.Tree.FatherName, Description = c.Tree.FatherDescription},
                        Mother = new ParentModel() {Name = c.Tree.MotherName, Description = c.Tree.MotherDescription},
                        horseid = id,
                        HorseName = c.Name
                    }).FirstOrDefault();
                List<Child> listOfChildren = (from c in context.Horses
                    where c.ID == id
                    select c.Tree.Children).FirstOrDefault();
                    horse.Children = listOfChildren.Select(childModel => new ChildModel() {Name = childModel.Name, Description = childModel.Description}).ToList();
                return horse;
            }
        }
        public static List<ImageModel> GetAllSlideShowImages()
        {
            using (var context = new HorseContext())
            {
                return (from i in context.SlideShowImages
                        where i.Active == true && i.ImagePath.StartsWith(@"~/SlideImages/")
                        select (new ImageModel
                        {
                            ID = i.ID,
                            Active = i.Active,
                            ImagePath = i.ImagePath,
                            FileName = i.FileName
                        })).ToList();
            }
        }
        public static void AddNewSlideShowFile(string fileName, string path)
        {
            using (var context = new HorseContext())
            {
                context.SlideShowImages.Add(new SlideShowImage()
                {
                    FileName = fileName,
                    ImagePath = path,
                    Active = true
                }
                    );
                context.SaveChanges();
            }
        }
        public static void DeleteSlideShowImage(int id)
        {
            using (var context = new HorseContext())
            {
                var image = context.SlideShowImages.Find(id);
                context.SlideShowImages.Remove(image);
                context.SaveChanges();
            }
        }
        public static string GetAdminEmail()
        {
            using (var context = new HorseContext())
            {
                return
                    (from u in context.Users
                     where u.AdminLevel == 1
                     select u.Email).FirstOrDefault();
            }
        }
        public static HorseProfileModel GetHorseProfileById(int id)
        {
            using (var context = new HorseContext())
            {
                var currentHorse = (from h in context.Horses
                                    where h.ID == id
                                    select new HorseProfileModel
                                    {
                                        Awards = h.Awards,
                                        Birthday = h.Birthday,
                                        Breeding = h.Breeding,
                                        Description = h.Description,
                                        FacebookPath = h.FacebookPath,
                                        FamilyTree = h.FamilyTree,
                                        Gender = h.Gender,
                                        IsActive = !h.IsActive,
                                        IsForSale = h.IsForSale,
                                        IsSold = h.IsSold,
                                        Rent = h.Rent,
                                        Price = h.Price,
                                        Medicine = h.Medicine,
                                        Name = h.Name,
                                        Race = h.Race,
                                        Withers = h.Withers,
                                        ImagePath = h.ImagePath

                                    }).FirstOrDefault();

                return currentHorse;
            }
        }
        public static List<FooterModel> GetAllFooterLinks()
        {
            using (var context = new HorseContext())
            {
                return (from l in context.FooterLinks
                        select new FooterModel { ID = l.ID, Name = l.LinkName, Url = l.LinkURL, Column = l.Column }).ToList();
            }
        }

        public static void AddNewFooterLink(FooterModel model)
        {
            using (var context = new HorseContext())
            {
                context.FooterLinks.Add(new FooterLink() { LinkName = model.Name, LinkURL = model.Url, Column = model.Column });
                context.SaveChanges();
            }
        }

        public static List<HorseVideoModel> GetHorseVideosByID(int id)
        {
            List<HorseVideoModel> listToReturn = new List<HorseVideoModel>();

            using (var context = new HorseContext())
            {
                List<YoutubeVideoURL> videoList = (from v in context.Horses
                        where v.ID == id
                        select v.YoutubeVideoURLs).FirstOrDefault();

                foreach (var video in videoList)
                {
                    listToReturn.Add(new HorseVideoModel() {ID = video.ID, HorseID = id ,VideoName = video.VideoName, VideoURL = video.VideoURL });
                }
            }

            return listToReturn;
        }

        public static void DeleteFooterLink(int id)
        {
            using (var context = new HorseContext())
            {
                var footerToDelete = (from l in context.FooterLinks
                                      where l.ID == id
                                      select l).FirstOrDefault();

                context.FooterLinks.Remove(footerToDelete);
                context.SaveChanges();
            }
        }

        public static void RegisterAdmin(RegisterAdminModel model)
        {
            using (var context = new HorseContext())
            {
                var newAdmin = new User()
                {
                    Username = model.Username,
                    Email = model.Email,
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

        public static HorseProfileModel GetSpecificHorse(int id)
        {

            using (var context = new HorseContext())
            {
                var horse = (from h in context.Horses
                             where h.ID == id
                             select new HorseProfileModel()
                             {
                                 ID = h.ID,
                                 Name = h.Name,
                                 Race = h.Race,
                                 Withers = h.Withers,
                                 Birthday = h.Birthday,
                                 Description = h.Description,
                                 Medicine = h.Medicine,
                                 FamilyTree = h.FamilyTree,
                                 Awards = h.Awards,
                                 ImagePath = h.ImagePath,
                                 Blog = new BlogModel()
                                 {
                                     ID = h.Blog.ID,
                                     HorseId = h.ID,
                                     Created = h.Blog.Created,
                                     Description = h.Blog.Description,
                                 },
                                 IsSold = h.IsSold,
                                 FacebookPath = h.FacebookPath,
                                 IsActive = h.IsActive,
                                 IsForSale = h.IsForSale,
                                 Price = h.Price
                             }).FirstOrDefault();

                List<Post> posts = (from h in context.Horses
                                    where h.ID == horse.ID
                                    select h.Blog.Posts).FirstOrDefault();

                List<BlogPostModel> blogposts = posts.Select(x => new BlogPostModel()
                {
                    BlogID = x.Blog.ID,
                    ID = x.ID,
                    IsActive = x.IsActive,
                    Created = x.Created,
                    Content = x.Content,
                    Title = x.Title
                }).ToList();

                horse.Blog.Posts = blogposts;
                return horse;
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
                            ID = h.ID,
                            Name = h.Name,
                            Race = h.Race,
                            Withers = h.Withers,
                            Birthday = h.Birthday,
                            Description = h.Description,
                            Medicine = h.Medicine,
                            FamilyTree = h.FamilyTree,
                            Awards = h.Awards,
                            ImagePath = h.ImagePath
                        }).FirstOrDefault();
            }
        }

        public static void AddNewYoutubeVideoToHorse(HorseVideoModel model)
        {
            using(var context = new HorseContext())
            {
                var horse = (from h in context.Horses
                            where h.ID == model.HorseID
                            select h).FirstOrDefault();

                horse.YoutubeVideoURLs.Add(new YoutubeVideoURL() { VideoName = model.VideoName, VideoURL = model.VideoURL });

                context.SaveChanges();
            }
        }

        public static int DeleteYoutubeVideoFromHorse(int id)
        {
            int horseID;

            using (var context = new HorseContext())
            {
                var videoToRemove = (from y in context.YoutubeVideoURLs
                                     where y.ID == id
                                     select y).FirstOrDefault();

                horseID = videoToRemove.Horse.ID;

                context.YoutubeVideoURLs.Remove(videoToRemove);
                context.SaveChanges();
                
            }

            return horseID;
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
                                     where h.IsActive == true
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
                                         State = "All horses",
                                         ImagePath = h.ImagePath
                                     }).ToList();
                        break;

                    case 2:
                        horseList = (from h in context.Horses
                                     where h.IsForSale == true && h.IsActive == true
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
                                         State = "Horses for sale",
                                         ImagePath = h.ImagePath
                                     }).ToList();
                        break;
                    case 3:
                        horseList = (from h in context.Horses
                                     where h.IsSold == true && h.IsActive == true
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
                                         State = "Sold horses",
                                         ImagePath = h.ImagePath
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
                            Header3 = a.Header3,
                            Textfield1 = a.Textfield1,
                            Textfield2 = a.Textfield2,
                            Textfield3 = a.Textfield3
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
        public static EditHorseProfileModel GetFullInformationOnSpecificHorseById(int id, EditHorseProfileModel model)
        {
            using (var context = new HorseContext())
            {
                var currentHorse = (from h in context.Horses
                                    where h.ID == id
                                    select new EditHorseProfileModel
                                    {
                                        Awards = h.Awards,
                                        Birthday = h.Birthday,
                                        Breeding = h.Breeding,
                                        Description = h.Description,
                                        FacebookPath = h.FacebookPath,
                                        FamilyTree = h.FamilyTree,
                                        Gender = h.Gender,
                                        IsActive = !h.IsActive,
                                        IsForSale = h.IsForSale,
                                        IsSold = h.IsSold,
                                        Rent = h.Rent,
                                        Price = h.Price,
                                        Medicine = h.Medicine,
                                        Name = h.Name,
                                        Race = h.Race,
                                        Withers = h.Withers,
                                        LastUpdated = DateTime.Now

                                    }).FirstOrDefault();
                return currentHorse;
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
        public static void UpdateHorseProfile(int horseID, EditHorseProfileModel model)
        {
            using (var context = new HorseContext())
            {

                var horse = context.Horses.Find(horseID);
                horse.Name = model.Name;
                horse.Birthday = model.Birthday;
                horse.Race = model.Race;
                horse.Awards = model.Awards;
                horse.Description = model.Description;
                horse.Medicine = model.Medicine;
                horse.FamilyTree = model.FamilyTree;
                horse.IsForSale = model.IsForSale;
                horse.Price = model.Price;
                horse.IsActive = !model.IsActive;
                horse.FacebookPath = model.FacebookPath;
                horse.IsSold = model.IsSold;
                horse.Gender = model.Gender;
                horse.Breeding = model.Breeding;


	            context.Entry(horse).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static List<ImageModel> GetAllGalleryImages()
        {
            using (var context = new HorseContext())
            {
                return (from i in context.GalleryImages
                        where i.Active == true && i.ImagePath.StartsWith(@"~/Images/")
                        select (new ImageModel
                        {
                            ID = i.ID,
                            Active = i.Active,
                            ImagePath = i.ImagePath,
                            FileName = i.FileName
                        })).ToList();
            }
        }

        public static void AddNewFile(string fileName, string path)
        {
            using (var context = new HorseContext())
            {
                context.GalleryImages.Add(new GalleryImage()
                {
                    FileName = fileName,
                    ImagePath = path,
                    Active = true
                }
                    );
                context.SaveChanges();
            }
        }

        public static string RemoveOldProfileImage(int id)
        {
            string path = "";

            using (var context = new HorseContext())
            {
                GalleryImage image = (from h in context.GalleryImages
                                      where h.FileName.StartsWith(id + "")
                                      select h).FirstOrDefault();

                path = image.ImagePath;
                context.GalleryImages.Remove(image);
                context.SaveChanges();
            };

            return path;
        }

        public static List<HorseProfileGalleryImagesModel> GetHorseProfileGalleryImages(int id)
        {
            using (var context = new HorseContext())
            {
                return (from i in context.GalleryImages
                        where i.Active == true && i.ImagePath.StartsWith(@"~/HorseProfileImages/" + id)
                        select (new HorseProfileGalleryImagesModel()
                        {
                            ID = i.ID,
                            Active = i.Active,
                            ImagePath = i.ImagePath,
                            FileName = i.FileName,
                            HorseID = id
                        })).ToList();
            }
        }
        public static int DeleteGalleryImage(int id)
        {
            using (var context = new HorseContext())
            {
                int horseid = 0;
                var image = context.GalleryImages.Find(id);
                horseid = image.FileName[0];
                context.GalleryImages.Remove(image);
                context.SaveChanges();
                return horseid;
            }
        }

        public static void AddNewFilePathToHorse(string imageName, int horseId)
        {
            string imagePath = @"~/ProfileImages/" + imageName;

            using (var context = new HorseContext())
            {
                var horse = context.Horses.Find(horseId);
                horse.ImagePath = imagePath;
                context.SaveChanges();
            }
        }

        public static string GetFacebookPath(int id)
        {
            using (var context = new HorseContext())
            {
                var query =
                    (from h in context.Horses
                     where h.ID == id
                     select h.FacebookPath).First();

                return query;
            }
        }

        public static int AddNewBlogPost(BlogPostModel blogpost, int blogId)
        {
            var horseId = 0;
            using (var context = new HorseContext())
            {
                var blog = context.Blogs.Find(blogId);
                var newBlogpost = new Post(blogpost.Title, blogpost.Created, blogpost.Content) { Blog = blog, ID = blogpost.ID, Created = blogpost.Created };
                blog.Posts.Add(newBlogpost);
                context.SaveChanges();
                horseId = (from h in context.Horses
                           where h.Blog.ID == blogId
                           select h.ID).FirstOrDefault();
            }
            return horseId;
        }


        public static List<HorseModel> GetLatestUpdates()
        {
            using (var context = new HorseContext())
            {
                var query =
                    (from h in context.Horses
                     select new HorseModel() { ID = h.ID, ImagePath = h.ImagePath }
                        ).ToList();

                if (query.Count > 5)
                {
                    var HM = new List<HorseModel>();

                    HM.Add(query[0]);
                    HM.Add(query[1]);
                    HM.Add(query[2]);
                    HM.Add(query[3]);
                    HM.Add(query[4]);
                }

                return query;

            }
        }
		public static EditAboutModel GetLatestAboutInformation()
		{
			using (var context = new HorseContext())
			{
				var query =
					(from a in context.Abouts
					 orderby a.ID descending
					 select
						 new EditAboutModel()
						 {
							 ID = a.ID,
							 Header1 = a.Header1,
							 Header2 = a.Header2,
							 Textfield1 = a.Textfield1,
							 Textfield2 = a.Textfield2
						 }).FirstOrDefault();

				return query;
			}
		}

		public static About GetLatestAbout()
		{
			using (var context = new HorseContext())
			{
				var query =
					(from a in context.Abouts
					 orderby a.ID descending
					 select a).FirstOrDefault();

				return query;
			}
		}

		public static void UpdateAbouts(About about)
		{
			using (var context = new HorseContext())
			{
				context.Entry(about).State = EntityState.Modified;
				context.SaveChanges();
			}
		}
		public static About SetAboutValues(EditAboutModel model, About about)
		{
			about.ID = model.ID;
			about.Header1 = model.Header1;
			about.Header2 = model.Header2;
			about.Textfield1 = model.Textfield1;
			about.Textfield2 = model.Textfield2;
			return about;
		}

		public static EditPuffModel GetPuffs()
		{
			using (var context = new HorseContext())
			{
				var query =
					(from p in context.Puffs
					 orderby p.ID descending
					 select
						new EditPuffModel()
						{
							ID = p.ID,
							Header1 = p.Header1,
							Header2 = p.Header2,
							Header3 = p.Header3,
							Textfield1 = p.Textfield1,
							Textfield2 = p.Textfield2,
							Textfield3 = p.Textfield3,
							Link1 = p.Link1,
							Link2 = p.Link2,
							Link3 = p.Link3
						}).FirstOrDefault();
				return query;
			}
		}


        public static List<EditorModel> GetEditorForSpecificHorse(int id)
        {
            using (var context = new HorseContext())
            {
                var users =
                    (from h in context.Horses
                        where h.ID == id
                        select h.AssignedEditors).FirstOrDefault();
                List<EditorModel> model = new List<EditorModel>();
                var horseName =
                    (from h in context.Horses
                        where h.ID == id
                        select h.Name).FirstOrDefault();
                
                foreach (var user in users)
                {
                    model.Add(new EditorModel(){EditorId = user.ID,EditorName = user.Username,HorseId = id,HorseName = horseName});
                }
                return model;
            }
        }

        public static void AddEditor(EditorModel editor, int horseId)
        {
            using (var context = new HorseContext())
            {
                var EditorId = editor.EditorId;
               

                var horse =
                    (from h in context.Horses
                        where h.ID == horseId
                        select h).FirstOrDefault();
                var Editor =
                    (from e in context.Users
                     where e.ID == EditorId
                     select e).FirstOrDefault();

                if (horse != null)
                    horse.AssignedEditors.Add(Editor);
                
                if (Editor != null) 
                    Editor.AssignedHorses.Add(horse);
            }
        }

		public static void UpdatePuffs(EditPuffModel model)
		{
			using (var context = new HorseContext())
			{

				var puff = context.Puffs.First();
				puff.Header1 = model.Header1;
				puff.Header2 = model.Header2;
				puff.Header3 = model.Header3;
				puff.Textfield1 = model.Textfield1;
				puff.Textfield2 = model.Textfield2;
				puff.Textfield3 = model.Textfield3;
				puff.Link1 = model.Link1;
				puff.Link2 = model.Link2;
				puff.Link3 = model.Link3;

				context.Entry(puff).State = EntityState.Modified;
				context.SaveChanges();
			}
		}

        public static void EditHorseFamilyTree(FamilyTreeModel model)
        {
            using (var context = new HorseContext())
            {
                FamilyTree familyTree = new FamilyTree()
                {
                    MotherName = model.Mother.Name, 
                    MotherDescription = model.Mother.Description, 
                    FatherName = model.Father.Name, 
                    FatherDescription = model.Father.Description, 
                };
           
            }
        }
    }
}

