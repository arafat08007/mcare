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
	public partial class HcUsersDAL
	{
		public DataTable GetAllHcUsersRecord(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
            string sql = @"SELECT ID, userImageUrl, LogName, LogPass, SecurPass, Email, FirstName, LastName, Gender, Address, UserType, UserID, RoleID, IsActive, CreatedBy, CreatedTime, UpdatedBy, UpdatedTime, LastLogIn 
                , 'User Name' UserName
                FROM HC_Users Where 1=1";
            HcUsersEntity obj = new HcUsersEntity();
            if (param != null) obj = (HcUsersEntity)param;

            if (!string.IsNullOrEmpty(obj.Logname))
                sql += " And LogName = '" + obj.Logname + "'";
            if (!string.IsNullOrEmpty(obj.Logpass))
                sql += " And LogPass = '" + obj.Logpass + "'";
            if (!string.IsNullOrEmpty(obj.SecurPass))
                sql += " And SecurPass = '" + obj.SecurPass + "'";
            if (!string.IsNullOrEmpty(obj.Isactive))
                sql += " And IsActive = '" + obj.Isactive + "'";

            sql += " Order By LogName Asc";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			DataSet ds = db.ExecuteDataSet(dbCommand);
			return ds.Tables[0];
		}

	}
}

