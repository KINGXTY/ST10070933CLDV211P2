using Microsoft.AspNetCore.Mvc;
using ST10070933CLDV211POE.Models;

namespace ST10070933CLDV211POE.Controllers
{
    public class SignupController : Controller
    {
        private readonly UserModel usrtbl = new UserModel();

        [HttpPost]
        public ActionResult About(UserModel Users)
        {
            if (ModelState.IsValid)
            {
                var result = usrtbl.InsertUser(Users);
                if (result)
                {
                    return RedirectToAction("index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Failed to create user.");
                }
            }
            return View(Users);
        }

        [HttpGet]
        public ActionResult About()
        {
            return View(new UserModel());
        }
    }
}
