﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AWBNumberUpdate.Model
{
    public class HSChkCourierAvailibilty
    {
        /// <summary>
        /// Pickup_postcode
        /// </summary>
        public int Pickup_postcode { get; set; }

        /// <summary>
        /// Delivery_postcode
        /// </summary>
        public int Delivery_postcode { get; set; }

        /// <summary>
        /// Cod
        /// </summary>
        public int Cod { get; set; }

        /// <summary>
        /// Weight
        /// </summary>
        public decimal Weight { get; set; }
    }
    public class ResponseCourierAvailibilty
    {
        /// <summary>
        /// StatusCode
        /// </summary>
        public string StatusCode { get; set; }

        /// <summary>
        /// Available
        /// </summary>
        public string Available { get; set; }


        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; }
    }
}
