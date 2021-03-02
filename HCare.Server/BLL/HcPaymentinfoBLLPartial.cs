using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCare.Models;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using HCare.Server.DAL;

namespace HCare.Server.BLL
{
	public partial class HcPaymentinfoBLL
	{
		public object GetAllHcPaymentinfoRecord(object param)
		{
			object retObj = null;
			HcPaymentinfoDAL hcPaymentinfoDAL = new HcPaymentinfoDAL();
			retObj = (object)hcPaymentinfoDAL.GetAllHcPaymentinfoRecord(param);
			return retObj;
		}

	}
}

