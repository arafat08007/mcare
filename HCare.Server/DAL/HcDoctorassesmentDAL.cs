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
	public partial class HcDoctorassesmentDAL
	{
		#region Auto Generated 

		public bool SaveHcDoctorassesmentInfo(HcDoctorassesmentEntity hcDoctorassesmentEntity, Database db, DbTransaction transaction)
		{
			string sql = "INSERT INTO HC_DoctorAssesment ( Id, PatientId, DoctorId, DiseaseId, isAttachment, AttachmentPath, isRx, RxPath, AssesmentType, AssementCommunication, AssesmentDate, AssesmentStartTime, AssesmentEndTime, AssesmentDuration, Status) VALUES (  @Id,  @Patientid,  @Doctorid,  @Diseaseid,  @Isattachment,  @Attachmentpath,  @Isrx,  @Rxpath,  @Assesmenttype,  @Assementcommunication,  @Assesmentdate,  @Assesmentstarttime,  @Assesmentendtime,  @Assesmentduration,  @Status )";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);

			db.AddInParameter(dbCommand, "Id", DbType.String, hcDoctorassesmentEntity.Id);
			db.AddInParameter(dbCommand, "Patientid", DbType.String, hcDoctorassesmentEntity.Patientid);
			db.AddInParameter(dbCommand, "Doctorid", DbType.String, hcDoctorassesmentEntity.Doctorid);
			db.AddInParameter(dbCommand, "Diseaseid", DbType.String, hcDoctorassesmentEntity.Diseaseid);
			db.AddInParameter(dbCommand, "Isattachment", DbType.String, hcDoctorassesmentEntity.Isattachment);
			db.AddInParameter(dbCommand, "Attachmentpath", DbType.String, hcDoctorassesmentEntity.Attachmentpath);
			db.AddInParameter(dbCommand, "Isrx", DbType.String, hcDoctorassesmentEntity.Isrx);
			db.AddInParameter(dbCommand, "Rxpath", DbType.String, hcDoctorassesmentEntity.Rxpath);
			db.AddInParameter(dbCommand, "Assesmenttype", DbType.String, hcDoctorassesmentEntity.Assesmenttype);
			db.AddInParameter(dbCommand, "Assementcommunication", DbType.String, hcDoctorassesmentEntity.Assementcommunication);
			db.AddInParameter(dbCommand, "Assesmentdate", DbType.String, hcDoctorassesmentEntity.Assesmentdate);
			db.AddInParameter(dbCommand, "Assesmentstarttime", DbType.String, hcDoctorassesmentEntity.Assesmentstarttime);
			db.AddInParameter(dbCommand, "Assesmentendtime", DbType.String, hcDoctorassesmentEntity.Assesmentendtime);
			db.AddInParameter(dbCommand, "Assesmentduration", DbType.String, hcDoctorassesmentEntity.Assesmentduration);
			db.AddInParameter(dbCommand, "Status", DbType.String, hcDoctorassesmentEntity.Status);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;		}

		public bool UpdateHcDoctorassesmentInfo(HcDoctorassesmentEntity hcDoctorassesmentEntity, Database db, DbTransaction transaction)
		{
			string sql = "UPDATE HC_DoctorAssesment SET PatientId= @Patientid, DoctorId= @Doctorid, DiseaseId= @Diseaseid, isAttachment= @Isattachment, AttachmentPath= @Attachmentpath, isRx= @Isrx, RxPath= @Rxpath, AssesmentType= @Assesmenttype, AssementCommunication= @Assementcommunication, AssesmentDate= @Assesmentdate, AssesmentStartTime= @Assesmentstarttime, AssesmentEndTime= @Assesmentendtime, AssesmentDuration= @Assesmentduration, Status= @Status WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id",DbType.String, hcDoctorassesmentEntity.Id);
			db.AddInParameter(dbCommand, "Patientid", DbType.String, hcDoctorassesmentEntity.Patientid);
			db.AddInParameter(dbCommand, "Doctorid", DbType.String, hcDoctorassesmentEntity.Doctorid);
			db.AddInParameter(dbCommand, "Diseaseid", DbType.String, hcDoctorassesmentEntity.Diseaseid);
			db.AddInParameter(dbCommand, "Isattachment", DbType.String, hcDoctorassesmentEntity.Isattachment);
			db.AddInParameter(dbCommand, "Attachmentpath", DbType.String, hcDoctorassesmentEntity.Attachmentpath);
			db.AddInParameter(dbCommand, "Isrx", DbType.String, hcDoctorassesmentEntity.Isrx);
			db.AddInParameter(dbCommand, "Rxpath", DbType.String, hcDoctorassesmentEntity.Rxpath);
			db.AddInParameter(dbCommand, "Assesmenttype", DbType.String, hcDoctorassesmentEntity.Assesmenttype);
			db.AddInParameter(dbCommand, "Assementcommunication", DbType.String, hcDoctorassesmentEntity.Assementcommunication);
			db.AddInParameter(dbCommand, "Assesmentdate", DbType.String, hcDoctorassesmentEntity.Assesmentdate);
			db.AddInParameter(dbCommand, "Assesmentstarttime", DbType.String, hcDoctorassesmentEntity.Assesmentstarttime);
			db.AddInParameter(dbCommand, "Assesmentendtime", DbType.String, hcDoctorassesmentEntity.Assesmentendtime);
			db.AddInParameter(dbCommand, "Assesmentduration", DbType.String, hcDoctorassesmentEntity.Assesmentduration);
			db.AddInParameter(dbCommand, "Status", DbType.String, hcDoctorassesmentEntity.Status);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public bool DeleteHcDoctorassesmentInfoById(object param, Database db, DbTransaction transaction)
		{
			string sql = "DELETE FROM HC_DoctorAssesment WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public HcDoctorassesmentEntity GetSingleHcDoctorassesmentRecordById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sql = "SELECT Id, PatientId, DoctorId, DiseaseId, isAttachment, AttachmentPath, isRx, RxPath, AssesmentType, AssementCommunication, AssesmentDate, AssesmentStartTime, AssesmentEndTime, AssesmentDuration, Status FROM HC_DoctorAssesment WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);
			HcDoctorassesmentEntity hcDoctorassesmentEntity = null;
			using (IDataReader dataReader = db.ExecuteReader(dbCommand))
			{
				if (dataReader.Read())
				{
					hcDoctorassesmentEntity = new HcDoctorassesmentEntity();
					if (dataReader["Id"] != DBNull.Value)
					{
						hcDoctorassesmentEntity.Id = dataReader["Id"].ToString();
					}
					if (dataReader["PatientId"] != DBNull.Value)
					{
						hcDoctorassesmentEntity.Patientid = dataReader["PatientId"].ToString();
					}
					if (dataReader["DoctorId"] != DBNull.Value)
					{
						hcDoctorassesmentEntity.Doctorid = dataReader["DoctorId"].ToString();
					}
					if (dataReader["DiseaseId"] != DBNull.Value)
					{
						hcDoctorassesmentEntity.Diseaseid = dataReader["DiseaseId"].ToString();
					}
					if (dataReader["isAttachment"] != DBNull.Value)
					{
						hcDoctorassesmentEntity.Isattachment = dataReader["isAttachment"].ToString();
					}
					if (dataReader["AttachmentPath"] != DBNull.Value)
					{
						hcDoctorassesmentEntity.Attachmentpath = dataReader["AttachmentPath"].ToString();
					}
					if (dataReader["isRx"] != DBNull.Value)
					{
						hcDoctorassesmentEntity.Isrx = dataReader["isRx"].ToString();
					}
					if (dataReader["RxPath"] != DBNull.Value)
					{
						hcDoctorassesmentEntity.Rxpath = dataReader["RxPath"].ToString();
					}
					if (dataReader["AssesmentType"] != DBNull.Value)
					{
						hcDoctorassesmentEntity.Assesmenttype = dataReader["AssesmentType"].ToString();
					}
					if (dataReader["AssementCommunication"] != DBNull.Value)
					{
						hcDoctorassesmentEntity.Assementcommunication = dataReader["AssementCommunication"].ToString();
					}
					if (dataReader["AssesmentDate"] != DBNull.Value)
					{
						hcDoctorassesmentEntity.Assesmentdate = dataReader["AssesmentDate"].ToString();
					}
					if (dataReader["AssesmentStartTime"] != DBNull.Value)
					{
						hcDoctorassesmentEntity.Assesmentstarttime = dataReader["AssesmentStartTime"].ToString();
					}
					if (dataReader["AssesmentEndTime"] != DBNull.Value)
					{
						hcDoctorassesmentEntity.Assesmentendtime = dataReader["AssesmentEndTime"].ToString();
					}
					if (dataReader["AssesmentDuration"] != DBNull.Value)
					{
						hcDoctorassesmentEntity.Assesmentduration = dataReader["AssesmentDuration"].ToString();
					}
					if (dataReader["Status"] != DBNull.Value)
					{
						hcDoctorassesmentEntity.Status = dataReader["Status"].ToString();
					}
				}
			}
			return hcDoctorassesmentEntity;
		}

		#endregion

	}
}

