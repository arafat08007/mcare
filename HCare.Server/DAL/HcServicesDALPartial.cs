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
	public partial class HcServicesDAL
	{
		public DataTable GetAllHcServicesRecord(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
            string sql = @"SELECT ID, Name, Description, Icon, Type, IsActive, CreatedBy, CreatedTime, UpdatedBy, UpdatedTime, SortBy, IsView, ViewBy, ViewTime 
                FROM HC_Services Where 1=1";

            HcServicesEntity obj = new HcServicesEntity();
            if (param != null) obj = (HcServicesEntity)param;

            if (!string.IsNullOrEmpty(obj.Isactive))
                sql += " And IsActive = '" + obj.Isactive + "'";
            if (!string.IsNullOrEmpty(obj.Isview))
                sql += " And IsView = '" + obj.Isview + "'";

            sql += string.IsNullOrEmpty(obj.Sortby) ? " Order By Name Asc" : " Order By SortBy Asc";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			DataSet ds = db.ExecuteDataSet(dbCommand);
			return ds.Tables[0];
		}

	}
}

