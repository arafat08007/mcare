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
	public partial class HcCountryDAL
	{
		#region Auto Generated 

		public bool SaveHcCountryInfo(HcCountryEntity hcCountryEntity, Database db, DbTransaction transaction)
		{
			string sql = "INSERT INTO HC_Country ( Countryname, flag, IsActive) VALUES (  @Countryname,  @Flag,  @Isactive )";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);

			db.AddInParameter(dbCommand, "Countryname", DbType.String, hcCountryEntity.Countryname);
			db.AddInParameter(dbCommand, "Flag", DbType.String, hcCountryEntity.Flag);
			db.AddInParameter(dbCommand, "Isactive", DbType.String, hcCountryEntity.Isactive);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;		}

		public bool UpdateHcCountryInfo(HcCountryEntity hcCountryEntity, Database db, DbTransaction transaction)
		{
			string sql = "UPDATE HC_Country SET Countryname= @Countryname, flag= @Flag, IsActive= @Isactive WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id",DbType.String, hcCountryEntity.Id);
			db.AddInParameter(dbCommand, "Countryname", DbType.String, hcCountryEntity.Countryname);
			db.AddInParameter(dbCommand, "Flag", DbType.String, hcCountryEntity.Flag);
			db.AddInParameter(dbCommand, "Isactive", DbType.String, hcCountryEntity.Isactive);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public bool DeleteHcCountryInfoById(object param, Database db, DbTransaction transaction)
		{
			string sql = "DELETE FROM HC_Country WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public HcCountryEntity GetSingleHcCountryRecordById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sql = "SELECT ID, Countryname, flag, IsActive FROM HC_Country WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);
			HcCountryEntity hcCountryEntity = null;
			using (IDataReader dataReader = db.ExecuteReader(dbCommand))
			{
				if (dataReader.Read())
				{
					hcCountryEntity = new HcCountryEntity();
					if (dataReader["ID"] != DBNull.Value)
					{
						hcCountryEntity.Id = dataReader["ID"].ToString();
					}
					if (dataReader["Countryname"] != DBNull.Value)
					{
						hcCountryEntity.Countryname = dataReader["Countryname"].ToString();
					}
					if (dataReader["flag"] != DBNull.Value)
					{
						hcCountryEntity.Flag = dataReader["flag"].ToString();
					}
					if (dataReader["IsActive"] != DBNull.Value)
					{
						hcCountryEntity.Isactive = dataReader["IsActive"].ToString();
					}
				}
			}
			return hcCountryEntity;
		}

		#endregion

	}
}

