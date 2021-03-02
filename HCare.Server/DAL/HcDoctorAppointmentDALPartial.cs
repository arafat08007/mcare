using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using HCare.Models;
using Microsoft.Practices.EnterpriseLibrary.Data;


namespace HCare.Server.DAL
{
	public partial class HcDoctorAppointmentDAL
	{
		public DataTable GetAllHcDoctorAppointmentRecord(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
            string sql = @"SELECT A.ID, A.PatientUID, U.FirstName+' '+U.LastName  as Username, U.Gender,
                            (SELECT FLOOR((CAST (GetDate() AS INTEGER) - CAST( cast(U.DOB as datetime) AS INTEGER)) / 365.25)) AS Age,  
                            A.DoctorID, A.Dates, A.TimeID, A.Reasons, A.PayMethod, A.Status, A.CreatedBy, A.CreatedTime, A.UpdatedBy, A.UpdatedTime 
                            , D.Name DoctorName, D.Specialist, (Select Name From HC_Doctor_Departments z Where z.ID = D.Department) DoctorDeptName, T.Times,
                            A.symtomps_image_path, A.prescription_image_path
                            FROM HC_Doctor_Appointment A 
                            Left Join HC_DoctorInfo D ON D.ID = A.DoctorID
                            Left Join HC_Users U ON U.ID = A.PatientUID
                            Left Join HC_Doctor_Times T ON T.ID = A.TimeID
                            Where 1=1";

            HcDoctorAppointmentEntity obj = new HcDoctorAppointmentEntity();
            if (param != null) obj = (HcDoctorAppointmentEntity)param;

            if (!string.IsNullOrEmpty(obj.QueryFlag) && obj.QueryFlag == "Patient")
            {
                if (!string.IsNullOrEmpty(obj.Patientuid))
                    sql += " And A.PatientUID = '" + obj.Patientuid + "'";
                if (!string.IsNullOrEmpty(obj.Status))
                    sql += " And A.Status = '" + obj.Status + "'";                
            }

            else if (!string.IsNullOrEmpty(obj.QueryFlag) && obj.QueryFlag == "Doctor")
            {

                if (!string.IsNullOrEmpty(obj.Patientuid))
                    sql += " And A.DoctorID = '" + obj.Patientuid + "'";
                              
            }
            if (!string.IsNullOrEmpty(obj.Id))
                sql += " And A.ID = '" + obj.Id + "'";

            sql += " Order By Convert(dateTime,A.CreatedTime,103) Desc";

			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			DataSet ds = db.ExecuteDataSet(dbCommand);
			return ds.Tables[0];
		}

	}
}

