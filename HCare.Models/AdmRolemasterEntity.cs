using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace HCare.Models
{
	public class AdmRolemasterEntity
	{
		public string Id
		{
			get;
			set;
		}
		public string Rolename
		{
			get;
			set;
		}
		public string Roledescription
		{
			get;
			set;
		}
        public string DefaultBoard
		{
			get;
			set;
		}
        public string AllDashboard
		{
			get;
			set;
		}
		public string Isactive
		{
			get;
			set;
		}
		public string Createdby
		{
			get;
			set;
		}
		public string Createdtime
		{
			get;
			set;
		}
		public string Updatedby
		{
			get;
			set;
		}
		public string Updatedtime
		{
			get;
			set;
		}

        public string JsonDetails { get; set; }
	}
}

