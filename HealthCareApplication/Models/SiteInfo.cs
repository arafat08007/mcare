using HCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthCareApplication.Models
{
    public class SiteInfo
    {
        public string LoginUser { get; set; }
        public string LoginPass { get; set; }


        public string MenuId { get; set; }
        public string MenuIcon { get; set; }
        public string MenuName { get; set; }
        public string MenuUrl { get; set; }


        public bool Success { get; set; }
        public string Message { get; set; }
        public string Id { get; set; }
        public string TableData { get; set; }
        public string TabData { get; set; }

        public string Countryname { get; set; }
        public string Specialist { get; set; }
        public string Location { get; set; }
        public string Testcategory { get; set; }

        public SelectListItem SelectListCountry { get; set; }
    }
}