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
	public partial class HcUserlabtestDAL
	{
		public DataTable GetAllHcUserlabtestRecord(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sql = "SELECT Id, testId, testCatId, createBy, created_at AS CreatedAt, updateBy, updateDate, testAmount, testFor, sampleCollectDate, sampleCollectTime, paymentType, status FROM HC_UserLabTest";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			DataSet ds = db.ExecuteDataSet(dbCommand);
			return ds.Tables[0];
		}

	}
}

