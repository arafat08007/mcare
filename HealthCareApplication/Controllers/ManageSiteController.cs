using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HCare.Models;
using System.Web.Script.Serialization;
using HCare.Structure;
using System.Data;

namespace HealthCareApplication.Controllers
{
    public class ManageSiteController : BaseController
    {
        //
        // GET: /ManageSite/  

        #region Services
        public ActionResult Services()
        {
            string eMsg = SiteMainMenuList("Services List", "ManageSite", "Services");
            if (!string.IsNullOrEmpty(eMsg)) return RedirectToOut(eMsg);
            //else if (!SiteUserAccess("", "V")) return RedirectToOut();

            ViewBag.TableData = ServicesTableData();
            return View();
        }

        string ServicesTableData()
        {
            string TableData = "";
            HcServicesEntity obj = new HcServicesEntity();
            obj.Isactive = "Active";
            obj.Sortby = "yes";
            DataTable dt = (DataTable)ExecuteDB(HCareTaks.AG_GetAllHcServicesRecord, obj);
            foreach (DataRow dr in dt.Rows)
            {
                TableData += "<tr>" +
                "<th><label class='customcheckbox'><input type='checkbox' class='listCheckbox' value='" + dr["ID"] + "' " + dr["Isview"] + " /><span class='checkmark'></span></label></th>" +
                "<td>" + dr["SortBy"] + "</td>" +
                "<td>" + dr["Name"] + "</td>" +
                "<td>" + dr["Description"] + "</td>" +
                "</tr>";
            }
            return TableData;
        }

        [HttpPost]
        public JsonResult ServicesUpdate(HcServicesEntity iGet)
        {
            bool Success = false;
            HcServicesEntity obj = new HcServicesEntity();
            obj.QueryFlag = "EmptyView";
            obj.Viewby = Session["UserId"].ToString();
            obj.Viewtime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            Success = (bool)ExecuteDB(HCareTaks.AG_UpdateHcServicesInfo, obj);

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            List<HcServicesEntity> dGetObj = serializer.Deserialize<List<HcServicesEntity>>(iGet.JsonDetails);
            obj.QueryFlag = "SetView";
            foreach (HcServicesEntity dr in dGetObj)
            {
                obj.Id = dr.Id;
                Success = (bool)ExecuteDB(HCareTaks.AG_UpdateHcServicesInfo, obj);
            }

            string Message = Success ? "Process has been done successfully" : "Sorry something went wrong!";
            return Json(new { Success = Success, Message = Message });

        }
        #endregion


        #region Doctors
        public ActionResult Doctors()
        {
            string eMsg = SiteMainMenuList("Doctors List", "ManageSite", "Doctors");
            if (!string.IsNullOrEmpty(eMsg)) return RedirectToOut(eMsg);
            //else if (!SiteUserAccess("", "V")) return RedirectToOut();

            ViewBag.TableData = DoctorsTableData();
            return View();
        }

        string DoctorsTableData()
        {
            string TableData = "";
            HcDoctorinfoEntity obj = new HcDoctorinfoEntity();
            obj.Isactive = "Active";
            obj.Sortby = "yes";
            DataTable dt = (DataTable)ExecuteDB(HCareTaks.AG_GetAllHcDoctorinfoRecord, obj);
            foreach (DataRow dr in dt.Rows)
            {
                TableData += "<tr>" +
                "<th><label class='customcheckbox'><input type='checkbox' class='listCheckbox' value='" + dr["ID"] + "' " + dr["Isview"] + " /><span class='checkmark'></span></label></th>" +
                "<td>" + dr["SortBy"] + "</td>" +
                "<td>" + dr["Name"] + "</td>" +
                "<td>" + dr["Department"] + "</td>" +
                "<td>" + dr["Specialist"] + "</td>" +
                "<td>" + dr["Gender"] + "</td>" +
                "<td>" + dr["Fees"] + "</td>" +
                "</tr>";
            }
            return TableData;
        }

        [HttpPost]
        public JsonResult DoctorsUpdate(HcDoctorinfoEntity iGet)
        {
            bool Success = false;
            HcDoctorinfoEntity obj = new HcDoctorinfoEntity();
            obj.QueryFlag = "EmptyView";
            obj.Viewby = Session["UserId"].ToString();
            obj.Viewtime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            Success = (bool)ExecuteDB(HCareTaks.AG_UpdateHcDoctorinfoInfo, obj);

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            List<HcDoctorinfoEntity> dGetObj = serializer.Deserialize<List<HcDoctorinfoEntity>>(iGet.JsonDetails);
            obj.QueryFlag = "SetView";
            foreach (HcDoctorinfoEntity dr in dGetObj)
            {
                obj.Id = dr.Id;
                Success = (bool)ExecuteDB(HCareTaks.AG_UpdateHcDoctorinfoInfo, obj);
            }

            string Message = Success ? "Process has been done successfully" : "Sorry something went wrong!";
            return Json(new { Success = Success, Message = Message });

        }
        #endregion

    }
}
