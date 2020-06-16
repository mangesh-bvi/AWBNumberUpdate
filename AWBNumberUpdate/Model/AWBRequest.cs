using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;


namespace AWBNumberUpdate.Model
{
    public class AWBRequest
    {
        public int pickup_postcode { get; set; }
        public int delivery_postcode { get; set; }
        public int weight { get; set; }
        public orderDetails orderDetails { get; set; }


    }
    public class CustomOrderMaster
    {
        /// <summary>
        /// Pick up Pin code
        /// </summary>
        public string PincodeID { get; set; }

        /// <summary>
        /// Delivery Pin code
        /// </summary>
        public string PinCode { get; set; }

        public List<orderDetails> orderDetails { get; set; }
    }
    public class orderDetails
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonIgnore]
        public int TenantId { get; set; }
        [JsonIgnore]
        public bool StoreDelivery { get; set; }

        public string order_id { get; set; }
        public string order_date { get; set; }
        public string pickup_location { get; set; }
        public string channel_id { get; set; }
        public string billing_customer_name { get; set; }
        public string billing_last_name { get; set; }
        public string billing_address { get; set; }
        public string billing_address_2 { get; set; }
        public string billing_city { get; set; }
        public string billing_pincode { get; set; }
        public string billing_state { get; set; }
        public string billing_country { get; set; }
        public string billing_email { get; set; }
        public string billing_phone { get; set; }
        public string billing_alternate_phone { get; set; }
        public bool shipping_is_billing { get; set; }
        public string shipping_customer_name { get; set; }
        public string shipping_last_name { get; set; }
        public string shipping_address { get; set; }
        public string shipping_address_2 { get; set; }
        public string shipping_city { get; set; }
        public string shipping_pincode { get; set; }
        public string shipping_country { get; set; }
        public string shipping_state { get; set; }
        public string shipping_email { get; set; }
        public string shipping_phone { get; set; }
        
        public List<order_items> order_items { get; set; }
        public string payment_method { get; set; }
        public int shipping_charges { get; set; }
        public int giftwrap_charges { get; set; }
        public int transaction_charges { get; set; }
        public int total_discount { get; set; }
        public int sub_total { get; set; }
        public int length { get; set; }
        public int breadth { get; set; }
        public int height { get; set; }
        public decimal weight { get; set; }
    }
    public class order_items
    {
        [JsonIgnore]
        public int OrderItemID { get; set;}
        public string name { get; set; }
        public string sku { get; set; }
        public int units { get; set; }
        public string selling_price { get; set; }
        public int discount { get; set; }
        public int tax { get; set; }
        public int hsn { get; set; }
    }
}
