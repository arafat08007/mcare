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
	public partial class HcProductcategoryBLL
	{
		public object GetAllHcProductcategoryRecord(object param)
		{
			object retObj = null;
			HcProductcategoryDAL hcProductcategoryDAL = new HcProductcategoryDAL();
			retObj = (object)hcProductcategoryDAL.GetAllHcProductcategoryRecord(param);
			return retObj;
		}

	}
}

