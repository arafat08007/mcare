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
	public partial class HcServicecenterBLL
	{
		public object GetAllHcServicecenterRecord(object param)
		{
			object retObj = null;
			HcServicecenterDAL hcServicecenterDAL = new HcServicecenterDAL();
			retObj = (object)hcServicecenterDAL.GetAllHcServicecenterRecord(param);
			return retObj;
		}

	}
}

