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
	public partial class HcServicecenterDAL
	{
		public DataTable GetAllHcServicecenterRecord(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
            string sql = @"SELECT Distinct A.Id, A.serviceCenterName, A.serviceCenerAddress, A.Latitude, 
 A.Longitude, A.Phone, A.Email, A.ownerName, A.status, A.createdBy, A.createdAt, 
A.serviceType, B.Name as ServiceName, A.serviceTags FROM HC_ServiceCenter A, HC_Services B
where A.serviceType = B.ID";

            HcServicecenterEntity obj = new HcServicecenterEntity();
            if (param != null) obj = (HcServicecenterEntity)param;

            if (!string.IsNullOrEmpty(obj.Status))
                sql += " And A.Status = '" + obj.Status + "'";

            if (!string.IsNullOrEmpty(obj.Servicetype))
                sql += " And A.serviceType = '" + obj.Servicetype + "'";


			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			DataSet ds = db.ExecuteDataSet(dbCommand);
			return ds.Tables[0];
		}

	}
}

