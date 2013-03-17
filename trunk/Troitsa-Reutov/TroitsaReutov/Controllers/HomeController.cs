using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Net.Mail;
using System.Web.Mvc;

namespace TroitsaReutov.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

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
            ViewBag.Message = "Your contact page.";

			
			if (!String.IsNullOrEmpty(Request["SenderName"]) && !String.IsNullOrEmpty(Request["SenderEmail"]) && !String.IsNullOrEmpty(Request["SenderMessage"]))
			{
				ViewBag.Message = "Your contact page.";

				System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("smtp.mail.ru", 25);
				
				client.Credentials= new NetworkCredential("juuunior@inbox.ru", "victory2000");

				MailMessage Message = new MailMessage();
				Message.From = new MailAddress("juuunior@inbox.ru");
				Message.To.Add(new MailAddress("juuunior@mail.ru"));
				Message.Subject = "Сообщение с сайта Троицкого храма от: " + Request["SenderName"];
				Message.Body = Request["SenderMessage"] + Request["SenderEmail"];

				client.Send(Message);
				client.Dispose();
			}


            return View();
        }

        public ActionResult Service()
        {
            return View();
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
		
    }
}
