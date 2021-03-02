using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace HCare.Models
{
	public class HcDoctorTimesEntity
	{
		public string Id
		{
			get;
			set;
		}
		public string Doctorid
		{
			get;
			set;
		}
		public string Days
		{
			get;
			set;
		}
		public string Times
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

		public string QueryFlag { get; set; }

        public bool GetTimeByDay { get; set; }

    //public string Sunday { get; set; }
    //public string Monday { get; set; }
    //public string Tuesday { get; set; }
    //public string Wednesday { get; set; }
    //public string Thursday { get; set; }
    //public string Friday { get; set; }
    //public string Saturday { get; set; }

        public List<HcDoctorTimesEntity> TimeList { get; set; }

    }
}

