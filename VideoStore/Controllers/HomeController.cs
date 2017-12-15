using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VideoStore.Models;

namespace VideoStore.Controllers
{
    public class HomeController : Controller
    {
        private VideoContext db = new VideoContext();
        private Customer cust = new Customer();
        public ActionResult Index()
        {
            var videos = db.Video.ToList();
            return View(videos);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoModels video = db.Video.Find(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            return View(video);
        }
        [HttpPost]
        public ActionResult Edit(VideoModels video)
        {
            if (ModelState.IsValid)
            {
                db.Entry(video).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(video);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(VideoModels video)
        {
            if (ModelState.IsValid)
            {
                db.Video.Add(video);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(video);
        }

        [Authorize]
        public ActionResult RentMovie(Customer rental)
        {
            List<RentDetailsView> model = new List<RentDetailsView>();

            var customerView = (from r in db.Rental
                                join v in db.Video
                                on r.videoId equals v.id
                              //  join u in db.User
                            //    on r.customerId equals u.UserName
                                   where r.customerId  == User.Identity.Name
                               select new
                               { 
                               
                                  rentdate= r.rentDate,
                                  retDate= r.returnDate,
                                  desc = v.description,
                                  info =  v.title,
                                  image = v.Image
                               }).ToList();


            foreach (var item in customerView) //retrieve each item and assign to model
            {
                model.Add(new RentDetailsView()
                {
                    desscription = item.desc,
                  //  customer = item.cust,
                    rentDate = item.rentdate,
                    returnDate = item.retDate,
                    title = item.info,
                    Image = item.image
                    
 
                });
            }


            return View(model);
        }


    [Authorize]
        [HttpPost]
        public ActionResult RentMovie(int reportName)
        {
            Customer cust = new Customer();

            DateTime today = DateTime.Now;

            var rental = new List<RentalModels>
                {
                new RentalModels {customerId = User.Identity.Name, videoId = reportName , rentDate = today, returnDate = today.AddDays(14) }
                };

            foreach (var item in rental)
            {
                db.Rental.Add(item);
            }
            db.SaveChanges();



            return RedirectToAction("Index");
        }

    }
}