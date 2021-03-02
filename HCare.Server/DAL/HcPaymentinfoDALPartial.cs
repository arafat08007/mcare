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
	public partial class HcPaymentinfoDAL
	{
		public DataTable GetAllHcPaymentinfoRecord(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sql = "SELECT ID, paymentMethod, paymentStatus FROM HC_PaymentInfo";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			DataSet ds = db.ExecuteDataSet(dbCommand);
			return ds.Tables[0];
		}

	}
}

