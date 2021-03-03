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
	public partial class HcDoctorinfoDAL
	{
		public DataTable GetAllHcDoctorinfoRecord(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
            string sql = @"SELECT distinct D.ID, D.Name, D.Department, D.Specialist, D.Education, D.Experience, D.About, D.Fees, D.JoinDate, D.Photo, D.Gender, D.IsActive, D.CreatedBy, D.CreatedTime, D.UpdatedBy, D.UpdatedTime, D.SortBy, D.IsView, D.ViewBy, D.ViewTime , D.Phone, D.Location,D.Latitude,D.Longitude,D.DoctroRating,E.Countryname, D.Country as countryid, F.Organizationname,
                (Select Name From HC_Doctor_Departments z Where z.ID = D.Department) DepartmentName,
                E.flag as CFlag , F.logo , D.language
                FROM HC_DoctorInfo D , 
                HC_Country E, HC_Organization F
                Where  D.Country = E.ID 
                and D.organization = F.ID
                and 1=1";

            HcDoctorinfoEntity obj = new HcDoctorinfoEntity();
            if (param != null) obj = (HcDoctorinfoEntity)param;
            if (string.IsNullOrEmpty(obj.Searchflag))
            {
                if (!string.IsNullOrEmpty(obj.Department))
                    sql += " And D.Department = '" + obj.Department + "'";
                if (!string.IsNullOrEmpty(obj.Isactive))
                    sql += " And D.IsActive = '" + obj.Isactive + "'";
                if (!string.IsNullOrEmpty(obj.Isview))
                    sql += " And D.IsView = '" + obj.Isview + "'";
                if (!string.IsNullOrEmpty(obj.Id))
                    sql += " And D.ID = '" + obj.Id + "'";
                // New filter params string latitude, string longitude, string Gender, string exp, string rating

                if (!string.IsNullOrEmpty(obj.Latitude))
                    sql += " And D.Latitude = '" + obj.Latitude + "'";
                if (!string.IsNullOrEmpty(obj.Longitude))
                    sql += " And D.Longitude = '" + obj.Longitude + "'";
                //New params--------------------------------------------------------------------------
                if (!string.IsNullOrEmpty(obj.Experience))
                    sql += " And D.Experience = '" + obj.Experience + "'";
                if (!string.IsNullOrEmpty(obj.DoctroRating))
                    sql += " And CAST(D.DoctroRating as DECIMAL(9,2))    = '" + obj.DoctroRating + "'";
                if (!string.IsNullOrEmpty(obj.Gender))
                    sql += " And D.Gender = '" + obj.Gender + "'";
                if (!string.IsNullOrEmpty(obj.Name))
                    sql += " And D.Name like  '%" + obj.Name + "%'";

                if (!string.IsNullOrEmpty(obj.countryid))
                    sql += " And D.Country ='" + obj.countryid + "'";
                if (!string.IsNullOrEmpty(obj.ispromo))
                    sql += " And D.ispromo ='" + obj.ispromo + "'";

                if (!string.IsNullOrEmpty(obj.Department))
                    sql += " And D.Department ='" + obj.Department + "'";
                if (!string.IsNullOrEmpty(obj.Location))
                    sql += " And D.Location like  '%" + obj.Location + "%'";
            }
            else {
                sql += " And UPPER(D.Name) like  Upper('%" + obj.Name + "%')";
                sql += " OR UPPER(D.Department) like  Upper('%" + obj.Name + "%')";
            }

                
                // sql += string.IsNullOrEmpty(obj.Sortby) ? " Order By D.Name Asc" : " Order By D.SortBy Asc";


                DbCommand dbCommand = db.GetSqlStringCommand(sql);
			DataSet ds = db.ExecuteDataSet(dbCommand);
			return ds.Tables[0];
		}

	}
}

