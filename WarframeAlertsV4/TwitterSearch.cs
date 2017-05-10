using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarframeAlertsV4
{
    public class TwitterSearch
    {
        public TwitterSearch()
        {
        }
        public string completed_in { get; set; }
        public string max_id { get; set; }
        public string max_id_str { get; set; }
        public string next_page { get; set; }
        public string page { get; set; }
        public string query { get; set; }
        public string refresh_url { get; set; }
        public object[] results { get; set; }
        public string results_per_page { get; set; }
        public string since_id { get; set; }
        public string since_id_str { get; set; }

    }
}
