using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkeletorDAL.POCO
{
	public class About
	{
		public int ID { get; set; }
		public string Header1 { get; set; }
		public string Header2 { get; set; }
		public string Textfield1 { get; set; }
		public string Textfield2 { get; set; }

	    public About()
	    {
	        
	    }

	    public About(string header1, string textfield1, string header2, string textfield2)
	    {
	        Header1 = header1;
	        Header2 = header2;
	        Textfield1 = textfield1;
	        Textfield2 = textfield2;
	    }
	}
}
