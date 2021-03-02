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
	public partial class HcUserlabtestDAL
	{
		#region Auto Generated 

		public bool SaveHcUserlabtestInfo(HcUserlabtestEntity hcUserlabtestEntity, Database db, DbTransaction transaction)
		{
			string sql = "INSERT INTO HC_UserLabTest ( Id, testId, testCatId, createBy, created_at, updateBy, updateDate, testAmount, testFor, sampleCollectDate, sampleCollectTime, paymentType, status) VALUES (  @Id,  @Testid,  @Testcatid,  @Createby,  @CreatedAt,  @Updateby,  @Updatedate,  @Testamount,  @Testfor,  @Samplecollectdate,  @Samplecollecttime,  @Paymenttype,  @Status )";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);

			db.AddInParameter(dbCommand, "Id", DbType.String, hcUserlabtestEntity.Id);
			db.AddInParameter(dbCommand, "Testid", DbType.String, hcUserlabtestEntity.Testid);
			db.AddInParameter(dbCommand, "Testcatid", DbType.String, hcUserlabtestEntity.Testcatid);
			db.AddInParameter(dbCommand, "Createby", DbType.String, hcUserlabtestEntity.Createby);
			db.AddInParameter(dbCommand, "CreatedAt", DbType.String, hcUserlabtestEntity.CreatedAt);
			db.AddInParameter(dbCommand, "Updateby", DbType.String, hcUserlabtestEntity.Updateby);
			db.AddInParameter(dbCommand, "Updatedate", DbType.String, hcUserlabtestEntity.Updatedate);
			db.AddInParameter(dbCommand, "Testamount", DbType.String, hcUserlabtestEntity.Testamount);
			db.AddInParameter(dbCommand, "Testfor", DbType.String, hcUserlabtestEntity.Testfor);
			db.AddInParameter(dbCommand, "Samplecollectdate", DbType.String, hcUserlabtestEntity.Samplecollectdate);
			db.AddInParameter(dbCommand, "Samplecollecttime", DbType.String, hcUserlabtestEntity.Samplecollecttime);
			db.AddInParameter(dbCommand, "Paymenttype", DbType.String, hcUserlabtestEntity.Paymenttype);
			db.AddInParameter(dbCommand, "Status", DbType.String, hcUserlabtestEntity.Status);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;		}

		public bool UpdateHcUserlabtestInfo(HcUserlabtestEntity hcUserlabtestEntity, Database db, DbTransaction transaction)
		{
			string sql = "UPDATE HC_UserLabTest SET testId= @Testid, testCatId= @Testcatid, createBy= @Createby, created_at= @CreatedAt, updateBy= @Updateby, updateDate= @Updatedate, testAmount= @Testamount, testFor= @Testfor, sampleCollectDate= @Samplecollectdate, sampleCollectTime= @Samplecollecttime, paymentType= @Paymenttype, status= @Status WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id",DbType.String, hcUserlabtestEntity.Id);
			db.AddInParameter(dbCommand, "Testid", DbType.String, hcUserlabtestEntity.Testid);
			db.AddInParameter(dbCommand, "Testcatid", DbType.String, hcUserlabtestEntity.Testcatid);
			db.AddInParameter(dbCommand, "Createby", DbType.String, hcUserlabtestEntity.Createby);
			db.AddInParameter(dbCommand, "CreatedAt", DbType.String, hcUserlabtestEntity.CreatedAt);
			db.AddInParameter(dbCommand, "Updateby", DbType.String, hcUserlabtestEntity.Updateby);
			db.AddInParameter(dbCommand, "Updatedate", DbType.String, hcUserlabtestEntity.Updatedate);
			db.AddInParameter(dbCommand, "Testamount", DbType.String, hcUserlabtestEntity.Testamount);
			db.AddInParameter(dbCommand, "Testfor", DbType.String, hcUserlabtestEntity.Testfor);
			db.AddInParameter(dbCommand, "Samplecollectdate", DbType.String, hcUserlabtestEntity.Samplecollectdate);
			db.AddInParameter(dbCommand, "Samplecollecttime", DbType.String, hcUserlabtestEntity.Samplecollecttime);
			db.AddInParameter(dbCommand, "Paymenttype", DbType.String, hcUserlabtestEntity.Paymenttype);
			db.AddInParameter(dbCommand, "Status", DbType.String, hcUserlabtestEntity.Status);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public bool DeleteHcUserlabtestInfoById(object param, Database db, DbTransaction transaction)
		{
			string sql = "DELETE FROM HC_UserLabTest WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public HcUserlabtestEntity GetSingleHcUserlabtestRecordById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sql = "SELECT Id, testId, testCatId, createBy, created_at, updateBy, updateDate, testAmount, testFor, sampleCollectDate, sampleCollectTime, paymentType, status FROM HC_UserLabTest WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);
			HcUserlabtestEntity hcUserlabtestEntity = null;
			using (IDataReader dataReader = db.ExecuteReader(dbCommand))
			{
				if (dataReader.Read())
				{
					hcUserlabtestEntity = new HcUserlabtestEntity();
					if (dataReader["Id"] != DBNull.Value)
					{
						hcUserlabtestEntity.Id = dataReader["Id"].ToString();
					}
					if (dataReader["testId"] != DBNull.Value)
					{
						hcUserlabtestEntity.Testid = dataReader["testId"].ToString();
					}
					if (dataReader["testCatId"] != DBNull.Value)
					{
						hcUserlabtestEntity.Testcatid = dataReader["testCatId"].ToString();
					}
					if (dataReader["createBy"] != DBNull.Value)
					{
						hcUserlabtestEntity.Createby = dataReader["createBy"].ToString();
					}
					if (dataReader["created_at"] != DBNull.Value)
					{
						hcUserlabtestEntity.CreatedAt = dataReader["created_at"].ToString();
					}
					if (dataReader["updateBy"] != DBNull.Value)
					{
						hcUserlabtestEntity.Updateby = dataReader["updateBy"].ToString();
					}
					if (dataReader["updateDate"] != DBNull.Value)
					{
						hcUserlabtestEntity.Updatedate = dataReader["updateDate"].ToString();
					}
					if (dataReader["testAmount"] != DBNull.Value)
					{
						hcUserlabtestEntity.Testamount = dataReader["testAmount"].ToString();
					}
					if (dataReader["testFor"] != DBNull.Value)
					{
						hcUserlabtestEntity.Testfor = dataReader["testFor"].ToString();
					}
					if (dataReader["sampleCollectDate"] != DBNull.Value)
					{
						hcUserlabtestEntity.Samplecollectdate = dataReader["sampleCollectDate"].ToString();
					}
					if (dataReader["sampleCollectTime"] != DBNull.Value)
					{
						hcUserlabtestEntity.Samplecollecttime = dataReader["sampleCollectTime"].ToString();
					}
					if (dataReader["paymentType"] != DBNull.Value)
					{
						hcUserlabtestEntity.Paymenttype = dataReader["paymentType"].ToString();
					}
					if (dataReader["status"] != DBNull.Value)
					{
						hcUserlabtestEntity.Status = dataReader["status"].ToString();
					}
				}
			}
			return hcUserlabtestEntity;
		}

		#endregion

	}
}

