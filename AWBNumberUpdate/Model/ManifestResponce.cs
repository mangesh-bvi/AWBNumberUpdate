using System;
using System.Collections.Generic;
using System.Text;

namespace AWBNumberUpdate.Model
{
    public class ManifestResponce
    {
        /// <summary>
        /// status
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// manifestUrl
        /// </summary>
        public string manifestUrl { get; set; }

        /// <summary>
        /// message
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// status_code
        /// </summary>
        public int status_code { get; set; }
    }
}
