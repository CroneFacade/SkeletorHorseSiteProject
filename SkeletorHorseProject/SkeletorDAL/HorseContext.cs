using SkeletorDAL.POCO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkeletorDAL
{
	public class HorseContext: DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Horse> Horses { get; set; }
		public DbSet<Blog> Blogs { get; set; }
		public DbSet<Post> Posts { get; set; }
		public DbSet<About> Abouts { get; set; }
		public DbSet<GalleryImage> GalleryImages { get; set; }
        public DbSet<SlideShowImage> SlideShowImages { get; set; }

	}
}
