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
	public partial class HcAboutDAL
	{
		public DataTable GetAllHcAboutRecord(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sql = "SELECT Id, about, mission, vision, contactinfo, phone1, phone2, email, website, address FROM HC_About";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			DataSet ds = db.ExecuteDataSet(dbCommand);
			return ds.Tables[0];
		}

	}
}

