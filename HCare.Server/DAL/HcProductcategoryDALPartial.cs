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
		public DataTable GetAllHcProductcategoryRecord(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
            string sql = @"SELECT ID, categoryName, status FROM HC_ProductCategory where 1=1";


            HcProductcategoryEntity obj = new HcProductcategoryEntity();
            if (param != null) obj = (HcProductcategoryEntity)param;


            if (!string.IsNullOrEmpty(obj.QueryFlag) && obj.QueryFlag == "All")
            {                
                    sql += " Order by categoryName Asc";
   
            }


            if (!string.IsNullOrEmpty(obj.Id) )
            {

                sql += " And ID = '" + obj.Id + "'";


            }


			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			DataSet ds = db.ExecuteDataSet(dbCommand);
			return ds.Tables[0];
		}

	}
}

