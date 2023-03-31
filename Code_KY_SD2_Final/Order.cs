using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CsvHelper.Configuration.Attributes;


namespace Code_KY_SD2_Final
{
    public class Order
    {
        public int order_id { get; set; }
        public string customer_name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string size { get; set; }
        public string color { get; set; }
        public string style { get; set; }
        public string tv_show { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }
        public string fulfillment_type { get; set; }

        //public string FormatPhoneNumber()
        //{
        //    if (string.IsNullOrEmpty(phone))
        //    {
        //        return string.Empty;
        //    }

        //    var digitsOnly = new Regex(@"[^\d]");
        //    var phoneNumber = digitsOnly.Replace(phone, "");

        //    if (phoneNumber.Length != 10)
        //    {
        //        return phone;
        //    }

        //    return Regex.Replace(phoneNumber, @"(\d{3})(\d{3})(\d{4})", "($1) $2-$3");
        //}
        public string CleanPhoneNumber()
        {
            // Extract the extension, if present
            string extension = "";
            int extensionIndex = phone.LastIndexOf("x");
            if (extensionIndex != -1)
            {
                extension = phone.Substring(extensionIndex);
                phone = phone.Substring(0, extensionIndex);
            }

            // Remove all non-digit characters from the phone number
            string digitsOnly = Regex.Replace(phone, "[^0-9]", "");

            // Format the phone number
            string formatted = Regex.Replace(digitsOnly, @"(\d{3})(\d{3})(\d{4})", "($1) $2-$3");

            // Add the extension back, if present
            if (!string.IsNullOrEmpty(extension))
            {
                formatted += " " + extension;
            }

            return formatted;
        }

        //public string CleanPhoneNumber()
        //{
        //    string digitsOnly = Regex.Replace(phone, "[^0-9]", "");
        //    string formatted = Regex.Replace(digitsOnly, @"(\d{3})(\d{3})(\d{4})", "($1) $2-$3");
        //    return formatted;
        //}
    }


}





