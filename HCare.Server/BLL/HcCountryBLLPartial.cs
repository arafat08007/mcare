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
	public partial class HcCountryBLL
	{
		public object GetAllHcCountryRecord(object param)
		{
			object retObj = null;
			HcCountryDAL hcCountryDAL = new HcCountryDAL();
			retObj = (object)hcCountryDAL.GetAllHcCountryRecord(param);
			return retObj;
		}

	}
}

