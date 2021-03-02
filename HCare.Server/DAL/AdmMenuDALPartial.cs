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
	public partial class AdmMenuDAL
	{
		public DataTable GetAllAdmMenuRecord(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sql = @"SELECT ID, SortBy, MenuIcon, MenuName, MenuUrl, IsActive, CreatedBy, CreatedTime, UpdatedBy, UpdatedTime 
                FROM Adm_Menu Where 1=1";

            AdmMenuEntity obj = new AdmMenuEntity();
            if (param != null) obj = (AdmMenuEntity)param;

            if (!string.IsNullOrEmpty(obj.Isactive))
                sql += " And IsActive = '" + obj.Isactive + "'";

            sql += " Order By SortBy Asc";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			DataSet ds = db.ExecuteDataSet(dbCommand);
			return ds.Tables[0];
		}

	}
}

