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
		#region Auto Generated 

		public object SaveHcDoctorAppointmentInfo(HcDoctorAppointmentEntity hcDoctorAppointmentEntity, Database db, DbTransaction transaction)
		{
            string sql = "INSERT INTO HC_Doctor_Appointment ( PatientUID, DoctorID, Dates, TimeID, Reasons, PayMethod, Status, CreatedBy, CreatedTime ) output inserted.ID VALUES (  @Patientuid,  @Doctorid,  @Dates,  @Timeid,  @Reasons,  @Paymethod,  @Status,  @Createdby,  @Createdtime )";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);

            db.AddInParameter(dbCommand, "Patientuid", DbType.String, hcDoctorAppointmentEntity.Patientuid);
			db.AddInParameter(dbCommand, "Doctorid", DbType.String, hcDoctorAppointmentEntity.Doctorid);
			db.AddInParameter(dbCommand, "Dates", DbType.String, hcDoctorAppointmentEntity.Dates);
			db.AddInParameter(dbCommand, "Timeid", DbType.String, hcDoctorAppointmentEntity.Timeid);
			db.AddInParameter(dbCommand, "Reasons", DbType.String, hcDoctorAppointmentEntity.Reasons);
			db.AddInParameter(dbCommand, "Paymethod", DbType.String, hcDoctorAppointmentEntity.Paymethod);
			db.AddInParameter(dbCommand, "Status", DbType.String, hcDoctorAppointmentEntity.Status);
			db.AddInParameter(dbCommand, "Createdby", DbType.String, hcDoctorAppointmentEntity.Createdby);
			db.AddInParameter(dbCommand, "Createdtime", DbType.String, hcDoctorAppointmentEntity.Createdtime);

            var id = db.ExecuteScalar(dbCommand, transaction).ToString();
            return id;
        }

		public bool UpdateHcDoctorAppointmentInfo(HcDoctorAppointmentEntity hcDoctorAppointmentEntity, Database db, DbTransaction transaction)
		{
            string sql = "UPDATE HC_Doctor_Appointment SET PatientUID= @Patientuid, DoctorID= @Doctorid, Dates= @Dates, TimeID= @Timeid, Reasons= @Reasons, PayMethod= @Paymethod, Status= @Status, UpdatedBy= @Updatedby, UpdatedTime= @Updatedtime WHERE Id=@Id";

            if (hcDoctorAppointmentEntity.QueryFlag == "Cancelled")
                sql = "UPDATE HC_Doctor_Appointment SET Status= @Status, UpdatedBy= @Updatedby, UpdatedTime= @Updatedtime WHERE Id=@Id";

			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id",DbType.String, hcDoctorAppointmentEntity.Id);
            db.AddInParameter(dbCommand, "Patientuid", DbType.String, hcDoctorAppointmentEntity.Patientuid);
			db.AddInParameter(dbCommand, "Doctorid", DbType.String, hcDoctorAppointmentEntity.Doctorid);
			db.AddInParameter(dbCommand, "Dates", DbType.String, hcDoctorAppointmentEntity.Dates);
			db.AddInParameter(dbCommand, "Timeid", DbType.String, hcDoctorAppointmentEntity.Timeid);
			db.AddInParameter(dbCommand, "Reasons", DbType.String, hcDoctorAppointmentEntity.Reasons);
			db.AddInParameter(dbCommand, "Paymethod", DbType.String, hcDoctorAppointmentEntity.Paymethod);
			db.AddInParameter(dbCommand, "Status", DbType.String, hcDoctorAppointmentEntity.Status);
			db.AddInParameter(dbCommand, "Updatedby", DbType.String, hcDoctorAppointmentEntity.Updatedby);
			db.AddInParameter(dbCommand, "Updatedtime", DbType.String, hcDoctorAppointmentEntity.Updatedtime);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public bool DeleteHcDoctorAppointmentInfoById(object param, Database db, DbTransaction transaction)
		{
			string sql = "DELETE FROM HC_Doctor_Appointment WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public HcDoctorAppointmentEntity GetSingleHcDoctorAppointmentRecordById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sql = "SELECT ID, PatientUID, DoctorID, Dates, TimeID, Reasons, PayMethod, Status, CreatedBy, CreatedTime, UpdatedBy, UpdatedTime FROM HC_Doctor_Appointment WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);
			HcDoctorAppointmentEntity hcDoctorAppointmentEntity = null;
			using (IDataReader dataReader = db.ExecuteReader(dbCommand))
			{
				if (dataReader.Read())
				{
					hcDoctorAppointmentEntity = new HcDoctorAppointmentEntity();
					if (dataReader["ID"] != DBNull.Value)
					{
						hcDoctorAppointmentEntity.Id = dataReader["ID"].ToString();
					}
					if (dataReader["PatientUID"] != DBNull.Value)
					{
						hcDoctorAppointmentEntity.Patientuid = dataReader["PatientUID"].ToString();
					}
					if (dataReader["DoctorID"] != DBNull.Value)
					{
						hcDoctorAppointmentEntity.Doctorid = dataReader["DoctorID"].ToString();
					}
					if (dataReader["Dates"] != DBNull.Value)
					{
						hcDoctorAppointmentEntity.Dates = dataReader["Dates"].ToString();
					}
					if (dataReader["TimeID"] != DBNull.Value)
					{
						hcDoctorAppointmentEntity.Timeid = dataReader["TimeID"].ToString();
					}
					if (dataReader["Reasons"] != DBNull.Value)
					{
						hcDoctorAppointmentEntity.Reasons = dataReader["Reasons"].ToString();
					}
					if (dataReader["PayMethod"] != DBNull.Value)
					{
						hcDoctorAppointmentEntity.Paymethod = dataReader["PayMethod"].ToString();
					}
					if (dataReader["Status"] != DBNull.Value)
					{
						hcDoctorAppointmentEntity.Status = dataReader["Status"].ToString();
					}
					if (dataReader["CreatedBy"] != DBNull.Value)
					{
						hcDoctorAppointmentEntity.Createdby = dataReader["CreatedBy"].ToString();
					}
					if (dataReader["CreatedTime"] != DBNull.Value)
					{
						hcDoctorAppointmentEntity.Createdtime = dataReader["CreatedTime"].ToString();
					}
					if (dataReader["UpdatedBy"] != DBNull.Value)
					{
						hcDoctorAppointmentEntity.Updatedby = dataReader["UpdatedBy"].ToString();
					}
					if (dataReader["UpdatedTime"] != DBNull.Value)
					{
						hcDoctorAppointmentEntity.Updatedtime = dataReader["UpdatedTime"].ToString();
					}
				}
			}
			return hcDoctorAppointmentEntity;
		}

		#endregion

	}
}

