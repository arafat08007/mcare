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
	public partial class HcProductcartBLL
	{
		public object GetAllHcProductcartRecord(object param)
		{
			object retObj = null;
			HcProductcartDAL hcProductcartDAL = new HcProductcartDAL();
			retObj = (object)hcProductcartDAL.GetAllHcProductcartRecord(param);
			return retObj;
		}

	}
}

