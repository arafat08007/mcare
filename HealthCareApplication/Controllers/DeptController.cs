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
    public class DeptController : BaseController
    {
        public ActionResult Departments()
        {
          
            return View();
        }
    }
}