using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using infinite.mvc.dogstore.test.Models;
using System.Data.Entity;

namespace infinite.mvc.dogstore.test.Controllers
{
    public class DogStoreController : Controller
    {

        private readonly ApplicationDbContext _context = null;



        public DogStoreController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: DogStore
        public ActionResult Index()
        {
            var dogstore = _context.DogStores.ToList();
            return View(dogstore);
        }
        public ActionResult Details(int id)
        {
            var dogstore = _context.DogStores.Include(d=>d.Breed).FirstOrDefault(d => d.Id == id);
            if (dogstore != null)
            {
                return View(dogstore);
            }
            return HttpNotFound();

        }

        public ActionResult Edit(int id)
        {
            var dogstore = _context.DogStores.FirstOrDefault(p => p.Id == id);
            if (dogstore != null)
            {
                var Breeds = _context.Breeds.ToList();
                ViewBag.Breeds = Breeds;
                return View(dogstore);
            }
            return HttpNotFound("Breed Id doesn't exists");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(DogStore dogstore)
        {
            if (dogstore != null)
            {
                var dogstoreInDb = _context.DogStores.Find(dogstore.Id);
                if (dogstoreInDb != null)
                {
                    dogstoreInDb.Height = dogstore.Height;
                    dogstoreInDb.Age = dogstore.Age;
                    dogstoreInDb.Description = dogstore.Description;
                    dogstoreInDb.BreedId = dogstore.BreedId;
                    //_context.Products.AddOrUpdate(productInDb);
                    _context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            var breeds = _context.Breeds.ToList();
            ViewBag.Breeds = breeds;
            return View(dogstore);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var dogstoreInDb = _context.DogStores.FirstOrDefault(d => d.Id == id);
            if (dogstoreInDb != null)
            {
                _context.DogStores.Remove(dogstoreInDb);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }
    }
}



                

            