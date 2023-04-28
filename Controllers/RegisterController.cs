using Microsoft.AspNetCore.Mvc;
using RegisterLoginAppn.Models;

namespace RegisterLoginAppn.Controllers
{
    public class RegisterController : Controller
    {

        private readonly TestContext _testcontext = null;

        public RegisterController(TestContext testcontext)
        {
            _testcontext = testcontext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Register register)
        {
            if(ModelState.IsValid)
            {
                var query = from r in _testcontext.Registers
                            where r.Email == register.Email
                            || r.Loginname == register.Loginname
                            select r;

                if(query.Any())
                {
                    ViewBag.Error = "Login name or email exists. Provide different login or email.";
                    return View();
                }
                else
                {
                    Login login = new Login();
                    login.Email=register.Email;
                    login.Password = register.Password;

                    _testcontext.Add<Register>(register);
                    _testcontext.Add<Login>(login);

                    int rows=_testcontext.SaveChanges();
                    if (rows > 0)
                    {
                        TempData["email"] = register.Email;
                        return RedirectToAction("Success");
                    }
                    
                }
            }

            return View(register);
        }

        public ViewResult Success()
        {
            if(TempData["email"] != null)
            {
                ViewBag.Email=TempData["email"];
                
            }
            return View();
        }
    }
}
