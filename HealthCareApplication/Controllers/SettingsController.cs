using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using HCare.Models;
using HCare.Structure;
using HealthCareApplication.Models;
using System.Web.Script.Serialization;

namespace HealthCareApplication.Controllers
{
    public class SettingsController : BaseController
    {
        //
        // GET: /Settings/

        #region Feature
        public ActionResult FeatureList(string Id)
        {
            string eMsg = SiteMainMenuList("Feature List", "Settings", "FeatureList");
            if (!string.IsNullOrEmpty(eMsg)) return RedirectToOut(eMsg);
            //else if (!SiteUserAccess("", "V")) return RedirectToOut();

            ViewBag.TableData = FeatureListTableData();
            return View();
        }

        string FeatureListTableData()
        {
            string TableData = "";
            AdmMenuEntity obj = new AdmMenuEntity();
            DataTable dt = (DataTable)ExecuteDB(HCareTaks.AG_GetAllAdmMenuRecord, obj);
            int Count = 1;
            foreach (DataRow dr in dt.Rows)
            {
                string Action = "<i class='mdi mdi-table-edit iAction' title='Edit This' onclick=\"EditDetails('" + dr["Id"].ToString() + "')\" style='color:orange'></i>";
                    Action += "<i class='mdi mdi-close-box iAction' title='Inactive This' onclick=\"DeleteDetails('" + dr["Id"].ToString() + "', this)\" style='color:red'></i>";
                TableData +=
                    "<tr>" +
                    "<td><i class='mdi mdi-format-float-left iAction' title='Sub-Feature' onclick=\"SubFeatureDetails('" + dr["Id"].ToString() + "')\" style='color:green'></i></td>" +
                    "<td>F" + dr["ID"] + "</td>" +
                    "<td>" + dr["SortBy"] + "</td>" +
                    "<td>" + dr["MenuIcon"] + "</td>" +
                    "<td>" + dr["MenuName"] + "</td>" +
                    "<td>" + dr["MenuUrl"] + "</td>" +
                    "<td class='IsActive'>" + dr["IsActive"] + "</td>" +
                    "<td>" + Action + "</td>" +
                    "</tr>";
                Count += 1;
            }

            string CreateBtn = "<button class='btn btn-primary' type='button' onclick='CreateDetails()'  style='margin-bottom:10px;'> New</button>";
            string tHead =
                "<tr>" +
                    "<th>Sub</th>" +
                    "<th>Code</th>" +
                    "<th>SortBy</th>" +
                    "<th>Icon</th>" +
                    "<th>Feature</th>" +
                    "<th>Url</ th>" +
                    "<th>IsActive</th>" +
                    "<th>Action</th>" +
                "</tr>";
            TableData = CreateBtn + "<div class='table-responsive'><table id='zero_config' class='table table-striped table-bordered'>" +
                "<thead>" + tHead + "</thead><tbody>" + TableData + "</tbody></table></div>";

            return TableData;
        }

        public JsonResult FeatureDeleteById(string Id)
        {
            bool Success = false;
            AdmMenuEntity obj = (AdmMenuEntity)ExecuteDB(HCareTaks.AG_GetSingleAdmMenuRecordById, Id);
            if (obj != null)
            {
                obj.Updatedby = Session["UserId"].ToString();
                obj.Updatedtime = DateTime.Now.ToString("dd/MM/yyyy");
                obj.Isactive = "Inactive";
                Success = (bool)ExecuteDB(HCareTaks.AG_UpdateAdmMenuInfo, obj);
            }
            string Message = Success ? "Delete Success" : "Sorry something went wrong!";
            return Json(new { Success = Success, Message = Message });
        }

        public ActionResult FeatureCreate(string Id)
        {
            string eMsg = SiteMainMenuList("Feature Details", "Settings", "FeatureList");
            if (!string.IsNullOrEmpty(eMsg)) return RedirectToOut(eMsg);
            //else if (!SiteUserAccess("", "V")) return RedirectToOut();

            AdmMenuEntity obj = new AdmMenuEntity();
            obj.Menuicon = "mdi mdi-blur-linear";
            obj.Menuurl = "#";
            if(!string.IsNullOrEmpty(Id)) obj = (AdmMenuEntity)ExecuteDB(HCareTaks.AG_GetSingleAdmMenuRecordById, Id);

            return View(obj);
        }

        [HttpPost]
        public JsonResult FeatureSaveUpdate(AdmMenuEntity obj)
        {
            bool Success = false;
            if (string.IsNullOrEmpty(obj.Isactive)) obj.Isactive = "Active";
            if (string.IsNullOrEmpty(obj.Id))
            {
                obj.Createdby = Session["UserId"].ToString();
                obj.Createdtime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                obj.Id = (string)ExecuteDB(HCareTaks.AG_SaveAdmMenuInfo, obj);
                if (!string.IsNullOrEmpty(obj.Id)) Success = true;
            }
            else
            {
                obj.Updatedby = Session["UserId"].ToString();
                obj.Updatedtime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                Success = (bool)ExecuteDB(HCareTaks.AG_UpdateAdmMenuInfo, obj);
            }

            string Message = Success ? "Process has been done successfully" : "Sorry something went wrong!";
            return Json(new { Success = Success, Message = Message, Id = obj.Id });

        }
        #endregion


        #region SubFeature
        public ActionResult SubFeatureList(string Id)
        {
            string eMsg = SiteMainMenuList("SubFeature List", "Settings", "FeatureList");
            if (!string.IsNullOrEmpty(eMsg)) return RedirectToOut(eMsg);
            //else if (!SiteUserAccess("", "V")) return RedirectToOut();

            ViewBag.TableData = SubFeatureListTableData(Id);
            return View();
        }

        string SubFeatureListTableData(string Id)
        {
            string TableData = "";
            AdmMenusubEntity obj = new AdmMenusubEntity();
            obj.Menuid = Id;
            DataTable dt = (DataTable)ExecuteDB(HCareTaks.AG_GetAllAdmMenusubRecord, obj);
            int Count = 1;
            foreach (DataRow dr in dt.Rows)
            {
                string Action = "<i class='mdi mdi-table-edit iAction' title='Edit This' onclick=\"EditDetails('" + dr["Id"].ToString() + "')\" style='color:orange'></i>";
                    Action += "<i class='mdi mdi-close-box iAction' title='Inactive This' onclick=\"DeleteDetails('" + dr["Id"].ToString() + "', this)\" style='color:red'></i>";
                TableData +=
                    "<tr>" +
                    "<td>" + dr["MenuName"] + "</td>" +
                    "<td>SF" + dr["ID"] + "</td>" +
                    "<td>" + dr["SortBy"] + "</td>" +
                    "<td>" + dr["SubIcon"] + "</td>" +
                    "<td>" + dr["SubName"] + "</td>" +
                    "<td>" + dr["SubUrl"] + "</td>" +
                    "<td class='IsActive'>" + dr["IsActive"] + "</td>" +
                    "<td>" + Action + "</td>" +
                    "</tr>";
                Count += 1;
            }

            string CreateBtn = "<button class='btn btn-primary' type='button' onclick='CreateDetails()'  style='margin-bottom:10px;'> New</button>";
            string tHead =
                "<tr>" +
                    "<th>Feature</th>" +
                    "<th>Code</th>" +
                    "<th>SortBy</th>" +
                    "<th>Icon</th>" +
                    "<th>Sub-Feature</th>" +
                    "<th>Url</ th>" +
                    "<th>IsActive</th>" +
                    "<th>Action</th>" +
                "</tr>";
            TableData = CreateBtn + "<div class='table-responsive'><table id='zero_config' class='table table-striped table-bordered'>" +
                "<thead>" + tHead + "</thead><tbody>" + TableData + "</tbody></table></div>";

            return TableData;
        }

        public JsonResult SubFeatureDeleteById(string Id)
        {
            bool Success = false;
            AdmMenusubEntity obj = (AdmMenusubEntity)ExecuteDB(HCareTaks.AG_GetSingleAdmMenusubRecordById, Id);
            if (obj != null)
            {
                obj.Updatedby = Session["UserId"].ToString();
                obj.Updatedtime = DateTime.Now.ToString("dd/MM/yyyy");
                obj.Isactive = "Inactive";
                Success = (bool)ExecuteDB(HCareTaks.AG_UpdateAdmMenusubInfo, obj);
            }
            string Message = Success ? "Delete Success" : "Sorry something went wrong!";
            return Json(new { Success = Success, Message = Message });
        }

        public ActionResult SubFeatureCreate(string Id)
        {
            string eMsg = SiteMainMenuList("SubFeature Details", "Settings", "FeatureList");
            if (!string.IsNullOrEmpty(eMsg)) return RedirectToOut(eMsg);
            //else if (!SiteUserAccess("", "V")) return RedirectToOut();

            ViewBag.MainFeatureList = List_MainFeature();
            AdmMenusubEntity obj = new AdmMenusubEntity();
            obj.Subicon = "mdi mdi-chart-bubble";
            if (!string.IsNullOrEmpty(Id)) obj = (AdmMenusubEntity)ExecuteDB(HCareTaks.AG_GetSingleAdmMenusubRecordById, Id);

            return View(obj);
        }

        [HttpPost]
        public JsonResult SubFeatureSaveUpdate(AdmMenusubEntity obj)
        {
            bool Success = false;
            if (string.IsNullOrEmpty(obj.Isactive)) obj.Isactive = "Active";
            if (string.IsNullOrEmpty(obj.Id))
            {
                obj.Createdby = Session["UserId"].ToString();
                obj.Createdtime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                obj.Id = (string)ExecuteDB(HCareTaks.AG_SaveAdmMenusubInfo, obj);
                if (!string.IsNullOrEmpty(obj.Id)) Success = true;
            }
            else
            {
                obj.Updatedby = Session["UserId"].ToString();
                obj.Updatedtime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                Success = (bool)ExecuteDB(HCareTaks.AG_UpdateAdmMenusubInfo, obj);
            }

            string Message = Success ? "Process has been done successfully" : "Sorry something went wrong!";
            return Json(new { Success = Success, Message = Message, Id = obj.Menuid });

        }
        #endregion


        #region Roles
        public ActionResult RoleList(string Id)
        {
            string eMsg = SiteMainMenuList("Role List", "Settings", "RoleList");
            if (!string.IsNullOrEmpty(eMsg)) return RedirectToOut(eMsg);
            //else if (!SiteUserAccess("", "V")) return RedirectToOut();

            ViewBag.TableData = RoleListTableData();
            return View();
        }

        string RoleListTableData()
        {
            string TableData = "";
            AdmRolemasterEntity obj = new AdmRolemasterEntity();
            DataTable dt = (DataTable)ExecuteDB(HCareTaks.AG_GetAllAdmRolemasterRecord, obj);
            int Count = 1;
            foreach (DataRow dr in dt.Rows)
            {
                string Action = "<i class='mdi mdi-table-edit iAction' title='Edit This' onclick=\"EditDetails('" + dr["Id"].ToString() + "')\" style='color:orange'></i>";
                    Action += "<i class='mdi mdi-close-box iAction' title='Inactive This' onclick=\"DeleteDetails('" + dr["Id"].ToString() + "', this)\" style='color:red'></i>";
                TableData +=
                    "<tr>" +
                    "<td>" + Count + "</td>" +
                    "<td>" + dr["RoleName"] + "</td>" +
                    "<td>" + dr["RoleDescription"] + "</td>" +
                    "<td class='IsActive'>" + dr["IsActive"] + "</td>" +
                    "<td>" + Action + "</td>" +
                    "</tr>";
                Count += 1;
            }

            string CreateBtn = "<button class='btn btn-primary' type='button' onclick='CreateDetails()'  style='margin-bottom:10px;'> New</button>";
            string tHead =
                "<tr>" +
                    "<th>SortBy</th>" +
                    "<th>RoleName</th>" +
                    "<th>RoleDescription</th>" +
                    "<th>IsActive</th>" +
                    "<th>Action</th>" +
                "</tr>";
            TableData = CreateBtn + "<div class='table-responsive'><table id='zero_config' class='table table-striped table-bordered'>" +
                "<thead>" + tHead + "</thead><tbody>" + TableData + "</tbody></table></div>";

            return TableData;
        }

        public JsonResult RoleDeleteById(string Id)
        {
            bool Success = false;
            AdmRolemasterEntity obj = (AdmRolemasterEntity)ExecuteDB(HCareTaks.AG_GetSingleAdmRolemasterRecordById, Id);
            if (obj != null)
            {
                obj.Updatedby = Session["UserId"].ToString();
                obj.Updatedtime = DateTime.Now.ToString("dd/MM/yyyy");
                obj.Isactive = "Inactive";
                Success = (bool)ExecuteDB(HCareTaks.AG_UpdateAdmRolemasterInfo, obj);
            }
            string Message = Success ? "Delete Success" : "Sorry something went wrong!";
            return Json(new { Success = Success, Message = Message });
        }

        public ActionResult RoleCreate(string Id)
        {
            string eMsg = SiteMainMenuList("Role Details", "Settings", "RoleList");
            if (!string.IsNullOrEmpty(eMsg)) return RedirectToOut(eMsg);
            //else if (!SiteUserAccess("", "V")) return RedirectToOut();

            ViewBag.MainFeatureList = List_MainFeature();
            ViewBag.DashboardList = SiteDashboardList();
            AdmRolemasterEntity obj = new AdmRolemasterEntity();
            if (!string.IsNullOrEmpty(Id))
            {
                obj = (AdmRolemasterEntity)ExecuteDB(HCareTaks.AG_GetSingleAdmRolemasterRecordById, Id);
                if (obj == null) obj = new AdmRolemasterEntity();
            }
            ViewBag.TableData = RoleDetailsTableData(Id);

            return View(obj);
        }

        string RoleDetailsTableData(string Id)
        {
            List<AdmRoledetailsEntity> RoleList = new List<AdmRoledetailsEntity>();
            if (!string.IsNullOrEmpty(Id))
            {
                AdmRoledetailsEntity obj = new AdmRoledetailsEntity { Roleid = Id };
                DataTable dt = (DataTable)ExecuteDB(HCareTaks.AG_GetAllAdmRoledetailsRecord, obj);
                foreach (DataRow dr in dt.Rows)
                {
                    RoleList.Add(new AdmRoledetailsEntity()
                    {
                        Id = dr["Id"].ToString(),
                        Roleid = dr["RoleId"].ToString(),
                        Featureid = dr["FeatureId"].ToString(),
                        Isview = dr["IsView"].ToString(),
                        Isadd = dr["IsAdd"].ToString(),
                        Isedit = dr["IsEdit"].ToString(),
                        Isdelete = dr["IsDelete"].ToString(),
                    });
                }
            }

            int Count = 1;
            string TableData = "";
            //........ Web Permission
            List<SiteInfo> MainMenuList = SiteMainMenusList();
            foreach (SiteInfo Menu in MainMenuList)
            {
                string MenuId = Menu.MenuId, MenuName = Menu.MenuName;
                List<SiteInfo> SubMenuList = SiteSubMenusList(MenuId);
                string SubFeature = "";
                foreach (SiteInfo sMenu in SubMenuList)
                {
                    string sMenuId = sMenu.MenuId, sMenuName = sMenu.MenuName;
                    var reponse = RoleList.Find(r => r.Featureid == sMenuId);
                    string view = reponse != null ? reponse.Isview : "",
                        add = reponse != null ? reponse.Isadd : "",
                        edit = reponse != null ? reponse.Isedit : "",
                        delete = reponse != null ? reponse.Isdelete : "",
                        detlid = reponse != null ? reponse.Id : "";

                    SubFeature += "<tr>" +
                        "<td>" + sMenuName + " <input data-detlid='" + detlid + "' type='hidden' value='" + sMenuId + "' class='allInput' id='id" + Count + "' /></td>" +
                        "<td><input type='checkbox' class='allSel' onchange='SelectAll(this)' /></td>" +
                        "<td><input type='checkbox' class='allSel' id='view" + Count + "' " + view + " />" +
                        "<td><input type='checkbox' class='allSel' id='add" + Count + "' " + add + " /></td>" +
                        "<td><input type='checkbox' class='allSel' id='edit" + Count + "' " + edit + " /></td>" +
                        "<td><input type='checkbox' class='allSel' id='delete" + Count + "' " + delete + " /></td>" +
                    "</tr>";
                    Count++;
                }
                if (!string.IsNullOrEmpty(SubFeature))
                {
                    TableData += @"<a style='color:blue;' class='card-header link border-top' data-toggle='collapse' data-parent='#accordian-4' href='#Toggle-" + Count + "' aria-expanded='true' aria-controls='Toggle-" + Count + "'>" +
                        "<i class='seticon fa fa-arrow-right' aria-hidden='true'></i> <span>" + MenuName + "</span></a>" +
                        "<div id='Toggle-" + Count + "' class='collapse show multi-collapse'>" +
                        "<div class='card-body widget-content'>" +
                        "<div class='table-responsive'>" +
                        @"<table class='table'>
                    <thead class='thead-light'><tr><th width='50%'>Feature</th><th width='10%'>All</th><th width='10%'>View</th><th width='10%'>Add</th><th width='10%'>Edit</th><th width='10%'>Delete</th></tr></thead>
                    <tbody>" + SubFeature + "</tbody></table></div></div></div>";
                }
            }

            TableData = "<div id='accordian-4'><div class='card m-t-30'>" + TableData + "</div></div>";

            return TableData;
        }

        [HttpPost]
        public JsonResult RoleSaveUpdate(AdmRolemasterEntity obj)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            List<AdmRoledetailsEntity> dGetObj = serializer.Deserialize<List<AdmRoledetailsEntity>>(obj.JsonDetails);

            bool Success = false;
            if (string.IsNullOrEmpty(obj.Isactive)) obj.Isactive = "Active";
            if (string.IsNullOrEmpty(obj.Id))
            {
                obj.Createdby = Session["UserId"].ToString();
                obj.Createdtime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                obj.Id = (string)ExecuteDB(HCareTaks.AG_SaveAdmRolemasterInfo, obj);
                if (!string.IsNullOrEmpty(obj.Id)) Success = true;
            }
            else
            {
                obj.Updatedby = Session["UserId"].ToString();
                obj.Updatedtime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                Success = (bool)ExecuteDB(HCareTaks.AG_UpdateAdmRolemasterInfo, obj);
            }

            if (Success)
            {
                foreach (AdmRoledetailsEntity uObj in dGetObj)
                {
                    uObj.Roleid = obj.Id;
                    if (string.IsNullOrEmpty(uObj.Id)) ExecuteDB(HCareTaks.AG_SaveAdmRoledetailsInfo, uObj);
                    else ExecuteDB(HCareTaks.AG_UpdateAdmRoledetailsInfo, uObj);
                }
            }

            string Message = Success ? "Process has been done successfully" : "Sorry something went wrong!";
            return Json(new { Success = Success, Message = Message, Id = obj.Id });

        }
        #endregion


        #region User
        public ActionResult UserList(string Id)
        {
            string eMsg = SiteMainMenuList("User List", "Settings", "UserList");
            if (!string.IsNullOrEmpty(eMsg)) return RedirectToOut(eMsg);
            //else if (!SiteUserAccess("", "V")) return RedirectToOut();

            ViewBag.TableData = UserListTableData();
            return View();
        }

        string UserListTableData()
        {
            string TableData = "";
            HcUsersEntity obj = new HcUsersEntity();
            DataTable dt = (DataTable)ExecuteDB(HCareTaks.AG_GetAllHcUsersRecord, obj);
            int Count = 1;
            foreach (DataRow dr in dt.Rows)
            {
                string Action = "<i class='mdi mdi-table-edit iAction' title='Edit This' onclick=\"EditDetails('" + dr["ID"].ToString() + "')\" style='color:orange'></i>";
                Action += "<i class='mdi mdi-close-box iAction' title='Inactive This' onclick=\"DeleteDetails('" + dr["ID"].ToString() + "', this)\" style='color:red'></i>";
                TableData +=
                    "<tr>" +
                    "<td>" + dr["LogName"] + "</td>" +
                    "<td>" + dr["SecurPass"] + "</td>" +
                    "<td>" + dr["FirstName"] + "</td>" +
                    "<td>" + dr["LastName"] + "</td>" +
                    "<td>" + dr["Email"] + "</td>" +
                    "<td>" + dr["Gender"] + "</td>" +
                    "<td>" + dr["UserType"] + "</td>" +
                    "<td class='IsActive'>" + dr["IsActive"] + "</td>" +
                    "<td>" + Action + "</td>" +
                    "</tr>";
                Count += 1;
            }

            string CreateBtn = "<button class='btn btn-primary' type='button' onclick='CreateDetails()'  style='margin-bottom:10px;'> New</button>";
            string tHead =
                "<tr>" +
                    "<th>UserId</th>" +
                    "<th>SecurPass</th>" +
                    "<th>First Name</th>" +
                    "<th>Last Name</th>" +
                    "<th>Email</th>" +
                    "<th>Gender</th>" +
                    "<th>UserType</th>" +
                    "<th>IsActive</th>" +
                    "<th>Action</th>" +
                "</tr>";
            TableData = CreateBtn + "<div class='table-responsive'><table id='zero_config' class='table table-striped table-bordered'>" +
                "<thead>" + tHead + "</thead><tbody>" + TableData + "</tbody></table></div>";

            return TableData;
        }

        public JsonResult UserDeleteById(string Id)
        {
            bool Success = false;
            HcUsersEntity obj = (HcUsersEntity)ExecuteDB(HCareTaks.AG_GetSingleHcUsersRecordById, Id);
            if (obj != null)
            {
                obj.Updatedby = Session["UserId"].ToString();
                obj.Updatedtime = DateTime.Now.ToString("dd/MM/yyyy");
                obj.Isactive = "Inactive";
                Success = (bool)ExecuteDB(HCareTaks.AG_UpdateHcUsersInfo, obj);
            }
            string Message = Success ? "Delete Success" : "Sorry something went wrong!";
            return Json(new { Success = Success, Message = Message });
        }

        public ActionResult UserCreate(string Id)
        {
            string eMsg = SiteMainMenuList("User Details", "Settings", "UserList");
            if (!string.IsNullOrEmpty(eMsg)) return RedirectToOut(eMsg);
            //else if (!SiteUserAccess("", "V")) return RedirectToOut();

            ViewBag.ListUserRole = List_UserRole();
            ViewBag.GenderList = List_Gender();
            ViewBag.UserTypeList = List_UserType();

            SelectListItem OnTop = new SelectListItem() { Text = "Select...", Value = "" };
            ViewBag.ListUserRole.Insert(0, OnTop);

            HcUsersEntity obj = new HcUsersEntity();
            obj.Gender = "Male";
            if (!string.IsNullOrEmpty(Id))
            {
                obj = (HcUsersEntity)ExecuteDB(HCareTaks.AG_GetSingleHcUsersRecordById, Id);
                if (obj == null) obj = new HcUsersEntity();
            }

            return View(obj);
        }

        [HttpPost]
        public JsonResult UserSaveUpdate(HcUsersEntity obj)
        {
            bool Success = false; string Message = "Sorry something went wrong!";
            bool Mail = !string.IsNullOrEmpty(obj.Email) ? RkIsEmailValid(obj.Email) : true;

            if (!string.IsNullOrEmpty(obj.Logname) && !string.IsNullOrEmpty(obj.Logpass) && !string.IsNullOrEmpty(obj.FirstName) && Mail)
            {
                HcUsersEntity iGet = new HcUsersEntity();
                iGet.Logname = obj.Logname;
                DataTable dt = (DataTable)ExecuteDB(HCareTaks.AG_GetAllHcUsersRecord, iGet);
                if (dt.Rows.Count > 0 && (string.IsNullOrEmpty(obj.Id) || (obj.Id.ToLower() != dt.Rows[0]["ID"].ToString().ToLower()))) Message = "Sorry, You are already Registered.";
                else
                {
                    if (string.IsNullOrEmpty(obj.Isactive)) obj.Isactive = "Active";

                    if (string.IsNullOrEmpty(obj.Id))
                    {
                        obj.Createdby = Session["UserId"].ToString();
                        obj.Createdtime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                        obj.Id = (string)ExecuteDB(HCareTaks.AG_SaveHcUsersInfo, obj);
                        if (!string.IsNullOrEmpty(obj.Id)) Success = true;
                    }
                    else
                    {
                        obj.Updatedby = Session["UserId"].ToString();
                        obj.Updatedtime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                        Success = (bool)ExecuteDB(HCareTaks.AG_UpdateHcUsersInfo, obj);
                    }
                }
            }
            else Message = "Sorry, Validation Error!";

            if (Success) Message = "Process has been done successfully";
            return Json(new { Success = Success, Message = Message, Id = obj.Id });
        }

        public string SelectTypeUser(string ut = "", string sel = "")
        {
            string TableData = "<option>Select...</option>";
            if (ut == "Doctor")
            {
                HcDoctorinfoEntity obj = new HcDoctorinfoEntity();
                DataTable dt = (DataTable)ExecuteDB(HCareTaks.AG_GetAllHcDoctorinfoRecord, obj);
                foreach (DataRow dr in dt.Rows)
                {
                    string selcted = !string.IsNullOrEmpty(sel) && sel.ToLower() == dr["ID"].ToString().ToLower() ? "selcted" : "";
                    string aClass = dr["IsActive"].ToString() == "Active" ? "text-success" : "text-danger";
                    TableData += "<option class='" + aClass + "' value='" + dr["ID"] + "' " + selcted + ">" + dr["Name"] + " (" + dr["DepartmentName"] + ")</option>";
                }
            }
            return TableData;
        }

        public JsonResult SelectedUserInfo(string ut = "", string uid = "")
        {
            string Img = "/Docx/NoImage.jpg", Name = "", Gender = "";
            if (ut == "Doctor" && !string.IsNullOrEmpty(uid))
            {
                HcDoctorinfoEntity obj = (HcDoctorinfoEntity)ExecuteDB(HCareTaks.AG_GetSingleHcDoctorinfoRecordById, uid);
                if (obj != null)
                {
                    Img = obj.Photo;
                    Name = obj.Name;
                    Gender = obj.Gender;
                }
            }
            return Json(new { Img = Img, Name = Name, Gender = Gender });
        }
        #endregion


        #region Services
        public ActionResult ServiceList(string Id)
        {
            string eMsg = SiteMainMenuList("Service List", "Settings", "ServiceList");
            if (!string.IsNullOrEmpty(eMsg)) return RedirectToOut(eMsg);
            //else if (!SiteUserAccess("", "V")) return RedirectToOut();

            ViewBag.TableData = ServiceListTableData();
            return View();
        }

        string ServiceListTableData()
        {
            string TableData = "";
            HcServicesEntity obj = new HcServicesEntity();
            obj.Sortby = "yes";
            DataTable dt = (DataTable)ExecuteDB(HCareTaks.AG_GetAllHcServicesRecord, obj);
            foreach (DataRow dr in dt.Rows)
            {
                string Action = "<i class='mdi mdi-table-edit iAction' title='Edit This' onclick=\"EditDetails('" + dr["ID"].ToString() + "')\" style='color:orange'></i>";
                Action += "<i class='mdi mdi-close-box iAction' title='Inactive This' onclick=\"DeleteDetails('" + dr["ID"].ToString() + "', this)\" style='color:red'></i>";
                TableData +=
                    "<tr>" +
                    "<td>" + dr["SortBy"] + "</td>" +
                    "<td>" + dr["Name"] + "</td>" +
                    "<td>" + dr["Description"] + "</td>" +
                    "<td class='IsActive'>" + dr["IsActive"] + "</td>" +
                    "<td>" + Action + "</td>" +
                    "</tr>";
            }

            string CreateBtn = "<button class='btn btn-primary' type='button' onclick='CreateDetails()'  style='margin-bottom:10px;'> New</button>";
            string tHead =
                "<tr>" +
                    "<th>SortBy</th>" +
                    "<th>Name</th>" +
                    "<th width='50%'>Description</th>" +
                    "<th>IsActive</th>" +
                    "<th>Action</th>" +
                "</tr>";
            TableData = CreateBtn + "<div class='table-responsive'><table id='zero_config' class='table table-striped table-bordered'>" +
                "<thead>" + tHead + "</thead><tbody>" + TableData + "</tbody></table></div>";

            return TableData;
        }

        public JsonResult ServiceDeleteById(string Id)
        {
            bool Success = false;
            HcServicesEntity obj = (HcServicesEntity)ExecuteDB(HCareTaks.AG_GetSingleHcServicesRecordById, Id);
            if (obj != null)
            {
                obj.Updatedby = Session["UserId"].ToString();
                obj.Updatedtime = DateTime.Now.ToString("dd/MM/yyyy");
                obj.Isactive = "Inactive";
                Success = (bool)ExecuteDB(HCareTaks.AG_UpdateHcServicesInfo, obj);
            }
            string Message = Success ? "Delete Success" : "Sorry something went wrong!";
            return Json(new { Success = Success, Message = Message });
        }

        public ActionResult ServiceCreate(string Id)
        {
            string eMsg = SiteMainMenuList("Service Details", "Settings", "ServiceList");
            if (!string.IsNullOrEmpty(eMsg)) return RedirectToOut(eMsg);
            //else if (!SiteUserAccess("", "V")) return RedirectToOut();

            ViewBag.TypeList = List_ServiceType();
            HcServicesEntity obj = new HcServicesEntity();
            obj.Icon = "fa fa-gg";
            if (!string.IsNullOrEmpty(Id))
            {
                obj = (HcServicesEntity)ExecuteDB(HCareTaks.AG_GetSingleHcServicesRecordById, Id);
                if (obj == null) obj = new HcServicesEntity();
            }

            return View(obj);
        }

        [HttpPost]
        public JsonResult ServiceSaveUpdate(HcServicesEntity obj)
        {
            bool Success = false;
            if (string.IsNullOrEmpty(obj.Isactive)) obj.Isactive = "Active";
            if (string.IsNullOrEmpty(obj.Id))
            {
                obj.Createdby = Session["UserId"].ToString();
                obj.Createdtime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                obj.Id = (string)ExecuteDB(HCareTaks.AG_SaveHcServicesInfo, obj);
                if (!string.IsNullOrEmpty(obj.Id)) Success = true;
            }
            else
            {
                obj.Updatedby = Session["UserId"].ToString();
                obj.Updatedtime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                Success = (bool)ExecuteDB(HCareTaks.AG_UpdateHcServicesInfo, obj);
            }
            string Message = Success ? "Process has been done successfully" : "Sorry something went wrong!";
            return Json(new { Success = Success, Message = Message, Id = obj.Id });
        }
        #endregion


        #region Doctor
        public ActionResult DoctorList(string Id)
        {
            string eMsg = SiteMainMenuList("Doctor List", "Settings", "DoctorList");
            if (!string.IsNullOrEmpty(eMsg)) return RedirectToOut(eMsg);
            //else if (!SiteUserAccess("", "V")) return RedirectToOut();

            ViewBag.TableData = DoctorListTableData();
            return View();
        }

        string DoctorListTableData()
        {
            string TableData = "";
            HcDoctorinfoEntity obj = new HcDoctorinfoEntity();
            obj.Sortby = "yes";
            DataTable dt = (DataTable)ExecuteDB(HCareTaks.AG_GetAllHcDoctorinfoRecord, obj);
            int Count = 1;
            foreach (DataRow dr in dt.Rows)
            {
                string Action = "<i class='mdi mdi-table-edit iAction' title='Edit This' onclick=\"EditDetails('" + dr["ID"].ToString() + "')\" style='color:orange'></i>";
                Action += "<i class='mdi mdi-close-box iAction' title='Inactive This' onclick=\"DeleteDetails('" + dr["ID"].ToString() + "', this)\" style='color:red'></i>";
                TableData +=
                    "<tr>" +
                    "<td><i class='mdi mdi-format-float-left iAction' title='Schedules' onclick=\"ScheduleDetails('" + dr["Id"].ToString() + "')\" style='color:green'></i></td>" +
                    "<td>" + dr["SortBy"] + "</td>" +
                    "<td>" + dr["Name"] + "</td>" +
                    "<td>" + dr["DepartmentName"] + "</td>" +
                    "<td>" + dr["Specialist"] + "</td>" +
                    "<td>" + dr["Gender"] + "</td>" +
                    "<td>" + dr["Fees"] + "</td>" +
                    "<td class='IsActive'>" + dr["IsActive"] + "</td>" +
                    "<td>" + Action + "</td>" +
                    "</tr>";
                Count += 1;
            }

            string CreateBtn = "<button class='btn btn-primary' type='button' onclick='CreateDetails()'  style='margin-bottom:10px;'> New</button>";
            string tHead =
                "<tr>" +
                    "<th>SortBy</th>" +
                    "<th>Name</th>" +
                    "<th>Department</th>" +
                    "<th width='20%'>Specialist</th>" +
                    "<th>Gender</th>" +
                    "<th>Fees</th>" +
                    "<th>IsActive</th>" +
                    "<th>Action</th>" +
                "</tr>";
            TableData = CreateBtn + "<div class='table-responsive'><table id='zero_config' class='table table-striped table-bordered'>" +
                "<thead>" + tHead + "</thead><tbody>" + TableData + "</tbody></table></div>";

            return TableData;
        }

        public JsonResult DoctorDeleteById(string Id)
        {
            bool Success = false;
            HcDoctorinfoEntity obj = (HcDoctorinfoEntity)ExecuteDB(HCareTaks.AG_GetSingleHcDoctorinfoRecordById, Id);
            if (obj != null)
            {
                obj.Updatedby = Session["UserId"].ToString();
                obj.Updatedtime = DateTime.Now.ToString("dd/MM/yyyy");
                obj.Isactive = "Inactive";
                Success = (bool)ExecuteDB(HCareTaks.AG_UpdateHcDoctorinfoInfo, obj);
            }
            string Message = Success ? "Delete Success" : "Sorry something went wrong!";
            return Json(new { Success = Success, Message = Message });
        }

        public ActionResult DoctorCreate(string Id)
        {
            string eMsg = SiteMainMenuList("Doctor Details", "Settings", "DoctorList");
            if (!string.IsNullOrEmpty(eMsg)) return RedirectToOut(eMsg);
            //else if (!SiteUserAccess("", "V")) return RedirectToOut();

            ViewBag.DepartmentList = List_Department();
            ViewBag.GenderList = List_Gender();
            ViewBag.FilePath = "/Docx/NoImage.jpg";

            HcDoctorinfoEntity obj = new HcDoctorinfoEntity();
            obj.Gender = "Male";
            if (!string.IsNullOrEmpty(Id))
            {
                obj = (HcDoctorinfoEntity)ExecuteDB(HCareTaks.AG_GetSingleHcDoctorinfoRecordById, Id);
                if (obj == null) obj = new HcDoctorinfoEntity();
                else if (!string.IsNullOrEmpty(obj.Photo)) ViewBag.FilePath = obj.Photo;
            }

            return View(obj);
        }

        [HttpPost]
        public JsonResult DoctorSaveUpdate(HcDoctorinfoEntity obj)
        {
            bool Success = false;
            if (string.IsNullOrEmpty(obj.Isactive)) obj.Isactive = "Active";
            if (string.IsNullOrEmpty(obj.Experience)) obj.Experience = "0";
            if (string.IsNullOrEmpty(obj.Fees)) obj.Fees = "0";

            if (string.IsNullOrEmpty(obj.Id))
            {
                obj.Createdby = Session["UserId"].ToString();
                obj.Createdtime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                obj.Id = (string)ExecuteDB(HCareTaks.AG_SaveHcDoctorinfoInfo, obj);
                if (!string.IsNullOrEmpty(obj.Id)) Success = true;
            }
            else
            {
                obj.Updatedby = Session["UserId"].ToString();
                obj.Updatedtime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                Success = (bool)ExecuteDB(HCareTaks.AG_UpdateHcDoctorinfoInfo, obj);
            }
            string Message = Success ? "Process has been done successfully" : "Sorry something went wrong!";
            return Json(new { Success = Success, Message = Message, Id = obj.Id });
        }
        #endregion


        #region DoctorsDepartment
        public ActionResult DoctorsDepartmentList(string Id)
        {
            string eMsg = SiteMainMenuList("Doctors Department List", "Settings", "DoctorsDepartmentList");
            if (!string.IsNullOrEmpty(eMsg)) return RedirectToOut(eMsg);
            //else if (!SiteUserAccess("", "V")) return RedirectToOut();

            ViewBag.TableData = DoctorsDepartmentListTableData();
            return View();
        }

        string DoctorsDepartmentListTableData()
        {
            string TableData = "";
            HcDoctorDepartmentsEntity obj = new HcDoctorDepartmentsEntity();
            DataTable dt = (DataTable)ExecuteDB(HCareTaks.AG_GetAllHcDoctorDepartmentsRecord, obj);
            int Count = 1;
            foreach (DataRow dr in dt.Rows)
            {
                string Action = "<i class='mdi mdi-table-edit iAction' title='Edit This' onclick=\"EditDetails('" + dr["Id"].ToString() + "')\" style='color:orange'></i>";
                    Action += "<i class='mdi mdi-close-box iAction' title='Inactive This' onclick=\"DeleteDetails('" + dr["Id"].ToString() + "', this)\" style='color:red'></i>";
                TableData +=
                    "<tr>" +
                    "<td>" + Count + "</td>" +
                    "<td>" + dr["Name"] + "</td>" +
                    "<td>" + dr["About"] + "</td>" +
                    "<td class='IsActive'>" + dr["IsActive"] + "</td>" +
                    "<td>" + Action + "</td>" +
                    "</tr>";
                Count += 1;
            }

            string CreateBtn = "<button class='btn btn-primary' type='button' onclick='CreateDetails()'  style='margin-bottom:10px;'> New</button>";
            string tHead =
                "<tr>" +
                    "<th>Sort</th>" +
                    "<th>Name</th>" +
                    "<th>About</th>" +
                    "<th>IsActive</th>" +
                    "<th>Action</th>" +
                "</tr>";
            TableData = CreateBtn + "<div class='table-responsive'><table id='zero_config' class='table table-striped table-bordered'>" +
                "<thead>" + tHead + "</thead><tbody>" + TableData + "</tbody></table></div>";

            return TableData;
        }

        public JsonResult DoctorsDepartmentDeleteById(string Id)
        {
            bool Success = false;
            HcDoctorDepartmentsEntity obj = (HcDoctorDepartmentsEntity)ExecuteDB(HCareTaks.AG_GetSingleHcDoctorDepartmentsRecordById, Id);
            if (obj != null)
            {
                obj.Updatedby = Session["UserId"].ToString();
                obj.Updatedtime = DateTime.Now.ToString("dd/MM/yyyy");
                obj.Isactive = "Inactive";
                Success = (bool)ExecuteDB(HCareTaks.AG_UpdateHcDoctorDepartmentsInfo, obj);
            }
            string Message = Success ? "Delete Success" : "Sorry something went wrong!";
            return Json(new { Success = Success, Message = Message });
        }

        public ActionResult DoctorsDepartmentCreate(string Id)
        {
            string eMsg = SiteMainMenuList("Doctors Department Details", "Settings", "DoctorsDepartmentList");
            if (!string.IsNullOrEmpty(eMsg)) return RedirectToOut(eMsg);
            //else if (!SiteUserAccess("", "V")) return RedirectToOut();

            HcDoctorDepartmentsEntity obj = new HcDoctorDepartmentsEntity();
            if (!string.IsNullOrEmpty(Id)) obj = (HcDoctorDepartmentsEntity)ExecuteDB(HCareTaks.AG_GetSingleHcDoctorDepartmentsRecordById, Id);

            return View(obj);
        }

        [HttpPost]
        public JsonResult DoctorsDepartmentSaveUpdate(HcDoctorDepartmentsEntity obj)
        {
            bool Success = false;
            if (string.IsNullOrEmpty(obj.Isactive)) obj.Isactive = "Active";
            if (string.IsNullOrEmpty(obj.Id))
            {
                obj.Createdby = Session["UserId"].ToString();
                obj.Createdtime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                obj.Id = (string)ExecuteDB(HCareTaks.AG_SaveHcDoctorDepartmentsInfo, obj);
                if (!string.IsNullOrEmpty(obj.Id)) Success = true;
            }
            else
            {
                obj.Updatedby = Session["UserId"].ToString();
                obj.Updatedtime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                Success = (bool)ExecuteDB(HCareTaks.AG_UpdateHcDoctorDepartmentsInfo, obj);
            }

            string Message = Success ? "Process has been done successfully" : "Sorry something went wrong!";
            return Json(new { Success = Success, Message = Message, Id = obj.Id });

        }
        #endregion


        #region DoctorsSchedule
        public ActionResult DoctorsScheduleList(string Id)
        {
            string eMsg = SiteMainMenuList("Doctor Schedule List", "Settings", "DoctorList");
            if (!string.IsNullOrEmpty(eMsg)) return RedirectToOut(eMsg);
            //else if (!SiteUserAccess("", "V")) return RedirectToOut();

            ViewBag.TableData = DoctorsScheduleListTableData(Id);
            ViewBag.DocId = Id;

            return View();
        }

        string DoctorsScheduleListTableData(string DocId)
        {
            string TableData = "";
            HcDoctorTimesEntity obj = new HcDoctorTimesEntity();
            obj.Doctorid = DocId;
            DataTable dt = (DataTable)ExecuteDB(HCareTaks.AG_GetAllHcDoctorTimesRecord, obj);
            int Count = 1;
            foreach (DataRow dr in dt.Rows)
            {
                string Action = "<i class='mdi mdi-table-edit iAction' title='Edit This' onclick=\"EditDetails('" + dr["Id"].ToString() + "')\" style='color:orange'></i>";
                    Action += "<i class='mdi mdi-close-box iAction' title='Inactive This' onclick=\"DeleteDetails('" + dr["Id"].ToString() + "', this)\" style='color:red'></i>";
                TableData +=
                    "<tr>" +
                    "<td>" + Count + "</td>" +
                    "<td>" + dr["DoctorName"] + "</td>" +
                    "<td>" + dr["Days"] + "</td>" +
                    "<td>" + dr["Times"] + "</td>" +
                    "<td class='IsActive'>" + dr["IsActive"] + "</td>" +
                    "<td>" + Action + "</td>" +
                    "</tr>";
                Count += 1;
            }

            string CreateBtn = "<button class='btn btn-primary' type='button' onclick='CreateDetails()'  style='margin-bottom:10px;'> New</button>";
            string tHead =
                "<tr>" +
                    "<th>Sort</th>" +
                    "<th>DoctorName</th>" +
                    "<th>Days</th>" +
                    "<th>Times</th>" +
                    "<th>IsActive</th>" +
                    "<th>Action</th>" +
                "</tr>";
            TableData = CreateBtn + "<div class='table-responsive'><table id='zero_config' class='table table-striped table-bordered'>" +
                "<thead>" + tHead + "</thead><tbody>" + TableData + "</tbody></table></div>";

            return TableData;
        }

        public JsonResult DoctorsScheduleDeleteById(string Id)
        {
            bool Success = false;
            HcDoctorTimesEntity obj = (HcDoctorTimesEntity)ExecuteDB(HCareTaks.AG_GetSingleHcDoctorTimesRecordById, Id);
            if (obj != null)
            {
                obj.Updatedby = Session["UserId"].ToString();
                obj.Updatedtime = DateTime.Now.ToString("dd/MM/yyyy");
                obj.Isactive = "Inactive";
                Success = (bool)ExecuteDB(HCareTaks.AG_UpdateHcDoctorTimesInfo, obj);
            }
            string Message = Success ? "Delete Success" : "Sorry something went wrong!";
            return Json(new { Success = Success, Message = Message });
        }

        public ActionResult DoctorsScheduleCreate(string Id, string Doc)
        {
            string eMsg = SiteMainMenuList("Doctor Schedule Details", "Settings", "DoctorList");
            if (!string.IsNullOrEmpty(eMsg)) return RedirectToOut(eMsg);
            //else if (!SiteUserAccess("", "V")) return RedirectToOut();

            ViewBag.ListDays = List_Days();
            ViewBag.ListDoctor = List_Doctor("","");

            HcDoctorTimesEntity obj = new HcDoctorTimesEntity();
            obj.Doctorid = Doc;
            if (!string.IsNullOrEmpty(Id)) obj = (HcDoctorTimesEntity)ExecuteDB(HCareTaks.AG_GetSingleHcDoctorTimesRecordById, Id);

            return View(obj);
        }

        [HttpPost]
        public JsonResult DoctorsScheduleSaveUpdate(HcDoctorTimesEntity obj)
        {
            bool Success = false;
            if (string.IsNullOrEmpty(obj.Isactive)) obj.Isactive = "Active";
            if (string.IsNullOrEmpty(obj.Id))
            {
                obj.Createdby = Session["UserId"].ToString();
                obj.Createdtime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                obj.Id = (string)ExecuteDB(HCareTaks.AG_SaveHcDoctorTimesInfo, obj);
                if (!string.IsNullOrEmpty(obj.Id)) Success = true;
            }
            else
            {
                obj.Updatedby = Session["UserId"].ToString();
                obj.Updatedtime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                Success = (bool)ExecuteDB(HCareTaks.AG_UpdateHcDoctorTimesInfo, obj);
            }

            string Message = Success ? "Process has been done successfully" : "Sorry something went wrong!";
            return Json(new { Success = Success, Message = Message, Id = obj.Doctorid });

        }
        #endregion
    }
}
