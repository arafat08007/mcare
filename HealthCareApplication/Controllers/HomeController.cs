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
    public class HomeController : BaseController
    {

        #region HomePage
        public ActionResult Index()
        {
            ViewBag.ServicesTab = ServicesData();
            ViewBag.DoctorsTab = getAllDoctor();
            ViewBag.DepartmentTab = getAllDepartment();
            ViewBag.Packages = getAllPackages();
            ViewBag.Blog = getAllBlog();
            ViewBag.Medicine = getAllMedicine();
            return View();
        }

        string ServicesData()
        {
            string TableData = "";
            HcServicesEntity obj = new HcServicesEntity();
            obj.Isactive = "Active";
            obj.Sortby = "yes";
            obj.Isview = "checked";
            DataTable dt = (DataTable)ExecuteDB(HCareTaks.AG_GetAllHcServicesRecord, obj);
            foreach (DataRow dr in dt.Rows)
            {
                TableData += "<div class='col-xs-12 col-sm-6 col-md-4'>" +
                    "<div class='text-center mb-30 p-10'>" +
                        "<i class='" + dr["Icon"] + " text-theme-colored font-30 service-icon'></i>" +
                        "<h3 class='mt-10'>" + dr["Name"] + "</h3> <p>" + dr["Description"] + "</p>" +
                    "</div>" +
                "</div>";
            }
            return TableData;
        }
        #region Consultants/Doctor
        public ActionResult Consultants()        {

            // ViewBag.getCountryData = getCountry();
            HcDoctorinfoEntity obj = new HcDoctorinfoEntity();
            ViewBag.getCountryData = List_Country();
            ViewBag.getSpecialistData = List_Specialist();
            ViewBag.getLocation = List_Location();
            ViewBag.DoctorData = DoctorsData(obj);
            return View();
        }
        [HttpPost]
        public ActionResult Consultants(HcDoctorinfoEntity obj) {
          
            obj.Name = String.Format("{0}", Request.Form["searchtrm"]);
            obj.Department = String.Format("{0}", Request.Form["Specialist"]);
            obj.countryid = String.Format("{0}", Request.Form["Countryname"]);
          
            obj.Gender = String.Format("{0}", Request.Form["genderM"]);// ? String.Format("{0}", Request.Form["genderF"]) :"";

            if (obj.Gender != "Male")
            {
                obj.Gender = String.Format("{0}", Request.Form["genderF"]);//
            }
            else {
                obj.Gender = "";
            }
            obj.Experience = String.Format("{0}", Request.Form["expfeild"]);
            if (!string.IsNullOrEmpty(obj.Name))
            {
                obj.Searchflag = "Yes";
            }

            ViewBag.getCountryData = List_Country();
            ViewBag.getSpecialistData = List_Specialist();
            ViewBag.getLocation = List_Location();
            ViewBag.DoctorData = DoctorsData(obj);

            return View();
        }
        string DoctorsData(HcDoctorinfoEntity mobj)
        {
            string TableData = "";
            HcDoctorinfoEntity obj = new HcDoctorinfoEntity();
            obj.Isactive = "Active";
            obj.Sortby = "yes";
            obj.Isview = "checked";
            //new params
            if (mobj.Searchflag != "Yes")
            {

                obj.Department = mobj.Department;
                obj.countryid = mobj.countryid;
                obj.Location = mobj.locationid;
                obj.Experience = mobj.Experience;
                obj.Gender = mobj.Gender;
            }
            else
            {
                obj.Name = mobj.Name;
                obj.Searchflag = mobj.Searchflag;
            }


            DataTable dt = (DataTable)ExecuteDB(HCareTaks.AG_GetAllHcDoctorinfoRecord, obj);
            if (dt.Rows.Count > 1)
            {
                foreach (DataRow dr in dt.Rows)
            {

                TableData += @"<div class=' col-md-3 col-lg-3 col-xl-4 doctor-card'>" +
                        "<a class='' href = '/Home/TheDoctor/" + dr["ID"] + "' >" +
                            "<div class='team-thumb'>" +
                            "<img class='img-fullwidth boxImg img-fluid' alt='' src='" + dr["Photo"] + "'>" +
                            "<div class='team-overlay'></div>" +
                            "</div>" +
                            "<div class='card-body'>" +
                            "<h4 class='text-uppercase font-weight-600 m-5'>" + dr["Name"] + "</h4>" +
                            "<h6 class='text-theme-colored font-weight-400 mt-0'>" + dr["DepartmentName"] + "</h6> </hr>" +
                            "<h6 class='text-theme-colored  font-weight-400 mt-0'>" + dr["Specialist"] + "</h6>" +
                            "<h6 class='text-theme-colored  font-weight-400 mt-0'>" + dr["education"] + "</h6>" +
                            "<h6 class='text-theme-colored  font-weight-400 mt-0'>" + "Total year of experince: <span class='label label-info'> " + dr["Experience"] + " </span> Years </h6>" +
                           
                            "</div>" +
                        "</a>" +
                    "</div>";
                }
            }
            else {
                TableData += @"<div class='col-md-12 col-lg-12>" +
                        "<div class='alert alert-warning' role='alert'>"+
                        "No match found, Please search again."+
                        "</div>"+
                    "</div>";
            }
            return TableData;
        }
        string getAllDoctor() {
            string DoctorsData = "";
            HcDoctorinfoEntity obj = new HcDoctorinfoEntity();
            obj.Isactive = "Active";
            obj.Sortby = "yes";
            obj.Isview = "checked";
            DataTable dt = (DataTable)ExecuteDB(HCareTaks.AG_GetAllHcDoctorinfoRecord, obj);
            foreach (DataRow dr in dt.Rows)
            {


                DoctorsData += @"<div class='card border-bottom-theme-color-2px maxwidth400' >" +
                    "<a href = '/Home/TheDoctor/" + dr["ID"] + "'>" +
                                "<img class='img-fullwidth boxImg img-fluid' alt='' src='" + dr["Photo"] + "'>" +
                        "<div class='team-overlay'></div>" +
                                "<div class='card-body'>" +
                                    "<h4 class='card-title'>"+ dr["Name"] +"</h4>" +
                                    "<h6 class='card-text'>" + dr["DepartmentName"] + "</h6>" +
                                    "<h6 class='text-theme-colored  font-weight-400 mt-0'>" + dr["Specialist"] + "</h6>" +
                                     "<h6 class='text-theme-colored  font-weight-400 mt-0'>" + dr["education"] + "</h6>" +
                        "<h6 class='text-theme-colored  font-weight-400 mt-0'>" + "Total year of experince:  <span class='label label-info'>" + dr["Experience"] + " </span> &nbsp; Years </h6>" +
                                  
                                    
                            "</div> </a></div>";
            }

            return DoctorsData;
        }
        string getSingleDoctorsData(string id)
        {
            string TableData = "";
            HcDoctorinfoEntity obj = new HcDoctorinfoEntity();
            obj.Isactive = "Active";
            obj.Sortby = "yes";
            obj.Isview = "checked";
            obj.Id = id;

            DataTable dt = (DataTable)ExecuteDB(HCareTaks.AG_GetAllHcDoctorinfoRecord, obj);
            foreach (DataRow dr in dt.Rows)
            {
                TableData += @"<div class='row'>" +
                    "<div class='col-md-3 col-lg-3'>"+
                     "<img class='img boxImg img-fluid' alt='' src='" + dr["Photo"] + "'>" +
                    "</div>" +
                    "<div class='col-md-3 col-lg-6'>" +
                        "<h3 class='card-title'>" + dr["Name"] + "&nbsp; &nbsp; <Span>" + "<img class='img img-fluid' src='" + dr["CFlag"] + "' alt='" + dr["Countryname"] + "'/>" + "</Span></h3>" +
                        "<h5 class='card-text'>" + dr["DepartmentName"] + "</h5>" +
                        "<h6 class='text-theme-colored  font-weight-400 mt-0'>" + dr["Specialist"] + "</h6>" +
                        "<h6 class='text-theme-colored  font-weight-400 mt-0'>" + dr["education"] + "</h6>" +
                        "<p class='text-theme-colored  font-weight-400 mt-0'>" + "Total year of experince:  <span class='label label-info'> " + dr["Experience"] + " </span> &nbsp; Years </h6> <hr/>" +
                        
                        "<h5 class='font-weight-400 mt-0'> Can speak: " + dr["language"] + "</h5>" +

                    "</div>" +
                  /*  "<div class='col-md-3 col-lg-3 d-flex'>" +
                    "<a href = '#' class='btn btn-lg btn-danger  btn-block'>Get appoinment</a>" +
                    "<div class='btn-group'>" +
                      "<a  class='btn btn-secondary' href='callto:+8801713060063' >"+" <i class='fa fa-phone'> Phone call </i>"+"</a>"+
                       "<a  class='btn btn-secondary' href='mailto:info@abc.com' >" + " <i class='fa fa-envelope-o'> Send email </i>" + "</a>" +
                    "</div>" +

                    "</div>" +*/

                "</div> <br/>";
                TableData = TableData + @"<div class='row'>" +
                    "<h4> About " + dr["Name"] + "</h4>" +
                    "<p>"+ dr["About"] + "</p>"+
                    "</div>";
                TableData = TableData + @"<div class='row'>" +
                   "<h4> Hospitals Associated with </h4>" +
                   "<p>" + dr["Organizationname"] + "</p>" +
                   "</div>";
            }
            return TableData;
        }
        #endregion

        string getDoctorTime(string id)
        {
            string TimeTable = "";
            TimeTable = TimeTable+ @"<div class='table-responsive'> " +
                   "<table class='table'>" +
                       "<thead>" +
                           "<tr>" +
                           "<th scope = 'col'>#</th>" +
                           "<th scope = 'col'> Days </ th >" +
                            "<th scope = 'col'> Time </ th >" +
                           "</tr>" +
                       " </thead > <tbody>";

            HcDoctorTimesEntity obj = new HcDoctorTimesEntity();
            obj.Doctorid = id;
            DataTable dt = (DataTable)ExecuteDB(HCareTaks.AG_GetAllHcDoctorTimesRecord, obj);
            int rowcount = 0;
            foreach (DataRow dr in dt.Rows) {
                rowcount++;

                TimeTable = TimeTable+ @"<tr>" +
                            "<td>" + rowcount + "</th>" +
                            "<td> " + dr["Days"] + "</th>" +
                             "<td> " + dr["Times"] + "</th>" +
                            "</tr>";
                        
                     


            }
            TimeTable = TimeTable + " </tbody></table> </div>";

            return TimeTable;
        }   
                
        string getDoctors(string id)
        {
            string singleDoctorData = "";
            HcDoctorinfoEntity obj = new HcDoctorinfoEntity();
            obj.Isactive = "Active";
            obj.Department = id;
            DataTable dt = (DataTable)ExecuteDB(HCareTaks.AG_GetAllHcDoctorinfoRecord, obj);
            singleDoctorData += @"<div class='card flex-row flex-wrap'>" + "<h5>"+ dt.Rows.Count + "<small> Counsultant found near you. </small>"+"</h5>" + "</div>";
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {

                    singleDoctorData += @"<div class='card custome-card '>" +
                                            "<a href='/Home/TheDoctor/" + dr["ID"] + "' >" +
                                            "<div class='card-header border-0'>"+ 
                                                "<div class='row'>" +
			                                        " <div class ='col-md-6 col-lg-6'><img  class='img img-fluid card-img pull-left' src='" + dr["Photo"] + "' alt=''> </div>" +
			                                        "<div class ='col-md-6 col-lg-6'><a class='btn btn-success btn-block pull-right' href = '/WebAccount/NewAppointment/" + dr["ID"]+"'>"+"Consult Now"+ "</a> "+
			                                        "</div>"+
		                                        "</div>"+
	                                        "</div>" +
	                                        "<div class='card-body'> <div class='row'>" +
		                                        "<div class='col-md-8 col-lg-8 pull-left'>" +
			                                        "<h4 class='card-title text-colored'>" + dr["Name"] + "</h4>" +
			                                        "<p class='card-text'>" + dr["Specialist"] + "</p>" +
			                                        "<p class='card-text'>" + dr["education"] + "</p>" +
			                                        "<p class='font-weight-400 mt-0'>" + "Total year of experince: <span class='badge badge-pill badge-primary'>" + dr["Experience"] + " Years </span></p> "+
		                                        "</div>" +
		                                        "<div class='col-md-4 col-lg-4 pull-right'>" +
		                                        "<img  src='" + dr["CFlag"] + "' class='img img-fluid' alt='country flag'>" +
		                                        "<p class='card-text'> <small>" + dr["Countryname"] + "</small></p>" +
		                                        "<p class='card-text'> Fees: <strong> " + dr["fees"] + "</strong></p>" +
		                                        "<p class='card-text'>  Rating: <strong>" + dr["DoctroRating"] + "/5</strong></p>" +
		                                        "</div>" +
		                                        "</div>"+
	                                        "</div>" +

	                                        "<div class='card-footer w-100 text-muted'>" +
		                                        "<p class='card-text'> <strong> Speak: " + dr["language"] + "</strong></p>" +
	                                        "</div> "+
	                                        "</a>" +
                                        "</div>";



                }
            }
            else {
                singleDoctorData += @"<div class='card flex-row flex-wrap'>" +"<h4> No consultant found! </h4>"+ "</div>";


            }

            return singleDoctorData;

        }
        //single doctor view
        public ActionResult TheDoctor(string id)
        {
          

            ViewBag.DoctorData = getSingleDoctorsData(id);
            ViewBag.DoctorTime = getDoctorTime(id);

            return View();
        }

        #endregion
        #region Department

        public ActionResult Department(string ID) {
            string deptId = ID;
            ViewBag.DepartmentTab = getminmalDepartment();
            ViewBag.DepartmentDetails = getSingleDept(deptId);
            ViewBag.DoctorList = getDoctors(deptId);


            return View();
        }
        string getAllDepartment()
        {
            HcDoctorDepartmentsEntity obj = new HcDoctorDepartmentsEntity();
            string DepartmentData = "";
            string noImage = "/Docx/no_image.png";
            obj.Isactive = "Active";

            DataTable dt = (DataTable)ExecuteDB(HCareTaks.AG_GetAllHcDoctorDepartmentsRecord, obj);
            foreach (DataRow dr in dt.Rows)
            {
                string deptimg = string.IsNullOrEmpty(dr["dept_image"].ToString()) ? noImage : dr["dept_image"].ToString();

                DepartmentData += @"<div class='card border-bottom-theme-color-2px maxwidth400' >" +
                                "<img class='img-fullwidth boxImg img-fluid' alt='' src='" + deptimg + "'>" +
                        "<div class='team-overlay'></div>" +
                                "<div class='card-body'>" +
                                    "<h4 class='card-title'>" + dr["Name"] + "</h4>" +
                                    "<p class='card-text'>" + dr["About"] + "</p>" +

                                    "<a href = '/Home/Department/" + dr["ID"] + "' class='btn btn-sm btn-outline-success btn-block'>Find Consultant</a>" +
                            "</div></div>";
            }



            return DepartmentData;
        }

        string getminmalDepartment()
        {
            HcDoctorDepartmentsEntity obj = new HcDoctorDepartmentsEntity();
            string DepartmentData = "";
            string noImage = "/Docx/no_image.png";
            obj.Isactive = "Active";

            DataTable dt = (DataTable)ExecuteDB(HCareTaks.AG_GetAllHcDoctorDepartmentsRecord, obj);
            foreach (DataRow dr in dt.Rows)
            {
                string deptimg = string.IsNullOrEmpty(dr["dept_image"].ToString()) ? noImage : dr["dept_image"].ToString();

                DepartmentData += @"<div class='card' > <a href='/Home/Department/" + dr["ID"] + " '>" +
                                "<img class='img-fluid' alt='' src='" + deptimg + "'>" +
                        "<div class='team-overlay'></div>" +
                                "<div class='card-body'>" +
                                    "<h6 class='card-title'>" + dr["Name"] + "</h6>" +
                                    "<p class='card-text text-mute'> <small>" + dr["About"] + " </small></p>" +

                            "</div> </a></div>";
            }



            return DepartmentData;
        }
        string getSingleDept(string id)
        {
            string singleDeptData = "";
            HcDoctorDepartmentsEntity obj = new HcDoctorDepartmentsEntity();
            obj.Isactive = "Active";
            obj.Id = id;
            DataTable dt = (DataTable)ExecuteDB(HCareTaks.AG_GetAllHcDoctorDepartmentsRecord, obj);
            foreach (DataRow dr in dt.Rows)
            {
                singleDeptData += @"<h6 class='card-title'>" + dr["Name"] + "</h6>" +
            "<p class='card-text text-mute'> <small>" + dr["About"] + " </small></p>" +
            "<p class='card-text text-mute'> <small>" + dr["full_desc"] + " </small></p>";

            }


            return singleDeptData;

        }
        #endregion

        #region Packages 

        string getAllPackages()
        {


            string packageData = "";
            HcPackagemasterEntity pmObj = new HcPackagemasterEntity();
            HcPackagedetailsEntity pdObj = new HcPackagedetailsEntity();
            pmObj.Isactive = "1";
            DataTable dt = (DataTable)ExecuteDB(HCareTaks.AG_GetAllHcPackagemasterRecord, pmObj);
            if(dt.Rows.Count >0)
                foreach(DataRow dpm in dt.Rows){
                    packageData += @"<div class='card custome-card' style='background-image: url(" + dpm["packageImage"] + ") no-repeat; background-color: #ffffff' >" +
                    "<a href = '/Home/Packages/" + dpm["ID"] + "'>" +
                    "<img class='card-img-top' src=" + dpm["packageImage"] + " alt='Packeage iamge'>" +
                    "<div class='card-body'>" +
                    "<div class='row'>"+
                    "<div class='col-md-8 col-lg-8 '>"+
                     "<h4 class='card-title'>" + dpm["PackageName"] + "</h4>" +
                     "<p class='card-text'>" + dpm["PackageShorDesc"] + "</p>" +
                     "</div>"+

                       "<div class='col-md-4 col-lg-4'>" +
                       
                     "<h3 class='card-title text-center'>" + dpm["PackagePrice"] + " </h3>" +
                    
                     "</div>" +

                     "</div>"+
                    "</div> </a> </div>";


                }



            return packageData;
        }

        #endregion

        #region Blogs
        string getAllBlog() {
            string BlogData = "";

            HcBlogEntity iGet = new HcBlogEntity();
            iGet.Isactive = "1";
            DataTable dt = (DataTable)ExecuteDB(HCareTaks.AG_GetAllHcBlogRecord, iGet);
            if (dt.Rows.Count > 0)
                foreach (DataRow dpm in dt.Rows)
                {
                    BlogData += @"<div class='card custome-card' style='background-color: #ffffff' >" +
                        "<a href = '/Home/Packages/" + dpm["ID"] + "' target='_blank'>" +
                        "<img class='card-img-top' src=" + dpm["BlogImage"] + " alt='Packeage iamge'/>" +
                            "<div class='card-body'>" +
                                "<div class='row'>" +
                                    "<div class='col-md-8 col-lg-8'>" +
                                         "<h4 class='card-title'>" + dpm["BlogTitle"] + "</h4>" +
                                        "<p class='card-text text-truncate'>" + dpm["BlogDetail"] + "</p>" +
                                    "</div>" +

                                    "<div class='col-md-4 col-lg-4'>" +

                                        "<a class='btn btn-link' href =" + dpm["BlogLink"] + " target='_blank'> Source </a> " + 

                                    "</div>" +

                                "</div>" +
                            "</div>"+
                           "</a>"+
                         "</div>";


                }

            return BlogData;
        
        }

        #endregion





        public ActionResult LabTest()
        {
            HcLabTestEntity obj = new HcLabTestEntity();
            
            ViewBag.AllLabTest = getAllLabTest(obj);
            ViewBag.AllTestCategory = List_Labtest();
            return View();
        }

        [HttpPost]

        public ActionResult LabTest(HcLabTestEntity obj)
        {
            HcLabTestEntity pobj = new HcLabTestEntity();
            pobj.Testcategory = String.Format("{0}", Request.Form["Testcategory"]);
            pobj.Testname = String.Format("{0}", Request.Form["labsearch"]);

            ViewBag.AllLabTest = getAllLabTest(pobj);
            ViewBag.AllTestCategory = List_Labtest();
            return View();
        }

        string getAllLabTest(HcLabTestEntity obj)
        {
           string LabTestData = "";
           HcLabTestEntity parms = new HcLabTestEntity();
           parms.Testcategory = obj.Testcategory;
           parms.Testname = obj.Testname;
           parms.Teststatus = "Active";

           DataTable dt = (DataTable)ExecuteDB(HCareTaks.AG_GetAllHcLabTestRecord, parms);
           if (dt.Rows.Count > 1)
           {
               foreach (DataRow dr in dt.Rows)
               {
                   LabTestData += @"<div class='col-md-4 col-lg-4 mb-30'>" +
                             "<div class='card card-doctor'>" +
                                "<img src='/' alt='' />" +
                                "<div class='card-title'>" +
                                   "<h6 class='py-10'>" + dr["testName"] + "</h6>" +
                                   "<p class='py-10'> <span class='badge badge-pill badge-danger'>" + dr["catTestName"] + "</span></p>" +
                                "</div>" +
                                "<div class='card-body'>" +
                                 "<p class='py-10 text-primary font-1'>" + "Something about the test. maybe a breif " + "</p>" +
                                "</div>" +
                              //  addtocart" (66cd831b-066b-40e2-b2db-4b4773954ba3)';'
                                  "<button  onclick='addtocart("+ dr["Id"] +");'  class='btn btn-success btn-sm btn-block'>ADD &nbsp;" + dr["testAmount"] + " $</button>" +
                             "</div>" +
                          "</div>";

               }
           }
           else {
               LabTestData += @"<p class='py-10'> Sorry! No Lab test associate with your search.</p>";
           }
            return LabTestData;
        }
       


        #region Medicine
        public ActionResult Medicine()
        {
            return View();
        }

        string getAllMedicine()
        { 
            string MedicineData ="";
            HcMedicineEntity iGet = new HcMedicineEntity();
            iGet.FullView = true;

            string noImage = "/Docx/no_image.png";
            

            // = "1";
            DataTable dt = (DataTable)ExecuteDB(HCareTaks.AG_GetAllHcMedicineRecord, iGet);
            if (dt.Rows.Count > 0)
                foreach (DataRow dpm in dt.Rows)
                {
                    string medicineimage = string.IsNullOrEmpty(dpm["ImageUrl"].ToString()) ? noImage : dpm["ImageUrl"].ToString();

                    MedicineData += @"<div class='card custome-card' style='background-color: #ffffff' >" +
                        "<a href = '/Home/Medicine/" + dpm["ID"] + "' target='_blank'>" +
                        "<img class='card-img-top' src='" + medicineimage + "' alt='Packeage iamge'/>" +
                            "<div class='card-body'>" +
                                "<div class='row'>" +
                                    "<div class='col-md-12 col-lg-12'>" +
                                     "<h3> &nbsp; $ " + dpm["Medicineprice"] + "</h3>" +
                                         "<h4 class='card-title'>" + dpm["Medicinename"] + "</h4>" +
                                         "<small>" + dpm["UoM"] + "</small>" +
                                        "<p class='card-text text-truncate'>" + dpm["Medicinecompany"] + "</p>" +
                                       
                                         "<p class='card-text text-truncate'>" + dpm["Medicinetypename"] + "</p>" +
                                          "<p class='card-text text-truncate'>" + dpm["categoryName"] + "</p>" +
                                            
                                    "</div>" +

                                 

                                "</div>" +
                            "</div>" +
                           "</a>" +
                         "</div>";


                }


                return MedicineData;
        }

        #endregion


        #region Eshop
        public ActionResult Eshop()
        {
            return View();
        }
        #endregion

    }
}
