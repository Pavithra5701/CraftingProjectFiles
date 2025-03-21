using Microsoft.AspNetCore.Mvc;

namespace CraftingProject.Controllers
{
        public class LoginController : Controller
        {
            public IActionResult Index()
            {
                if (HttpContext.Session.GetString("Username") != null)
                {
                    return RedirectToAction("Dashboard");
                }
                return View();
            }

            [HttpPost]
            public IActionResult Index(string username, string password)
            {
                if (username == "admin" && password == "password") // Dummy validation
                {
                    HttpContext.Session.SetString("Username", username); // Store in session
                    return RedirectToAction("Dashboard");
                }
                ViewBag.Message = "Invalid username or password";
                return View();
            }

            public IActionResult Dashboard()
            {
                if (HttpContext.Session.GetString("Username") == null)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }

            public IActionResult Logout()
            {
                HttpContext.Session.Clear(); // Clear session
                return RedirectToAction("Index");
            }
        }
    }


