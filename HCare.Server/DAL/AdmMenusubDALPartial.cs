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
	public partial class AdmMenusubDAL
	{
		public DataTable GetAllAdmMenusubRecord(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
            string sql = @"SELECT D.ID, D.MenuId, D.SortBy, D.SubIcon, D.SubName, D.SubUrl, D.IsActive, D.CreatedBy, D.CreatedTime, D.UpdatedBy, D.UpdatedTime 
                , M.MenuName
                FROM Adm_MenuSub D
                Left Join Adm_Menu M ON M.ID = D.MenuId Where 1=1";

            AdmMenusubEntity obj = new AdmMenusubEntity();
            if (param != null) obj = (AdmMenusubEntity)param;

            if (!string.IsNullOrEmpty(obj.Menuid))
                sql += " And D.MenuId = '" + obj.Menuid + "'";
            if (!string.IsNullOrEmpty(obj.Isactive))
                sql += " And D.IsActive = '" + obj.Isactive + "' And M.IsActive = '" + obj.Isactive + "'";

            sql += " Order By M.SortBy Asc, D.SortBy Asc";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			DataSet ds = db.ExecuteDataSet(dbCommand);
			return ds.Tables[0];
		}

	}
}

