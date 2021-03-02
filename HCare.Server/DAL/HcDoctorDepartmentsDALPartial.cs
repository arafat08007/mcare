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
	public partial class HcDoctorDepartmentsDAL
	{
		public DataTable GetAllHcDoctorDepartmentsRecord(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sql = @"SELECT ID, Name, About, dept_image, COALESCE(full_desc,null,'Nothing found') as full_desc, IsActive, CreatedBy, CreatedTime, UpdatedBy, UpdatedTime 
                FROM HC_Doctor_Departments Where 1=1";

            HcDoctorDepartmentsEntity obj = new HcDoctorDepartmentsEntity();
            if (param != null) obj = (HcDoctorDepartmentsEntity)param;

            if (!string.IsNullOrEmpty(obj.Isactive))
                sql += " And IsActive = '" + obj.Isactive + "'";
			if (!string.IsNullOrEmpty(obj.Id))
				sql += " And ID = '" + obj.Id + "'";

			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			DataSet ds = db.ExecuteDataSet(dbCommand);
			return ds.Tables[0];
		}

	}
}

