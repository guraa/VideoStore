using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoStore.Models
{
    public class Customer
    {
        public List<VideoModels> Videos { get; set; }
        public List<RentalModels> Rental { get; set; }
       // public List<ApplicationUser> User { get; set; }
    }
}