using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;


namespace AWBNumberUpdate.Model
{
    public class AWBRequest
    {
        /// <summary>
        /// pickup_postcode
        /// </summary>
        public int pickup_postcode { get; set; }

        /// <summary>
        /// delivery_postcode
        /// </summary>
        public int delivery_postcode { get; set; }

        /// <summary>
        /// weight
        /// </summary>
        public int weight { get; set; }

        /// <summary>
        /// orderDetails
        /// </summary>
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
        /// <summary>
        /// Id
        /// </summary>
        [JsonIgnore]
        public int Id { get; set; }
        /// <summary>
        /// TenantId
        /// </summary>
        [JsonIgnore]
        public int TenantId { get; set; }


        /// <summary>
        /// StoreId
        /// </summary>
        [JsonIgnore]
        public int StoreId { get; set; }

        /// <summary>
        /// StoreDelivery
        /// </summary>
        [JsonIgnore]
        public bool StoreDelivery { get; set; }


        /// <summary>
        /// order_id
        /// </summary>
        public string order_id { get; set; }

        /// <summary>
        /// order_date
        /// </summary>
        public string order_date { get; set; }
        /// <summary>
        /// pickup_location
        /// </summary>
        public string pickup_location { get; set; }
        /// <summary>
        /// channel_id
        /// </summary>
        public string channel_id { get; set; }
        /// <summary>
        /// billing_customer_name
        /// </summary>
        public string billing_customer_name { get; set; }
        /// <summary>
        /// billing_last_name
        /// </summary>
        public string billing_last_name { get; set; }
        /// <summary>
        /// billing_address
        /// </summary>
        public string billing_address { get; set; }

        /// <summary>
        /// billing_address_2
        /// </summary>
        public string billing_address_2 { get; set; }

        /// <summary>
        /// billing_city
        /// </summary>
        public string billing_city { get; set; }

        /// <summary>
        /// billing_pincode
        /// </summary>
        public string billing_pincode { get; set; }

        /// <summary>
        /// billing_state
        /// </summary>
        public string billing_state { get; set; }

        /// <summary>
        /// billing_country
        /// </summary>
        public string billing_country { get; set; }


        /// <summary>
        /// billing_email
        /// </summary>
        public string billing_email { get; set; }

        /// <summary>
        /// billing_phone
        /// </summary>
        public string billing_phone { get; set; }


        /// <summary>
        /// billing_alternate_phone
        /// </summary>
        public string billing_alternate_phone { get; set; }


        /// <summary>
        /// shipping_is_billing
        /// </summary>
        public bool shipping_is_billing { get; set; }

        /// <summary>
        /// shipping_customer_name
        /// </summary>
        public string shipping_customer_name { get; set; }


        /// <summary>
        /// shipping_last_name
        /// </summary>
        public string shipping_last_name { get; set; }

        /// <summary>
        /// shipping_address
        /// </summary>
        public string shipping_address { get; set; }

        /// <summary>
        /// shipping_address_2
        /// </summary>
        public string shipping_address_2 { get; set; }

        /// <summary>
        /// shipping_city
        /// </summary>
        public string shipping_city { get; set; }

        /// <summary>
        /// shipping_pincode
        /// </summary>
        public string shipping_pincode { get; set; }

        /// <summary>
        /// shipping_country
        /// </summary>
        public string shipping_country { get; set; }


        /// <summary>
        /// shipping_state
        /// </summary>
        public string shipping_state { get; set; }

        /// <summary>
        /// shipping_email
        /// </summary>
        public string shipping_email { get; set; }

        /// <summary>
        /// shipping_phone
        /// </summary>
        public string shipping_phone { get; set; }
        
        public List<order_items> order_items { get; set; }

        /// <summary>
        /// payment_method
        /// </summary>
        public string payment_method { get; set; }

        /// <summary>
        /// shipping_charges
        /// </summary>
        public int shipping_charges { get; set; }

        /// <summary>
        /// giftwrap_charges
        /// </summary>
        public int giftwrap_charges { get; set; }

        /// <summary>
        /// transaction_charges
        /// </summary>
        public int transaction_charges { get; set; }

        /// <summary>
        /// total_discount
        /// </summary>
        public int total_discount { get; set; }

        /// <summary>
        /// sub_total
        /// </summary>
        public int sub_total { get; set; }

        /// <summary>
        /// length
        /// </summary>
        public int length { get; set; }

        /// <summary>
        /// breadth
        /// </summary>
        public int breadth { get; set; }

        /// <summary>
        /// height
        /// </summary>
        public int height { get; set; }

        /// <summary>
        /// weight
        /// </summary>
        public decimal weight { get; set; }

        /// <summary>
        /// ProgramCode
        /// </summary>
        public string ProgramCode { get; set; }
    }
    public class order_items
    {

        /// <summary>
        /// OrderItemID
        /// </summary>
        [JsonIgnore]
        public int OrderItemID { get; set;}

        /// <summary>
        /// name
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// sku
        /// </summary>
        public string sku { get; set; }


        /// <summary>
        /// units
        /// </summary>
        public int units { get; set; }


        /// <summary>
        /// selling_price
        /// </summary>
        public string selling_price { get; set; }


        /// <summary>
        /// discount
        /// </summary>
        public int discount { get; set; }

        /// <summary>
        /// tax
        /// </summary>
        public int tax { get; set; }

        /// <summary>
        /// hsn
        /// </summary>
        public int hsn { get; set; }
    }
}
