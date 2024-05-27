using Microsoft.AspNetCore.Mvc;
using ST10070933CLDV211POE.Models;

namespace ST10070933CLDV211POE.Controllers
{
    public class ProductController : Controller
    {
        public ProductModel prodtbl = new ProductModel();

        [HttpPost]
        public ActionResult MyWork(ProductModel products)
        {
            if (ModelState.IsValid)
            {
                var result2 = prodtbl.InsertProduct(products);
                if (result2)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Failed to insert product.");
                }
            }
            return View(products);
        }

        [HttpGet]
        public ActionResult MyWork()
        {
            return View(new ProductModel());
        }
    }
}
