using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkeletorDAL
{
	public class Blog
	{
		public int ID { get; set; }
		public string Description { get; set; }
    [Column(TypeName = "datetime2")]
		public DateTime Created { get; set; }
		public virtual List<Post> Posts { get; set; }

		public Blog()
		{
			
		}
		public Blog(string description,DateTime created, List<Post> posts )
		{
			Description = description;

			Created = created;
			Posts = posts;
		}
	}


}
