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
	public partial class HcAssesmentDAL
	{
		#region Auto Generated 

		public bool SaveHcAssesmentInfo(HcAssesmentEntity hcAssesmentEntity, Database db, DbTransaction transaction)
		{
			string sql = "INSERT INTO HC_Assesment ( Type, Description) VALUES (  @Type,  @Description )";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);

			db.AddInParameter(dbCommand, "Type", DbType.String, hcAssesmentEntity.Type);
			db.AddInParameter(dbCommand, "Description", DbType.String, hcAssesmentEntity.Description);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;		}

		public bool UpdateHcAssesmentInfo(HcAssesmentEntity hcAssesmentEntity, Database db, DbTransaction transaction)
		{
			string sql = "UPDATE HC_Assesment SET Type= @Type, Description= @Description WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id",DbType.String, hcAssesmentEntity.Id);
			db.AddInParameter(dbCommand, "Type", DbType.String, hcAssesmentEntity.Type);
			db.AddInParameter(dbCommand, "Description", DbType.String, hcAssesmentEntity.Description);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public bool DeleteHcAssesmentInfoById(object param, Database db, DbTransaction transaction)
		{
			string sql = "DELETE FROM HC_Assesment WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public HcAssesmentEntity GetSingleHcAssesmentRecordById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sql = "SELECT ID, Type, Description FROM HC_Assesment WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);
			HcAssesmentEntity hcAssesmentEntity = null;
			using (IDataReader dataReader = db.ExecuteReader(dbCommand))
			{
				if (dataReader.Read())
				{
					hcAssesmentEntity = new HcAssesmentEntity();
					if (dataReader["ID"] != DBNull.Value)
					{
						hcAssesmentEntity.Id = dataReader["ID"].ToString();
					}
					if (dataReader["Type"] != DBNull.Value)
					{
						hcAssesmentEntity.Type = dataReader["Type"].ToString();
					}
					if (dataReader["Description"] != DBNull.Value)
					{
						hcAssesmentEntity.Description = dataReader["Description"].ToString();
					}
				}
			}
			return hcAssesmentEntity;
		}

		#endregion

	}
}

