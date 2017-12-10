using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoStore.Models
{
    public class VideoModels
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public long price { get; set; }
        public string genre { get; set; }
        public byte[] Image { get; set; }
    }
}