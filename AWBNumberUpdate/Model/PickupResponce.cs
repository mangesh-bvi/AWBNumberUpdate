using System;
using System.Collections.Generic;
using System.Text;

namespace AWBNumberUpdate.Model
{
    public class PickupResponce
    {
        public string statusCode { get; set; }
        public string data { get; set; }
        public response response { get; set; }
    }
    public class response
    {
        public string pickupTokenNumber { get; set; }
        public string pickupScheduledDate { get; set; }
        public string status { get; set; }
        public pickupGeneratedDate pickupGeneratedDate { get; set; }
    }
    public class pickupGeneratedDate
    {
        public string date { get; set; }
        public string timezoneType { get; set; }
        public string timezone { get; set; }
    }
}

