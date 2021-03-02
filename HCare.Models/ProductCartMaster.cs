using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCare.Models
{

    public class ProductCartMaster
    {
        public string userId { get; set; }
        public List<ProductCartDetails> productList { get; set; }
    }


    public class ProductCartDetails
    {
        public string Id { get; set; }
        public string Productid { get; set; }
        public string Productname { get; set; }
        public string Productcategoryid { get; set; }
        public string Productcategoryname { get; set; }
        public string Productimageurl { get; set; }
        public string Productprice { get; set; }
        public string Productqnty { get; set; }
        public object Createdby { get; set; }
        public string Createdat { get; set; }
        public string Cartstatus { get; set; }
    }


  



}


// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 

