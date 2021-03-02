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
	public partial class HcPackagedetailsDAL
	{
		public DataTable GetAllHcPackagedetailsRecord(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sql = "SELECT Id, refid, PackageCovers, PackageIncludes, PackageProcess, LabPartner, Packagebenifits, createdby, createdDate, updateby, updateDate, isactive FROM HC_PackageDetails";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			DataSet ds = db.ExecuteDataSet(dbCommand);
			return ds.Tables[0];
		}

	}
}

