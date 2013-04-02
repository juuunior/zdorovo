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
