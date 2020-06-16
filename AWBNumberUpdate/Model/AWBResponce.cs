using System;
using System.Collections.Generic;
using System.Text;

namespace AWBNumberUpdate.Model
{
    public class AWBResponce
    {
        public string statusCode { get; set; }
        public data data { get; set; }
    }
    public class data
    {
        public string awb_code { get; set; }
        public string order_id { get; set; }
        public string shipment_id { get; set; }
        public string courier_company_id { get; set; }
        public string courier_name { get; set; }
        public string rate { get; set; }
        public string is_custom_rate { get; set; }
        public string cod_multiplier { get; set; }
        public string cod_charges { get; set; }
        public string freight_charge { get; set; }
        public string rto_charges { get; set; }
        public string min_weight { get; set; }
        public string etd_hours { get; set; }
        public string etd { get; set; }
        public string estimated_delivery_days { get; set; }
    }

}
