using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkeletorDAL.Model
{
	public class EditAboutModel
	{
		public int ID { get; set; }
		public string Header1 { get; set; }
		public string Header2 { get; set; }
		[DataType(DataType.MultilineText)]
		public string Textfield1 { get; set; }
		[DataType(DataType.MultilineText)]
		public string Textfield2 { get; set; }
	}
}
