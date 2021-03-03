using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace HCare.Models
{
	public class HcMedicineEntity
	{
		public string Id
		{
			get;
			set;
		}
		public string Medicinename
		{
			get;
			set;
		}
		public string Medicinecompany
		{
			get;
			set;
		}
		public string Medicinetype
		{
			get;
			set;
		}
        public string Medicinetypename
        {
            get;
            set;
        }

		public string Productcategory
		{
			get;
			set;
		}
        public string Productcategoryname
        {
            get;
            set;
        }
		public string Medicineprice
		{
			get;
			set;
		}
		public string Medicineimage
		{
			get;
			set;
		}
		public string Uom
		{
			get;
			set;
		}
		public string Stockqnty
		{
			get;
			set;
		}
		public string Createdby
		{
			get;
			set;
		}
		public string Createdat
		{
			get;
			set;
		}
		public string Updateby
		{
			get;
			set;
		}
		public string Updatedat
		{
			get;
			set;
		}
		public string Status
		{
			get;
			set;
		}
        public string QueryFlag
        {
            get;
            set;
        }

        public string ImageUrl
        {
            get;
            set;
        }

        public string MedicineDesc
        {

            get;
            set;
        }


        public bool FullView { get; set; }

        public string ispromo { get; set; }
    }
}

