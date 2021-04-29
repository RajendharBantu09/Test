using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridge.Model
{
    public class Products
    {
        public long ID { get; set; }
        public string ItemType { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public long Quantity { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public long  ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }


    }
}
