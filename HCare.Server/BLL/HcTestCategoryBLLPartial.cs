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
	public partial class HcTestCategoryBLL
	{
		public object GetAllHcTestCategoryRecord(object param)
		{
			object retObj = null;
			HcTestCategoryDAL hcTestCategoryDAL = new HcTestCategoryDAL();
			retObj = (object)hcTestCategoryDAL.GetAllHcTestCategoryRecord(param);
			return retObj;
		}

	}
}

