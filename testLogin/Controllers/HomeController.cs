using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace testLogin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login()
        {
            ViewBag.Message = "Your Login page.";

            return View();
        }
        //public ActionResult Success(string user, string pass)
        //{
        //    if (user != "test" && pass != "test")
        //    {
        //        Console.WriteLine("không thàng công");
        //    }
        //    return View();
        //}

        public ActionResult Success()
        {
            return View();
        }

        // check tài khoản mail
        //private static bool LoginWithAD(string user, string pass)
        //{

        //    string account = user;
        //    string strAccount = "dc02" + "\\" + account; ;
        //    string strLDAP = "LDAP://dc02.fujixerox.net/OU=FX-Users,dc=dc02,dc=fujixerox,dc=net";
        //    string strPwd = pass;
        //    DirectoryEntry entry = new DirectoryEntry(strLDAP, strAccount, strPwd);
        //    if (ValityDomainUsers(entry, strAccount))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        //Kiem tra login bang tai khoan AD
        //private static bool ValityDomainUsers(DirectoryEntry de, string strAccount)
        //{
        //    try
        //    {
        //        string strName = de.Name;
        //        DirectorySearcher search = new DirectorySearcher(de);
        //        string[] strTemp = strAccount.Split('\\');
        //        search.Filter = "(sAMAccountName=" + strTemp[1] + ")";
        //        search.PropertiesToLoad.Add("cn");
        //        SearchResult sr = search.FindOne();
        //        de = new DirectoryEntry(sr.Path);
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //    de.Close();
        //    return true;
        //}

        //public ActionResult Submit()
        //{
        //    return View();
        //    //C# code here
        //}
    }
}
