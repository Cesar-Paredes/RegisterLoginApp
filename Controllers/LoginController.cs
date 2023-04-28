using Microsoft.AspNetCore.Mvc;
using RegisterLoginAppn.Models;

namespace RegisterLoginAppn.Controllers
{
    public class LoginController : Controller
    {
        private readonly TestContext _testContext;

        public LoginController(TestContext testContext)
        {
            _testContext = testContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Login login)
        {
            if(ModelState.IsValid)
            {
                var query=from l in _testContext.Logins
                          where l.Email== login.Email && l.Password == login.Password   
                          select l;

                if(query.Count()>0)
                {
                    ViewBag.Email=login.Email;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Error = "Invalid Email/Password";
                    return View();
                }
            }
            return View(login);
        }
    }
}
