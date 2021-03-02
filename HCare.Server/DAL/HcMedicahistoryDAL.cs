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
	public partial class HcMedicahistoryDAL
	{
		#region Auto Generated 

		public bool SaveHcMedicahistoryInfo(HcMedicahistoryEntity hcMedicahistoryEntity, Database db, DbTransaction transaction)
		{
			string sql = "INSERT INTO HC_MedicaHistory ( UserId, chornicillness, medicineName, drugSensitivity, createdBy, caratedAt, isActive) VALUES (  @Userid,  @Chornicillness,  @Medicinename,  @Drugsensitivity,  @Createdby,  @Caratedat,  @Isactive )";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);

			db.AddInParameter(dbCommand, "Userid", DbType.String, hcMedicahistoryEntity.Userid);
			db.AddInParameter(dbCommand, "Chornicillness", DbType.String, hcMedicahistoryEntity.Chornicillness);
			db.AddInParameter(dbCommand, "Medicinename", DbType.String, hcMedicahistoryEntity.Medicinename);
			db.AddInParameter(dbCommand, "Drugsensitivity", DbType.String, hcMedicahistoryEntity.Drugsensitivity);
			db.AddInParameter(dbCommand, "Createdby", DbType.String, hcMedicahistoryEntity.Createdby);
			db.AddInParameter(dbCommand, "Caratedat", DbType.String, hcMedicahistoryEntity.Caratedat);
			db.AddInParameter(dbCommand, "Isactive", DbType.String, hcMedicahistoryEntity.Isactive);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;		}

		public bool UpdateHcMedicahistoryInfo(HcMedicahistoryEntity hcMedicahistoryEntity, Database db, DbTransaction transaction)
		{
			string sql = "UPDATE HC_MedicaHistory SET UserId= @Userid, chornicillness= @Chornicillness, medicineName= @Medicinename, drugSensitivity= @Drugsensitivity, createdBy= @Createdby, caratedAt= @Caratedat, isActive= @Isactive WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id",DbType.String, hcMedicahistoryEntity.Id);
			db.AddInParameter(dbCommand, "Userid", DbType.String, hcMedicahistoryEntity.Userid);
			db.AddInParameter(dbCommand, "Chornicillness", DbType.String, hcMedicahistoryEntity.Chornicillness);
			db.AddInParameter(dbCommand, "Medicinename", DbType.String, hcMedicahistoryEntity.Medicinename);
			db.AddInParameter(dbCommand, "Drugsensitivity", DbType.String, hcMedicahistoryEntity.Drugsensitivity);
			db.AddInParameter(dbCommand, "Createdby", DbType.String, hcMedicahistoryEntity.Createdby);
			db.AddInParameter(dbCommand, "Caratedat", DbType.String, hcMedicahistoryEntity.Caratedat);
			db.AddInParameter(dbCommand, "Isactive", DbType.String, hcMedicahistoryEntity.Isactive);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public bool DeleteHcMedicahistoryInfoById(object param, Database db, DbTransaction transaction)
		{
			string sql = "DELETE FROM HC_MedicaHistory WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public HcMedicahistoryEntity GetSingleHcMedicahistoryRecordById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sql = "SELECT ID, UserId, chornicillness, medicineName, drugSensitivity, createdBy, caratedAt, isActive FROM HC_MedicaHistory WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);
			HcMedicahistoryEntity hcMedicahistoryEntity = null;
			using (IDataReader dataReader = db.ExecuteReader(dbCommand))
			{
				if (dataReader.Read())
				{
					hcMedicahistoryEntity = new HcMedicahistoryEntity();
					if (dataReader["ID"] != DBNull.Value)
					{
						hcMedicahistoryEntity.Id = dataReader["ID"].ToString();
					}
					if (dataReader["UserId"] != DBNull.Value)
					{
						hcMedicahistoryEntity.Userid = dataReader["UserId"].ToString();
					}
					if (dataReader["chornicillness"] != DBNull.Value)
					{
						hcMedicahistoryEntity.Chornicillness = dataReader["chornicillness"].ToString();
					}
					if (dataReader["medicineName"] != DBNull.Value)
					{
						hcMedicahistoryEntity.Medicinename = dataReader["medicineName"].ToString();
					}
					if (dataReader["drugSensitivity"] != DBNull.Value)
					{
						hcMedicahistoryEntity.Drugsensitivity = dataReader["drugSensitivity"].ToString();
					}
					if (dataReader["createdBy"] != DBNull.Value)
					{
						hcMedicahistoryEntity.Createdby = dataReader["createdBy"].ToString();
					}
					if (dataReader["caratedAt"] != DBNull.Value)
					{
						hcMedicahistoryEntity.Caratedat = dataReader["caratedAt"].ToString();
					}
					if (dataReader["isActive"] != DBNull.Value)
					{
						hcMedicahistoryEntity.Isactive = dataReader["isActive"].ToString();
					}
				}
			}
			return hcMedicahistoryEntity;
		}

		#endregion

	}
}

