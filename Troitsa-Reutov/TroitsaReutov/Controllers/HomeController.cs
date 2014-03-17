using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Net.Mail;
using System.Web.Mvc;
using System.Xml.Serialization;
using System.Net.Http;
using System.Web.Security;
using WebMatrix.WebData;
using TroitsaReutov.Models;

namespace TroitsaReutov.Controllers
{
    public class HomeController : Controller
    {

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }


        private ActionResult RedirectToLocal(string returnUrl)
        {
            
            
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        //
        // POST: /Account/Login

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid && FormsAuthentication.Authenticate(model.UserName, model.Password))
            {
                FormsAuthentication.SetAuthCookie(model.UserName,false);
                return RedirectToAction("Editor", "Home");
            }

            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(model);
        }


        public ActionResult Index()
        {
            string path = Server.MapPath("~/claims.txt");
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            if (System.IO.File.Exists(path))
                ViewBag.Claims = System.IO.File.ReadAllText(path);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

		public ActionResult Baptismo()
		{
			return View();
		}

		public ActionResult Burial()
		{
			return View();
		}
		
        public ActionResult Contact()
        {
            ViewBag.Message = "Контактная информация";

			
			if (!String.IsNullOrEmpty(Request["SenderName"]) && !String.IsNullOrEmpty(Request["SenderEmail"]) && !String.IsNullOrEmpty(Request["SenderMessage"]))
			{
				ViewBag.Message = "Your contact page.";

				System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("smtp.mail.ru", 25);

				client.Credentials = new NetworkCredential("troitsa-reutov@mail.ru", "t1r1o1i1t1s1a1");

				MailMessage Message = new MailMessage();
				Message.From = new MailAddress("troitsa-reutov@mail.ru");
				Message.To.Add(new MailAddress("troitsareutov@gmail.com"));
				Message.Subject = "Сообщение с сайта Троицкого храма от: " + Request["SenderName"];
				Message.Body = Request["SenderMessage"] +"     \r\n"+ Request["SenderEmail"];

				client.Send(Message);
				client.Dispose();
			}


            return View();
        }

        public ActionResult Service()
        {
			Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("ru-RU");
			Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("ru-RU");

			var xser = new XmlSerializer(typeof(ChirchServices));

			ChirchServices timetable;
			
			using (var strm = System.IO.File.Open(Request.PhysicalApplicationPath+"test.xml",FileMode.Open))
	        
			{
				timetable = (ChirchServices)xser.Deserialize(strm);
			}


			return View(timetable);
        }

		public ActionResult ServicesDescription()
		{
			return View();
		}

		public ActionResult ExtremeUnction()
		{
			return View();
		}

		public ActionResult Evharisto()
		{
			return View();
		}

		public ActionResult Wedding()
		{
			return View();
		}

        [ValidateInput(false)]
        [Authorize]
        public ActionResult Editor()
        {

            string path = Server.MapPath("~/claims.txt");
            if (!String.IsNullOrEmpty(Request["editor"]))
            {
                string claims = Request["editor"];
                System.IO.File.WriteAllText(path, claims);
            }

            if (System.IO.File.Exists(path))
                ViewBag.Claims = System.IO.File.ReadAllText(path);


            return View();
        }

		public ActionResult Conversation()
		{
			return View();
		}

		public ActionResult Confession()
		{
			return View();
		}

		public ActionResult Consecration()
		{
			return View();
		}
        public ActionResult Praying()
        {
            return View();
        }
		public ActionResult Lection()
		{
			return View();
		}
		public ActionResult Media()
		{

            string _address = "https://oauth.vk.com/token?grant_type=password&client_id=3573991&client_secret=XyilPaO8wX9ec4eQIuX2&angelina.gu@mail.ru&password=P@ssw0rd&scope=photos&test_redirect_uri=1";

            HttpClient client = new HttpClient();

            // Send a request asynchronously continue when complete 
            client.GetAsync(_address).ContinueWith(
                (requestTask) =>
                {
                    // Get HTTP response from completed task. 
                    HttpResponseMessage response = requestTask.Result;

                    // Check that response was successful or throw exception 
                    response.EnsureSuccessStatusCode();

                    // Read response asynchronously as JsonValue and write out top facts for each country 
                    response.Content.ToString();
                });

               




			return View();
		}
		public ActionResult Hymnography()
		{
			return View();
		}
		public ActionResult Library()
		{
			return View();
		}
		
    }
}
