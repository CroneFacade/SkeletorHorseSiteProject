using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkeletorDAL
{
	public class Post
	{
		public int ID { get; set; }
		public string Title { get; set; }
		public DateTime Created { get; set; }
		public string Content { get; set; }
		public bool IsActive { get; set; }
		public virtual Blog Blog { get; set; }

		public Post()
		{
			
		}
		public Post(string title, DateTime created, string content)
		{
			Title = title;
			Created = created;
			Content = content;
		}
	}
}
