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
	public partial class AdmMenusubBLL
	{
		public object GetAllAdmMenusubRecord(object param)
		{
			object retObj = null;
			AdmMenusubDAL admMenusubDAL = new AdmMenusubDAL();
			retObj = (object)admMenusubDAL.GetAllAdmMenusubRecord(param);
			return retObj;
		}

	}
}

