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
	public partial class AdmRoledetailsDAL
	{
		public DataTable GetAllAdmRoledetailsRecord(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
            string sql = @"SELECT D.ID, D.RoleId, D.FeatureId, D.IsView, D.IsAdd, D.IsEdit, D.IsDelete 
                FROM Adm_RoleDetails D
                Left Join Adm_RoleMaster M ON M.ID = D.RoleId Where 1=1";

            AdmRoledetailsEntity obj = new AdmRoledetailsEntity();
            if (param != null) obj = (AdmRoledetailsEntity)param;

            if (!string.IsNullOrEmpty(obj.Roleid))
                sql += " And D.RoleId = '" + obj.Roleid + "'";
            if (!string.IsNullOrEmpty(obj.Isview))
                sql += " And D.IsView = '" + obj.Isview + "'";
            if (!string.IsNullOrEmpty(obj.Isadd))
                sql += " And D.IsAdd = '" + obj.Isadd + "'";
            if (!string.IsNullOrEmpty(obj.Isedit))
                sql += " And D.IsEdit = '" + obj.Isedit + "'";
            if (!string.IsNullOrEmpty(obj.Isdelete))
                sql += " And D.IsDelete = '" + obj.Isdelete + "'";
            if (!string.IsNullOrEmpty(obj.Isactive))
                sql += " And M.IsActive = '" + obj.Isactive + "'";

			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			DataSet ds = db.ExecuteDataSet(dbCommand);
			return ds.Tables[0];
		}

	}
}

