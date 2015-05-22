using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkeletorDAL
{
	public class Blog
	{
		public int ID { get; set; }
		public string Description { get; set; }
		public DateTime Created { get; set; }
		public virtual List<Post> Posts { get; set; }
		public virtual Horse Horse { get; set; }

		public Blog()
		{
			
		}
		public Blog(string description, Horse horse, DateTime created, List<Post> posts )
		{
			Description = description;
			Horse = horse;
			Created = created;
			Posts = posts;
		}
	}


}
