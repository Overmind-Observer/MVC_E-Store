using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EStore_MVC_.Models;

namespace EStore_MVC_.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        StoreEntities storeDB = new StoreEntities();

        public ActionResult Index()
        {
            // Get most popular products
            var products = GetTopSellingProducts(5);

            return View(products);
        }

        private List<Product> GetTopSellingProducts(int count)
        {
            // Group the order details by product and return
            // the albums with the highest count

            return storeDB.Products
                .OrderByDescending(a => a.OrderDetails.Count())
                .Take(count)
                .ToList();
        }
    }
}