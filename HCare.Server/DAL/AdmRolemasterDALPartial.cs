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
	public partial class AdmRolemasterDAL
	{
		public DataTable GetAllAdmRolemasterRecord(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
            string sql = @"SELECT ID, RoleName, RoleDescription, DefaultBoard, AllDashboard, IsActive, CreatedBy, CreatedTime, UpdatedBy, UpdatedTime 
                FROM Adm_RoleMaster Where 1=1";

            AdmRolemasterEntity obj = new AdmRolemasterEntity();
            if (param != null) obj = (AdmRolemasterEntity)param;

            if (!string.IsNullOrEmpty(obj.Isactive))
                sql += " And IsActive = '" + obj.Isactive + "'";

            sql += " Order By RoleName Asc";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			DataSet ds = db.ExecuteDataSet(dbCommand);
			return ds.Tables[0];
		}

	}
}

