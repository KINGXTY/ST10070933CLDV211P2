using Microsoft.AspNetCore.Mvc;
using ST10070933CLDV211POE.Models;

namespace ST10070933CLDV211POE.Controllers
{
    public class ProductDisplayController : Controller
    {
        // Ideally, this would be stored in a database. For simplicity, using a static list.
        private static List<ProductDisplayModel> transactions = new List<ProductDisplayModel>();

        [HttpPost]
        public IActionResult Transactions(ProductDisplayModel model)
        {
            model.IsSubmitted = true;
            transactions.Add(model);
            return View("Index", model);
        }

        public IActionResult Index()
        {
            return View(new ProductDisplayModel());
        }

        public IActionResult Transactions()
        {
            return View(transactions);
        }
    }
}