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
	public partial class HcGuidedetailsDAL
	{
		public DataTable GetAllHcGuidedetailsRecord(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sql = "SELECT id, refid, Chapter, ChapterDetails FROM HC_GuideDetails";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			DataSet ds = db.ExecuteDataSet(dbCommand);
			return ds.Tables[0];
		}

	}
}

