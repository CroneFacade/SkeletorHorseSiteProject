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
	    private readonly List<Puff> puffs; 
        public HorseContextInitializer()
        {
			puffs = new List<Puff>();
			puffs.Add(new Puff()
			{
				Header1 = "Team Nordahl",
                Textfield1 = "Fusce sed convallis sem. Aliquam erat volutpat. Sed rutrum, dolor sed maximus molestie, nulla erat volutpat lectus, non iaculis nisl magna quis sapien. Vivamus a suscipit dolor. Vestibulum vulputate in arcu quis posuere. Nulla ut velit vel lorem imperdiet rhoncus sed pulvinar purus. Maecenas ut rutrum eros. Curabitur sed velit sem. Phasellus dictum, lorem quis elementum elementum, sapien dui eleifend ex, at ornare augue mi id nunc. Nulla vitae mauris ut urna vulputate iaculis blandit blandit sem. Proin eget justo nec libero imperdiet cras amet.",
				Link1 = "http://www.cupcakeipsum.com",
				Header2 = "Horses for Sale",
				Textfield2 = "Suspendisse facilisis tincidunt dui, vel commodo elit ultrices eu. Integer ac lacus quam. Donec efficitur nisi nec elit egestas, id luctus libero aliquam. Cras in lacus quam. Curabitur mattis tincidunt orci eu aliquam. Phasellus vehicula nisi et dignissim pretium. Proin pretium fermentum felis, quis vulputate ex finibus nec." +
                            "Nullam in neque nec purus iaculis viverra. Etiam ut cursus massa. Donec in fringilla arcu, eget viverra nulla. Etiam posuere odio tempor tortor ullamcorper finibus. Ut a euismod urna. Maecenas quis tellus sit amet lacus sed.",
				Link2 = "https://baconipsum.com/",
				Header3 = "Our Stallions",
                Textfield3 = "Nulla facilisi. Morbi pharetra nec mi dapibus semper. Nam dignissim ligula non arcu ultrices, eu facilisis lectus consectetur. Sed eu nunc ante. Nulla sed maximus ipsum. Donec tempor odio massa, sed faucibus nibh elementum at. Mauris arcu libero, consequat quis dapibus consequat, hendrerit quis leo. Integer ut tellus ut nibh venenatis pellentesque. Sed nunc leo, blandit et ornare mattis, iaculis a lacus. In malesuada pellentesque elit euismod finibus. Curabitur luctus diam vitae orci pellentesque consectetur.",
				Link3 = "http://veggieipsum.com/"
			});


            var Helge = new Horse("Helge", DateTime.Now, "Camargue", 150, "1a i VM 2005", "650.000", ("https://www.facebook.com/cramagoTriton?__mref=message_bubble")) { ImagePath = @"~/ProfileImages/1Dummy1.jpg", Description = "Detta är Helges beskrivning", Medicine = "Detta är Helges Medicin", FamilyTree = "Detta är Helges släktträd" };
            var Jens = new Horse("Jens", DateTime.Now, "Ponny", 44, string.Empty, "350.000", ("https://www.facebook.com/cramagoTriton?__mref=message_bubble")) { ImagePath = "~/ProfileImages/2Dummy2.gif", Description = "Detta är Jens beskrivning", Medicine = "Detta är Jens Medicin", FamilyTree = "Detta är Jens släktträd" };
            var Gösta = new Horse("Gösta", DateTime.Now, "Camargue", 100, "-", "100.000", ("https://www.facebook.com/cramagoTriton?__mref=message_bubble")) { ImagePath = "~/ProfileImages/3Dummy3.jpg", Description = "Detta är Gösta beskrivning", Medicine = "Detta är Gösta Medicin", FamilyTree = "Detta är Gösta släktträd" };
            var Adolf = new Horse("Adolf", DateTime.Now, "Conny", 150, "Superduktig men har inte vunnit något", "1 000 000", ("https://www.facebook.com/cramagoTriton?__mref=message_bubble")) { ImagePath = "~/ProfileImages/DefaultHead.jpg", Description = "Detta är Adolf Medicin", Medicine = "Detta är Adolf beskrivning", FamilyTree = "Detta är Adolf släktträd" };
            var Hermina = new Horse("Hermina", DateTime.Now, "Camargue", 150, "Superduktig men har inte vunnit något", "1 000 000", ("https://www.facebook.com/cramagoTriton?__mref=message_bubble")) { ImagePath = "~/ProfileImages/DefaultHead.jpg", Description = "Detta är Herminas Medicin", Medicine = "Detta är Herminas beskrivning", FamilyTree = "Detta är Herminas släktträd" };
            var LillBritt = new Horse("LillBritt", DateTime.Now, "Conny", 150, "Superduktig men har inte vunnit något", "1 000 000", ("https://www.facebook.com/cramagoTriton?__mref=message_bubble")) { ImagePath = "~/ProfileImages/DefaultHead.jpg", Description = "Detta är LillBritt Medicin", Medicine = "Detta är LillBritt beskrivning", FamilyTree = "Detta är LillBritts släktträd" };
            var Lisa = new Horse("Lisa", DateTime.Now, "Camargue", 150, "Superduktig men har inte vunnit något", "1 000 000", ("https://www.facebook.com/cramagoTriton?__mref=message_bubble")) { ImagePath = "~/ProfileImages/DefaultHead.jpg", Description = "Detta är Lisa Medicin", Medicine = "Detta är Lisa beskrivning", FamilyTree = "Detta är Lisas släktträd" };

            Helge.Tree = new FamilyTree() { FatherName = "Åke", FatherDescription = "Åke är pappan", MotherName = "Åsa", MotherDescription = "Åsa är mamma", Children = new List<Child>() { new Child() { Name = "Grete", Description = "Grete är en unge" }, new Child() { Name = "Martin", Description = "Martin är en unge" } } };
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
			Helge, Jens, Gösta, Adolf, 
            Hermina, LillBritt, Lisa
			};

            blogs = new List<Blog>()
			{
				HelgeBlog, JensBlog, GöstaBlog, AdolfBlog
			};
            users = new List<User>()
			{
				new User("admin", "admin".SuperHash(), 1, "teamnordahl123@gmail.com"),
				new User("Test1", "admin".SuperHash(), 2, "teamnordahl123@gmail.com"),
				new User("Test2", "admin".SuperHash(), 2, "teamnordahl123@gmail.com"),
			};



            abouts = new List<About>()
			{
				//new About("Header1",@"balblablalblablalbla","Header2","heuheuehuehueheuheuhe", "fwqojfwq", "fijsedfiwqfwwq"),
				new About("Team Nordahl", 
						  @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean et enim quis sem blandit mollis eu sed nibh. Pellentesque eu neque erat. Nullam tempus purus velit, sed ullamcorper est suscipit ac. Aenean molestie odio ut purus tristique tempus. Suspendisse sed purus eget augue vulputate dignissim. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed vel fermentum nunc. Nam nec dapibus tortor. Cras tellus nibh, fringilla ut facilisis et, fringilla sit amet erat. In tempor bibendum turpis eget sollicitudin. Praesent pharetra rhoncus metus, a cursus massa consectetur pharetra. Nulla pulvinar nisi quis sem molestie, in luctus mi scelerisque. Nulla facilisi. Duis sit amet volutpat diam. Proin vitae auctor lectus.", 
                          "Camargue", 
						  @"Maecenas finibus viverra tincidunt. Praesent vitae est sed sem pharetra consequat. Phasellus facilisis lacus velit, id lacinia elit facilisis sit amet. Nullam luctus, nisi sit amet bibendum convallis, justo felis sodales eros, nec rutrum tellus sapien ornare ex. Morbi fermentum tristique magna ut hendrerit. Mauris tincidunt ante ut libero mollis, eu pulvinar nunc dapibus. Fusce vestibulum nibh dui, ut blandit nisl pellentesque eu. In id sapien eget neque suscipit sollicitudin at quis augue. Quisque ac eleifend leo, in porta dolor. Pellentesque luctus lectus sapien, a pulvinar velit faucibus quis. Curabitur a mattis eros. In congue, quam sed luctus aliquam, neque ipsum ultricies quam, at blandit magna sem a orci. Nulla leo quam, tempor nec lacus vitae, feugiat elementum lectus. Phasellus pellentesque rhoncus est quis luctus. Fusce imperdiet, eros quis volutpat ultricies, nulla nulla tincidunt purus, et varius urna libero in velit. Morbi vulputate convallis leo. Ut venenatis odio sit amet nisi condimentum semper. Etiam nunc tellus, mattis nec turpis eget, eleifend rhoncus tortor. Aenean id sem sodales quam lobortis porttitor. Pellentesque rhoncus tellus quis est bibendum vestibulum. Sed gravida imperdiet tincidunt. Sed mollis est nunc, id faucibus orci aliquet ut. Nulla facilisi. Morbi sit amet felis ipsum. Suspendisse ut diam posuere, euismod mauris vitae, maximus urna. Aenean lorem turpis, accumsan nec consequat in, tincidunt vitae velit. Nulla quis tellus convallis, ullamcorper purus at, pellentesque ligula.", 
                          "Our Ranch", 
                          @"In congue, quam sed luctus aliquam, neque ipsum ultricies quam, at blandit magna sem a orci. Nulla leo quam, tempor nec lacus vitae, feugiat elementum lectus. Phasellus pellentesque rhoncus est quis luctus. Fusce imperdiet, eros quis volutpat ultricies, nulla nulla tincidunt purus, et varius urna libero in velit. Morbi vulputate convallis leo. Ut venenatis odio sit amet nisi condimentum semper. Etiam nunc tellus, mattis nec turpis eget, eleifend rhoncus tortor. Aenean id sem sodales quam lobortis porttitor. Pellentesque rhoncus tellus quis est bibendum vestibulum. Sed gravida imperdiet tincidunt. Sed mollis est nunc, id faucibus orci aliquet ut. Nulla facilisi. Morbi sit amet felis ipsum. Suspendisse ut diam posuere, euismod mauris vitae, maximus urna.")
			};
		}

        public override void InitializeDatabase(HorseContext context)
        {
			puffs.ForEach(p => context.Puffs.Add(p));
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
