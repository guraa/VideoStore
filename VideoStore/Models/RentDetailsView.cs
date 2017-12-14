using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoStore.Models
{
    public class RentDetailsView
    {
        public string customer { get; set; }
        public DateTime rentDate { get; set; }
        public DateTime returnDate { get; set; }
        public string desscription { get; set; }
        public string title { get; set; }
        public byte[] Image { get; set; }

    }
}