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
	public partial class HcPackagemasterBLL
	{
		public object GetAllHcPackagemasterRecord(object param)
		{
			object retObj = null;
			HcPackagemasterDAL hcPackagemasterDAL = new HcPackagemasterDAL();
			retObj = (object)hcPackagemasterDAL.GetAllHcPackagemasterRecord(param);
			return retObj;
		}

	}
}

