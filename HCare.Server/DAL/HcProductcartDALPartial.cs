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
		public DataTable GetAllHcProductcartRecord(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
            string sql = @"SELECT A.ID, A.productId,B.MedicineName,  A.productCategoryId,  C.categoryName, B.ImageUrl, A.productPrice, A.productQnty, A.createdBy, A.createdAt, A.cartStatus 
                            FROM HC_ProductCart A, HC_Medicine B , HC_ProductCategory C
                            where A.productId = B.Id
                            AND A.productCategoryId = C.Id
                            and 1=1";

            HcProductcartEntity obj = new HcProductcartEntity();
            if (param != null) obj = (HcProductcartEntity)param;

            if (!string.IsNullOrEmpty(obj.Createdby))
                sql += " And A.createdBy = '" + obj.Createdby + "'";
            if (!string.IsNullOrEmpty(obj.Productid))
                sql += " And A.productId = '" + obj.Productid + "'";
            if (!string.IsNullOrEmpty(obj.Id))
                sql += " And A.ID ='" + obj.Id + "'";
            if (!string.IsNullOrEmpty(obj.Productid))
                sql += " And A.cartStatus = 'Pending'";


            


			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			DataSet ds = db.ExecuteDataSet(dbCommand);
			return ds.Tables[0];
		}

	}
}

