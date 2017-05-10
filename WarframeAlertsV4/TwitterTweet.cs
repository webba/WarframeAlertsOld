using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarframeAlertsV4
{
    public class TwitterTweet
    {
        public TwitterTweet()
        {
        }
        public TwitterTweet(object obje)
        {
            Dictionary<string, object> d1 = (Dictionary<string, object>)obje;
            created_at = d1["created_at"].ToString();
            from_user = d1["from_user"].ToString();
            from_user_id = d1["from_user_id"].ToString();
            from_user_id_str = d1["from_user_id_str"].ToString();
            from_user_name = d1["from_user_name"].ToString();
            if (d1["geo"] != null)
                geo = d1["geo"].ToString();
            id = d1["id"].ToString();
            id_str = d1["id_str"].ToString();
            iso_language_code = d1["iso_language_code"].ToString();
            metadata = d1["metadata"];
            profile_image_url = d1["profile_image_url"].ToString();
            profile_image_url_https = d1["profile_image_url_https"].ToString();
            source = d1["source"].ToString();
            text = d1["text"].ToString();


        }
        public string created_at { get; set; }
        public string from_user { get; set; }
        public string from_user_id { get; set; }
        public string from_user_id_str { get; set; }
        public string from_user_name { get; set; }
        public string geo { get; set; }
        public string id { get; set; }
        public string id_str { get; set; }
        public string iso_language_code { get; set; }
        public object metadata { get; set; }
        public string profile_image_url { get; set; }
        public string profile_image_url_https { get; set; }
        public string source { get; set; }
        public string text { get; set; }

    }
}
