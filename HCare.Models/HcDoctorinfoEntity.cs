using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace HCare.Models
{
	public class HcDoctorinfoEntity
	{
        public string countryid;
        public string locationid;

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
		public string Department
		{
			get;
			set;
		}
		public string Specialist
		{
			get;
			set;
		}
        public string phone
        {
            get;
            set;
        }
		public string Education
		{
			get;
			set;
		}
		public string Experience
		{
			get;
			set;
		}
		public string About
		{
			get;
			set;
		}
		public string Fees
		{
			get;
			set;
		}
		public string Joindate
		{
			get;
			set;
		}
        public string Photo
		{
			get;
			set;
		}
		public string Gender
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

        public string DoctroRating
        {
            get;
            set;
        }

        public string Location
        {
            get;
            set;
        }

        public string Latitude
        {
            get;
            set;
        }
        public string Longitude
        {
            get;
            set;
        }

		public string Countryname { get; set; }
		public string Organizationname { get; set; }
		public string CFlag { get; set; }
		public string logo { get; set; }
		public string language { get; set; }






		public string JsonDetails { get; set; }
        public string QueryFlag { get; set; }
        public string filter
        {
            get;
            set;
        }
        public string Searchflag { get; set; }
    }
}

