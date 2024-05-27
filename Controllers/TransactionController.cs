using Microsoft.AspNetCore.Mvc;
using ST10070933CLDV211POE.Models;

namespace ST10070933CLDV211POE.Controllers
{
    public class TransactionController : Controller
    {
        private static List<TransactionModel> orders = new List<TransactionModel>();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(TransactionModel order)
        {
            if (ModelState.IsValid)
            {
                orders.Add(order);
                return RedirectToAction("Transactions");
            }
            return View(order);
        }

        public IActionResult Transactions()
        {
            return View(orders);
        }
    }
}