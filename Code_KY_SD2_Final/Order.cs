using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration.Attributes;


namespace Code_KY_SD2_Final
{
    public class Order
    {
        [Name("order_id")]
        public int OrderId { get; set; }

        [Name("customer_name")]
        public string CustomerName { get; set; }

        [Name("email")]
        public string Email { get; set; }

        [Name("phone")]
        public string Phone { get; set; }

        [Name("address")]
        public string Address { get; set; }

        [Name("size")]
        public string Size { get; set; }

        [Name("color")]
        public string Color { get; set; }

        [Name("style")]
        public string Style { get; set; }

        [Name("tv_show")]
        public string TvShow { get; set; }

        [Name("quantity")]
        public int Quantity { get; set; }

        [Name("price")]
        public decimal Price { get; set; }

        [Name("fulfillment_type")]
        public string FulfillmentType { get; set; }
    }



}
