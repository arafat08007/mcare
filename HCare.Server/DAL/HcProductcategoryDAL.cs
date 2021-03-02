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
	public partial class HcProductcategoryDAL
	{
		#region Auto Generated 

		public bool SaveHcProductcategoryInfo(HcProductcategoryEntity hcProductcategoryEntity, Database db, DbTransaction transaction)
		{
			string sql = "INSERT INTO HC_ProductCategory ( categoryName, status) VALUES (  @Categoryname,  @Status )";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);

			db.AddInParameter(dbCommand, "Categoryname", DbType.String, hcProductcategoryEntity.Categoryname);
			db.AddInParameter(dbCommand, "Status", DbType.String, hcProductcategoryEntity.Status);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;		}

		public bool UpdateHcProductcategoryInfo(HcProductcategoryEntity hcProductcategoryEntity, Database db, DbTransaction transaction)
		{
			string sql = "UPDATE HC_ProductCategory SET categoryName= @Categoryname, status= @Status WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id",DbType.String, hcProductcategoryEntity.Id);
			db.AddInParameter(dbCommand, "Categoryname", DbType.String, hcProductcategoryEntity.Categoryname);
			db.AddInParameter(dbCommand, "Status", DbType.String, hcProductcategoryEntity.Status);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public bool DeleteHcProductcategoryInfoById(object param, Database db, DbTransaction transaction)
		{
			string sql = "DELETE FROM HC_ProductCategory WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public HcProductcategoryEntity GetSingleHcProductcategoryRecordById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();

            
			string sql = "SELECT ID, categoryName, status FROM HC_ProductCategory WHERE Id=@Id";



			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);
			HcProductcategoryEntity hcProductcategoryEntity = null;
			using (IDataReader dataReader = db.ExecuteReader(dbCommand))
			{
				if (dataReader.Read())
				{
					hcProductcategoryEntity = new HcProductcategoryEntity();
					if (dataReader["ID"] != DBNull.Value)
					{
						hcProductcategoryEntity.Id = dataReader["ID"].ToString();
					}
					if (dataReader["categoryName"] != DBNull.Value)
					{
						hcProductcategoryEntity.Categoryname = dataReader["categoryName"].ToString();
					}
					if (dataReader["status"] != DBNull.Value)
					{
						hcProductcategoryEntity.Status = dataReader["status"].ToString();
					}
				}
			}
			return hcProductcategoryEntity;
		}

		#endregion

	}
}

