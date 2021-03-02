using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthCareApplication.Controllers
{
    public class AdmHomeController : BaseController
    {
        //
        // GET: /AdmHome/

        public ActionResult Dashboard()
        {
            string eMsg = SiteMainMenuList("Dashboard"); //--> PageHead, Controller, Action 
            if (!string.IsNullOrEmpty(eMsg)) return RedirectToOut(eMsg);
            
            string UserDefaultBoard = Session["UserDefaultBoard"].ToString();
            if (UserDefaultBoard == "Admin") return RedirectToAction("AdminDashboard", "AdmHome");
            else if (UserDefaultBoard == "Doctor") return RedirectToAction("DoctorDashboard", "AdmHome");
            else if (UserDefaultBoard == "Lab") return RedirectToAction("LabDashboard", "AdmHome");
            else if (UserDefaultBoard == "Shop") return RedirectToAction("ShopDashboard", "AdmHome");

            return View(); 
        }

        #region AdminDashboard
        public ActionResult AdminDashboard()
        {
            if (Session["UserAllDashboard"] != null && !Session["UserAllDashboard"].ToString().Contains("Admin")) return RedirectToAction("Dashboard", "AdmHome");
            string eMsg = SiteMainMenuList("Admin Dashboard"); //--> PageHead, Controller, Action 
            if (!string.IsNullOrEmpty(eMsg)) return RedirectToOut(eMsg);

            return View("Dashboard"); 
        }
        #endregion

        #region DoctorDashboard
        public ActionResult DoctorDashboard()
        {
            if (Session["UserAllDashboard"] != null && !Session["UserAllDashboard"].ToString().Contains("Doctor")) return RedirectToAction("Dashboard", "AdmHome");
            string eMsg = SiteMainMenuList("Doctor Dashboard"); //--> PageHead, Controller, Action 
            if (!string.IsNullOrEmpty(eMsg)) return RedirectToOut(eMsg);

            return View(); 
        }
        #endregion

        #region LabDashboard
        public ActionResult LabDashboard()
        {
            if (Session["UserAllDashboard"] != null && !Session["UserAllDashboard"].ToString().Contains("Lab")) return RedirectToAction("Dashboard", "AdmHome");
            string eMsg = SiteMainMenuList("Lab Dashboard"); //--> PageHead, Controller, Action 
            if (!string.IsNullOrEmpty(eMsg)) return RedirectToOut(eMsg);

            return View(); 
        }
        #endregion

        #region ShopDashboard
        public ActionResult ShopDashboard()
        {
            if (Session["UserAllDashboard"] != null && !Session["UserAllDashboard"].ToString().Contains("Shop")) return RedirectToAction("Dashboard", "AdmHome");
            string eMsg = SiteMainMenuList("E-Shop Dashboard"); //--> PageHead, Controller, Action 
            if (!string.IsNullOrEmpty(eMsg)) return RedirectToOut(eMsg);

            return View(); 
        }
        #endregion



    }
}
