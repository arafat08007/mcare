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
	public partial class HcServicecenterDAL
	{
		#region Auto Generated 

		public bool SaveHcServicecenterInfo(HcServicecenterEntity hcServicecenterEntity, Database db, DbTransaction transaction)
		{
			string sql = "INSERT INTO HC_ServiceCenter ( Id, serviceCenterName, serviceCenerAddress, Latitude, Longitude, Phone, Email, ownerName, status, createdBy, createdAt, serviceType, serviceTags) VALUES (  @Id,  @Servicecentername,  @Serviceceneraddress,  @Latitude,  @Longitude,  @Phone,  @Email,  @Ownername,  @Status,  @Createdby,  @Createdat,  @Servicetype,  @Servicetags )";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);

			db.AddInParameter(dbCommand, "Id", DbType.String, hcServicecenterEntity.Id);
			db.AddInParameter(dbCommand, "Servicecentername", DbType.String, hcServicecenterEntity.Servicecentername);
			db.AddInParameter(dbCommand, "Serviceceneraddress", DbType.String, hcServicecenterEntity.Serviceceneraddress);
			db.AddInParameter(dbCommand, "Latitude", DbType.String, hcServicecenterEntity.Latitude);
			db.AddInParameter(dbCommand, "Longitude", DbType.String, hcServicecenterEntity.Longitude);
			db.AddInParameter(dbCommand, "Phone", DbType.String, hcServicecenterEntity.Phone);
			db.AddInParameter(dbCommand, "Email", DbType.String, hcServicecenterEntity.Email);
			db.AddInParameter(dbCommand, "Ownername", DbType.String, hcServicecenterEntity.Ownername);
			db.AddInParameter(dbCommand, "Status", DbType.String, hcServicecenterEntity.Status);
			db.AddInParameter(dbCommand, "Createdby", DbType.String, hcServicecenterEntity.Createdby);
			db.AddInParameter(dbCommand, "Createdat", DbType.String, hcServicecenterEntity.Createdat);
			db.AddInParameter(dbCommand, "Servicetype", DbType.String, hcServicecenterEntity.Servicetype);
			db.AddInParameter(dbCommand, "Servicetags", DbType.String, hcServicecenterEntity.Servicetags);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;		}

		public bool UpdateHcServicecenterInfo(HcServicecenterEntity hcServicecenterEntity, Database db, DbTransaction transaction)
		{
			string sql = "UPDATE HC_ServiceCenter SET serviceCenterName= @Servicecentername, serviceCenerAddress= @Serviceceneraddress, Latitude= @Latitude, Longitude= @Longitude, Phone= @Phone, Email= @Email, ownerName= @Ownername, status= @Status, createdBy= @Createdby, createdAt= @Createdat, serviceType= @Servicetype, serviceTags= @Servicetags WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id",DbType.String, hcServicecenterEntity.Id);
			db.AddInParameter(dbCommand, "Servicecentername", DbType.String, hcServicecenterEntity.Servicecentername);
			db.AddInParameter(dbCommand, "Serviceceneraddress", DbType.String, hcServicecenterEntity.Serviceceneraddress);
			db.AddInParameter(dbCommand, "Latitude", DbType.String, hcServicecenterEntity.Latitude);
			db.AddInParameter(dbCommand, "Longitude", DbType.String, hcServicecenterEntity.Longitude);
			db.AddInParameter(dbCommand, "Phone", DbType.String, hcServicecenterEntity.Phone);
			db.AddInParameter(dbCommand, "Email", DbType.String, hcServicecenterEntity.Email);
			db.AddInParameter(dbCommand, "Ownername", DbType.String, hcServicecenterEntity.Ownername);
			db.AddInParameter(dbCommand, "Status", DbType.String, hcServicecenterEntity.Status);
			db.AddInParameter(dbCommand, "Createdby", DbType.String, hcServicecenterEntity.Createdby);
			db.AddInParameter(dbCommand, "Createdat", DbType.String, hcServicecenterEntity.Createdat);
			db.AddInParameter(dbCommand, "Servicetype", DbType.String, hcServicecenterEntity.Servicetype);
			db.AddInParameter(dbCommand, "Servicetags", DbType.String, hcServicecenterEntity.Servicetags);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public bool DeleteHcServicecenterInfoById(object param, Database db, DbTransaction transaction)
		{
			string sql = "DELETE FROM HC_ServiceCenter WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public HcServicecenterEntity GetSingleHcServicecenterRecordById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sql = "SELECT Id, serviceCenterName, serviceCenerAddress, Latitude, Longitude, Phone, Email, ownerName, status, createdBy, createdAt, serviceType, serviceTags FROM HC_ServiceCenter WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);
			HcServicecenterEntity hcServicecenterEntity = null;
			using (IDataReader dataReader = db.ExecuteReader(dbCommand))
			{
				if (dataReader.Read())
				{
					hcServicecenterEntity = new HcServicecenterEntity();
					if (dataReader["Id"] != DBNull.Value)
					{
						hcServicecenterEntity.Id = dataReader["Id"].ToString();
					}
					if (dataReader["serviceCenterName"] != DBNull.Value)
					{
						hcServicecenterEntity.Servicecentername = dataReader["serviceCenterName"].ToString();
					}
					if (dataReader["serviceCenerAddress"] != DBNull.Value)
					{
						hcServicecenterEntity.Serviceceneraddress = dataReader["serviceCenerAddress"].ToString();
					}
					if (dataReader["Latitude"] != DBNull.Value)
					{
						hcServicecenterEntity.Latitude = dataReader["Latitude"].ToString();
					}
					if (dataReader["Longitude"] != DBNull.Value)
					{
						hcServicecenterEntity.Longitude = dataReader["Longitude"].ToString();
					}
					if (dataReader["Phone"] != DBNull.Value)
					{
						hcServicecenterEntity.Phone = dataReader["Phone"].ToString();
					}
					if (dataReader["Email"] != DBNull.Value)
					{
						hcServicecenterEntity.Email = dataReader["Email"].ToString();
					}
					if (dataReader["ownerName"] != DBNull.Value)
					{
						hcServicecenterEntity.Ownername = dataReader["ownerName"].ToString();
					}
					if (dataReader["status"] != DBNull.Value)
					{
						hcServicecenterEntity.Status = dataReader["status"].ToString();
					}
					if (dataReader["createdBy"] != DBNull.Value)
					{
						hcServicecenterEntity.Createdby = dataReader["createdBy"].ToString();
					}
					if (dataReader["createdAt"] != DBNull.Value)
					{
						hcServicecenterEntity.Createdat = dataReader["createdAt"].ToString();
					}
					if (dataReader["serviceType"] != DBNull.Value)
					{
						hcServicecenterEntity.Servicetype = dataReader["serviceType"].ToString();
					}
					if (dataReader["serviceTags"] != DBNull.Value)
					{
						hcServicecenterEntity.Servicetags = dataReader["serviceTags"].ToString();
					}
				}
			}
			return hcServicecenterEntity;
		}

		#endregion

	}
}

