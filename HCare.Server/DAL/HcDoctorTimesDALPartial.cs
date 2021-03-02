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
	public partial class HcDoctorTimesDAL
	{
		public DataTable GetAllHcDoctorTimesRecord(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
            string sql = @"SELECT T.ID, T.DoctorID, T.Days, T.Times, T.IsActive, T.CreatedBy, T.CreatedTime, T.UpdatedBy, T.UpdatedTime 
                , (Select Name From HC_DoctorInfo z Where z.ID = T.DoctorID) DoctorName
                FROM HC_Doctor_Times T Where 1=1";

            HcDoctorTimesEntity obj = new HcDoctorTimesEntity();
            if (param != null) obj = (HcDoctorTimesEntity)param;


            //------ Call Other Functions
            //------------------------------

            if (obj.GetTimeByDay)
                return GetAllHcDoctorTimesRecord_ByDay(param);

            //--------------------------



            if (!string.IsNullOrEmpty(obj.Doctorid))
                sql += " And T.DoctorID = '" + obj.Doctorid + "'";
            if (!string.IsNullOrEmpty(obj.Days))
                sql += " And T.Days = '" + obj.Days + "'";
            if (!string.IsNullOrEmpty(obj.Isactive))
                sql += " And T.IsActive = '" + obj.Isactive + "'";

            sql += " Order By T.Days Asc, T.Times Asc";

            if (obj.QueryFlag == "DayOfWeek")
            {
                sql = "Select distinct stuff(( select distinct ', ' + Days from HC_Doctor_Times Where 1=1";
                if (!string.IsNullOrEmpty(obj.Doctorid))
                    sql += " And DoctorID = '" + obj.Doctorid + "'";
                sql += " for xml path('') ), 1, 2, '') DayOfWeek from HC_Doctor_Times T Where 1=1";
                if (!string.IsNullOrEmpty(obj.Doctorid))
                    sql += " And T.DoctorID = '" + obj.Doctorid + "'";
            }
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			DataSet ds = db.ExecuteDataSet(dbCommand);
			return ds.Tables[0];
		}
        public DataTable GetAllHcDoctorTimesRecord_ByDay(object param)
        {
            HcDoctorTimesEntity obj = new HcDoctorTimesEntity();
            if (param != null) obj = (HcDoctorTimesEntity)param;

            Database db = DatabaseFactory.CreateDatabase();
            string sql = @"select * from (
select Days,Times from HC_Doctor_Times 
where DoctorID = '" + obj.Doctorid + "'";
            sql += @" ) A
PIVOT
(
max(Times)
FOR days IN ([Sunday], [Monday],[Tuesday],[Wednesday],[Thursday],[Friday],[Saturday])
) AS PivotTable
 ";


            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            DataSet ds = db.ExecuteDataSet(dbCommand);
            return ds.Tables[0];
        }


	}
}

