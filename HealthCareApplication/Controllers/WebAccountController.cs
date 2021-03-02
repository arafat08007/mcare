using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HealthCareApplication.Models;
using HCare.Models;
using System.Data;
using HCare.Structure;

namespace HealthCareApplication.Controllers
{
    public class WebAccountController : BaseController
    {

        #region Login
        public ActionResult Login(string Id = "")
        {
            ViewBag.LogedMessage = !string.IsNullOrEmpty(Id) ? Id : "";

            return View();
        }

        [HttpPost]
        public ActionResult Login(SiteInfo obj)
        {
            if (string.IsNullOrEmpty(obj.LoginUser))
            {
                ViewBag.LogedMessage = "Sorry, Empty Username";
            }
            else if (string.IsNullOrEmpty(obj.LoginPass))
            {
                ViewBag.LogedMessage = "Sorry, Empty Password";
            }
            else
            {
                HcUsersEntity uObj = new HcUsersEntity();
                uObj.Isactive = "Active";
                uObj.Logname = obj.LoginUser;
                uObj.Logpass = obj.LoginPass;
                DataTable dt = (DataTable)ExecuteDB(HCareTaks.AG_GetAllHcUsersRecord, uObj);
                string Id = dt.Rows.Count > 0 ? dt.Rows[0]["Id"].ToString() : "";
                bool Success = !string.IsNullOrEmpty(Id) ? fnUserInfoSession(Id) : false;

                //................................................. Set Demo Sessions 
                if (!Success)
                {
                    Success = true;
                    Session["UserId"] = "7734E724-2181-44CD-ADC7-E3AC493ED8AB";
                    Session["UserName"] = "Mr. Admin";
                    Session["UserType"] = "Admin";
                    Session["UserRoleId"] = "";
                    Session["UserImage"] = "/Content/rkscript/docx/UserImage/NoImage.jpg";
                    Session["UserDefaultBoard"] = "Admin";
                    Session["UserAllDashboard"] = "Admin,Doctor,Lab,Shop";
                }

                if (Success && Session["UserType"].ToString() == "Admin") return RedirectToAction("AdminDashboard", "AdmHome");
                else if (Success && Session["UserRoleId"] != null) return RedirectToAction("Dashboard", "AdmHome");
                else if (Success) return RedirectToAction("MyBoard", "WebAccount");
                else ViewBag.LogedMessage = "Sorry something went wrong!";
            }

            return View();
        }

        bool fnUserInfoSession(string Id)
        {
            bool Success = false;

            HcUsersEntity uInfo = (HcUsersEntity)ExecuteDB(HCareTaks.AG_GetSingleHcUsersRecordById, Id);
            if (uInfo != null)
            {
                Success = true;
                string uId = uInfo.Id, uName = uInfo.FirstName + " " + uInfo.LastName, uType = uInfo.Usertype, uDetlId = uInfo.Userid, uRoleId = uInfo.Roleid, 
                    UserDefaultBoard = "", UserAllDashboard = "", 
                    UserImage = "/Content/rkscript/docx/UserImage/NoImage.jpg";

                //................................................. Role Info
                if (uType == "Admin")
                {
                    UserDefaultBoard = "Admin";
                    List<SiteInfo> Items = SiteDashboardList();
                    foreach(SiteInfo dr in Items) UserAllDashboard += dr.MenuId + ",";
                }
                else if (!string.IsNullOrEmpty(uRoleId))
                {
                    AdmRolemasterEntity sObj = (AdmRolemasterEntity)ExecuteDB(HCareTaks.AG_GetSingleAdmRolemasterRecordById, uRoleId);
                    if (sObj != null)
                    {
                        UserDefaultBoard = sObj.DefaultBoard;
                        UserAllDashboard = sObj.AllDashboard;
                    }
                }

                //................................................. User Details Info
                if (!string.IsNullOrEmpty(uDetlId))
                {
                    if (uType == "Doctor")
                    {
                        HcDoctorinfoEntity sObj = (HcDoctorinfoEntity)ExecuteDB(HCareTaks.AG_GetSingleHcDoctorinfoRecordById, uDetlId);
                        if (sObj != null && !string.IsNullOrEmpty(sObj.Photo))
                        {
                            uName = sObj.Name;
                            if (!string.IsNullOrEmpty(sObj.Photo)) UserImage = sObj.Photo;
                        }
                    }
                    else if (uType == "Patient")
                    {
                        //HcDoctorinfoEntity sObj = (HcDoctorinfoEntity)ExecuteDB(HCareTaks.AG_GetSingleHcDoctorinfoRecordById, uDetlId);
                        //if (sObj != null && !string.IsNullOrEmpty(sObj.Photo))
                        //{
                        //    uName = sObj.Name;
                        //    if (!string.IsNullOrEmpty(sObj.Photo)) UserImage = sObj.Photo;
                        //}
                    }
                }

                if (Success)
                {
                    //................................................. Set Sessions 
                    Session["UserId"] = uId;
                    Session["UserName"] = uName;
                    Session["UserType"] = uType;   // Admin, Doctor, Patient, Staff
                    Session["UserRoleId"] = uRoleId;
                    Session["UserImage"] = UserImage;
                    Session["UserDefaultBoard"] = UserDefaultBoard;
                    Session["UserAllDashboard"] = UserDefaultBoard + "," + UserAllDashboard;

                    //................................................. Set LastLogIn Time 
                    HcUsersEntity log = new HcUsersEntity();
                    log.Id = Id;
                    log.Lastlogin = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                    log.QueryFlag = "LastLogIn";
                    ExecuteDB(HCareTaks.AG_UpdateHcUsersInfo, log);
                }
            }
            return Success;
        }

        public ActionResult AccessOut(string Id = "")
        {
            //    Session.Abandon();
            Session.Clear();
            string eMsg = !string.IsNullOrEmpty(Id) ? Id == "0" ? "" : Id : "Logged Out";
            return RedirectToAction("Login", "WebAccount", new { Id = eMsg });
        }
        #endregion


        #region LogForgotPassword
        public ActionResult LogForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogForgotPassword(HcUsersEntity iGet)
        {
            if (string.IsNullOrEmpty(iGet.Logname) || string.IsNullOrEmpty(iGet.SecurPass) || string.IsNullOrEmpty(iGet.Logpass) || string.IsNullOrEmpty(iGet.ConfirmPass))
                ViewBag.FPMessage = "Sorry, Please Check Required Fields.";
            else if (string.IsNullOrEmpty(iGet.Logpass) != string.IsNullOrEmpty(iGet.ConfirmPass))
                ViewBag.FPMessage = "Sorry, Please Check Passwords.";
            else
            {
                HcUsersEntity obj = new HcUsersEntity();
                obj.Logname = iGet.Logname;
                obj.SecurPass = iGet.SecurPass;
                DataTable dt = (DataTable)ExecuteDB(HCareTaks.AG_GetAllHcUsersRecord, obj);
                if (dt.Rows.Count == 0)
                    ViewBag.FPMessage = "Sorry, You are not Registered.";
                else if (dt.Rows[0]["IsActive"].ToString() == "Inactive")
                    ViewBag.FPMessage = "Sorry, You are Inactiveted.";
                else
                {
                    obj.QueryFlag = "LogPass";
                    obj.Logpass = iGet.Logpass;
                    obj.Id = dt.Rows[0]["ID"].ToString();
                    bool Success = (bool)ExecuteDB(HCareTaks.AG_UpdateHcUsersInfo, obj);
                    ViewBag.FPMessage = Success ? "Your Password has been changed." : "Sorry something went wrong!";
                }
            }
            return View(iGet);
        }
        #endregion


        #region LogRegistration
        public ActionResult LogRegistration()
        {
            ViewBag.GenderList = List_Gender();
            HcUsersEntity obj = new HcUsersEntity();
            obj.Gender = "Male";
            return View(obj);
        }

        [HttpPost]
        public ActionResult LogRegistration(HcUsersEntity iGet)
        {
            ViewBag.GenderList = List_Gender();
            bool Mail = !string.IsNullOrEmpty(iGet.Email) ? RkIsEmailValid(iGet.Email) : true;

            if (string.IsNullOrEmpty(iGet.Logname) || string.IsNullOrEmpty(iGet.SecurPass) || string.IsNullOrEmpty(iGet.Logpass) || string.IsNullOrEmpty(iGet.ConfirmPass) || string.IsNullOrEmpty(iGet.FirstName))
                ViewBag.FPMessage = "Sorry, Please Check Required Fields.";
            else if (string.IsNullOrEmpty(iGet.Logpass) != string.IsNullOrEmpty(iGet.ConfirmPass))
                ViewBag.FPMessage = "Sorry, Please Check Passwords.";
            else if (!Mail)
                ViewBag.FPMessage = "Sorry, Please Check Your Email Address.";
            else
            {
                HcUsersEntity obj = new HcUsersEntity();
                obj.Logname = iGet.Logname;
                DataTable dt = (DataTable)ExecuteDB(HCareTaks.AG_GetAllHcUsersRecord, obj);
                if (dt.Rows.Count > 0)
                    ViewBag.FPMessage = "Sorry, You are already Registered.";
                else
                {
                    obj.Logpass = iGet.Logpass;
                    obj.SecurPass = DateFormatWebToDb(iGet.SecurPass);
                    obj.Email = iGet.Email;
                    obj.FirstName = iGet.FirstName;
                    obj.LastName = iGet.LastName;
                    obj.Gender = iGet.Gender;
                    obj.Address = iGet.Address;
                    obj.Usertype = "Patient";
                    obj.Isactive = "Active";
                    obj.Createdtime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                    obj.Id = (string)ExecuteDB(HCareTaks.AG_SaveHcUsersInfo, obj);
                    ViewBag.FPMessage = !string.IsNullOrEmpty(obj.Id) ? "Your Registration has been completed. <a href='/WebAccount/Login' class='text-warning'>Login</a>" : "Sorry something went wrong!";
                }
            }
            return View(iGet);
        }
        #endregion




        #region MyBoard
        public ActionResult MyBoard(string Id = "")
        {
            ViewBag.AdminError = Id;
            string eMsg = SiteMyMenuList("MyBoard"); //--> PageHead, Controller, Action  --> SiteMainMenuWithAccess()
            if (!string.IsNullOrEmpty(eMsg)) return AccessOut(eMsg);


            //DateTime sysTime = DateTime.Now;
            //DateTime dbTime = DateTime.ParseExact("24/08/2020", "dd/MM/yyyy", null).AddDays(1);
            //double tDays = (dbTime - sysTime).TotalDays;

            //dbTime = DateTime.ParseExact("20/08/2020", "dd/MM/yyyy", null).AddDays(1);
            //tDays = (dbTime - sysTime).TotalDays;

            //dbTime = DateTime.ParseExact("27/08/2020", "dd/MM/yyyy", null).AddDays(1);
            //tDays = (dbTime - sysTime).TotalDays;

            return View();
        }
        #endregion

        #region NewAppointment
        public ActionResult NewAppointment(string Id)
        {
            string eMsg = SiteMyMenuList("NewAppointment");
            if (!string.IsNullOrEmpty(eMsg)) return AccessOut("0");

            ViewBag.ListDepartment = List_Department();
            ViewBag.ListPaymentMethod = List_PaymentMethod();

            SelectListItem OnTop = new SelectListItem() { Text = "Select...", Value = "" };
            ViewBag.BlankList = new List<SelectListItem> { OnTop };
            ViewBag.ListDepartment.Insert(0, OnTop);

            return View();
        }

        public JsonResult SaveAppointment(HcDoctorAppointmentEntity obj)
        {
            bool Success = false;
            
            if (!string.IsNullOrEmpty(obj.Doctorid) && !string.IsNullOrEmpty(obj.Dates) && !string.IsNullOrEmpty(obj.Timeid) && !string.IsNullOrEmpty(obj.Reasons) && !string.IsNullOrEmpty(obj.Paymethod))
            {
                try
                {
                    obj.Patientuid =
                    obj.Createdby = Session["UserId"].ToString();
                    obj.Createdtime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                    obj.Status = "Upcoming";
                    obj.Dates = DateFormatWebToDb(obj.Dates);
                    obj.Id = (string)ExecuteDB(HCareTaks.AG_SaveHcDoctorAppointmentInfo, obj);
                    if (!string.IsNullOrEmpty(obj.Id)) Success = true;
                }
                catch { }
            }

            string Message = Success ? "Process has been done successfully." : "Sorry something went wrong!";
            return Json(new { Success = Success, Message = Message });
        }

        public JsonResult DeleteAppointment(string Id)
        {
            bool Success = false;
            //DateTime sysTime = DateTime.Now;
            if (!string.IsNullOrEmpty(Id))
            {
                try
                {
                    HcDoctorAppointmentEntity obj = (HcDoctorAppointmentEntity)ExecuteDB(HCareTaks.AG_GetSingleHcDoctorAppointmentRecordById, Id);
                    obj.Id = Id;
                    //obj.Updatedby = !string.IsNullOrEmpty(Uid) ? Uid : null;
                    obj.Updatedby = Session["UserId"].ToString();
                    obj.Updatedtime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                    obj.Status = "Cancelled";
                    obj.QueryFlag = "Cancelled";
                    Success = (bool)ExecuteDB(HCareTaks.AG_UpdateHcDoctorAppointmentInfo, obj);

                    //DateTime dbTime = DateTime.ParseExact(Dates, "dd/MM/yyyy", null);
                    //string AppDate = dbTime.ToString("dddd, dd MMMM yyyy") + " & " + Times;
                    //double tDays = (dbTime.AddDays(1) - sysTime).TotalDays;

                    //if (Status == "Pending" && tDays < 0) { DeleteAppointments(Id); Status = "Cancelled"; }
                }
                catch { }
            }
            string Message = Success ? "Process has been done successfully." : "Sorry something went wrong!";
            return Json(new { Success = Success, Message = Message });
        }

        public JsonResult AppointDoctorList(string Dep)
        {
            string Result = "<option value=''>Select...</option>";
            if (!string.IsNullOrEmpty(Dep))
            {
                List<SelectListItem> Items = List_Doctor("Active", Dep);
                foreach (SelectListItem itm in Items)
                    Result += "<option value='" + itm.Value + "'>" + itm.Text + "</option>";
            }
            return Json(Result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AppointDoctorInfo(string Doc)
        {
            string Result = "";
            if (!string.IsNullOrEmpty(Doc))
            {
                string Img = "/Docx/NoImage.jpg", Days = "none", Fees = "0", Rating = "0";

                HcDoctorinfoEntity obj = (HcDoctorinfoEntity)ExecuteDB(HCareTaks.AG_GetSingleHcDoctorinfoRecordById, Doc);
                if (obj != null)
                {
                    if (!string.IsNullOrEmpty(obj.Photo)) Img = obj.Photo;
                    if (!string.IsNullOrEmpty(obj.Fees)) Fees = obj.Fees;
                    Days = DoctorDaysOfWeek(Doc);
                    Rating = DoctorRating(Doc);
                }

                Result = "<label class='text-info'>Doctor Information</label>" +
                "<img alt='' src='" + Img + "' style='margin-top:7px;overflow:hidden;width:150px; height:auto;' onclick = 'window.open(this.src)' />" +
                "<label class='text-info mt-20'>Days In Week</label><p>" + Days + "</p>" +
                "<label class='text-info'>Fees</label><p>Tk. " + Fees + "</p>" +
                "<label class='text-info'>Rating</label><p>" + Rating + " Star</p>" +
                "<p><a class='btn btn-block btn-warning pt-0 pb-0' href='/WebAccount/DoctorProfile/" + Doc + "' target='_blank'>Details...</a></p>";
            }
            return Json(Result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AppointDoctorTimes(string Doc, string Dt)
        {
            bool Success = false; string TimeList = "<option value='' selected>Select...</option>";
            if (!string.IsNullOrEmpty(Doc) && !string.IsNullOrEmpty(Dt))
            {
                string AllDays = DoctorDaysOfWeek(Doc);

                DateTime dbTime = DateTime.ParseExact(Dt, "yyyy-MM-dd", null);
                string Day = dbTime.DayOfWeek.ToString();
                if (AllDays.ToUpper().Contains(Day.ToUpper()))
                {
                    Success = true;
                    HcDoctorTimesEntity tObj = new HcDoctorTimesEntity();
                    tObj.Doctorid = Doc;
                    tObj.Days = Day;
                    tObj.Isactive = "Active";
                    DataTable tDt = (DataTable)ExecuteDB(HCareTaks.AG_GetAllHcDoctorTimesRecord, tObj);
                    foreach(DataRow dr in tDt.Rows)
                        TimeList += "<option value='" + dr["ID"] + "'>" + dr["Times"] + "</option>";
                }
            }
            return Json(new { Success = Success, TimeList = TimeList });
        }
        #endregion

        #region ManageAppointment
        public ActionResult ManageAppointment()
        {
            string eMsg = SiteMyMenuList("ManageAppointment");
            if (!string.IsNullOrEmpty(eMsg)) return AccessOut(eMsg);

            ViewBag.AppointmentData = ManageAppointmentData();

            return View();
        }

        string ManageAppointmentData()
        {
            string Upcoming = @"<div class='appointment-list bg-info p-10 mb-20'><h4>Upcoming Appointment</h4>
                    <table class='table table-sm table-responsive table-hover'><thead>
                    <tr><th>#</th><th>Doctor</th><th>Reasons</th><th>Appointment</th><th>Created</th><th>&nabla;</th></tr></thead><tbody>", 
                Completed = @"<div class='appointment-list bg-success p-10 mb-20'><h4>Completed Appointment</h4>
                    <table class='table table-sm table-responsive'><thead>
                    <tr><th>#</th><th>Doctor</th><th>Reasons</th><th>Appointment</th><th>Created</th></tr></thead><tbody>",
                Cancelled = @"<div class='appointment-list bg-danger p-10 mb-20'><h4>Cancelled Appointment</h4>
                    <table class='table table-sm table-responsive'><thead>
                    <tr><th>#</th><th>Doctor</th><th>Reasons</th><th>Appointment</th><th>Created</th></tr></thead><tbody>";
            HcDoctorAppointmentEntity obj = new HcDoctorAppointmentEntity();
            obj.Patientuid = Session["UserId"].ToString();
            DataTable dt = (DataTable)ExecuteDB(HCareTaks.AG_GetAllHcDoctorAppointmentRecord, obj);
            int Up = 1, Co = 1, Ca = 1;
            foreach (DataRow dr in dt.Rows)
            {
                string Id = dr["Id"].ToString(),
                    Status = dr["Status"].ToString(),
                    Times = dr["Times"].ToString(),
                    Dates = dr["Dates"].ToString() + "<br><small>" + Times + "</small>",
                    Created = dr["CreatedTime"].ToString().Substring(0, 10),
                    Reasons = dr["Reasons"].ToString(),
                    Doctor = dr["DoctorName"].ToString() + "<br><small>" + dr["DoctorDeptName"].ToString() + "</small>";

                if (Status == "Upcoming")
                {
                    string Action = "<i class='fa fa-times text-danger iPointer' onclick=\"DeleteAppointment('" + Id + "')\" title='Cancel This Appointment'></i>";
                    Upcoming += "<tr><td>" + Up + "</td><td>" + Doctor + "</td><td>" + Reasons + "</td><td>" + Dates + "</td><td>" + Created + "</td><td>" + Action + "</td></tr>";
                    Up++;
                }
                else if (Status == "Completed")
                {
                    Completed += "<tr><td>" + Co + "</td><td>" + Doctor + "</td><td>" + Reasons + "</td><td>" + Dates + "</td><td>" + Created + "</td></tr>";
                    Co++;
                }
                else if (Status == "Cancelled")
                {
                    Cancelled += "<tr><td>" + Ca + "</td><td>" + Doctor + "</td><td>" + Reasons + "</td><td>" + Dates + "</td><td>" + Created + "</td></tr>";
                    Ca++;
                }
            }
            return Upcoming + "</tbody></table></div>" + Completed + "</tbody></table></div>" + Cancelled + "</tbody></table></div>";
        }
        #endregion

        public ActionResult DoctorProfile(string Id)
        {

            return View();
        }

        public ActionResult ProductProfile(string Id)
        {

            return View();
        }

        public ActionResult ShowDetails(string Id)
        {
            if (!string.IsNullOrEmpty(Id))
            {
                string[] Detl = Id.Split(new string[] { "__" }, StringSplitOptions.None);
                if (Detl[0] == "Doctor") return RedirectToAction("DoctorProfile", "WebAccount", new { Id = Detl[1] });
                else if (Detl[0] == "Product") return RedirectToAction("ProductProfile", "WebAccount", new { Id = Detl[1] });
            }

            return RedirectToAction("Index", "Home");
        }

    }
}
