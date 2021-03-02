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
	public partial class HcMedicahistoryBLL
	{
		public object GetAllHcMedicahistoryRecord(object param)
		{
			object retObj = null;
			HcMedicahistoryDAL hcMedicahistoryDAL = new HcMedicahistoryDAL();
			retObj = (object)hcMedicahistoryDAL.GetAllHcMedicahistoryRecord(param);
			return retObj;
		}

	}
}

