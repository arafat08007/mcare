using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCare.Models
{
    

    public class ProductOrderMaster
    {
        public string orderId { get; set; }
        public string orderForUser { get; set; }
        public string orderStatus { get; set; }
        public string orderDate { get; set; }
        public List<ProductorderDetails> OrderList { get; set; }
    }

    //A.ID, A.orderId, A.productId,B.MedicineName, A.productQnty, A.productPrice, A.orderStatus, A.orderForUser, A.orderDate, A.updateBy, A.updateAt, B.[ImageUrl] 

    public class ProductorderDetails
    {
        public string Id { get; set; }
        public string Productid { get; set; }
        public string MedicineName { get; set; }      
        public string Productimageurl { get; set; }
        public string Productprice { get; set; }
        public string Productqnty { get; set; }

       
      
    }

}
