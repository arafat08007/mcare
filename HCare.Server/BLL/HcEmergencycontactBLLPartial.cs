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
	public partial class HcEmergencycontactBLL
	{
		public object GetAllHcEmergencycontactRecord(object param)
		{
			object retObj = null;
			HcEmergencycontactDAL hcEmergencycontactDAL = new HcEmergencycontactDAL();
			retObj = (object)hcEmergencycontactDAL.GetAllHcEmergencycontactRecord(param);
			return retObj;
		}

	}
}

