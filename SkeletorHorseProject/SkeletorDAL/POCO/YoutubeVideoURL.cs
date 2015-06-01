using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkeletorDAL.POCO
{
    public class YoutubeVideoURL
    {
        public int ID { get; set; }
        public string VideoName { get; set; }
        public string VideoURL { get; set; }
        public virtual Horse Horse { get; set; }
        public YoutubeVideoURL()
        {

        }
    }
}
