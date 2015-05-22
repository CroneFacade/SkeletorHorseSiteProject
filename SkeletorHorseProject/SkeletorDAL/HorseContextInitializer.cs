using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkeletorDAL
{
	public class HorseContextInitializer : DropCreateDatabaseAlways<HorseContext>
	{
		private readonly List<Horse> horses;
		private readonly List<Blog> blogs;
		private readonly List<User> users;

		public HorseContextInitializer()
		{
			var Helge = new Horse("Helge", DateTime.Now, "Camargue", 150, "1a i VM 2005");
			var Jens = new Horse("Jens", DateTime.Now, "Ponny", 44, string.Empty);
			var Gösta = new Horse("Gösta", DateTime.Now, "Camargue", 100, "-");
			var Adolf = new Horse("Adolf", DateTime.Now, "Conny", 150, "Superduktig men har inte vunnit något");



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
				new User("admin", "admin", 1)
			};
		}

		public override void InitializeDatabase(HorseContext context)
		{
			horses.ForEach(h => context.Horses.Add(h));
			blogs.ForEach(b => context.Blogs.Add(b));
			users.ForEach(u => context.Users.Add(u));
			base.InitializeDatabase(context);
		}
	}
}
