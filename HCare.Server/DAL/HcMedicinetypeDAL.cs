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
	public partial class HcMedicinetypeDAL
	{
		#region Auto Generated 

		public bool SaveHcMedicinetypeInfo(HcMedicinetypeEntity hcMedicinetypeEntity, Database db, DbTransaction transaction)
		{
			string sql = "INSERT INTO HC_MedicineType ( MedicineTypeName, status) VALUES (  @Medicinetypename,  @Status )";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);

			db.AddInParameter(dbCommand, "Medicinetypename", DbType.String, hcMedicinetypeEntity.Medicinetypename);
			db.AddInParameter(dbCommand, "Status", DbType.String, hcMedicinetypeEntity.Status);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;		}

		public bool UpdateHcMedicinetypeInfo(HcMedicinetypeEntity hcMedicinetypeEntity, Database db, DbTransaction transaction)
		{
			string sql = "UPDATE HC_MedicineType SET MedicineTypeName= @Medicinetypename, status= @Status WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id",DbType.String, hcMedicinetypeEntity.Id);
			db.AddInParameter(dbCommand, "Medicinetypename", DbType.String, hcMedicinetypeEntity.Medicinetypename);
			db.AddInParameter(dbCommand, "Status", DbType.String, hcMedicinetypeEntity.Status);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public bool DeleteHcMedicinetypeInfoById(object param, Database db, DbTransaction transaction)
		{
			string sql = "DELETE FROM HC_MedicineType WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public HcMedicinetypeEntity GetSingleHcMedicinetypeRecordById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sql = "SELECT ID, MedicineTypeName, status FROM HC_MedicineType WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);
			HcMedicinetypeEntity hcMedicinetypeEntity = null;
			using (IDataReader dataReader = db.ExecuteReader(dbCommand))
			{
				if (dataReader.Read())
				{
					hcMedicinetypeEntity = new HcMedicinetypeEntity();
					if (dataReader["ID"] != DBNull.Value)
					{
						hcMedicinetypeEntity.Id = dataReader["ID"].ToString();
					}
					if (dataReader["MedicineTypeName"] != DBNull.Value)
					{
						hcMedicinetypeEntity.Medicinetypename = dataReader["MedicineTypeName"].ToString();
					}
					if (dataReader["status"] != DBNull.Value)
					{
						hcMedicinetypeEntity.Status = dataReader["status"].ToString();
					}
				}
			}
			return hcMedicinetypeEntity;
		}

		#endregion

	}
}

