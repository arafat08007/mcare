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
		public DataTable GetAllHcProductorderRecord(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();

            HcProductorderEntity obj = new HcProductorderEntity();
            if (param != null) obj = (HcProductorderEntity)param;

            string sql = "";
            if (!string.IsNullOrEmpty(obj.queryflag) && obj.queryflag == "distinct")
            {

                sql = @"SELECT DISTINCT   A.orderId, '' as ID, A.orderStatus, A.orderForUser, A.orderDate
                            FROM HC_ProductOrder A ,HC_Medicine B
                            where 1=1
                            and  A.productId = B.Id";

            }
            else
            {

                 sql = @"SELECT DISTINCT A.ID, A.orderId, A.productId,B.MedicineName, A.productQnty, A.productPrice, A.orderStatus, A.orderForUser, A.orderDate, A.updateBy, A.updateAt , B.ImageUrl
                            FROM HC_ProductOrder A ,HC_Medicine B
                            where 1=1
                            and  A.productId = B.Id";
            }

           


           

            if (!string.IsNullOrEmpty(obj.Orderid))
                sql += " And A.orderId = '" + obj.Orderid + "'";
            if (!string.IsNullOrEmpty(obj.Orderforuser))
                sql += " And A.orderForUser = '" + obj.Orderforuser + "'";
            if (!string.IsNullOrEmpty(obj.Productid))
                sql += " And A.productId = '" + obj.Productid + "'";
            if (!string.IsNullOrEmpty(obj.Orderdate))
                sql += " And A.orderDate = '" + obj.Orderdate + "'";

                sql += " Order by A.orderStatus asc";


			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			DataSet ds = db.ExecuteDataSet(dbCommand);
			return ds.Tables[0];
		}

	}
}

