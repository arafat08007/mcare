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
	public partial class HcProductorderDAL
	{
		#region Auto Generated 

		public object SaveHcProductorderInfo(HcProductorderEntity hcProductorderEntity, Database db, DbTransaction transaction)
		{
            string sql = "INSERT INTO HC_ProductOrder ( orderId, productId, productQnty, productPrice, orderStatus, orderForUser, orderDate, updateBy, updateAt) output inserted.ID VALUES (  @Orderid,  @Productid,  @Productqnty,  @Productprice,  @Orderstatus,  @Orderforuser,  @Orderdate,  @Updateby,  @Updateat )";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);

			db.AddInParameter(dbCommand, "Orderid", DbType.String, hcProductorderEntity.Orderid);
			db.AddInParameter(dbCommand, "Productid", DbType.String, hcProductorderEntity.Productid);
			db.AddInParameter(dbCommand, "Productqnty", DbType.String, hcProductorderEntity.Productqnty);
			db.AddInParameter(dbCommand, "Productprice", DbType.String, hcProductorderEntity.Productprice);
			db.AddInParameter(dbCommand, "Orderstatus", DbType.String, hcProductorderEntity.Orderstatus);
			db.AddInParameter(dbCommand, "Orderforuser", DbType.String, hcProductorderEntity.Orderforuser);
			db.AddInParameter(dbCommand, "Orderdate", DbType.String, hcProductorderEntity.Orderdate);
			db.AddInParameter(dbCommand, "Updateby", DbType.String, hcProductorderEntity.Updateby);
			db.AddInParameter(dbCommand, "Updateat", DbType.String, hcProductorderEntity.Updateat);

			//db.ExecuteNonQuery(dbCommand, transaction);
			//return true;
            var id = db.ExecuteScalar(dbCommand, transaction).ToString();
            return id;
        
        
        }

		public bool UpdateHcProductorderInfo(HcProductorderEntity hcProductorderEntity, Database db, DbTransaction transaction)
		{
			string sql = "UPDATE HC_ProductOrder SET orderId= @Orderid, productId= @Productid, productQnty= @Productqnty, productPrice= @Productprice, orderStatus= @Orderstatus, orderForUser= @Orderforuser, orderDate= @Orderdate, updateBy= @Updateby, updateAt= @Updateat WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id",DbType.String, hcProductorderEntity.Id);
			db.AddInParameter(dbCommand, "Orderid", DbType.String, hcProductorderEntity.Orderid);
			db.AddInParameter(dbCommand, "Productid", DbType.String, hcProductorderEntity.Productid);
			db.AddInParameter(dbCommand, "Productqnty", DbType.String, hcProductorderEntity.Productqnty);
			db.AddInParameter(dbCommand, "Productprice", DbType.String, hcProductorderEntity.Productprice);
			db.AddInParameter(dbCommand, "Orderstatus", DbType.String, hcProductorderEntity.Orderstatus);
			db.AddInParameter(dbCommand, "Orderforuser", DbType.String, hcProductorderEntity.Orderforuser);
			db.AddInParameter(dbCommand, "Orderdate", DbType.String, hcProductorderEntity.Orderdate);
			db.AddInParameter(dbCommand, "Updateby", DbType.String, hcProductorderEntity.Updateby);
			db.AddInParameter(dbCommand, "Updateat", DbType.String, hcProductorderEntity.Updateat);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

        public bool DeleteHcProductorderInfoById(HcProductorderEntity hcProductorderEntity, Database db, DbTransaction transaction)
		{
            string sql = "DELETE FROM HC_ProductOrder WHERE orderId=@orderId and orderforuser = @Orderforuser ";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
            db.AddInParameter(dbCommand, "orderId", DbType.String, hcProductorderEntity.Orderid);
            db.AddInParameter(dbCommand, "Orderforuser", DbType.String, hcProductorderEntity.Orderforuser);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public HcProductorderEntity GetSingleHcProductorderRecordById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sql = "SELECT ID, orderId, productId, productQnty, productPrice, orderStatus, orderForUser, orderDate, updateBy, updateAt FROM HC_ProductOrder WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);
			HcProductorderEntity hcProductorderEntity = null;
			using (IDataReader dataReader = db.ExecuteReader(dbCommand))
			{
				if (dataReader.Read())
				{
					hcProductorderEntity = new HcProductorderEntity();
					if (dataReader["ID"] != DBNull.Value)
					{
						hcProductorderEntity.Id = dataReader["ID"].ToString();
					}
					if (dataReader["orderId"] != DBNull.Value)
					{
						hcProductorderEntity.Orderid = dataReader["orderId"].ToString();
					}
					if (dataReader["productId"] != DBNull.Value)
					{
						hcProductorderEntity.Productid = dataReader["productId"].ToString();
					}
					if (dataReader["productQnty"] != DBNull.Value)
					{
						hcProductorderEntity.Productqnty = dataReader["productQnty"].ToString();
					}
					if (dataReader["productPrice"] != DBNull.Value)
					{
						hcProductorderEntity.Productprice = dataReader["productPrice"].ToString();
					}
					if (dataReader["orderStatus"] != DBNull.Value)
					{
						hcProductorderEntity.Orderstatus = dataReader["orderStatus"].ToString();
					}
					if (dataReader["orderForUser"] != DBNull.Value)
					{
						hcProductorderEntity.Orderforuser = dataReader["orderForUser"].ToString();
					}
					if (dataReader["orderDate"] != DBNull.Value)
					{
						hcProductorderEntity.Orderdate = dataReader["orderDate"].ToString();
					}
					if (dataReader["updateBy"] != DBNull.Value)
					{
						hcProductorderEntity.Updateby = dataReader["updateBy"].ToString();
					}
					if (dataReader["updateAt"] != DBNull.Value)
					{
						hcProductorderEntity.Updateat = dataReader["updateAt"].ToString();
					}
				}
			}
			return hcProductorderEntity;
		}

		#endregion

	}
}

