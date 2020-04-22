using EStore_MVC_.Models;
using System.Linq;
using System.Web.Mvc;

namespace EStore_MVC_.Controllers
{
    public class StoreController : Controller
    {
        StoreEntities storeDB = new StoreEntities();

        //
        // GET: /Store/

        public ActionResult Index()
        {
            var genres = storeDB.Categories.ToList();

            return View(genres);
        }

        //
        // GET: /Store/Browse?category = laptops

        public ActionResult Browse(string categoty)
        {
            // Retrieve Category and its Associated Products from database
            var categoryModel = storeDB.Categories.Include("Products")
                .Single(c => c.Name == categoty);

            return View(categoryModel);
        }

        //
        // GET: /Store/Details/5

        public ActionResult Details(int id)
        {
            var product = storeDB.Products.Find(id);

            return View(product);
        }

        //
        // GET: /Store/CategoryMenu

        [ChildActionOnly]
        public ActionResult CategoryMenu()
        {
            var categories = storeDB.Categories.ToList();

            return PartialView(categories);
        }

    }
}