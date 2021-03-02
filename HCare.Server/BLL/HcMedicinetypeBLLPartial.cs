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
	public partial class HcMedicinetypeBLL
	{
		public object GetAllHcMedicinetypeRecord(object param)
		{
			object retObj = null;
			HcMedicinetypeDAL hcMedicinetypeDAL = new HcMedicinetypeDAL();
			retObj = (object)hcMedicinetypeDAL.GetAllHcMedicinetypeRecord(param);
			return retObj;
		}

	}
}

