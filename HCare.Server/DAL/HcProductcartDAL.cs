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
	public partial class HcProductcartDAL
	{
		#region Auto Generated 

        public object SaveHcProductcartInfo(HcProductcartEntity hcProductcartEntity, Database db, DbTransaction transaction)
		{
            string sql = "INSERT INTO HC_ProductCart ( productId, productName, productCategoryId, productCategoryName, productImageUrl, productPrice, productQnty, createdBy, createdAt, cartStatus) output inserted.ID VALUES (  @Productid,  @Productname,  @Productcategoryid,  @Productcategoryname,  @Productimageurl,  @Productprice,  @Productqnty,  @Createdby,  @Createdat,  @Cartstatus )";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);

			db.AddInParameter(dbCommand, "Productid", DbType.String, hcProductcartEntity.Productid);
			db.AddInParameter(dbCommand, "Productname", DbType.String, hcProductcartEntity.Productname);
			db.AddInParameter(dbCommand, "Productcategoryid", DbType.String, hcProductcartEntity.Productcategoryid);
			db.AddInParameter(dbCommand, "Productcategoryname", DbType.String, hcProductcartEntity.Productcategoryname);
			db.AddInParameter(dbCommand, "Productimageurl", DbType.String, hcProductcartEntity.Productimageurl);
			db.AddInParameter(dbCommand, "Productprice", DbType.String, hcProductcartEntity.Productprice);
			db.AddInParameter(dbCommand, "Productqnty", DbType.String, hcProductcartEntity.Productqnty);
			db.AddInParameter(dbCommand, "Createdby", DbType.String, hcProductcartEntity.Createdby);
			db.AddInParameter(dbCommand, "Createdat", DbType.String, hcProductcartEntity.Createdat);
			db.AddInParameter(dbCommand, "Cartstatus", DbType.String, hcProductcartEntity.Cartstatus);

			//db.ExecuteNonQuery(dbCommand, transaction);
			//return true;		
            var id = db.ExecuteScalar(dbCommand, transaction).ToString();
            return id;
        
        }

		public bool UpdateHcProductcartInfo(HcProductcartEntity hcProductcartEntity, Database db, DbTransaction transaction)
		{
			string sql = "UPDATE HC_ProductCart SET productId= @Productid, productName= @Productname, productCategoryId= @Productcategoryid, productCategoryName= @Productcategoryname, productImageUrl= @Productimageurl, productPrice= @Productprice, productQnty= @Productqnty, createdBy= @Createdby, createdAt= @Createdat, cartStatus= @Cartstatus WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id",DbType.String, hcProductcartEntity.Id);
			db.AddInParameter(dbCommand, "Productid", DbType.String, hcProductcartEntity.Productid);
			db.AddInParameter(dbCommand, "Productname", DbType.String, hcProductcartEntity.Productname);
			db.AddInParameter(dbCommand, "Productcategoryid", DbType.String, hcProductcartEntity.Productcategoryid);
			db.AddInParameter(dbCommand, "Productcategoryname", DbType.String, hcProductcartEntity.Productcategoryname);
			db.AddInParameter(dbCommand, "Productimageurl", DbType.String, hcProductcartEntity.Productimageurl);
			db.AddInParameter(dbCommand, "Productprice", DbType.String, hcProductcartEntity.Productprice);
			db.AddInParameter(dbCommand, "Productqnty", DbType.String, hcProductcartEntity.Productqnty);
			db.AddInParameter(dbCommand, "Createdby", DbType.String, hcProductcartEntity.Createdby);
			db.AddInParameter(dbCommand, "Createdat", DbType.String, hcProductcartEntity.Createdat);
			db.AddInParameter(dbCommand, "Cartstatus", DbType.String, hcProductcartEntity.Cartstatus);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public bool DeleteHcProductcartInfoById(object param, Database db, DbTransaction transaction)
		{
            string sql = "DELETE FROM HC_ProductCart WHERE  Id= @Id ";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public HcProductcartEntity GetSingleHcProductcartRecordById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sql = "SELECT ID, productId, productName, productCategoryId, productCategoryName, productImageUrl, productPrice, productQnty, createdBy, createdAt, cartStatus FROM HC_ProductCart WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);
			HcProductcartEntity hcProductcartEntity = null;
			using (IDataReader dataReader = db.ExecuteReader(dbCommand))
			{
				if (dataReader.Read())
				{
					hcProductcartEntity = new HcProductcartEntity();
					if (dataReader["ID"] != DBNull.Value)
					{
						hcProductcartEntity.Id = dataReader["ID"].ToString();
					}
					if (dataReader["productId"] != DBNull.Value)
					{
						hcProductcartEntity.Productid = dataReader["productId"].ToString();
					}
					if (dataReader["productName"] != DBNull.Value)
					{
						hcProductcartEntity.Productname = dataReader["productName"].ToString();
					}
					if (dataReader["productCategoryId"] != DBNull.Value)
					{
						hcProductcartEntity.Productcategoryid = dataReader["productCategoryId"].ToString();
					}
					if (dataReader["productCategoryName"] != DBNull.Value)
					{
						hcProductcartEntity.Productcategoryname = dataReader["productCategoryName"].ToString();
					}
					if (dataReader["productImageUrl"] != DBNull.Value)
					{
						hcProductcartEntity.Productimageurl = dataReader["productImageUrl"].ToString();
					}
					if (dataReader["productPrice"] != DBNull.Value)
					{
						hcProductcartEntity.Productprice = dataReader["productPrice"].ToString();
					}
					if (dataReader["productQnty"] != DBNull.Value)
					{
						hcProductcartEntity.Productqnty = dataReader["productQnty"].ToString();
					}
					if (dataReader["createdBy"] != DBNull.Value)
					{
						hcProductcartEntity.Createdby = dataReader["createdBy"].ToString();
					}
					if (dataReader["createdAt"] != DBNull.Value)
					{
						hcProductcartEntity.Createdat = dataReader["createdAt"].ToString();
					}
					if (dataReader["cartStatus"] != DBNull.Value)
					{
						hcProductcartEntity.Cartstatus = dataReader["cartStatus"].ToString();
					}
				}
			}
			return hcProductcartEntity;
		}

		#endregion

	}
}

