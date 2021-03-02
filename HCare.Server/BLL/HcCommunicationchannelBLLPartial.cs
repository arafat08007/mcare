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
	public partial class HcCommunicationchannelBLL
	{
		public object GetAllHcCommunicationchannelRecord(object param)
		{
			object retObj = null;
			HcCommunicationchannelDAL hcCommunicationchannelDAL = new HcCommunicationchannelDAL();
			retObj = (object)hcCommunicationchannelDAL.GetAllHcCommunicationchannelRecord(param);
			return retObj;
		}

	}
}

