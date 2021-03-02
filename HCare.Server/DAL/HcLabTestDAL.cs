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
	public partial class HcLabTestDAL
	{
		#region Auto Generated 

		public bool SaveHcLabTestInfo(HcLabTestEntity hcLabTestEntity, Database db, DbTransaction transaction)
		{
			string sql = "INSERT INTO HC_Lab_test ( Id, testId, testName, testAmount, testStatus, testCategory, createBy, created_at, updateBy, updateDate) VALUES (  @Id,  @Testid,  @Testname,  @Testamount,  @Teststatus,  @Testcategory,  @Createby,  @CreatedAt,  @Updateby,  @Updatedate )";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);

			db.AddInParameter(dbCommand, "Id", DbType.String, hcLabTestEntity.Id);
			db.AddInParameter(dbCommand, "Testid", DbType.String, hcLabTestEntity.Testid);
			db.AddInParameter(dbCommand, "Testname", DbType.String, hcLabTestEntity.Testname);
			db.AddInParameter(dbCommand, "Testamount", DbType.String, hcLabTestEntity.Testamount);
			db.AddInParameter(dbCommand, "Teststatus", DbType.String, hcLabTestEntity.Teststatus);
			db.AddInParameter(dbCommand, "Testcategory", DbType.String, hcLabTestEntity.Testcategory);
			db.AddInParameter(dbCommand, "Createby", DbType.String, hcLabTestEntity.Createby);
			db.AddInParameter(dbCommand, "CreatedAt", DbType.String, hcLabTestEntity.CreatedAt);
			db.AddInParameter(dbCommand, "Updateby", DbType.String, hcLabTestEntity.Updateby);
			db.AddInParameter(dbCommand, "Updatedate", DbType.String, hcLabTestEntity.Updatedate);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;		}

		public bool UpdateHcLabTestInfo(HcLabTestEntity hcLabTestEntity, Database db, DbTransaction transaction)
		{
			string sql = "UPDATE HC_Lab_test SET testId= @Testid, testName= @Testname, testAmount= @Testamount, testStatus= @Teststatus, testCategory= @Testcategory, createBy= @Createby, created_at= @CreatedAt, updateBy= @Updateby, updateDate= @Updatedate WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id",DbType.String, hcLabTestEntity.Id);
			db.AddInParameter(dbCommand, "Testid", DbType.String, hcLabTestEntity.Testid);
			db.AddInParameter(dbCommand, "Testname", DbType.String, hcLabTestEntity.Testname);
			db.AddInParameter(dbCommand, "Testamount", DbType.String, hcLabTestEntity.Testamount);
			db.AddInParameter(dbCommand, "Teststatus", DbType.String, hcLabTestEntity.Teststatus);
			db.AddInParameter(dbCommand, "Testcategory", DbType.String, hcLabTestEntity.Testcategory);
			db.AddInParameter(dbCommand, "Createby", DbType.String, hcLabTestEntity.Createby);
			db.AddInParameter(dbCommand, "CreatedAt", DbType.String, hcLabTestEntity.CreatedAt);
			db.AddInParameter(dbCommand, "Updateby", DbType.String, hcLabTestEntity.Updateby);
			db.AddInParameter(dbCommand, "Updatedate", DbType.String, hcLabTestEntity.Updatedate);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public bool DeleteHcLabTestInfoById(object param, Database db, DbTransaction transaction)
		{
			string sql = "DELETE FROM HC_Lab_test WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public HcLabTestEntity GetSingleHcLabTestRecordById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sql = "SELECT Id, testId, testName, testAmount, testStatus, testCategory, createBy, created_at, updateBy, updateDate FROM HC_Lab_test WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);
			HcLabTestEntity hcLabTestEntity = null;
			using (IDataReader dataReader = db.ExecuteReader(dbCommand))
			{
				if (dataReader.Read())
				{
					hcLabTestEntity = new HcLabTestEntity();
					if (dataReader["Id"] != DBNull.Value)
					{
						hcLabTestEntity.Id = dataReader["Id"].ToString();
					}
					if (dataReader["testId"] != DBNull.Value)
					{
						hcLabTestEntity.Testid = dataReader["testId"].ToString();
					}
					if (dataReader["testName"] != DBNull.Value)
					{
						hcLabTestEntity.Testname = dataReader["testName"].ToString();
					}
					if (dataReader["testAmount"] != DBNull.Value)
					{
						hcLabTestEntity.Testamount = dataReader["testAmount"].ToString();
					}
					if (dataReader["testStatus"] != DBNull.Value)
					{
						hcLabTestEntity.Teststatus = dataReader["testStatus"].ToString();
					}
					if (dataReader["testCategory"] != DBNull.Value)
					{
						hcLabTestEntity.Testcategory = dataReader["testCategory"].ToString();
					}
					if (dataReader["createBy"] != DBNull.Value)
					{
						hcLabTestEntity.Createby = dataReader["createBy"].ToString();
					}
					if (dataReader["created_at"] != DBNull.Value)
					{
						hcLabTestEntity.CreatedAt = dataReader["created_at"].ToString();
					}
					if (dataReader["updateBy"] != DBNull.Value)
					{
						hcLabTestEntity.Updateby = dataReader["updateBy"].ToString();
					}
					if (dataReader["updateDate"] != DBNull.Value)
					{
						hcLabTestEntity.Updatedate = dataReader["updateDate"].ToString();
					}
				}
			}
			return hcLabTestEntity;
		}

		#endregion

	}
}

