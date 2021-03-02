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
	public partial class HcEmergencycontactDAL
	{
		public DataTable GetAllHcEmergencycontactRecord(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
            string sql = @"

   SELECT A.ID, A.UserId, B.Address, A.userphone, B.postalcode, A.emergencyContactPerson, A.emergencycontactPhone, A.createdBy, A.createdAt, A.updateBy, A.upadateAt FROM HC_EmergencyContact A, [HC_Users] B
  where 1=1
  and A.UserId = B.ID";



            HcEmergencycontactEntity iGet = new HcEmergencycontactEntity();
            if (param != null) iGet = (HcEmergencycontactEntity)param;

            if (!string.IsNullOrEmpty(iGet.Userid))
                sql += " AND A.UserId = '" + iGet.Userid + "' ";

			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			DataSet ds = db.ExecuteDataSet(dbCommand);
			return ds.Tables[0];
		}

	}
}

