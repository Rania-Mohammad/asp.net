using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projectF.Data;
using projectF.Models;
using static System.Net.WebRequestMethods;
namespace projectF.Controllers
{
	public class WelcomeController : Controller
	{
		private ApplicationDBcontext db;
        private const string SessionKeyEmail = "email";
        private const string SessionKeyPassword = "password";
		private const string SessionKeyState = "state";
        public string SessionKeyRem = "yes";
        //,Microsoft.AspNetCore.Http.HttpContext context
        public WelcomeController(ApplicationDBcontext db)
		{
			this.db = db;
            //context.Session.SetString(SessionKeyEmail, "");
            //context.Session.SetString(SessionKeyPassword,"");
            //context.Session.SetString(SessionKeyState, "");
        }
		public IActionResult Index()
		{
           // HttpContext.Session.GetString(SessionKeyState);
            if (HttpContext.Session.GetString(SessionKeyRem) != null)
            {
                TempData["x"] = HttpContext.Session.GetString(SessionKeyRem);
            }
            HttpContext.Session.SetString("email", "");
            HttpContext.Session.SetString("phone", "");
            //var model = HttpContext.Session.GetString(SessionKeyState);

            //return View(model);
            //if (!Request.Cookies.TryGetValue("state", out string state))
            //{
            //    return RedirectToAction("login");
            //}

            //return View("Profile", state);
            //if (Request.Cookies.TryGetValue("state", out string state))
            //return View(state); 
            return View();
		}
		[HttpPost]
		public IActionResult Index(IFormCollection fr)
		{
            //if ((string)fr["owner"] == "Admin")
            //	TempData["type"] = (string)fr["owner"];
            //else if ((string)fr["employee"] == "Employee")
            //	TempData["type"] = (string)fr["employee"];
            if (!Request.Cookies.TryGetValue("state", out string state))
            {
                return RedirectToAction("login");
            }
            return View("home", state);
            //return RedirectToAction("login");
		}
		public IActionResult login()
		{
            //List<login> los = new List<login>();
            //los = db.login.ToList();
            // ViewBag.err = "Invalid E-mail or Password";
            //var model = new login();

            //if (HttpContext.Session.GetString(SessionKeyEmail) != null)
            //{
            //    model.email = HttpContext.Session.GetString(SessionKeyEmail);
            //    model.Remember = true;
            //}
            //return View(model);
            TempData["errmsg"] = "There is something wrong with your email or password";
            return View();
		}
		[HttpPost]
		public IActionResult login(IFormCollection frm,login model)
		{
			var log = db.login.Find((string)frm["email"]);
			TempData["st"] = frm["state"].ToString();
            HttpContext.Session.SetString("email", (string)frm["remail"]);
            HttpContext.Session.SetString("phone", (string)frm["Phone"]);
			if(log != null)
			{
				if (log.email != (string)frm["email"] || log.password != (string)frm["password"]||(log.email != (string)frm["email"]&& log.password != (string)frm["password"]))
                {
					//if (model.e == "user" && model.Password == "pass")
					//{
					//	HttpContext.Session.SetString(SessionKeyEmail, model.email);
					//	HttpContext.Session.SetString(SessionKeyPassword, model.password);
					//HttpContext.Session.SetString(SessionKeyState, model.state);


					//               if (model.Remember)
					//	{
					//		var options = new CookieOptions
					//		{
					//			Expires = System.DateTimeOffset.Now.AddDays(7),
					//			HttpOnly = true,
					//			Secure = true
					//		};
					//		Response.Cookies.Append("email", model.email, options);
					//	}
					//	else
					//	{
					//		Response.Cookies.Delete("email");
					//	}

					//return RedirectToAction("home");
					//}
					//else
					//{
					//	ModelState.AddModelError(string.Empty, "Invalid username or password");
					//}
					//ViewBag.check = false;
					//return View(ViewBag.check);
					//return RedirectToAction("Error");
					TempData["errmsg"] = "There is something wrong with your email or password";
                    ViewBag.err = false;
                    return View();
					//ModelState.AddModelError(string.Empty, "Invalid username or password");
                }
				else
				{
                    //ModelState.AddModelError(string.Empty, "Invalid username or password");
                    //return RedirectToAction("Error");
                    //ModelState.AddModelError(string.Empty, "Invalid username or password");
                    if (frm["check"] == "checked")
                    {
                        HttpContext.Session.SetString(SessionKeyEmail, model.email);
                        HttpContext.Session.SetString(SessionKeyPassword, model.password);
                        HttpContext.Session.SetString(SessionKeyState, model.state);
                        HttpContext.Session.SetString(SessionKeyRem, "true");
                        return RedirectToAction("home");
                    }
                    //if (model.Remember)
                    //{
                    //    var options = new CookieOptions
                    //    {
                    //        Expires = System.DateTimeOffset.Now.AddDays(7),
                    //        HttpOnly = true,
                    //        Secure = true
                    //    };
                    //    Response.Cookies.Append("state", model.state, options);
                    //}
                    //else
                    //{
                    //    Response.Cookies.Delete("email");
                    //}

                    return RedirectToAction("home");
                }
            }
			else
			{

				//ViewBag.check = false;
				//return View(ViewBag.check);
				ModelState.AddModelError(string.Empty, "Invalid username or password");
			}

            //if ()
            //{
            //	//if (log.state == (string)frm["state"])
            //	//{
            //	//	//ViewBag.state=log.state;
            //	//	ViewData["state"] = (string)frm["state"];
            //	//}
            //}
            //else
            //	ViewBag.error = "Wrong Data";

            return View();
        }
		public IActionResult home()
		{
			
			
            return View();
		}
		//[NonAction]
		//public IActionResult check(bool check)
		//{
		//	ViewBag.check= check;
		//	return View("login");
		//}

		[HttpPost]
		public IActionResult Logout()
		{
			HttpContext.Session.Remove(SessionKeyEmail);
			HttpContext.Session.Remove(SessionKeyPassword);
            HttpContext.Session.Remove(SessionKeyState);
            Response.Cookies.Delete("email");

			return RedirectToAction("index");
		}
        public IActionResult notification() {
            ViewBag.email=HttpContext.Session.GetString("email");
            ViewBag.phone = HttpContext.Session.GetString("phone");
            return View();        }
	}
}
