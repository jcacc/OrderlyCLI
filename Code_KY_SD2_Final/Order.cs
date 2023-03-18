using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_KY_SD2_Final
{
    public class Order
    {
        public int Id { get; set; }
        public string FulfillmentType { get; set; }
        public string ShippingMethod { get; set; }
        public string CustomerName { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
    }

}
