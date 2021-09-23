using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace test1.Controllers
{
    public class DammioController : Controller
    {
        // GET: Dammio
        public string Index()
        {
            return "đây là phương thức mặc định";
        }
        //public string chaoMung()
        //{
        //    return "đây là phưng thức chào mừng";
        //}

        //public ActionResult Login()
        //{
        //    return View();
        //}
        public string chaoMung(string ten, int tuoi)
        {
            return (HttpUtility.HtmlEncode("xin chào " + ten + ".Tuổi là : " + tuoi));
        }

        public string test(int id)
        {
            return (HttpUtility.HtmlEncode("xin chào " + id));
        }

        public ActionResult test2()
        {
            return View();
        }
        public ActionResult Hello(string name, string address, int numTimes =10)
        {
            ViewBag.Message = "Hello " + name;
            ViewBag.NumTimes = numTimes;
            ViewBag.Address = "địa chỉ " + address;
            return View();
        }
    }
}