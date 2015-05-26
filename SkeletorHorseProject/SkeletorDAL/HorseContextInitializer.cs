using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkeletorDAL.Helpers;
using SkeletorDAL.POCO;

namespace SkeletorDAL
{
	public class HorseContextInitializer : DropCreateDatabaseIfModelChanges<HorseContext>
	{
		private readonly List<Horse> horses;
		private readonly List<Blog> blogs;
		private readonly List<User> users;
		private readonly List<About> abouts;
		private readonly List<GalleryImage> galleryImages;

		public HorseContextInitializer()
		{
			var Helge = new Horse("Helge", DateTime.Now, "Camargue", 150, "1a i VM 2005","650.000");
			var Jens = new Horse("Jens", DateTime.Now, "Ponny", 44, string.Empty,"350.000");
			var Gösta = new Horse("Gösta", DateTime.Now, "Camargue", 100, "-","100.000");
			var Adolf = new Horse("Adolf", DateTime.Now, "Conny", 150, "Superduktig men har inte vunnit något","1 000 000");

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
                FileName = "Dummy2.jpg",
                ImagePath = "~/Images/Dummy2.jpg",
                Active = true
            });
            
            


			var HelgeBlog = new Blog("Detta är Helges Blogg", Helge, DateTime.Now, new List<Post>()
			{
				new Post("Helges första inlägg", DateTime.Now, "Hjehhej"),
				new Post("Helges andra inlägg", DateTime.Now, "ghahhaha")
			});
			var JensBlog = new Blog("Detta är Jens Blogg", Jens, DateTime.Now, new List<Post>()
			{
					new Post("Jens första inlägg", DateTime.Now, "jensjensjens"),
				new Post("Jens andra inlägg", DateTime.Now, "HUAhuhuehu")
			});
			var GöstaBlog = new Blog("Detta är Gösta Blogg", Gösta, DateTime.Now, new List<Post>()
			{
				new Post("Gösta första inlägg", DateTime.Now, "ffffffffffffffffffffffffffffsafa"),
				new Post("Gösta andra inlägg", DateTime.Now, "Gösta e bääääääääst")
			});
			var AdolfBlog = new Blog("Detta är Adolf Blogg", Adolf, DateTime.Now, new List<Post>()
			{
				new Post("Adolfs första inlägg", DateTime.Now, "Adolf shalalala"),
				new Post("Adolfs andra inlägg", DateTime.Now, "dsaaaaaaaaa")
			});

			horses = new List<Horse>()
			{
			Helge, Jens, Gösta, Adolf
			};

			blogs = new List<Blog>()
			{
				HelgeBlog, JensBlog, GöstaBlog, AdolfBlog
			};
			users = new List<User>()
			{
				new User("admin", "admin".SuperHash(), 1)
			};

			abouts = new List<About>()
			{
				new About("Header1",@"balblablalblablalbla","Header2","heuheuehuehueheuheuhe"),
				new About("Header1 Header up to date", 
						  @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean et enim quis sem blandit mollis eu sed nibh. Pellentesque eu neque erat. Nullam tempus purus velit, sed ullamcorper est suscipit ac. Aenean molestie odio ut purus tristique tempus. Suspendisse sed purus eget augue vulputate dignissim. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed vel fermentum nunc. Nam nec dapibus tortor. Cras tellus nibh, fringilla ut facilisis et, fringilla sit amet erat. In tempor bibendum turpis eget sollicitudin. Praesent pharetra rhoncus metus, a cursus massa consectetur pharetra. Nulla pulvinar nisi quis sem molestie, in luctus mi scelerisque. Nulla facilisi. Duis sit amet volutpat diam. Proin vitae auctor lectus.", "Header2 up to date", 
						  @"Maecenas finibus viverra tincidunt. Praesent vitae est sed sem pharetra consequat. Phasellus facilisis lacus velit, id lacinia elit facilisis sit amet. Nullam luctus, nisi sit amet bibendum convallis, justo felis sodales eros, nec rutrum tellus sapien ornare ex. Morbi fermentum tristique magna ut hendrerit. Mauris tincidunt ante ut libero mollis, eu pulvinar nunc dapibus. Fusce vestibulum nibh dui, ut blandit nisl pellentesque eu. In id sapien eget neque suscipit sollicitudin at quis augue. Quisque ac eleifend leo, in porta dolor. Pellentesque luctus lectus sapien, a pulvinar velit faucibus quis. Curabitur a mattis eros. Aenean lorem turpis, accumsan nec consequat in, tincidunt vitae velit. Nulla quis tellus convallis, ullamcorper purus at, pellentesque ligula.")
			};
		}

		public override void InitializeDatabase(HorseContext context)
		{
			horses.ForEach(h => context.Horses.Add(h));
			blogs.ForEach(b => context.Blogs.Add(b));
			users.ForEach(u => context.Users.Add(u));
			abouts.ForEach(a => context.Abouts.Add(a));
            galleryImages.ForEach(i => context.GalleryImages.Add((i)));
			base.InitializeDatabase(context);
		}
	}
}
