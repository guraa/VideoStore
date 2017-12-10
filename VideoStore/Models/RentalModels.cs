using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoStore.Models
{
    public class RentalModels
    {
        public int id { get; set; }
        public int videoId { get; set; }
        public string customerId { get; set; }
        public DateTime rentDate { get; set; }
        public DateTime returnDate { get; set; }
    }
}