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
	public partial class HcMedicineBLL
	{
		public object GetAllHcMedicineRecord(object param)
		{
			object retObj = null;
			HcMedicineDAL hcMedicineDAL = new HcMedicineDAL();
			retObj = (object)hcMedicineDAL.GetAllHcMedicineRecord(param);
			return retObj;
		}

	}
}

