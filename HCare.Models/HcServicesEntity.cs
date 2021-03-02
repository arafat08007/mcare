using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace HCare.Models
{
	public class HcServicesEntity
	{
		public string Id
		{
			get;
			set;
		}
		public string Name
		{
			get;
			set;
		}
		public string Description
		{
			get;
			set;
		}
		public string Icon
		{
			get;
			set;
		}
        public string Type
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
        public string Sortby
		{
			get;
			set;
		}
		public string Isview
		{
			get;
			set;
		}
		public string Viewby
		{
			get;
			set;
		}
		public string Viewtime
		{
			get;
			set;
		}

        public string JsonDetails { get; set; }
		public string QueryFlag { get; set; }
	}
}

