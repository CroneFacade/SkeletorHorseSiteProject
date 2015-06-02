using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using SkeletorDAL.Helpers;
using SkeletorDAL.POCO;

namespace SkeletorDAL
{
    public class HorseContextInitializer : DropCreateDatabaseAlways<HorseContext>
    {
        private readonly List<Horse> horses;
        private readonly List<Blog> blogs;
        private readonly List<User> users;
        private readonly List<About> abouts;
        private readonly List<GalleryImage> galleryImages;
        private readonly List<FooterLink> footerlinks;
        public HorseContextInitializer()
        {
            var Helge = new Horse("Helge", DateTime.Now, "Camargue", 150, "1a i VM 2005", "650.000", ("https://www.facebook.com/cramagoTriton?__mref=message_bubble")) { ImagePath = @"~/ProfileImages/1Dummy1.jpg", Description = "Detta är Helges beskrivning", Medicine = "Detta är Helges Medicin", FamilyTree = "Detta är Helges släktträd" };
            var Jens = new Horse("Jens", DateTime.Now, "Ponny", 44, string.Empty, "350.000", ("https://www.facebook.com/cramagoTriton?__mref=message_bubble")) { ImagePath = "~/ProfileImages/2Dummy2.gif", Description = "Detta är Jens beskrivning", Medicine = "Detta är Jens Medicin", FamilyTree = "Detta är Jens släktträd" };
            var Gösta = new Horse("Gösta", DateTime.Now, "Camargue", 100, "-", "100.000", ("https://www.facebook.com/cramagoTriton?__mref=message_bubble")) { ImagePath = "~/ProfileImages/3Dummy3.jpg", Description = "Detta är Gösta beskrivning", Medicine = "Detta är Gösta Medicin", FamilyTree = "Detta är Gösta släktträd" };
            var Adolf = new Horse("Adolf", DateTime.Now, "Conny", 150, "Superduktig men har inte vunnit något", "1 000 000", ("https://www.facebook.com/cramagoTriton?__mref=message_bubble")) { ImagePath = "~/ProfileImages/DefaultHead.jpg", Description = "Detta är Adolf Medicin", Medicine = "Detta är Adolf beskrivning", FamilyTree = "Detta är Adolf släktträd" };
            var Hermina = new Horse("Hermina", DateTime.Now, "Camargue", 150, "Superduktig men har inte vunnit något", "1 000 000", ("https://www.facebook.com/cramagoTriton?__mref=message_bubble")) { ImagePath = "~/ProfileImages/DefaultHead.jpg", Description = "Detta är Herminas Medicin", Medicine = "Detta är Herminas beskrivning", FamilyTree = "Detta är Herminas släktträd" };
            var LillBritt = new Horse("LillBritt", DateTime.Now, "Conny", 150, "Superduktig men har inte vunnit något", "1 000 000", ("https://www.facebook.com/cramagoTriton?__mref=message_bubble")) { ImagePath = "~/ProfileImages/DefaultHead.jpg", Description = "Detta är LillBritt Medicin", Medicine = "Detta är LillBritt beskrivning", FamilyTree = "Detta är LillBritts släktträd" };
            var Lisa = new Horse("Lisa", DateTime.Now, "Camargue", 150, "Superduktig men har inte vunnit något", "1 000 000", ("https://www.facebook.com/cramagoTriton?__mref=message_bubble")) { ImagePath = "~/ProfileImages/DefaultHead.jpg", Description = "Detta är Lisa Medicin", Medicine = "Detta är Lisa beskrivning", FamilyTree = "Detta är Lisas släktträd" };

            Helge.YoutubeVideoURLs.Add(new YoutubeVideoURL() { VideoName = "Test Video", VideoURL = @"http://www.youtube.com/embed/3rYoRaxgOE0?autoplay=0" });


            footerlinks = new List<FooterLink>();

            footerlinks.Add(new FooterLink { LinkName = "TestLink One", LinkURL = "http://www.google.com", Column = 1 });
            footerlinks.Add(new FooterLink { LinkName = "TestLink Two", LinkURL = "http://www.google.com", Column = 1 });
            footerlinks.Add(new FooterLink { LinkName = "TestLink Three", LinkURL = "http://www.google.com", Column = 1 });
            footerlinks.Add(new FooterLink { LinkName = "TestLink Four", LinkURL = "http://www.google.com", Column = 1 });
            footerlinks.Add(new FooterLink { LinkName = "TestLink Five", LinkURL = "http://www.google.com", Column = 2 });
            footerlinks.Add(new FooterLink { LinkName = "TestLink Six", LinkURL = "http://www.google.com", Column = 2 });
            footerlinks.Add(new FooterLink { LinkName = "TestLink Seven", LinkURL = "http://www.google.com", Column = 2 });
            footerlinks.Add(new FooterLink { LinkName = "TestLink Eight", LinkURL = "http://www.google.com", Column = 2 });
            footerlinks.Add(new FooterLink { LinkName = "TestLink Nine", LinkURL = "http://www.google.com", Column = 2 });
            footerlinks.Add(new FooterLink { LinkName = "TestLink Ten", LinkURL = "http://www.google.com", Column = 3 });
            footerlinks.Add(new FooterLink { LinkName = "TestLink Eleven", LinkURL = "http://www.google.com", Column = 3 });
            footerlinks.Add(new FooterLink { LinkName = "TestLink Twelve", LinkURL = "http://www.google.com", Column = 3 });
            footerlinks.Add(new FooterLink { LinkName = "TestLink Thirteen", LinkURL = "http://www.google.com", Column = 3 });
            footerlinks.Add(new FooterLink { LinkName = "TestLink Fourteen", LinkURL = "http://www.google.com", Column = 4 });
            footerlinks.Add(new FooterLink { LinkName = "TestLink Fifteen", LinkURL = "http://www.google.com", Column = 4 });


            Helge.IsForSale = true;
            Adolf.IsForSale = true;

            galleryImages = new List<GalleryImage>();

            galleryImages.Add(new GalleryImage()
            {
                FileName = "Dummy1.jpg",
                ImagePath = "~/Images/Dummy1.jpg",
                Active = true
            });

            galleryImages.Add(new GalleryImage()
            {
                FileName = "Dummy2.jpg",
                ImagePath = "~/Images/Dummy2.jpg",
                Active = true
            });

            galleryImages.Add(new GalleryImage()
            {
                FileName = "Dummy3.jpg",
                ImagePath = "~/Images/Dummy3.jpg",
                Active = true
            });

            //Profile pictures

            galleryImages.Add(new GalleryImage()
            {
                FileName = "1Dummy1.jpg",
                ImagePath = "~/ProfileImages/1Dummy1.jpg",
                Active = true
            });

            galleryImages.Add(new GalleryImage()
            {
                FileName = "2Dummy2.gif",
                ImagePath = "~/ProfileImages/2Dummy2.gif",
                Active = true
            });

            galleryImages.Add(new GalleryImage()
            {
                FileName = "3Dummy3.jpg",
                ImagePath = "~/ProfileImages/3Dummy3.jpg",
                Active = true
            });




            var HelgeBlog = new Blog("Detta är Helges Blogg", DateTime.Now, new List<Post>()
			{
				new Post("Helges första inlägg", DateTime.Now, "Hjehhej"),
				new Post("Helges andra inlägg", DateTime.Now, "ghahhaha")
			});
            Helge.Blog = HelgeBlog;
            var JensBlog = new Blog("Detta är Jens Blogg", DateTime.Now, new List<Post>()
			{
					new Post("Jens första inlägg", DateTime.Now, "jensjensjens"),
				new Post("Jens andra inlägg", DateTime.Now, "HUAhuhuehu")
			});
            Jens.Blog = JensBlog;
            var GöstaBlog = new Blog("Detta är Gösta Blogg", DateTime.Now, new List<Post>()
			{
				new Post("Gösta första inlägg", DateTime.Now, "ffffffffffffffffffffffffffffsafa"),
				new Post("Gösta andra inlägg", DateTime.Now, "Gösta e bääääääääst")
			});
            Gösta.Blog = GöstaBlog;
            var AdolfBlog = new Blog("Detta är Adolf Blogg", DateTime.Now, new List<Post>()
			{
				new Post("Adolfs första inlägg", DateTime.Now, "Adolf shalalala"),
				new Post("Adolfs andra inlägg", DateTime.Now, "dsaaaaaaaaa")
			});
            Adolf.Blog = AdolfBlog;
            horses = new List<Horse>()
			{
			Helge, Jens, Gösta, Adolf, Hermina, LillBritt, Lisa
			};

            blogs = new List<Blog>()
			{
				HelgeBlog, JensBlog, GöstaBlog, AdolfBlog
			};
            users = new List<User>()
			{
				new User("admin", "admin".SuperHash(), 1, "teamnordahl123@gmail.com")
			};

            abouts = new List<About>()
			{
				new About("Header1","Text here for header 1","Header2","Text here for header 2", "Header3", "Text here for header 3")
            };
        }

        public override void InitializeDatabase(HorseContext context)
        {
            horses.ForEach(h => context.Horses.Add(h));
            blogs.ForEach(b => context.Blogs.Add(b));
            users.ForEach(u => context.Users.Add(u));
            abouts.ForEach(a => context.Abouts.Add(a));
            galleryImages.ForEach(i => context.GalleryImages.Add(i));
            footerlinks.ForEach(l => context.FooterLinks.Add(l));
            base.InitializeDatabase(context);
        }
    }
}
