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
	public partial class HcServicesBLL
	{
		public object GetAllHcServicesRecord(object param)
		{
			object retObj = null;
			HcServicesDAL hcServicesDAL = new HcServicesDAL();
			retObj = (object)hcServicesDAL.GetAllHcServicesRecord(param);
			return retObj;
		}

	}
}

