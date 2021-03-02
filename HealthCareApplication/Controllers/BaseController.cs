using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HCare.Structure;
using HealthCareApplication.Models;
using HCare.Models;
using System.Data;
using System.IO;
using System.Net.Mail;

namespace HealthCareApplication.Controllers
{
    public class BaseController : Controller
    {

        public object ExecuteDB(string methodName, object param)
        {
            object retObject = ServerManager.GetTaskManager.Execute(methodName, param);
            return retObject;
        }

        #region Site Management Actions
        public ActionResult RedirectToOut(string eMsg = "")
        {
            if (string.IsNullOrEmpty(eMsg)) eMsg = "Sorry, Unauthorized Access!";
            return RedirectToAction("MyBoard", "WebAccount", new { Id = eMsg });
        }


        public string SiteMyMenuList(string cAction = "")
        {
            string ErrorMsg = "";
            if (Session["UserId"] == null) ErrorMsg = "Sorry, Time Out!";
            else
            {
                string UserName = Session["UserName"].ToString();
                string cClass = string.IsNullOrEmpty(cAction) || cAction == "MyBoard" ? "active" : "";
                string SiteMenuList = string.IsNullOrEmpty(ViewBag.AdminError) ? "" : "<span class='text-danger'>" + ViewBag.AdminError + "</span>";
                    SiteMenuList += "<div class='list-group'><a href='/WebAccount/MyBoard' class='list-group-item " + cClass + "'>Hello, " + UserName + "</a>";

                cClass = cAction == "NewAppointment" ? "active" : "";
                SiteMenuList += "<a href='/WebAccount/NewAppointment' class='list-group-item " + cClass + "'>New Appointment</a>";

                cClass = cAction == "ManageAppointment" ? "active" : "";
                SiteMenuList += "<a href='/WebAccount/ManageAppointment' class='list-group-item " + cClass + "'>Manage Appointment</a>";

                SiteMenuList += "</div>";

                //Session["SiteMyMenuList"] = SiteMenuList;
                ViewBag.SiteMyMenuList = SiteMenuList;
                ViewBag.AdminError = "";
            }
            return ErrorMsg;
        }

        public bool SiteUserAccess(string MenuId, string Action)
        {
            bool Access = false;
            try
            {
                bool IsAdmin = Session["UserType"].ToString() == "Admin" ? true : false;
                if (!IsAdmin && "VAED".Contains(Action.ToUpper()))
                {
                    AdmRoledetailsEntity obj = new AdmRoledetailsEntity();
                    obj.Roleid = Session["UserType"].ToString();
                    obj.Featureid = MenuId;
                    obj.Isactive = "Active";
                    if (Action.ToUpper() == "V") obj.Isview = "checked";
                    if (Action.ToUpper() == "A") obj.Isadd = "checked";
                    if (Action.ToUpper() == "E") obj.Isedit = "checked";
                    if (Action.ToUpper() == "D") obj.Isdelete = "checked";
                    DataTable dt = (DataTable)ExecuteDB(HCareTaks.AG_GetAllAdmRoledetailsRecord, obj);
                    if (dt.Rows.Count > 0) Access = true;
                }
                else if (IsAdmin) Access = true;
            }
            catch { }
            return Access;
        }

        public string SiteMainMenuList(string cPageHead = "", string cController = "", string cAction = "")
        {
            string ErrorMsg = "";
            ViewBag.SitePageHead = cPageHead;

            bool IsActive = false;
            if (Session["UserId"] != null) 
            {
                HcUsersEntity obj = (HcUsersEntity)ExecuteDB(HCareTaks.AG_GetSingleHcUsersRecordById, Session["UserId"].ToString());
                if (obj != null && obj.Isactive == "Active") IsActive = true;
            }


            if (!IsActive || Session["UserType"].ToString() == "Patient" || (Session["UserType"].ToString() != "Admin" && Session["UserRoleId"] == null)) 
                ErrorMsg = "Sorry, Authentication Error!";
            else
            {
                bool IsAdmin = Session["UserType"].ToString() == "Admin" ? true : false;
                List<AdmRoledetailsEntity> rDetl = new List<AdmRoledetailsEntity>();
                if (!IsAdmin)
                {
                    AdmRoledetailsEntity obj = new AdmRoledetailsEntity();
                    obj.Roleid = Session["UserRoleId"].ToString();
                    obj.Isview = "checked";
                    obj.Isactive = "Active";
                    DataTable aDt = (DataTable)ExecuteDB(HCareTaks.AG_GetAllAdmRoledetailsRecord, obj);
                    foreach (DataRow dr in aDt.Rows)
                        rDetl.Add(new AdmRoledetailsEntity { Featureid = dr["FeatureId"].ToString(), Isview = dr["IsView"].ToString(), Isadd = dr["IsAdd"].ToString(), Isedit = dr["IsEdit"].ToString(), Isdelete = dr["IsDelete"].ToString() });
                }

                string cSelected = cPageHead.Contains("Dashboard") ? "selected" : "";
                string cActive = !string.IsNullOrEmpty(cSelected) ? "active" : "";
                string cIn = !string.IsNullOrEmpty(cSelected) ? "in" : "";
                string SiteMenuList = "<li class='sidebar-item " + cSelected + "'> <a class='sidebar-link waves-effect waves-dark sidebar-link " + cActive + "' href='/AdmHome/Dashboard' aria-expanded='false'><i class='mdi mdi-view-dashboard'></i><span class='hide-menu'>Dashboard</span></a></li>";

                //..... Get Main Menu List
                List<SiteInfo> MainList = SiteMainMenusList();
                foreach (SiteInfo Menu in MainList)
                {
                    string mID = Menu.MenuId,
                        mIcon = Menu.MenuIcon,
                        mName = Menu.MenuName,
                        mUrl = Menu.MenuUrl;
                    string[] Url = mUrl.Split(new string[] { "/" }, StringSplitOptions.None);
                    string Controller = Url.Length > 1 ? Url[1] : "", Action = Url.Length > 2 ? Url[2] : "";

                    //..... Get Sub Menu List
                    List<SiteInfo> SubList = SiteSubMenusList(mID);
                    if (SubList.Count > 0)
                    {
                        string SubMenu = "", mActive = ""; 
                        foreach (SiteInfo Sub in SubList)
                        {
                            bool iView = IsAdmin;
                            if (!IsAdmin && rDetl.Count > 0)
                            {
                                var aDr = rDetl.FirstOrDefault(m => m.Featureid.ToUpper() == Sub.MenuId.ToUpper());
                                if (aDr != null) iView = true;
                            }

                            if (iView)
                            {
                                string sID = Sub.MenuId,
                                    sName = Sub.MenuName,
                                    sIcon = Sub.MenuIcon,
                                    sUrl = Sub.MenuUrl;

                                Url = sUrl.Split(new string[] { "/" }, StringSplitOptions.None);
                                Controller = Url.Length > 1 ? Url[1] : ""; Action = Url.Length > 2 ? Url[2] : "";

                                cActive = cController == Controller && cAction == Action && string.IsNullOrEmpty(Url[0]) ? "active" : "";
                                if (!string.IsNullOrEmpty(cActive)) mActive = cActive;
                                SubMenu += "<li class='sidebar-item " + cActive + "'><a href='" + sUrl + "' class='sidebar-link " + cActive + "'><i class='" + sIcon + "'></i><span class='hide-menu'> " + sName + " </span></a></li>";
                            }
                        }
                        if (!string.IsNullOrEmpty(SubMenu))
                        {
                            cSelected = !string.IsNullOrEmpty(mActive) ? "selected" : "";
                            cIn = !string.IsNullOrEmpty(mActive) ? "in" : "";
                            SiteMenuList += "<li class='sidebar-item " + cSelected + "'> <a class='sidebar-link has-arrow waves-effect waves-dark " + mActive + "' href='javascript:void(0)' aria-expanded='false'><i class='" + mIcon + "'></i><span class='hide-menu'>" + mName + " </span></a>"
                                + "<ul aria-expanded='false' class='collapse  first-level " + cIn + "'>" + SubMenu + "</ul></li>";
                        }
                    }
                    //else
                    //{
                    //    cSelected = cController == Controller && cAction == Action && string.IsNullOrEmpty(Url[0]) ? "selected" : "";
                    //    cActive = !string.IsNullOrEmpty(cSelected) ? "active" : "";
                    //    SiteMenuList += "<li class='sidebar-item " + cSelected + "'> <a class='sidebar-link waves-effect waves-dark sidebar-link " + cActive + "' href='" + mUrl + "' aria-expanded='false'><i class='" + mIcon + "'></i><span class='hide-menu'>" + mName + "</span></a></li>";
                    //}
                }
                ViewBag.SiteMainMenuList = SiteMenuList;
                ViewBag.SiteDashboardMenuList = DashboardMenuList();
                //Session["SiteMainMenuList"] = SiteMenuList;
            }
            return ErrorMsg;
        }

        public List<SiteInfo> SiteMainMenusList()
        {
            List<SiteInfo> Items = new List<SiteInfo>();
            AdmMenuEntity obj = new AdmMenuEntity();
            obj.Isactive = "Active";
            DataTable dt = (DataTable)ExecuteDB(HCareTaks.AG_GetAllAdmMenuRecord, obj);
            foreach(DataRow dr in dt.Rows)
                Items.Add(new SiteInfo { MenuId = dr["ID"].ToString(), MenuIcon = dr["MenuIcon"].ToString(), MenuName = dr["MenuName"].ToString(), MenuUrl = dr["MenuUrl"].ToString() });
            //Items.Add(new SiteInfo { MenuId = "3", MenuIcon = "mdi mdi-blur-linear", MenuName = "Manage User", MenuUrl = "/UserManage/UserList" });
            //Items.Add(new SiteInfo { MenuId = "6", MenuIcon = "mdi mdi-blur-linear", MenuName = "Reports", MenuUrl = "/Settings/CompanyList" });
            return Items;
        }

        public List<SiteInfo> SiteSubMenusList(string MenuId = "")
        {
            List<SiteInfo> Items = new List<SiteInfo>();
            if (!string.IsNullOrEmpty(MenuId))
            {
                AdmMenusubEntity obj = new AdmMenusubEntity();
                obj.Isactive = "Active";
                obj.Menuid = MenuId;
                DataTable dt = (DataTable)ExecuteDB(HCareTaks.AG_GetAllAdmMenusubRecord, obj);
                foreach (DataRow dr in dt.Rows)
                    Items.Add(new SiteInfo { MenuId = dr["ID"].ToString(), MenuIcon = dr["SubIcon"].ToString(), MenuName = dr["SubName"].ToString(), MenuUrl = dr["SubUrl"].ToString() });
            }
            return Items;
        }

        public List<SiteInfo> SiteDashboardList()
        {
            List<SiteInfo> Items = new List<SiteInfo>();
            Items.Add(new SiteInfo { MenuId = "Admin", MenuName = "Admin Dashboard", MenuIcon = "ti-world", MenuUrl = "/AdmHome/AdminDashboard", TabData = "btn-success" });
            Items.Add(new SiteInfo { MenuId = "Doctor", MenuName = "Doctor Dashboard", MenuIcon = "ti-heart", MenuUrl = "/AdmHome/DoctorDashboard", TabData = "btn-info" });
            Items.Add(new SiteInfo { MenuId = "Lab", MenuName = "Lab Dashboard", MenuIcon = "ti-shield", MenuUrl = "/AdmHome/LabDashboard", TabData = "btn-primary" });
            Items.Add(new SiteInfo { MenuId = "Shop", MenuName = "Shop Dashboard", MenuIcon = "ti-package", MenuUrl = "/AdmHome/ShopDashboard", TabData = "btn-danger" });
            return Items;
        }

        string DashboardMenuList()
        {
            bool IsAdmin = Session["UserType"].ToString() == "Admin" ? true : false;
            string TableData = "";
            if (IsAdmin || (Session["UserAllDashboard"] != null && !string.IsNullOrEmpty(Session["UserAllDashboard"].ToString())))
            {
                string AllDashboard = Session["UserAllDashboard"].ToString();
                TableData = @"<li class='nav-item dropdown'>
                            <a class='nav-link dropdown-toggle waves-effect waves-dark' href='' id='2' data-toggle='dropdown' aria-haspopup='true' aria-expanded='false'> <i class='font-24 mdi mdi-view-dashboard'></i>
                            </a>
                            <div class='dropdown-menu dropdown-menu-right mailbox animated bounceInDown' aria-labelledby='2'>
                            <ul class='list-style-none'><li><div class=''>";

                List<SiteInfo> Items = SiteDashboardList();
                foreach (SiteInfo dr in Items)
                    if (IsAdmin || AllDashboard.ToString().Contains(dr.MenuId))
                        TableData += "<a href='" + dr.MenuUrl + "' class='link border-top'><div class='d-flex no-block align-items-center p-10'>" +
                        "<span class='btn " + dr.TabData + " btn-circle'><i class='" + dr.MenuIcon + "'></i></span>" +
                        "<div class='m-l-10'><h5 class='m-b-0'>" + dr.MenuName + "</h5></div></div></a>";

                TableData += "</div></li></ul></div></li>";
            }
            return TableData;
        }
        #endregion


        #region List Functions
        public List<SelectListItem> List_MainFeature()
        {
            List<SelectListItem> Items = new List<SelectListItem>();
            AdmMenuEntity obj = new AdmMenuEntity();
            obj.Isactive = "Active";
            DataTable dt = (DataTable)ExecuteDB(HCareTaks.AG_GetAllAdmMenuRecord, obj);
            foreach(DataRow dr in dt.Rows)
                Items.Add(new SelectListItem { Text = dr["MenuName"].ToString(), Value = dr["ID"].ToString() });
            return Items;
        }
        public List<SelectListItem> List_Country()
        {
            List<SelectListItem> Items = new List<SelectListItem>();
            HcCountryEntity obj = new HcCountryEntity();
            obj.Isactive = "1";
            DataTable dt = (DataTable)ExecuteDB(HCareTaks.AG_GetAllHcCountryRecord, obj);
            foreach (DataRow dr in dt.Rows)
                Items.Add(new SelectListItem { Text = dr["Countryname"].ToString(), Value = dr["ID"].ToString() });
            return Items;
        }
        public List<SelectListItem> List_Specialist()
        {
            List<SelectListItem> Items = new List<SelectListItem>();
            HcDoctorDepartmentsEntity obj = new HcDoctorDepartmentsEntity();
           // HcCountryEntity obj = new HcCountryEntity();
            obj.Isactive = "Active";
            DataTable dt = (DataTable)ExecuteDB(HCareTaks.AG_GetAllHcDoctorDepartmentsRecord, obj);
            foreach (DataRow dr in dt.Rows)
                Items.Add(new SelectListItem { Text = dr["Name"].ToString(), Value = dr["ID"].ToString() });
            return Items;
        }
        public List<SelectListItem> List_Labtest()
        {
            List<SelectListItem> Items = new List<SelectListItem>();
            HcTestCategoryEntity obj = new HcTestCategoryEntity();        
           
            DataTable dt = (DataTable)ExecuteDB(HCareTaks.AG_GetAllHcTestCategoryRecord, obj);
            foreach (DataRow dr in dt.Rows)
                Items.Add(new SelectListItem { Text = dr["Cattestname"].ToString(), Value = dr["ID"].ToString() });
            return Items;
        }


        public List<SelectListItem> List_Location()
        {
            List<SelectListItem> Items = new List<SelectListItem>();
            HcDoctorinfoEntity obj = new HcDoctorinfoEntity();
            // HcCountryEntity obj = new HcCountryEntity();
            obj.Isactive = "Active";
            DataTable dt = (DataTable)ExecuteDB(HCareTaks.AG_GetAllHcDoctorinfoRecord, obj);
            foreach (DataRow dr in dt.Rows)
                Items.Add(new SelectListItem { Text = dr["Location"].ToString(), Value = dr["Location"].ToString() });
            return Items;
        }

        public List<SelectListItem> List_UserRole()
        {
            List<SelectListItem> Items = new List<SelectListItem>();
            AdmRolemasterEntity obj = new AdmRolemasterEntity();
            obj.Isactive = "Active";
            DataTable dt = (DataTable)ExecuteDB(HCareTaks.AG_GetAllAdmRolemasterRecord, obj);
            foreach(DataRow dr in dt.Rows)
                Items.Add(new SelectListItem { Text = dr["RoleName"].ToString(), Value = dr["ID"].ToString() });
            return Items;
        }

        public List<SelectListItem> List_Doctor(string IsActive = "Active", string DepId = "")
        {
            List<SelectListItem> Items = new List<SelectListItem>();
            HcDoctorinfoEntity obj = new HcDoctorinfoEntity();
            obj.Isactive = IsActive;
            obj.Department = DepId;
            DataTable dt = (DataTable)ExecuteDB(HCareTaks.AG_GetAllHcDoctorinfoRecord, obj);
            foreach (DataRow dr in dt.Rows)
                Items.Add(new SelectListItem { Text = dr["Name"] + " (" + dr["DepartmentName"] + ")", Value = dr["ID"].ToString() });
            return Items;
        }

        public List<SelectListItem> List_Days()
        {
            List<SelectListItem> Items = new List<SelectListItem>();
            Items.Add(new SelectListItem { Text = "Sunday", Value = "Sunday" });
            Items.Add(new SelectListItem { Text = "Monday", Value = "Monday" });
            Items.Add(new SelectListItem { Text = "Tuesday", Value = "Tuesday" });
            Items.Add(new SelectListItem { Text = "Wednesday", Value = "Wednesday" });
            Items.Add(new SelectListItem { Text = "Thursday", Value = "Thursday" });
            Items.Add(new SelectListItem { Text = "Friday", Value = "Friday" });
            Items.Add(new SelectListItem { Text = "Saturday", Value = "Saturday" });
            //Items.Add(new SelectListItem { Text = "Sunday", Value = "0" });
            //Items.Add(new SelectListItem { Text = "Monday", Value = "1" });
            //Items.Add(new SelectListItem { Text = "Tuesday", Value = "2" });
            //Items.Add(new SelectListItem { Text = "Wednesday", Value = "3" });
            //Items.Add(new SelectListItem { Text = "Thursday", Value = "4" });
            //Items.Add(new SelectListItem { Text = "Friday", Value = "5" });
            //Items.Add(new SelectListItem { Text = "Saturday", Value = "6" });
            return Items;
        }

        public List<SelectListItem> List_PaymentMethod()
        {
            List<SelectListItem> Items = new List<SelectListItem>();
            Items.Add(new SelectListItem { Text = "Paypal", Value = "Paypal" });
            Items.Add(new SelectListItem { Text = "Visa/Master Card", Value = "Card" });
            Items.Add(new SelectListItem { Text = "User Wallet", Value = "Wallet" });
            return Items;
        }

        public List<SelectListItem> List_Gender()
        {
            List<SelectListItem> Items = new List<SelectListItem>();
            Items.Add(new SelectListItem { Text = "Male", Value = "Male" });
            Items.Add(new SelectListItem { Text = "Female", Value = "Female" });
            return Items;
        }

        public List<SelectListItem> List_UserType()
        {
            List<SelectListItem> Items = new List<SelectListItem>();
            Items.Add(new SelectListItem { Text = "Patient", Value = "Patient" });
            Items.Add(new SelectListItem { Text = "Doctor", Value = "Doctor" });
            Items.Add(new SelectListItem { Text = "Staff", Value = "Staff" });
            return Items;
        }

        public List<SelectListItem> List_Department()
        {
            List<SelectListItem> Items = new List<SelectListItem>();
            HcDoctorDepartmentsEntity obj = new HcDoctorDepartmentsEntity();
            obj.Isactive = "Active";
            DataTable dt = (DataTable)ExecuteDB(HCareTaks.AG_GetAllHcDoctorDepartmentsRecord, obj);
            foreach (DataRow dr in dt.Rows)
                Items.Add(new SelectListItem { Text = dr["Name"].ToString(), Value = dr["ID"].ToString() });
            return Items;
        }

        //public List<SelectListItem> List_IsActive()
        //{
        //    List<SelectListItem> Items = new List<SelectListItem>();
        //    Items.Add(new SelectListItem { Text = "Active", Value = "Active" });
        //    Items.Add(new SelectListItem { Text = "Inactive", Value = "Inactive" });
        //    return Items;
        //}





        public List<SelectListItem> List_ServiceType()  /// is it needed?
        {
            List<SelectListItem> Items = new List<SelectListItem>();
            Items.Add(new SelectListItem { Text = "Type A", Value = "A" });
            Items.Add(new SelectListItem { Text = "Type B", Value = "B" });
            return Items;
        }
        #endregion


        #region Other Functions
        public string DoctorDaysOfWeek(string Id)
        {
            string AllDays = "none";
            HcDoctorTimesEntity tObj = new HcDoctorTimesEntity();
            tObj.Doctorid = Id;
            tObj.Isactive = "Active";
            tObj.QueryFlag = "DayOfWeek";
            DataTable tDt = (DataTable)ExecuteDB(HCareTaks.AG_GetAllHcDoctorTimesRecord, tObj);
            if (tDt.Rows.Count > 0) AllDays = tDt.Rows[0]["DayOfWeek"].ToString();
            return AllDays;
        }

        public string DoctorRating(string Id)
        {
            string Rating = "5";
            //HcDoctorTimesEntity tObj = new HcDoctorTimesEntity();
            //tObj.Doctorid = Id;
            //tObj.Isactive = "Active";
            //tObj.QueryFlag = "DayOfWeek";
            //DataTable tDt = (DataTable)ExecuteDB(HCareTaks.AG_GetAllHcDoctorTimesRecord, tObj);
            //if (tDt.Rows.Count > 0) AllDays = tDt.Rows[0]["DayOfWeek"].ToString().ToUpper();
            return Rating;
        }
        #endregion


        #region Common Functions
        public JsonResult UploadFiles(string Folder = "")
        {
            if (Folder == "11") Folder = "Doctors";
            //else if (Folder == "101") Folder = "Handling";
            //else if (Folder == "55") Folder = "Users";
            else Folder = "";

            bool Success = false; string Path = "";
            if (Request.Files.Count > 0 && !string.IsNullOrEmpty(Folder))
            {
                Path = "/Docx/" + Folder;
                int cSl = 1;
                foreach (string file in Request.Files)
                {
                    string FileName = Request.Form["name" + cSl];
                    var fileContent = Request.Files[file];

                    if (string.IsNullOrEmpty(FileName) || FileName == "undefined") FileName = Guid.NewGuid().ToString().ToLower();
                    string FilePath = System.IO.Path.Combine(Server.MapPath("~" + Path), FileName);
                    if (System.IO.File.Exists(FilePath))
                    {
                        System.IO.File.Delete(FilePath);
                        string[] arr = FileName.Split('.');
                        FileName = arr[0];
                    }
                    if (fileContent != null && fileContent.ContentLength > 0)
                    {
                        var stream = fileContent.InputStream;

                        var fileExt = System.IO.Path.GetExtension(fileContent.FileName);
                        FileName = FileName + fileExt;
                        FilePath = System.IO.Path.Combine(Server.MapPath("~" + Path), FileName);
                        if (System.IO.File.Exists(FilePath)) System.IO.File.Delete(FilePath);
                        using (var fileStream = System.IO.File.Create(FilePath))
                        {
                            stream.CopyTo(fileStream);
                        }
                        if (System.IO.File.Exists(FilePath))
                        {
                            Success = true;
                            Path = Path + "/" + FileName;
                        }
                    }
                }
            }

            string Message = Success ? "File Uploaded" : "Sorry File Error!";
            return Json(new { Success = Success, Message = Message, Path = Path });
        }

        public bool RkIsEmailValid(string emailaddress)
        {
            if (string.IsNullOrEmpty(emailaddress)) return false;
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public string DateFormatWebToDb(string dt)
        {
            string res = "";
            if (!string.IsNullOrEmpty(dt))
            {
                try
                {
                    DateTime dbTime = DateTime.ParseExact(dt, "yyyy-MM-dd", null);
                    res = dbTime.ToString("dd/MM/yyyy");
                }
                catch { }
            }
            return res;
        }

        public string DateFormatDbToWeb(string dt)
        {
            string res = "";
            if (!string.IsNullOrEmpty(dt))
            {
                try
                {
                    DateTime dbTime = DateTime.ParseExact(dt, "dd/MM/yyyy", null);
                    res = dbTime.ToString("yyyy-MM-dd");
                }
                catch { }
            }
            return res;
        }
        #endregion

    }
}
