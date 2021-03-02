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
	public partial class HcTestCategoryDAL
	{
		public DataTable GetAllHcTestCategoryRecord(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sql = "SELECT Id, catId, catTestType, catTestName, createBy, created_at AS CreatedAt, updateBy, updateDate FROM HC_Test_category";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			DataSet ds = db.ExecuteDataSet(dbCommand);
			return ds.Tables[0];
		}

	}
}

