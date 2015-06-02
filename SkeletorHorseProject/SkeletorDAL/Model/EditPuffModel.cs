using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkeletorDAL.Model
{
	public class EditPuffModel
	{
		public int ID { get; set; }
		[DisplayName("Header")]
		public string Header1 { get; set; }
		[StringLength(550)]
		[DataType(DataType.MultilineText)]
		[DisplayName("Text")]
		public string Textfield1 { get; set; }
		[DisplayName("Link")]
		public string Link1 { get; set; }
		[DisplayName("Header")]
		public string Header2 { get; set; }
		[StringLength(550)]
		[DataType(DataType.MultilineText)]
		[DisplayName("Text")]
		public string Textfield2 { get; set; }
		[DisplayName("Link")]
		public string Link2 { get; set; }
		[DisplayName("Header")]
		public string Header3 { get; set; }
		[StringLength(550)]
		[DataType(DataType.MultilineText)]
		[DisplayName("Text")]
		public string Textfield3 { get; set; }
		[DisplayName("Link")]
		public string Link3 { get; set; }
	}
}
