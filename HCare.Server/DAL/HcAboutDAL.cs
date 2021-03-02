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
	public partial class HcAboutDAL
	{
		#region Auto Generated 

		public bool SaveHcAboutInfo(HcAboutEntity hcAboutEntity, Database db, DbTransaction transaction)
		{
			string sql = "INSERT INTO HC_About ( Id, about, mission, vision, contactinfo, phone1, phone2, email, website, address) VALUES (  @Id,  @About,  @Mission,  @Vision,  @Contactinfo,  @Phone1,  @Phone2,  @Email,  @Website,  @Address )";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);

			db.AddInParameter(dbCommand, "Id", DbType.String, hcAboutEntity.Id);
			db.AddInParameter(dbCommand, "About", DbType.String, hcAboutEntity.About);
			db.AddInParameter(dbCommand, "Mission", DbType.String, hcAboutEntity.Mission);
			db.AddInParameter(dbCommand, "Vision", DbType.String, hcAboutEntity.Vision);
			db.AddInParameter(dbCommand, "Contactinfo", DbType.String, hcAboutEntity.Contactinfo);
			db.AddInParameter(dbCommand, "Phone1", DbType.String, hcAboutEntity.Phone1);
			db.AddInParameter(dbCommand, "Phone2", DbType.String, hcAboutEntity.Phone2);
			db.AddInParameter(dbCommand, "Email", DbType.String, hcAboutEntity.Email);
			db.AddInParameter(dbCommand, "Website", DbType.String, hcAboutEntity.Website);
			db.AddInParameter(dbCommand, "Address", DbType.String, hcAboutEntity.Address);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;		}

		public bool UpdateHcAboutInfo(HcAboutEntity hcAboutEntity, Database db, DbTransaction transaction)
		{
			string sql = "UPDATE HC_About SET about= @About, mission= @Mission, vision= @Vision, contactinfo= @Contactinfo, phone1= @Phone1, phone2= @Phone2, email= @Email, website= @Website, address= @Address WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id",DbType.String, hcAboutEntity.Id);
			db.AddInParameter(dbCommand, "About", DbType.String, hcAboutEntity.About);
			db.AddInParameter(dbCommand, "Mission", DbType.String, hcAboutEntity.Mission);
			db.AddInParameter(dbCommand, "Vision", DbType.String, hcAboutEntity.Vision);
			db.AddInParameter(dbCommand, "Contactinfo", DbType.String, hcAboutEntity.Contactinfo);
			db.AddInParameter(dbCommand, "Phone1", DbType.String, hcAboutEntity.Phone1);
			db.AddInParameter(dbCommand, "Phone2", DbType.String, hcAboutEntity.Phone2);
			db.AddInParameter(dbCommand, "Email", DbType.String, hcAboutEntity.Email);
			db.AddInParameter(dbCommand, "Website", DbType.String, hcAboutEntity.Website);
			db.AddInParameter(dbCommand, "Address", DbType.String, hcAboutEntity.Address);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public bool DeleteHcAboutInfoById(object param, Database db, DbTransaction transaction)
		{
			string sql = "DELETE FROM HC_About WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public HcAboutEntity GetSingleHcAboutRecordById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sql = "SELECT Id, about, mission, vision, contactinfo, phone1, phone2, email, website, address FROM HC_About WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);
			HcAboutEntity hcAboutEntity = null;
			using (IDataReader dataReader = db.ExecuteReader(dbCommand))
			{
				if (dataReader.Read())
				{
					hcAboutEntity = new HcAboutEntity();
					if (dataReader["Id"] != DBNull.Value)
					{
						hcAboutEntity.Id = dataReader["Id"].ToString();
					}
					if (dataReader["about"] != DBNull.Value)
					{
						hcAboutEntity.About = dataReader["about"].ToString();
					}
					if (dataReader["mission"] != DBNull.Value)
					{
						hcAboutEntity.Mission = dataReader["mission"].ToString();
					}
					if (dataReader["vision"] != DBNull.Value)
					{
						hcAboutEntity.Vision = dataReader["vision"].ToString();
					}
					if (dataReader["contactinfo"] != DBNull.Value)
					{
						hcAboutEntity.Contactinfo = dataReader["contactinfo"].ToString();
					}
					if (dataReader["phone1"] != DBNull.Value)
					{
						hcAboutEntity.Phone1 = dataReader["phone1"].ToString();
					}
					if (dataReader["phone2"] != DBNull.Value)
					{
						hcAboutEntity.Phone2 = dataReader["phone2"].ToString();
					}
					if (dataReader["email"] != DBNull.Value)
					{
						hcAboutEntity.Email = dataReader["email"].ToString();
					}
					if (dataReader["website"] != DBNull.Value)
					{
						hcAboutEntity.Website = dataReader["website"].ToString();
					}
					if (dataReader["address"] != DBNull.Value)
					{
						hcAboutEntity.Address = dataReader["address"].ToString();
					}
				}
			}
			return hcAboutEntity;
		}

		#endregion

	}
}

