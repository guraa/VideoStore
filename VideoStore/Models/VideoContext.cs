using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VideoStore.Models
{
    public class VideoContext : DbContext
    {
        public DbSet<VideoModels> Video { get; set; }
        public DbSet<RentalModels> Rental { get; set; }
    }
}