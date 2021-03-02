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
	public partial class HcPaymentinfoDAL
	{
		#region Auto Generated 

		public bool SaveHcPaymentinfoInfo(HcPaymentinfoEntity hcPaymentinfoEntity, Database db, DbTransaction transaction)
		{
			string sql = "INSERT INTO HC_PaymentInfo ( paymentMethod, paymentStatus) VALUES (  @Paymentmethod,  @Paymentstatus )";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);

			db.AddInParameter(dbCommand, "Paymentmethod", DbType.String, hcPaymentinfoEntity.Paymentmethod);
			db.AddInParameter(dbCommand, "Paymentstatus", DbType.String, hcPaymentinfoEntity.Paymentstatus);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;		}

		public bool UpdateHcPaymentinfoInfo(HcPaymentinfoEntity hcPaymentinfoEntity, Database db, DbTransaction transaction)
		{
			string sql = "UPDATE HC_PaymentInfo SET paymentMethod= @Paymentmethod, paymentStatus= @Paymentstatus WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id",DbType.String, hcPaymentinfoEntity.Id);
			db.AddInParameter(dbCommand, "Paymentmethod", DbType.String, hcPaymentinfoEntity.Paymentmethod);
			db.AddInParameter(dbCommand, "Paymentstatus", DbType.String, hcPaymentinfoEntity.Paymentstatus);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public bool DeleteHcPaymentinfoInfoById(object param, Database db, DbTransaction transaction)
		{
			string sql = "DELETE FROM HC_PaymentInfo WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public HcPaymentinfoEntity GetSingleHcPaymentinfoRecordById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sql = "SELECT ID, paymentMethod, paymentStatus FROM HC_PaymentInfo WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);
			HcPaymentinfoEntity hcPaymentinfoEntity = null;
			using (IDataReader dataReader = db.ExecuteReader(dbCommand))
			{
				if (dataReader.Read())
				{
					hcPaymentinfoEntity = new HcPaymentinfoEntity();
					if (dataReader["ID"] != DBNull.Value)
					{
						hcPaymentinfoEntity.Id = dataReader["ID"].ToString();
					}
					if (dataReader["paymentMethod"] != DBNull.Value)
					{
						hcPaymentinfoEntity.Paymentmethod = dataReader["paymentMethod"].ToString();
					}
					if (dataReader["paymentStatus"] != DBNull.Value)
					{
						hcPaymentinfoEntity.Paymentstatus = dataReader["paymentStatus"].ToString();
					}
				}
			}
			return hcPaymentinfoEntity;
		}

		#endregion

	}
}

