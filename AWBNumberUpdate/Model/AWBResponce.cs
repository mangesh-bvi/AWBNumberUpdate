using System;
using System.Collections.Generic;
using System.Text;

namespace AWBNumberUpdate.Model
{
    public class AWBResponce
    {
        /// <summary>
        /// statusCode
        /// </summary>
        public string statusCode { get; set; }

        /// <summary>
        /// data
        /// </summary>
        public data data { get; set; }
    }
    public class data
    {
        /// <summary>
        /// awb_code
        /// </summary>
        public string awb_code { get; set; }

        /// <summary>
        /// order_id
        /// </summary>
        public string order_id { get; set; }

        /// <summary>
        /// shipment_id
        /// </summary>
        public string shipment_id { get; set; }

        /// <summary>
        /// courier_company_id
        /// </summary>
        public string courier_company_id { get; set; }

        /// <summary>
        /// courier_name
        /// </summary>
        public string courier_name { get; set; }

        /// <summary>
        /// rate
        /// </summary>
        public string rate { get; set; }

        /// <summary>
        /// is_custom_rate
        /// </summary>
        public string is_custom_rate { get; set; }

        /// <summary>
        /// cod_multiplier
        /// </summary>
        public string cod_multiplier { get; set; }

        /// <summary>
        /// cod_charges
        /// </summary>
        public string cod_charges { get; set; }

        /// <summary>
        /// freight_charge
        /// </summary>
        public string freight_charge { get; set; }

        /// <summary>
        /// rto_charges
        /// </summary>
        public string rto_charges { get; set; }


        /// <summary>
        /// min_weight
        /// </summary>
        public string min_weight { get; set; }

        /// <summary>
        /// etd_hours
        /// </summary>
        public string etd_hours { get; set; }

        /// <summary>
        /// etd
        /// </summary>
        public string etd { get; set; }

        /// <summary>
        /// estimated_delivery_days
        /// </summary>
        public string estimated_delivery_days { get; set; }
    }

}
