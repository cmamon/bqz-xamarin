using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Newtonsoft.Json.Linq;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using System.Net;

namespace message_hub_xamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            Map map = new Map();

            JArray json2 = getfromserver();

            List<Pin> pins = new List<Pin>(100);


            for (int i = 0; i < json2.Count; i++)
            {

                pins.Add(new Pin
                {
                    Label = (String)json2[i].SelectToken("student_message"),
                    Address = "Côte d'Ivoire,Martinique,Congo Kinshasa",
                    Type = PinType.Place,
                    Position = new Position((double)json2[i].SelectToken("gps_lat"), (double)json2[i].SelectToken("gps_long"))

                });
                /*
                Console.WriteLine((String)json2[i].SelectToken("student_message"));
                Console.WriteLine((double)json2[i].SelectToken("gps_lat"));*/
            }

            foreach (Pin pi in pins)
            {
                map.Pins.Add(pi);
            }

            Content = map;

        }

        public JArray getfromserver()
        {

            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(Constants.address);
                // Console.WriteLine(json[0]);
                Console.WriteLine("blablabla");
                var json2 = JArray.Parse(json);


                //Console.WriteLine(i);
                //Console.WriteLine(json2[i].SelectToken("id"));

                //Gps_coordinnates[]



                // Console.WriteLine(json2[0].SelectToken("id"));
                // string zon = wc.DownloadString(Constants.address);
                /*
                     JArray jObject = JArray.Parse(json.ToString());
                     string id = (string)jObject.SelectToken("id");
                     string student_id = (string)jObject.SelectToken("student_id");
                     string gps_lat = (string)jObject.SelectToken("gps_lat");
                     string gps_long = (string)jObject.SelectToken("gps_long");
                     string student_message = (string)jObject.SelectToken("student_messsage");
                     
                     Console.WriteLine("{0}, {1}, {2},{3},{4}", id, student_id, gps_lat,gps_long,student_message);                
               */
                return json2;

            }



        }




    }
}