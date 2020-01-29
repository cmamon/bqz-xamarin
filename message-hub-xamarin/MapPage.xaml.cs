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
            Position position = new Position(43.611000, 3.87058);
            MapSpan mapSpan = new MapSpan(position, 5.90, 3.00);
            Map map = new Map(mapSpan);
            double zoomLevel = 0.5;
            double latlongDegrees = 360 / (Math.Pow(2, zoomLevel));

            if (map.VisibleRegion != null) {
                map.MoveToRegion(new MapSpan(map.VisibleRegion.Center, latlongDegrees, latlongDegrees));
            }

            RefreshMap(map);
        }

        public void DisplayMap(Map map)
        {
            JArray json2 = getfromserver();

            List<Pin> pins = new List<Pin>(100);

            for (int i = 0; i < json2.Count; i++)
            {
                if ((double)json2[i].SelectToken("gps_lat") != 0 && (double)json2[i].SelectToken("gps_long") != 0)
                {
                    pins.Add(new Pin
                    {
                        Label = (String)json2[i].SelectToken("student_message"),
                        Address = (String)json2[i].SelectToken("student_id"),
                        Type = PinType.Place,
                        Position = new Position((double)json2[i].SelectToken("gps_lat"), (double)json2[i].SelectToken("gps_long"))

                    });
                }
            }

            foreach (Pin pi in pins)
            {
                map.Pins.Add(pi);
            }

            Content = map;
        }

        public void RefreshMap(Map map)
        {
            DisplayMap(map);

            Device.StartTimer(TimeSpan.FromSeconds(10), () => {
                Device.BeginInvokeOnMainThread(() => DisplayMap(map));
                return true;
            });
        }

        public JArray getfromserver()
        {
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(Constants.address);
                var json2 = JArray.Parse(json);

                return json2;
            }
        }
    }
}