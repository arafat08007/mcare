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
	public partial class AdmMenuBLL
	{
		public object GetAllAdmMenuRecord(object param)
		{
			object retObj = null;
			AdmMenuDAL admMenuDAL = new AdmMenuDAL();
			retObj = (object)admMenuDAL.GetAllAdmMenuRecord(param);
			return retObj;
		}

	}
}

