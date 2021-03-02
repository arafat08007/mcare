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
	public partial class HcUsersBLL
	{
		public object GetAllHcUsersRecord(object param)
		{
			object retObj = null;
			HcUsersDAL hcUsersDAL = new HcUsersDAL();
			retObj = (object)hcUsersDAL.GetAllHcUsersRecord(param);
			return retObj;
		}

	}
}

