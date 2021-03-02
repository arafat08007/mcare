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
	public partial class HcPackagemasterDAL
	{
		public DataTable GetAllHcPackagemasterRecord(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
            string sql = "SELECT id, PackageName, PackageShorDesc, PackagePrice, createdby, createdDate, updateby, updateDate, isactive, packageImage FROM HC_PackageMaster";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			DataSet ds = db.ExecuteDataSet(dbCommand);
			return ds.Tables[0];
		}

	}
}

