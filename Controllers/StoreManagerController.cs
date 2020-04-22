using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using EStore_MVC_.Models;

namespace EStore_MVC_.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class StoreManagerController : Controller
    {
        private StoreEntities db = new StoreEntities();

        //
        // GET: /StoreManager/

        public ViewResult Index()
        {
            var products = db.Products.Include(a => a.Category).Include(a => a.Brand);
            return View(products.ToList());
        }

        //
        // GET: /StoreManager/Details/5

        public ViewResult Details(int id)
        {
            Product product = db.Products.Find(id);
            return View(product);
        }

        //
        // GET: /StoreManager/Create

        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");
            ViewBag.BrandId = new SelectList(db.Brands, "BrandId", "Name");
            return View();
        } 

        //
        // POST: /StoreManager/Create

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", product.CategoryId);
            ViewBag.BrandId = new SelectList(db.Brands, "BrandId", "Name", product.BrandId);
            return View(product);
        }
        
        //
        // GET: /StoreManager/Edit/5
 
        public ActionResult Edit(int id)
        {
            Product product = db.Products.Find(id);
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", product.CategoryId);
            ViewBag.BrandId = new SelectList(db.Brands, "BrandId", "Name", product.BrandId);
            return View(product);
        }

        //
        // POST: /StoreManager/Edit/5

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", product.CategoryId);
            ViewBag.BrandId = new SelectList(db.Brands, "BrandId", "Name", product.BrandId);
            return View(product);
        }

        //
        // GET: /StoreManager/Delete/5
 
        public ActionResult Delete(int id)
        {
            Product product = db.Products.Find(id);
            return View(product);
        }

        //
        // POST: /StoreManager/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
