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
	public partial class HcTestCategoryDAL
	{
		#region Auto Generated 

		public bool SaveHcTestCategoryInfo(HcTestCategoryEntity hcTestCategoryEntity, Database db, DbTransaction transaction)
		{
			string sql = "INSERT INTO HC_Test_category ( Id, catId, catTestType, catTestName, createBy, created_at, updateBy, updateDate) VALUES (  @Id,  @Catid,  @Cattesttype,  @Cattestname,  @Createby,  @CreatedAt,  @Updateby,  @Updatedate )";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);

			db.AddInParameter(dbCommand, "Id", DbType.String, hcTestCategoryEntity.Id);
			db.AddInParameter(dbCommand, "Catid", DbType.String, hcTestCategoryEntity.Catid);
			db.AddInParameter(dbCommand, "Cattesttype", DbType.String, hcTestCategoryEntity.Cattesttype);
			db.AddInParameter(dbCommand, "Cattestname", DbType.String, hcTestCategoryEntity.Cattestname);
			db.AddInParameter(dbCommand, "Createby", DbType.String, hcTestCategoryEntity.Createby);
			db.AddInParameter(dbCommand, "CreatedAt", DbType.String, hcTestCategoryEntity.CreatedAt);
			db.AddInParameter(dbCommand, "Updateby", DbType.String, hcTestCategoryEntity.Updateby);
			db.AddInParameter(dbCommand, "Updatedate", DbType.String, hcTestCategoryEntity.Updatedate);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;		}

		public bool UpdateHcTestCategoryInfo(HcTestCategoryEntity hcTestCategoryEntity, Database db, DbTransaction transaction)
		{
			string sql = "UPDATE HC_Test_category SET catId= @Catid, catTestType= @Cattesttype, catTestName= @Cattestname, createBy= @Createby, created_at= @CreatedAt, updateBy= @Updateby, updateDate= @Updatedate WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id",DbType.String, hcTestCategoryEntity.Id);
			db.AddInParameter(dbCommand, "Catid", DbType.String, hcTestCategoryEntity.Catid);
			db.AddInParameter(dbCommand, "Cattesttype", DbType.String, hcTestCategoryEntity.Cattesttype);
			db.AddInParameter(dbCommand, "Cattestname", DbType.String, hcTestCategoryEntity.Cattestname);
			db.AddInParameter(dbCommand, "Createby", DbType.String, hcTestCategoryEntity.Createby);
			db.AddInParameter(dbCommand, "CreatedAt", DbType.String, hcTestCategoryEntity.CreatedAt);
			db.AddInParameter(dbCommand, "Updateby", DbType.String, hcTestCategoryEntity.Updateby);
			db.AddInParameter(dbCommand, "Updatedate", DbType.String, hcTestCategoryEntity.Updatedate);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public bool DeleteHcTestCategoryInfoById(object param, Database db, DbTransaction transaction)
		{
			string sql = "DELETE FROM HC_Test_category WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public HcTestCategoryEntity GetSingleHcTestCategoryRecordById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sql = "SELECT Id, catId, catTestType, catTestName, createBy, created_at, updateBy, updateDate FROM HC_Test_category WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);
			HcTestCategoryEntity hcTestCategoryEntity = null;
			using (IDataReader dataReader = db.ExecuteReader(dbCommand))
			{
				if (dataReader.Read())
				{
					hcTestCategoryEntity = new HcTestCategoryEntity();
					if (dataReader["Id"] != DBNull.Value)
					{
						hcTestCategoryEntity.Id = dataReader["Id"].ToString();
					}
					if (dataReader["catId"] != DBNull.Value)
					{
						hcTestCategoryEntity.Catid = dataReader["catId"].ToString();
					}
					if (dataReader["catTestType"] != DBNull.Value)
					{
						hcTestCategoryEntity.Cattesttype = dataReader["catTestType"].ToString();
					}
					if (dataReader["catTestName"] != DBNull.Value)
					{
						hcTestCategoryEntity.Cattestname = dataReader["catTestName"].ToString();
					}
					if (dataReader["createBy"] != DBNull.Value)
					{
						hcTestCategoryEntity.Createby = dataReader["createBy"].ToString();
					}
					if (dataReader["created_at"] != DBNull.Value)
					{
						hcTestCategoryEntity.CreatedAt = dataReader["created_at"].ToString();
					}
					if (dataReader["updateBy"] != DBNull.Value)
					{
						hcTestCategoryEntity.Updateby = dataReader["updateBy"].ToString();
					}
					if (dataReader["updateDate"] != DBNull.Value)
					{
						hcTestCategoryEntity.Updatedate = dataReader["updateDate"].ToString();
					}
				}
			}
			return hcTestCategoryEntity;
		}

		#endregion

	}
}

