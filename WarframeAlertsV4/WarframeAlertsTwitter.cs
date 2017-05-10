using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Net;
using System.Web.Script.Serialization;

namespace WarframeAlertsV4
{
    public class WarframeAlertsTwitter
    {
        private static WebClient client = new WebClient();
        private static JavaScriptSerializer Serializer = new JavaScriptSerializer();
        public static string FetchCurrentAlerts(bool ShowAll)
        {
            string s = "";
            string line = "";
            string location = "";
            string rewards = "";
            string timeremaining = "";
            string[] seperator = { " - " };
            string[] seperator2 = { ": " };
            string[] seperator3 = { "(" };
            string[] seperator4 = { ")" };
            string[] temp;
            double temptime;
            TimeSpan tspan = new TimeSpan();
            TwitterTweet[] Tweets = GetLast15Tweets();
            if (Tweets.Length == 0)
                return string.Empty;
            foreach (TwitterTweet r in Tweets)
            {
                temp = r.text.Split(seperator2, StringSplitOptions.None)[1].Split(seperator, StringSplitOptions.None);
                location = r.text.Split(seperator2, StringSplitOptions.None)[0].Split(seperator3, StringSplitOptions.None)[1].Split(seperator4, StringSplitOptions.None)[0];
                tspan = Convert.ToDateTime(r.created_at) - DateTime.Now;
                temptime = tspan.TotalMinutes + Convert.ToInt32(temp[1].Substring(0, temp[1].Length - 1));
                if (temptime > 0)
                    timeremaining = temptime.ToString();
                else
                    timeremaining = "";
                switch (temp.Length)
                {
                    case 3:
                        if (ShowAll)
                            rewards = temp[2];
                        else
                            rewards = "";
                        break;
                    case 4:
                        /*if (ShowAll)
                            rewards = temp[2] + " + " + temp[3];
                        else
                            rewards = temp[3];*/
                        rewards = temp[3];
                        break;
                    default:
                        rewards = "";
                        break;
                }
                if (rewards != "" & timeremaining != "")
                {
                    line = string.Format("{0}     \t\t{1}m   \t\t{2}", location, timeremaining.Substring(0, 5), rewards);
                    s += line + "\n";
                }
            }
            return s;
        }
        public static TwitterTweet[] GetLast15Tweets()
        {
            object[] o;
            try
            {
                string s = client.DownloadString(@"http://api.twitter.com/1.1/search/tweets.json?q=from:warframealerts");
                TwitterSearch obj = Serializer.Deserialize<TwitterSearch>(s);
                o = obj.results;
            }
            catch (WebException ex)
            {
                LogException(ex.ToString());
                o = null;
            }

            List<TwitterTweet> Tweets = new List<TwitterTweet>();
            try
            {
                foreach (object r in o)
                {
                    TwitterTweet rr = new TwitterTweet(r);
                    Tweets.Add(rr);
                }
            }
            catch (NullReferenceException ex)
            {
                LogException(ex.ToString());
            }
            TwitterTweet[] tweets = Tweets.ToArray();
            return tweets;
        }
        private static void LogException(string s)
        {
            Console.WriteLine(s);
        }
    }
}
