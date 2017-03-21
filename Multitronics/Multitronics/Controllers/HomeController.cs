using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Multitronics.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Services()
        {
            return View();
        }
        public ActionResult OurWorks()
        {
            return View();
        }
        public ActionResult HowToBuy()
        {
            return View();
        }
        public ActionResult Reviews()
        {
            return View();
        }
        public ActionResult Contacts()
        {
            return View();
        }


        [HttpPost]
        public ActionResult CallBack(string name, string phone)
        {
            //SendEmailAsync(name, phone).GetAwaiter();

            MailAddress from = new MailAddress("multitronics@mail.ua", "Multitronics Server");
            //MailAddress to = new MailAddress("futupas@gmail.com");
            MailMessage m = new MailMessage();
            m.From = from;
            m.To.Add(new MailAddress("futupas@gmail.com"));
            m.To.Add(new MailAddress("vgorkyn@mail.ru"));
            m.Subject = "Multitronics phone call";
            m.Body = String.Format("<h1>Новая просьба об обратном звонке</h1><p>Пользователь {0} попросил перезвонить ему по номеру {1}.</p>", name, phone);
            m.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 2525);
            smtp.Credentials = new NetworkCredential("multitronics@mail.ua", "MultiEmail091_j6");
            smtp.EnableSsl = true;
            smtp.Send(m);

            return Json(new { name = name, phone = phone });
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SendMail(string MyName, string To, string Subject, string Body, bool IsHTML)
        {
            MailAddress from = new MailAddress("multitronics@mail.ua", MyName);
            MailAddress to = new MailAddress(To);
            MailMessage m = new MailMessage(from, to);
            m.Subject = Subject;
            m.Body = Body;
            m.IsBodyHtml = IsHTML;
            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 2525);
            smtp.Credentials = new NetworkCredential("multitronics@mail.ua", "MultiEmail091_j6");
            smtp.EnableSsl = true;
            smtp.Send(m);

            return Json(new { success = true });
        }
    }
}
