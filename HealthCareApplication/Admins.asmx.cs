using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using HCare.Models;
using System.Data;
using HCare.Structure;
using System.Web.Script.Serialization;
using System.Net.Mail;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace HealthCareApplication
{


    [WebService(Namespace = "http://172.16.61.221:8059/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public class Admins : System.Web.Services.WebService
    {

        #region Utilities function
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

        //Utility Functions
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
        public string CreateOrderId(string prodId)
        {
            string orderNum = "";

            long n = long.Parse(System.DateTime.Now.ToString("MMddHHmmss"));
            //string prefix = _random.Next(min, max); 

            Random rand = new Random((int)DateTime.Now.Ticks);
            int numIterations = 0;
            numIterations = rand.Next(1, Convert.ToInt32(n));

            //Response.Write(numIterations.ToString());

            return orderNum = numIterations.ToString().Trim();
        }





        #endregion


        #region User contact details


        [WebMethod]
        //  [ScriptMethod(UseHttpGet = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getContactDetails(string userId)
        {
            HcEmergencycontactEntity obj = new HcEmergencycontactEntity();
            obj.Userid = userId;


            DataTable dt = (DataTable)ServerManager.GetTaskManager.Execute(HCareTaks.AG_GetAllHcEmergencycontactRecord, obj);

            HcEmergencycontactEntity iSet = new HcEmergencycontactEntity();



            iSet.Userid = dt.Rows[0]["UserId"].ToString().Trim();
            iSet.postcode = dt.Rows[0]["postalcode"].ToString().Trim();
            iSet.Address = dt.Rows[0]["Address"].ToString().Trim();
            iSet.Createdby = dt.Rows[0]["createdBy"].ToString().Trim();
            iSet.Createdat = dt.Rows[0]["createdAt"].ToString().Trim();
            iSet.Userphone = dt.Rows[0]["userphone"].ToString().Trim();






            List<HcEmergencyContactDetails> EmergencyList = new List<HcEmergencyContactDetails>();


            foreach (DataRow dr in dt.Rows)
            {
                EmergencyList.Add(new HcEmergencyContactDetails
                {
                    Id = dr["ID"].ToString().Trim(),
                    Emergencycontactperson = dr["emergencyContactPerson"].ToString().Trim(),
                    Emergencycontactphone = dr["emergencycontactPhone"].ToString().Trim(),


                });


            }
            iSet.EmergencyList = EmergencyList;

            var json = new JavaScriptSerializer().Serialize(iSet);
            Context.Response.Write(json);
        }

        [WebMethod]
        //[ScriptMethod(UseHttpGet = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void saveToContact(string cartobj)
        {
            bool Success = false;
            String Message = "Contact Saved";
            String ID = null;
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            HcEmergencycontactEntity mInfo = serializer.Deserialize<HcEmergencycontactEntity>(cartobj);

            HcEmergencycontactEntity obj = new HcEmergencycontactEntity();

            if (!String.IsNullOrEmpty(mInfo.Userid))
            {

                // orderId = CreateOrderId(mInfo.Userid);
                obj.Userid = mInfo.Userid;



                try
                {

                    DataTable dt = (DataTable)ServerManager.GetTaskManager.Execute(HCareTaks.AG_GetAllHcEmergencycontactRecord, obj);
                    if (!string.IsNullOrEmpty(dt.Rows[0]["UserId"].ToString().Trim()))
                    {
                        bool isdeleted = (bool)ServerManager.GetTaskManager.Execute(HCareTaks.AG_DeleteHcEmergencycontactInfoById, obj);
                    }
                    obj.postcode = mInfo.postcode;
                    obj.Address = mInfo.Address;
                    obj.Createdby = mInfo.Userid;
                    obj.Createdat = System.DateTime.Now.ToString("dd-MM-yyyy");
                    obj.Userphone = mInfo.Userphone;
                    foreach (HcEmergencyContactDetails dInfo in mInfo.EmergencyList)
                    {


                        //orderId, productId, productQnty, productPrice, orderStatus, orderForUser, orderDate, updateBy, updateAt
                        obj.Emergencycontactperson = dInfo.Emergencycontactperson;
                        obj.Emergencycontactphone = dInfo.Emergencycontactphone;


                        //  productId, productName, productCategoryId, productCategoryName, productImageUrl, productPrice, productQnty, createdBy, createdAt, cartStatus


                        if (!string.IsNullOrEmpty(dInfo.Emergencycontactphone))
                        {

                            ID = (string)ServerManager.GetTaskManager.Execute(HCareTaks.AG_SaveHcEmergencycontactInfo, obj);

                            Success = true;

                        }



                    }

                    var xjson = new { Success = Success, Message = Message, Id = ID };
                    var json = new JavaScriptSerializer().Serialize(xjson);
                    Context.Response.Write(json);


                }
                catch (Exception ex)
                {
                    throw ex;
                }
                //}
            }
        }






        #endregion





        #region User login registration


        [WebMethod]
        //[ScriptMethod(UseHttpGet = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void userRegistraion(string username, string firstname, string lastname, string useremail, string userphone, string userpass, string address, string gender, string dob)
        {
            //( LogName, LogPass, SecurPass, Email, FirstName, LastName, Gender, Address, UserType, UserID, RoleID, IsActive, CreatedBy, CreatedTime )

            bool Success = false;
            string Message = "User created successfully!";
            bool Mail = !string.IsNullOrEmpty(useremail) ? RkIsEmailValid(useremail) : true;

            HcUsersEntity iGet = new HcUsersEntity();
            iGet.Logname = useremail;
            DataTable dt = (DataTable)ServerManager.GetTaskManager.Execute(HCareTaks.AG_GetAllHcUsersRecord, iGet);
            if (dt.Rows.Count == 0)
            {
                ////Success = false;
                //HcUsersEntity[] iArrayObj = new HcUsersEntity[dt.Rows.Count];
                //HcUsersEntity iSet = null;
                int iCount = 0;
                iGet.Logname = useremail;
                iGet.Logpass = userpass;
                iGet.ConfirmPass = userpass;
                iGet.SecurPass = userpass;
                //  iGet.userphone = userphone;
                iGet.Email = useremail;
                iGet.FirstName = firstname;
                iGet.LastName = lastname;
                iGet.Gender = gender;
                iGet.Address = address;
                iGet.Usertype = "Patient";
                iGet.Userid = "";
                iGet.Roleid = "";
                iGet.Isactive = "Active";
                iGet.Createdby = "";
                iGet.Createdtime = System.DateTime.Now.ToString("dd-MM-yyyy");

                iGet.userdob = dob;
                try
                {
                    if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(userpass) && !string.IsNullOrEmpty(firstname) && Mail)
                    {

                        String ID = (string)ServerManager.GetTaskManager.Execute(HCareTaks.AG_SaveHcUsersInfo, iGet);

                        Success = true;
                        var xjson = new { Success = Success, Message = Message, Id = ID };
                        var json = new JavaScriptSerializer().Serialize(xjson);
                        Context.Response.Write(json);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            else
            {
                Success = false;
                Message = "User already exist";
                var yjson = new { Success = Success, Message = Message, };
                var fjson = new JavaScriptSerializer().Serialize(yjson);
                Context.Response.Write(fjson);
            }

        }





        [WebMethod]
        //[ScriptMethod(UseHttpGet = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void allUsers()
        {
            HcUsersEntity obj = new HcUsersEntity();

            DataTable dt = (DataTable)ServerManager.GetTaskManager.Execute(HCareTaks.AG_GetAllHcUsersRecord, obj);

            HcUsersEntity[] iArrayObj = new HcUsersEntity[dt.Rows.Count];
            HcUsersEntity iSet = null;
            int iCount = 0;
            foreach (DataRow dr in dt.Rows)
            {
                iSet = new HcUsersEntity();
                iSet.Id = dr["Id"].ToString();
                iSet.FirstName = dr["FirstName"].ToString();
                iSet.LastName = dr["LastName"].ToString();
                iSet.Usertype = dr["UserType"].ToString();
                iSet.Usertype = dr["UserType"].ToString().Trim();

                iArrayObj[iCount] = iSet;
                iCount += 1;
            }


            var json = new JavaScriptSerializer().Serialize(iArrayObj);
            Context.Response.Write(json);
        }

        [WebMethod]
        //[ScriptMethod(UseHttpGet = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void userLogin(string email, string pass)
        {
            HcUsersEntity obj = new HcUsersEntity();
            bool Mail = !string.IsNullOrEmpty(email) ? RkIsEmailValid(email) : true;

            if (Mail && !string.IsNullOrEmpty(pass))
            {



                obj.Email = email;
                obj.Logname = email;
                obj.Logpass = pass;
                obj.Isactive = "Active";
                DataTable dt = (DataTable)ServerManager.GetTaskManager.Execute(HCareTaks.AG_GetAllHcUsersRecord, obj);

                HcUsersEntity[] iArrayObj = new HcUsersEntity[dt.Rows.Count];
                HcUsersEntity iSet = null;
                int iCount = 0;
                if (dt.Rows.Count == 1)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        iSet = new HcUsersEntity();
                        iSet.Id = dr["Id"].ToString();
                        iSet.FirstName = dr["FirstName"].ToString();
                        iSet.LastName = dr["LastName"].ToString();
                        iSet.Usertype = dr["UserType"].ToString();
                        iSet.Email = dr["Email"].ToString();
                        iSet.Logpass = dr["Logpass"].ToString();
                        iSet.Usertype = dr["UserType"].ToString().Trim();
                        iSet.userImageUrl = dr["userImageUrl"].ToString().Trim();

                        iArrayObj[iCount] = iSet;
                        iCount += 1;
                    }
                }
                else
                {
                    iArrayObj = new HcUsersEntity[1];

                    iSet = new HcUsersEntity();
                    iSet.Id = "";
                    iSet.FirstName = "";
                    iSet.LastName = "";
                    iSet.Usertype = "";
                    iSet.Email = "";
                    iSet.Logpass = "";
                    iSet.Usertype = "";

                    iArrayObj[iCount] = iSet;
                    //var json = new JavaScriptSerializer().Serialize(iArrayObj);
                    // Context.Response.Write(json);
                }
                var json = new JavaScriptSerializer().Serialize(iArrayObj);
                Context.Response.Write(json);




            }
        }

        #endregion


        #region Doctor
        [WebMethod]
        // [ScriptMethod(UseHttpGet = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getAvailibility(string DocId)
        {
            HcDoctorTimesEntity obj = new HcDoctorTimesEntity();
            //obj.GetTimeByDay = true;
            obj.Doctorid = DocId;
            obj.Isactive = "Active";
            DataTable dt = (DataTable)ServerManager.GetTaskManager.Execute(HCareTaks.AG_GetAllHcDoctorTimesRecord, obj);
            //HcDoctorTimesEntity[] iArrayObj = new HcDoctorTimesEntity[dt.Rows.Count];
            List<HcDoctorTimesEntity> iSet = new List<HcDoctorTimesEntity>();
            //int iCount = 0;


            string[] aDays = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
            foreach (string dName in aDays)
            {
                var results = from myRow in dt.AsEnumerable() where myRow.Field<string>("Days") == dName select myRow;
                if (results.Count() > 0)
                {
                    List<HcDoctorTimesEntity> Times = new List<HcDoctorTimesEntity>();
                    foreach (var row in results)
                    {
                        Times.Add(new HcDoctorTimesEntity
                        {
                            Id = row["ID"].ToString(),
                            Times = row["Times"].ToString(),
                        });
                    }
                    iSet.Add(new HcDoctorTimesEntity
                    {
                        Days = dName,
                        TimeList = Times,
                    });
                }
            }

            var json = new JavaScriptSerializer().Serialize(iSet);
            Context.Response.Write(json);
        }


        [WebMethod]
        //  [ScriptMethod(UseHttpGet = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getDoctors(string DocName, string latitude, string longitude, string Gender, string exp, string rating)
        {
            HcDoctorinfoEntity obj = new HcDoctorinfoEntity();
            obj.Sortby = "yes";
            obj.Isactive = "Active";

            obj.Gender = Gender;
            obj.Latitude = latitude;
            obj.Longitude = longitude;
            obj.Experience = exp;
            obj.DoctroRating = rating;
            obj.Name = DocName;

            DataTable dt = (DataTable)ServerManager.GetTaskManager.Execute(HCareTaks.AG_GetAllHcDoctorinfoRecord, obj);
            HcDoctorinfoEntity[] iArrayObj = new HcDoctorinfoEntity[dt.Rows.Count];
            HcDoctorinfoEntity iSet = null;
            int iCount = 0;
            foreach (DataRow dr in dt.Rows)
            {
                iSet = new HcDoctorinfoEntity();
                iSet.Id = dr["Id"].ToString().Trim();
                iSet.Name = dr["Name"].ToString().Trim();
                iSet.Department = dr["DepartmentName"].ToString().Trim();
                iSet.Specialist = dr["Specialist"].ToString().Trim();
                iSet.About = dr["About"].ToString().Trim();
                iSet.Education = dr["Education"].ToString().Trim();
                iSet.Photo = dr["Photo"].ToString().Trim();
                iSet.Fees = dr["Fees"].ToString().Trim();
                iSet.Gender = dr["Gender"].ToString().Trim();
                iSet.Experience = dr["Experience"].ToString().Trim();

                iSet.phone = dr["Phone"].ToString().Trim();
                iSet.Location = dr["Location"].ToString().Trim();
                iSet.Latitude = dr["Latitude"].ToString().Trim();
                iSet.Longitude = dr["Longitude"].ToString().Trim();
                iSet.DoctroRating = dr["DoctroRating"].ToString().Trim();
                iSet.Countryname = dr["Countryname"].ToString().Trim();
                iSet.Organizationname = dr["Organizationname"].ToString().Trim();
                iSet.CFlag = dr["CFlag"].ToString().Trim();
                iSet.logo = dr["logo"].ToString().Trim();
                iSet.language = dr["language"].ToString().Trim();

                iArrayObj[iCount] = iSet;
                iCount += 1;
            }

            var json = new JavaScriptSerializer().Serialize(iArrayObj);
            Context.Response.Write(json);
        }
        #endregion


        #region services
        [WebMethod]
        //  [ScriptMethod(UseHttpGet = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getServices()
        {
            HcServicesEntity obj = new HcServicesEntity();
            obj.Sortby = "yes";
            obj.Isactive = "Active";
            DataTable dt = (DataTable)ServerManager.GetTaskManager.Execute(HCareTaks.AG_GetAllHcServicesRecord, obj);
            HcServicesEntity[] iArrayObj = new HcServicesEntity[dt.Rows.Count];
            HcServicesEntity iSet = null;
            int iCount = 0;
            foreach (DataRow dr in dt.Rows)
            {
                iSet = new HcServicesEntity();
                iSet.Id = dr["Id"].ToString();
                iSet.Name = dr["Name"].ToString();
                iSet.Description = dr["Description"].ToString();
                iArrayObj[iCount] = iSet;
                iCount += 1;
            }

            var json = new JavaScriptSerializer().Serialize(iArrayObj);
            Context.Response.Write(json);
        }
        #endregion

        #region Appointment
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void userAppointment(string Patientuid, string Doctorid, string Dates, string Timeid, string Reasons, string payment)
        {
            //( LogName, LogPass, SecurPass, Email, FirstName, LastName, Gender, Address, UserType, UserID, RoleID, IsActive, CreatedBy, CreatedTime )

            bool Success = false;
            string Message = "Appointment has been created";
            //   bool Mail = !string.IsNullOrEmpty(useremail) ? RkIsEmailValid(useremail) : true;

            HcDoctorAppointmentEntity iGet = new HcDoctorAppointmentEntity();

            //Success = false;
            //  HcDoctorAppointmentEntity[] iArrayObj = new HcDoctorAppointmentEntity[dt.Rows.Count];
            HcDoctorAppointmentEntity iSet = null;
            int iCount = 0;

            iGet.Doctorid = Doctorid;
            iGet.Patientuid = Patientuid;
            iGet.Dates = Dates;
            iGet.Timeid = Timeid;
            iGet.Reasons = Reasons;
            iGet.Paymethod = payment;
            try
            {
                if (!string.IsNullOrEmpty(iGet.Doctorid) && !string.IsNullOrEmpty(iGet.Dates) && !string.IsNullOrEmpty(iGet.Timeid) && !string.IsNullOrEmpty(iGet.Reasons) && !string.IsNullOrEmpty(iGet.Paymethod))
                {
                    iGet.Patientuid = Patientuid;
                    iGet.Createdby = Patientuid.ToString();
                    iGet.Createdtime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                    iGet.Status = "Upcoming";
                    iGet.Dates = iGet.Dates;

                    String ID = (string)ServerManager.GetTaskManager.Execute(HCareTaks.AG_SaveHcDoctorAppointmentInfo, iGet);
                    Success = true;

                    var xjson = new { Success = Success, Message = Message, Id = ID };
                    var json = new JavaScriptSerializer().Serialize(xjson);
                    Context.Response.Write(json);
                }
                else
                {
                    Success = false;
                    Message = "Information missing, please check your inputs";
                    var xjson = new { Success = Success, Message = Message };
                    var json = new JavaScriptSerializer().Serialize(xjson);
                    Context.Response.Write(json);

                }
            }
            catch (Exception ex)
            {
                throw ex;
                Success = false;
                Message = "Oops! Massive Error.";
                var xjson = new { Success = Success, Message = Message };
                var json = new JavaScriptSerializer().Serialize(xjson);
                Context.Response.Write(json);
            }
        }

        [WebMethod]
        //[ScriptMethod(UseHttpGet = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getAppointment(string userId, string userType)
        {

            HcDoctorAppointmentEntity obj = new HcDoctorAppointmentEntity();
            obj.Patientuid = userId;
            obj.QueryFlag = userType;

            DataTable dt = (DataTable)ServerManager.GetTaskManager.Execute(HCareTaks.AG_GetAllHcDoctorAppointmentRecord, obj);



            HcDoctorAppointmentEntity[] iArrayObj = new HcDoctorAppointmentEntity[dt.Rows.Count];
            HcDoctorAppointmentEntity iSet = null;
            int iCount = 0;
            foreach (DataRow dr in dt.Rows)
            {
                iSet = new HcDoctorAppointmentEntity();
                iSet.Id = dr["Id"].ToString();
                iSet.Status = dr["Status"].ToString();
                iSet.Patientuid = dr["PatientUID"].ToString();
                iSet.PatientName = dr["Username"].ToString();
                iSet.Dates = dr["Dates"].ToString();
                iSet.Timeid = dr["TimeID"].ToString();
                iSet.Reasons = dr["Reasons"].ToString();
                iSet.Doctorid = dr["Doctorid"].ToString();
                iSet.doctorName = dr["DoctorName"].ToString();
                iSet.speciality = dr["Specialist"].ToString();
                iSet.doctorDept = dr["DoctorDeptName"].ToString();
                iSet.appointmentTime = dr["Times"].ToString();
                iSet.Gender = dr["Gender"].ToString();
                iSet.Age = dr["Age"].ToString();


                iSet.Createdtime = dr["CreatedTime"].ToString();

                iSet.QueryFlag = userType;


                iArrayObj[iCount] = iSet;
                iCount += 1;
            }


            var json = new JavaScriptSerializer().Serialize(iArrayObj);
            Context.Response.Write(json);
        }

        [WebMethod]
        //[ScriptMethod(UseHttpGet = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getAppointmentDetails(string userId, string Id)
        {

            HcDoctorAppointmentEntity obj = new HcDoctorAppointmentEntity();
            obj.Patientuid = userId;
            obj.Id = Id;


            DataTable dt = (DataTable)ServerManager.GetTaskManager.Execute(HCareTaks.AG_GetAllHcDoctorAppointmentRecord, obj);



            HcDoctorAppointmentEntity[] iArrayObj = new HcDoctorAppointmentEntity[dt.Rows.Count];
            HcDoctorAppointmentEntity iSet = null;
            int iCount = 0;
            foreach (DataRow dr in dt.Rows)
            {
                iSet = new HcDoctorAppointmentEntity();
                iSet.Id = dr["Id"].ToString();
                iSet.Status = dr["Status"].ToString();
                iSet.Patientuid = dr["PatientUID"].ToString();
                iSet.PatientName = dr["Username"].ToString();
                iSet.Dates = dr["Dates"].ToString();
                iSet.Timeid = dr["TimeID"].ToString();
                iSet.Reasons = dr["Reasons"].ToString();
                iSet.Doctorid = dr["Doctorid"].ToString();
                iSet.doctorName = dr["DoctorName"].ToString();
                iSet.speciality = dr["Specialist"].ToString();
                iSet.doctorDept = dr["DoctorDeptName"].ToString();
                iSet.appointmentTime = dr["Times"].ToString();
                iSet.Gender = dr["Gender"].ToString();
                iSet.Age = dr["Age"].ToString();
                iSet.SymptompImage = dr["symtomps_image_path"].ToString();
                iSet.RxImg = dr["prescription_image_path"].ToString();


                iSet.Createdtime = dr["CreatedTime"].ToString();

                iSet.QueryFlag = "Doctor";


                iArrayObj[iCount] = iSet;
                iCount += 1;
            }


            var json = new JavaScriptSerializer().Serialize(iArrayObj);
            Context.Response.Write(json);
        }


        //cancel appointment by user
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void cancelAppointment(string appointmentId, string userid)
        {
            //( LogName, LogPass, SecurPass, Email, FirstName, LastName, Gender, Address, UserType, UserID, RoleID, IsActive, CreatedBy, CreatedTime )

            bool Success = false;
            string Message = "Appointment Canceled";
            //   bool Mail = !string.IsNullOrEmpty(useremail) ? RkIsEmailValid(useremail) : true;         


            try
            {
                if (!string.IsNullOrEmpty(appointmentId))
                {



                    HcDoctorAppointmentEntity obj = (HcDoctorAppointmentEntity)ServerManager.GetTaskManager.Execute(HCareTaks.AG_GetSingleHcDoctorAppointmentRecordById, appointmentId);
                    obj.Id = appointmentId;
                    //obj.Updatedby = !string.IsNullOrEmpty(Uid) ? Uid : null;
                    obj.Updatedby = userid.ToString();
                    obj.Updatedtime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                    obj.Status = "Cancelled";
                    obj.QueryFlag = "Cancelled";
                    Success = (bool)ServerManager.GetTaskManager.Execute(HCareTaks.AG_UpdateHcDoctorAppointmentInfo, obj);



                    var xjson = new { Success = Success, Message = Message };
                    var json = new JavaScriptSerializer().Serialize(xjson);
                    Context.Response.Write(json);
                }
                else
                {
                    Success = false;
                    Message = "Information missing, please check your inputs";
                    var xjson = new { Success = Success, Message = Message };
                    var json = new JavaScriptSerializer().Serialize(xjson);
                    Context.Response.Write(json);

                }
            }
            catch (Exception ex)
            {
                throw ex;
                Success = false;
                Message = "Oops! Massive Error.";
                var xjson = new { Success = Success, Message = Message };
                var json = new JavaScriptSerializer().Serialize(xjson);
                Context.Response.Write(json);
            }
        }



        //update appointment by user
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void updateAppointment(string userid, string appointmentId, string docid, string timeId, string appointmentDate, string reason, string paymenthod)
        {
            //( LogName, LogPass, SecurPass, Email, FirstName, LastName, Gender, Address, UserType, UserID, RoleID, IsActive, CreatedBy, CreatedTime )

            bool Success = false;
            string Message = "Appointment Updated";
            //   bool Mail = !string.IsNullOrEmpty(useremail) ? RkIsEmailValid(useremail) : true;         


            try
            {
                if (!string.IsNullOrEmpty(appointmentId))
                {



                    HcDoctorAppointmentEntity obj = (HcDoctorAppointmentEntity)ServerManager.GetTaskManager.Execute(HCareTaks.AG_GetSingleHcDoctorAppointmentRecordById, appointmentId);
                    obj.Id = appointmentId;
                    obj.Updatedby = !string.IsNullOrEmpty(userid) ? userid : null;
                    obj.Patientuid = userid;
                    obj.Updatedby = userid.ToString();
                    obj.Updatedtime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                    obj.Status = "Active";
                    obj.Doctorid = docid;
                    obj.Dates = appointmentDate;
                    obj.Timeid = timeId;
                    obj.Reasons = reason;
                    obj.Paymethod = paymenthod;

                    // obj.QueryFlag = "Cancelled";
                    Success = (bool)ServerManager.GetTaskManager.Execute(HCareTaks.AG_UpdateHcDoctorAppointmentInfo, obj);



                    var xjson = new { Success = Success, Message = Message };
                    var json = new JavaScriptSerializer().Serialize(xjson);
                    Context.Response.Write(json);
                }
                else
                {
                    Success = false;
                    Message = "Information missing, please check your inputs";
                    var xjson = new { Success = Success, Message = Message };
                    var json = new JavaScriptSerializer().Serialize(xjson);
                    Context.Response.Write(json);

                }
            }
            catch (Exception ex)
            {
                throw ex;
                Success = false;
                Message = "Oops! Massive Error.";
                var xjson = new { Success = Success, Message = Message };
                var json = new JavaScriptSerializer().Serialize(xjson);
                Context.Response.Write(json);
            }
        }

        #endregion


        #region Labtest


        [WebMethod]
        //[ScriptMethod(UseHttpGet = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getLabtestCat()
        {

            HcTestCategoryEntity obj = new HcTestCategoryEntity();
            //obj.Patientuid = userId;

            DataTable dt = (DataTable)ServerManager.GetTaskManager.Execute(HCareTaks.AG_GetAllHcTestCategoryRecord, obj);

            HcTestCategoryEntity[] iArrayObj = new HcTestCategoryEntity[dt.Rows.Count];
            HcTestCategoryEntity iSet = null;
            int iCount = 0;
            foreach (DataRow dr in dt.Rows)
            {

                //SELECT A.Id, A.testId, A.testName, A.testAmount, A.testStatus, A.testCategory, b.[catTestName], A.createBy, A.created_at, A.updateBy, A.updateDate FROM HC_Lab_test A , [HC_Test_category] B WHERE A.testCategory = B.[catId] And A.testStatus='Active'
                iSet = new HcTestCategoryEntity();
                iSet.Id = dr["Id"].ToString().Trim();
                iSet.Catid = dr["catId"].ToString().Trim();
                iSet.Cattesttype = dr["catTestType"].ToString().Trim();
                iSet.Cattestname = dr["catTestName"].ToString().Trim();
               //  iSet.Testcategory = dr["testCategory"].ToString().Trim();
               //iSet.catTestName = dr["catTestName"].ToString().Trim();


                iArrayObj[iCount] = iSet;
                iCount += 1;
            }


            var json = new JavaScriptSerializer().Serialize(iArrayObj);
            Context.Response.Write(json);
        }


        [WebMethod]
        //[ScriptMethod(UseHttpGet = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getLabtestbyCat(string TestCategoryId)
        {

            HcLabTestEntity obj = new HcLabTestEntity();
            // obj.Id = TestCategoryId;
            obj.Testcategory = TestCategoryId;

            //obj.Patientuid = userId;

            DataTable dt = (DataTable)ServerManager.GetTaskManager.Execute(HCareTaks.AG_GetAllHcLabTestRecord, obj);

            HcLabTestEntity[] iArrayObj = new HcLabTestEntity[dt.Rows.Count];
            HcLabTestEntity iSet = null;
            int iCount = 0;
            foreach (DataRow dr in dt.Rows)
            {

                //SELECT A.Id, A.testId, A.testName, A.testAmount, A.testStatus, A.testCategory, b.[catTestName], A.createBy, A.created_at, A.updateBy, A.updateDate FROM HC_Lab_test A , [HC_Test_category] B WHERE A.testCategory = B.[catId] And A.testStatus='Active'
                iSet = new HcLabTestEntity();
                iSet.Id = dr["Id"].ToString().Trim();
                iSet.Testid = dr["testId"].ToString().Trim();
                iSet.Testname = dr["testName"].ToString().Trim();
                iSet.Testamount = dr["testAmount"].ToString().Trim();
                iSet.Testcategory = dr["testCategory"].ToString().Trim();
              //  iSet.catTestName = dr["catTestName"].ToString().Trim();


                iArrayObj[iCount] = iSet;
                iCount += 1;
            }


            var json = new JavaScriptSerializer().Serialize(iArrayObj);
            Context.Response.Write(json);
        }


        [WebMethod]
        //[ScriptMethod(UseHttpGet = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void geAlltLabtest()
        {

            HcLabTestEntity obj = new HcLabTestEntity();
            //obj.Patientuid = userId;

            DataTable dt = (DataTable)ServerManager.GetTaskManager.Execute(HCareTaks.AG_GetAllHcLabTestRecord, obj);

            HcLabTestEntity[] iArrayObj = new HcLabTestEntity[dt.Rows.Count];
            HcLabTestEntity iSet = null;
            int iCount = 0;
            foreach (DataRow dr in dt.Rows)
            {

                //SELECT A.Id, A.testId, A.testName, A.testAmount, A.testStatus, A.testCategory, b.[catTestName], A.createBy, A.created_at, A.updateBy, A.updateDate FROM HC_Lab_test A , [HC_Test_category] B WHERE A.testCategory = B.[catId] And A.testStatus='Active'
                iSet = new HcLabTestEntity();
                iSet.Id = dr["Id"].ToString().Trim();
                iSet.Testid = dr["testId"].ToString().Trim();
                iSet.Testname = dr["testName"].ToString().Trim();
                iSet.Testamount = dr["testAmount"].ToString().Trim();
                iSet.Testcategory = dr["testCategory"].ToString().Trim();
                iSet.catTestName = dr["catTestName"].ToString().Trim();


                iArrayObj[iCount] = iSet;
                iCount += 1;
            }


            var json = new JavaScriptSerializer().Serialize(iArrayObj);
            Context.Response.Write(json);
        }


        [WebMethod]
        //[ScriptMethod(UseHttpGet = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void viewLabtestbyUser(string TestFor)
        {

            HcUserlabtestEntity obj = new HcUserlabtestEntity();
            // obj.Id = TestCategoryId;
            obj.Testfor = TestFor;

            //obj.Patientuid = userId;

            DataTable dt = (DataTable)ServerManager.GetTaskManager.Execute(HCareTaks.AG_GetAllHcUserlabtestRecord, obj);

            HcUserlabtestEntity[] iArrayObj = new HcUserlabtestEntity[dt.Rows.Count];
            HcUserlabtestEntity iSet = null;
            int iCount = 0;
            foreach (DataRow dr in dt.Rows)
            {




                //SELECT A.Id, A.testId, A.testName, A.testAmount, A.testStatus, A.testCategory, b.[catTestName], A.createBy, A.created_at, A.updateBy, A.updateDate FROM HC_Lab_test A , [HC_Test_category] B WHERE A.testCategory = B.[catId] And A.testStatus='Active'
                iSet = new HcUserlabtestEntity();
                iSet.Id = dr["Id"].ToString().Trim();
                iSet.Testid = dr["testId"].ToString().Trim();
              //  iSet.TestName = dr["testName"].ToString().Trim();
                iSet.Testcatid = dr["testCatId"].ToString().Trim();

             //   iSet.CatTestName = dr["catTestName"].ToString().Trim();


                iSet.Testamount = dr["testAmount"].ToString().Trim();
                iSet.Testfor = dr["testFor"].ToString().Trim();
                iSet.Samplecollectdate = dr["sampleCollectDate"].ToString().Trim();
                iSet.Samplecollecttime = dr["sampleCollectTime"].ToString().Trim();
                iSet.Paymenttype = dr["paymentType"].ToString().Trim();
                iSet.Status = dr["status"].ToString().Trim();


                iArrayObj[iCount] = iSet;
                iCount += 1;
            }


            var json = new JavaScriptSerializer().Serialize(iArrayObj);
            Context.Response.Write(json);
        }

        // Save Labtest
        [WebMethod]
        //[ScriptMethod(UseHttpGet = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void userSaveLabTest(string testId, string userid, string testCatId, string testFor, string testAmount, string sampleCollectDate, string sampleCollectTime, string paymentType)
        {
            //( LogName, LogPass, SecurPass, Email, FirstName, LastName, Gender, Address, UserType, UserID, RoleID, IsActive, CreatedBy, CreatedTime )

            bool Success = false;
            string Message = "Lab test request successfully!";
            // bool Mail = !string.IsNullOrEmpty(useremail) ? RkIsEmailValid(useremail) : true;

            //testFor=@testFor and testId =@testId and testCatId =@testCatId and sampleCollectDate=@sampleCollectDate and sampleCollectTime=@sampleCollectTime 

            HcUserlabtestEntity iGet = new HcUserlabtestEntity();
            iGet.Testfor = testFor.ToString().Trim();
            iGet.Testid = testId.ToString().Trim();
            iGet.Testcatid = testCatId.ToString().Trim();
            iGet.Samplecollectdate = sampleCollectDate.ToString().Trim();
            iGet.Samplecollecttime = sampleCollectTime.ToString().Trim();

            DataTable dt = (DataTable)ServerManager.GetTaskManager.Execute(HCareTaks.AG_GetAllHcUserlabtestRecord, iGet);
            if (dt.Rows.Count == 0)
            {
                //Success = false;
                HcUserlabtestEntity[] iArrayObj = new HcUserlabtestEntity[dt.Rows.Count];
                HcUserlabtestEntity iSet = null;


                int iCount = 0;
                //iGet.Id = ""+iCount+1;
                iGet.Testid = testId;
                iGet.Testcatid = testCatId;
                iGet.Createby = userid;
                //  iGet.userphone = userphone;
                iGet.CreatedAt = System.DateTime.Now.ToString("dd-MM-yyyy");
                iGet.Updateby = "";
                iGet.Updatedate = "";
                iGet.Testamount = testAmount;
                iGet.Testfor = testFor;
                iGet.Samplecollectdate = sampleCollectDate;
                iGet.Samplecollecttime = sampleCollectTime;
                iGet.Paymenttype = paymentType;
                iGet.Status = "Pending";
                try
                {
                    if (!string.IsNullOrEmpty(testId) && !string.IsNullOrEmpty(testCatId))
                    {

                        String ID = (string)ServerManager.GetTaskManager.Execute(HCareTaks.AG_SaveHcUserlabtestInfo, iGet);

                        Success = true;
                        var xjson = new { Success = Success, Message = Message, Id = ID };
                        var json = new JavaScriptSerializer().Serialize(xjson);
                        Context.Response.Write(json);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            else
            {
                Success = false;
                Message = "Lab Test request already exist";
                var yjson = new { Success = Success, Message = Message, };
                var fjson = new JavaScriptSerializer().Serialize(yjson);
                Context.Response.Write(fjson);
            }

        }


        [WebMethod]
        //[ScriptMethod(UseHttpGet = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void updateFullLabTest(string Id, string testId, string userid, string testCatId, string testFor, string testAmount, string sampleCollectDate, string sampleCollectTime, string paymentType)
        {
            //( LogName, LogPass, SecurPass, Email, FirstName, LastName, Gender, Address, UserType, UserID, RoleID, IsActive, CreatedBy, CreatedTime )

            bool Success = false;
            string Message = "Your Lab Test update successfully!";

            HcUserlabtestEntity iGet = new HcUserlabtestEntity();



            iGet.Id = Id;

            iGet.Testid = testId;

            iGet.Testcatid = testCatId;
            //iGet.Createby = userid;

            // iGet.CreatedAt = System.DateTime.Now.ToString("dd-MM-yyyy");
            iGet.Updateby = userid;
            iGet.Updatedate = System.DateTime.Now.ToString("dd-MM-yyyy");
            iGet.Testamount = testAmount;
            iGet.Testfor = testFor;
            iGet.Samplecollectdate = sampleCollectDate;
            iGet.Samplecollecttime = sampleCollectTime;
            iGet.Paymenttype = paymentType;
            iGet.Status = "Pending";
            try
            {
                if (!string.IsNullOrEmpty(testId) && !string.IsNullOrEmpty(testCatId))
                {

                    bool IsUpdate = (bool)ServerManager.GetTaskManager.Execute(HCareTaks.AG_UpdateHcUserlabtestInfo, iGet);

                    Success = IsUpdate;
                    var xjson = new { Success = Success, Message = Message };
                    var json = new JavaScriptSerializer().Serialize(xjson);
                    Context.Response.Write(json);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }




        }



        [WebMethod]
        //[ScriptMethod(UseHttpGet = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void updateLabTestStatus(string Id, string userid, string Status, string testId, string testCatId)
        {
            //( LogName, LogPass, SecurPass, Email, FirstName, LastName, Gender, Address, UserType, UserID, RoleID, IsActive, CreatedBy, CreatedTime )

            bool Success = false;
            string Message = "Your Lab test has been updated successfully!";

            HcUserlabtestEntity iGet = new HcUserlabtestEntity();


            //UPDATE HC_UserLabTest SET testId= @Testid, testCatId= @Testcatid, createBy= @Createby, 
            //created_at= @CreatedAt, updateBy= @Updateby, updateDate= @Updatedate, 
            //testAmount= @Testamount, testFor= @Testfor, sampleCollectDate= @Samplecollectdate, 
            // sampleCollectTime= @Samplecollecttime, paymentType= @Paymenttype, status= @Status WHERE Id=@Id


            iGet.Id = Id;

            iGet.Testid = testId;

            iGet.Testcatid = testCatId;
            iGet.Testfor = userid;
            //iGet.Createby = userid;

            // iGet.CreatedAt = System.DateTime.Now.ToString("dd-MM-yyyy");
            iGet.Updateby = userid;
            iGet.Updatedate = System.DateTime.Now.ToString("dd-MM-yyyy");
            iGet.operationflag = "statusupdate";
            // iGet.Testamount = testAmount;
            // iGet.Testfor = testFor;
            // iGet.Samplecollectdate = sampleCollectDate;
            // iGet.Samplecollecttime = sampleCollectTime;
            //  iGet.Paymenttype = paymentType;
            iGet.Status = Status;
            try
            {
                if (!string.IsNullOrEmpty(Id) && !string.IsNullOrEmpty(userid))
                {

                    bool successmsg = (bool)ServerManager.GetTaskManager.Execute(HCareTaks.AG_UpdateHcUserlabtestInfo, iGet);

                    Success = successmsg;
                    var xjson = new { Success = Success, Message = Message };
                    var json = new JavaScriptSerializer().Serialize(xjson);
                    Context.Response.Write(json);
                }
            }
            catch (Exception ex)
            {
                throw ex;
                Message = "Error" + ex;
                Success = false;
                var xjson = new { Success = Success, Message = Message };
                var json = new JavaScriptSerializer().Serialize(xjson);
                Context.Response.Write(json);
            }




        }





        #endregion

        #region Medicine



        [WebMethod]
        //[ScriptMethod(UseHttpGet = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getProductCategory(string ProdCatId, string QueryFlag)
        {
            HcProductcategoryEntity obj = new HcProductcategoryEntity();
            obj.Id = ProdCatId;
            obj.QueryFlag = QueryFlag;

            DataTable dt = (DataTable)ServerManager.GetTaskManager.Execute(HCareTaks.AG_GetAllHcProductcategoryRecord, obj);

            HcProductcategoryEntity[] iArrayObj = new HcProductcategoryEntity[dt.Rows.Count];
            HcProductcategoryEntity iSet = null;
            int iCount = 0;
            foreach (DataRow dr in dt.Rows)
            {
                iSet = new HcProductcategoryEntity();
                iSet.Id = dr["ID"].ToString();
                iSet.Categoryname = dr["categoryName"].ToString();
                iSet.Status = dr["status"].ToString();

                iArrayObj[iCount] = iSet;
                iCount += 1;
            }


            var json = new JavaScriptSerializer().Serialize(iArrayObj);
            Context.Response.Write(json);
        }



        [WebMethod]
        //[ScriptMethod(UseHttpGet = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getMedicineType()
        {
            HcMedicinetypeEntity obj = new HcMedicinetypeEntity();
            // obj.Id = ProdCatId;
            //  obj.QueryFlag = QueryFlag;

            DataTable dt = (DataTable)ServerManager.GetTaskManager.Execute(HCareTaks.AG_GetAllHcMedicinetypeRecord, obj);

            HcMedicinetypeEntity[] iArrayObj = new HcMedicinetypeEntity[dt.Rows.Count];
            HcMedicinetypeEntity iSet = null;
            int iCount = 0;
            foreach (DataRow dr in dt.Rows)
            {
                iSet = new HcMedicinetypeEntity();
                iSet.Id = dr["ID"].ToString();
                iSet.Medicinetypename = dr["MedicineTypeName"].ToString();
                iSet.Status = dr["status"].ToString();
                iSet.imageUrl = dr["imageUrl"].ToString().Trim();

                iArrayObj[iCount] = iSet;
                iCount += 1;
            }


            var json = new JavaScriptSerializer().Serialize(iArrayObj);
            Context.Response.Write(json);
        }



        [WebMethod]
        //[ScriptMethod(UseHttpGet = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getAllMedicine(string MedicineId, string MedCompany, string medType, string ProductCategoryId)
        {
            HcMedicineEntity obj = new HcMedicineEntity();
            obj.Id = MedicineId;
            // obj.QueryFlag = QueryFlag;
            obj.Medicinetype = medType;
            obj.Medicinecompany = MedCompany;
            obj.Productcategory = ProductCategoryId;

            DataTable dt = (DataTable)ServerManager.GetTaskManager.Execute(HCareTaks.AG_GetAllHcMedicineRecord, obj);

            HcMedicineEntity[] iArrayObj = new HcMedicineEntity[dt.Rows.Count];
            HcMedicineEntity iSet = null;
            int iCount = 0;
            foreach (DataRow dr in dt.Rows)
            {

                //A.ID, A.MedicineName, A.MedicineCompany, A.MedicineType, B.MedicineTypeName, A.ProductCategory,C.categoryName, 
                //A.MedicinePrice, A.MedicineImage, A.UoM, A.StockQnty, A.CreatedBy, A.CreatedAt, A.UpdateBy, A.UpdatedAt, A.Status 
                iSet = new HcMedicineEntity();
                iSet.Id = dr["ID"].ToString().Trim();
                iSet.Medicinename = dr["Medicinename"].ToString().Trim();
                iSet.Medicinecompany = dr["MedicineCompany"].ToString().Trim();
                iSet.Medicinetype = dr["MedicineType"].ToString().Trim();
                iSet.Medicinetypename = dr["MedicineTypeName"].ToString().Trim();
                iSet.Productcategory = dr["ProductCategory"].ToString().Trim();
                iSet.Productcategoryname = dr["categoryName"].ToString().Trim();

                iSet.Medicineprice = dr["MedicinePrice"].ToString().Trim();

                iSet.Medicineimage = dr["MedicineImage"].ToString().Trim();

                iSet.Uom = dr["UoM"].ToString().Trim();
                iSet.Stockqnty = dr["StockQnty"].ToString().Trim();
                iSet.MedicineDesc = dr["MedicineDesc"].ToString().Trim();
                //iSet.Stockqnty = dr["StockQnty"].ToString();
                iSet.ImageUrl = dr["ImageUrl"].ToString();



                iArrayObj[iCount] = iSet;
                iCount += 1;
            }


            var json = new JavaScriptSerializer().Serialize(iArrayObj);
            Context.Response.Write(json);
        }

        #endregion



        #region start CART

        [WebMethod]
        //  [ScriptMethod(UseHttpGet = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void viewMyCart(string userId)
        {
            HcProductcartEntity obj = new HcProductcartEntity();
            obj.Createdby = userId;

            DataTable dt = (DataTable)ServerManager.GetTaskManager.Execute(HCareTaks.AG_GetAllHcProductcartRecord, obj);
            HcProductcartEntity[] iArrayObj = new HcProductcartEntity[dt.Rows.Count];
            HcProductcartEntity iSet = null;
            int iCount = 0;
            foreach (DataRow dr in dt.Rows)
            {
                iSet = new HcProductcartEntity();

                //A.ID, A.productId,B.MedicineName,  A.productCategoryId,  C.categoryName, B.ImageUrl, A.productPrice, A.productQnty, A.createdBy, A.createdAt, A.cartStatus 

                iSet.Id = dr["Id"].ToString().Trim();
                iSet.Productid = dr["productId"].ToString().Trim();
                iSet.Productname = dr["MedicineName"].ToString().Trim();
                iSet.Productcategoryid = dr["productCategoryId"].ToString().Trim();
                iSet.Productcategoryname = dr["categoryName"].ToString().Trim();
                iSet.Productimageurl = dr["ImageUrl"].ToString().Trim();
                iSet.Productprice = dr["productPrice"].ToString().Trim();
                iSet.Productqnty = dr["productQnty"].ToString().Trim();
                iSet.Cartstatus = dr["cartStatus"].ToString().Trim();



                iArrayObj[iCount] = iSet;
                iCount += 1;
            }

            var json = new JavaScriptSerializer().Serialize(iArrayObj);
            Context.Response.Write(json);
        }



        [WebMethod]
        //[ScriptMethod(UseHttpGet = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void saveMyCart(string productId, string productName, string productCategoryId, string productCategoryName, string productPrice, string productQnty, string createdBy)
        {




            bool Success = false;
            string Message = "Add to cart successfully!";

            HcProductcartEntity obj = new HcProductcartEntity();
            obj.Productid = productId;
            obj.Createdby = createdBy;
            obj.Cartstatus = "Pending";




            DataTable dt = (DataTable)ServerManager.GetTaskManager.Execute(HCareTaks.AG_GetAllHcProductcartRecord, obj);
            if (dt.Rows.Count == 0)
            {
                ////Success = false;
                //HcUsersEntity[] iArrayObj = new HcUsersEntity[dt.Rows.Count];
                //HcUsersEntity iSet = null;
                //  int iCount = 0;
                obj.Productid = productId;
                obj.Productname = productName;
                obj.Productcategoryid = productCategoryId;
                obj.Productcategoryname = productCategoryName;
                obj.Productimageurl = "";
                obj.Productprice = productPrice;
                obj.Productqnty = productQnty;
                obj.Createdby = createdBy;
                obj.Createdat = System.DateTime.Now.ToString("dd-MM-yyyy");
                obj.Cartstatus = "Pending";



                //  productId, productName, productCategoryId, productCategoryName, productImageUrl, productPrice, productQnty, createdBy, createdAt, cartStatus

                try
                {
                    if (!string.IsNullOrEmpty(productId))
                    {

                        String ID = (string)ServerManager.GetTaskManager.Execute(HCareTaks.AG_SaveHcProductcartInfo, obj);

                        Success = true;
                        var xjson = new { Success = Success, Message = Message, Id = ID };
                        var json = new JavaScriptSerializer().Serialize(xjson);
                        Context.Response.Write(json);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            else
            {
                Success = false;
                Message = "Product already exist in your cart!";
                var yjson = new { Success = Success, Message = Message, };
                var fjson = new JavaScriptSerializer().Serialize(yjson);
                Context.Response.Write(fjson);
            }

        }


        [WebMethod]
        //[ScriptMethod(UseHttpGet = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void updateMyCart(string cartid, string productId, string productName, string productCategoryId, string productCategoryName, string productPrice, string productQnty, string createdBy)
        {




            bool Success = false;
            string Message = "Update cart successfully!";

            HcProductcartEntity obj = new HcProductcartEntity();
            obj.Productid = productId;
            obj.Createdby = createdBy;
            obj.Cartstatus = "Pending";
            obj.Id = cartid;




            DataTable dt = (DataTable)ServerManager.GetTaskManager.Execute(HCareTaks.AG_GetAllHcProductcartRecord, obj);
            if (dt.Rows.Count >= 1)
            {
                ////Success = false;
                //HcUsersEntity[] iArrayObj = new HcUsersEntity[dt.Rows.Count];
                //HcUsersEntity iSet = null;
                //  int iCount = 0;
                obj.Productid = productId;
                obj.Productname = productName;
                obj.Productcategoryid = productCategoryId;
                obj.Productcategoryname = productCategoryName;
                obj.Productimageurl = "";
                obj.Productprice = productPrice;
                obj.Productqnty = productQnty;
                obj.Createdby = createdBy;
                obj.Createdat = System.DateTime.Now.ToString("dd-MM-yyyy");
                obj.Cartstatus = "Pending";



                //  productId, productName, productCategoryId, productCategoryName, productImageUrl, productPrice, productQnty, createdBy, createdAt, cartStatus

                try
                {
                    if (!string.IsNullOrEmpty(productId))
                    {

                        bool IsUpdate = (bool)ServerManager.GetTaskManager.Execute(HCareTaks.AG_UpdateHcProductcartInfo, obj);

                        Success = true;
                        var xjson = new { Success = Success, Message = Message, Id = productId };
                        var json = new JavaScriptSerializer().Serialize(xjson);
                        Context.Response.Write(json);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            else
            {
                Success = false;
                Message = "Requested Product Not found in your cart!";
                var yjson = new { Success = Success, Message = Message };
                var fjson = new JavaScriptSerializer().Serialize(yjson);
                Context.Response.Write(fjson);
            }

        }

        [WebMethod]
        //[ScriptMethod(UseHttpGet = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void DeleteMyCart(string cartid)
        {

            bool Success = false;
            string Message = "Item deleted successfully!";


            //  productId, productName, productCategoryId, productCategoryName, productImageUrl, productPrice, productQnty, createdBy, createdAt, cartStatus

            try
            {
                if (!string.IsNullOrEmpty(cartid))
                {
                    //  obj.Id = cartid.ToString().Trim();
                    bool IsUpdate = (bool)ServerManager.GetTaskManager.Execute(HCareTaks.AG_DeleteHcProductcartInfoById, cartid);

                    Success = true;
                    var xjson = new { Success = Success, Message = Message, Id = cartid };
                    var json = new JavaScriptSerializer().Serialize(xjson);
                    Context.Response.Write(json);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        #endregion

        #region Cart to Order box


        [WebMethod]
        //  [ScriptMethod(UseHttpGet = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void viewMyOrder(string userId)
        {
            HcProductorderEntity obj = new HcProductorderEntity();
            obj.Orderforuser = userId;
            obj.queryflag = "distinct";

            DataTable dt = (DataTable)ServerManager.GetTaskManager.Execute(HCareTaks.AG_GetAllHcProductorderRecord, obj);
            HcProductorderEntity[] iArrayObj = new HcProductorderEntity[dt.Rows.Count];
            HcProductorderEntity iSet = null;
            int iCount = 0;
            foreach (DataRow dr in dt.Rows)
            {
                iSet = new HcProductorderEntity();

                //A.ID, A.productId,B.MedicineName,  A.productCategoryId,  C.categoryName, B.ImageUrl, A.productPrice, A.productQnty, A.createdBy, A.createdAt, A.cartStatus 

                iSet.Id = dr["Id"].ToString().Trim();
                iSet.Orderid = dr["orderId"].ToString().Trim();
                iSet.Orderdate = dr["orderDate"].ToString().Trim();
                iSet.Orderstatus = dr["orderStatus"].ToString().Trim();




                iArrayObj[iCount] = iSet;
                iCount += 1;
            }

            var json = new JavaScriptSerializer().Serialize(iArrayObj);
            Context.Response.Write(json);
        }



        [WebMethod]
        //  [ScriptMethod(UseHttpGet = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void viewMyOrderDetails(string userId, string orderId)
        {
            HcProductorderEntity obj = new HcProductorderEntity();
            obj.Orderforuser = userId;
            obj.Orderid = orderId;
            DataTable dt = (DataTable)ServerManager.GetTaskManager.Execute(HCareTaks.AG_GetAllHcProductorderRecord, obj);
            ProductOrderMaster iSet = new ProductOrderMaster();


            iSet.orderId = dt.Rows[0]["orderId"].ToString().Trim();
            iSet.orderForUser = dt.Rows[0]["orderForUser"].ToString().Trim();
            iSet.orderStatus = dt.Rows[0]["orderStatus"].ToString().Trim();
            iSet.orderDate = dt.Rows[0]["orderDate"].ToString().Trim();


            List<ProductorderDetails> orderList = new List<ProductorderDetails>();
            List<ProductOrderMaster> orderMaster = new List<ProductOrderMaster>();
            foreach (DataRow dr in dt.Rows)
            {


                orderList.Add(new ProductorderDetails
                {
                    Id = dr["ID"].ToString().Trim(),
                    Productid = dr["productId"].ToString().Trim(),
                    MedicineName = dr["MedicineName"].ToString().Trim(),
                    Productimageurl = dr["ImageUrl"].ToString().Trim(),
                    Productprice = dr["productPrice"].ToString().Trim(),
                    Productqnty = dr["productQnty"].ToString().Trim(),

                });
            }
            iSet.OrderList = orderList;



            var json = new JavaScriptSerializer().Serialize(iSet);
            Context.Response.Write(json);

        }



        [WebMethod]
        //[ScriptMethod(UseHttpGet = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void saveToOrder(string cartobj)
        {
            bool Success = false;
            String Message = "Order submitted successfully";
            string orderId = "";

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            ProductCartMaster mInfo = serializer.Deserialize<ProductCartMaster>(cartobj);
            HcProductorderEntity obj = new HcProductorderEntity();
            if (!String.IsNullOrEmpty(mInfo.userId))
            {

                orderId = CreateOrderId(mInfo.userId);

                foreach (ProductCartDetails dInfo in mInfo.productList)
                {


                    //orderId, productId, productQnty, productPrice, orderStatus, orderForUser, orderDate, updateBy, updateAt
                    obj.Orderid = orderId;
                    obj.Productid = dInfo.Productid;

                    obj.Productqnty = dInfo.Productqnty;
                    obj.Productprice = dInfo.Productprice;
                    obj.Orderstatus = "Pending";
                    obj.Orderforuser = mInfo.userId;
                    obj.Orderdate = System.DateTime.Now.ToString("dd-MM-yyyy");
                    obj.Updateat = "";
                    obj.Updateby = "";

                    //  productId, productName, productCategoryId, productCategoryName, productImageUrl, productPrice, productQnty, createdBy, createdAt, cartStatus

                    try
                    {
                        if (!string.IsNullOrEmpty(dInfo.Productid))
                        {

                            String ID = (string)ServerManager.GetTaskManager.Execute(HCareTaks.AG_SaveHcProductorderInfo, obj);

                            Success = true;

                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                }

                var xjson = new { Success = Success, Message = Message, Id = orderId };
                var json = new JavaScriptSerializer().Serialize(xjson);
                Context.Response.Write(json);
            }
            //}
        }




        [WebMethod]
        //[ScriptMethod(UseHttpGet = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void DeleteMyOrder(string orderId, string userId)
        {

            bool Success = false;
            string Message = "Order deleted successfully!";

            HcProductorderEntity obj = new HcProductorderEntity();
            obj.Orderforuser = userId;
            obj.Orderid = orderId;
            //  productId, productName, productCategoryId, productCategoryName, productImageUrl, productPrice, productQnty, createdBy, createdAt, cartStatus

            try
            {
                if (!string.IsNullOrEmpty(orderId))
                {
                    //  obj.Id = cartid.ToString().Trim();
                    bool IsUpdate = (bool)ServerManager.GetTaskManager.Execute(HCareTaks.AG_DeleteHcProductorderInfoById, obj);

                    Success = true;
                    var xjson = new { Success = Success, Message = Message, Id = orderId };
                    var json = new JavaScriptSerializer().Serialize(xjson);
                    Context.Response.Write(json);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        #endregion


        #region Start Service 


        [WebMethod]
        //  [ScriptMethod(UseHttpGet = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void viewServiceCenter(string serviceId)
        {
            HcServicecenterEntity obj = new HcServicecenterEntity();
            obj.Servicetype = serviceId;
            obj.qeryflug = "distinct";

            DataTable dt = (DataTable)ServerManager.GetTaskManager.Execute(HCareTaks.AG_GetAllHcServicecenterRecord, obj);
            HcServicecenterEntity[] iArrayObj = new HcServicecenterEntity[dt.Rows.Count];
            HcServicecenterEntity iSet = null;
            int iCount = 0;
            foreach (DataRow dr in dt.Rows)
            {
                iSet = new HcServicecenterEntity();



                iSet.Id = dr["Id"].ToString().Trim();
                iSet.Servicecentername = dr["serviceCenterName"].ToString().Trim();
                iSet.Serviceceneraddress = dr["serviceCenerAddress"].ToString().Trim();
                iSet.Phone = dr["Phone"].ToString().Trim();
                iSet.Email = dr["Email"].ToString().Trim();
                iSet.Ownername = dr["ownerName"].ToString().Trim();
                iSet.Latitude = dr["Latitude"].ToString().Trim();
                iSet.Longitude = dr["Longitude"].ToString().Trim();
                iSet.Servicetype = dr["serviceType"].ToString().Trim();
                iSet.ServicetypeName = dr["ServiceName"].ToString().Trim();
                iSet.Servicetags = dr["serviceTags"].ToString().Trim();




                iArrayObj[iCount] = iSet;
                iCount += 1;
            }

            var json = new JavaScriptSerializer().Serialize(iArrayObj);
            Context.Response.Write(json);
        }



        #endregion

    }

}







