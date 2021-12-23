using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NietDiscord.Models
{
    public class Message
    {
        public int ID { get; set; }
        public string sendfrom { get; set; }
        public string sento { get; set; }
        public string messagecontents { get; set; }
        public bool isedited { get; set; } = false;
        public bool ispinned { get; set; } = false;

       
    }
}
