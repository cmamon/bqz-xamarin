
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using Xamarin.Forms;


namespace message_hub_xamarin
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        protected Clientinfo Client;
        
        public MainPage()
        {
            InitializeComponent();
            //Xamarin.FormsMaps.Init("INSERT_AUTHENTICATION_TOKEN_HERE");
            //Xamarin.Forms.Maps


        }

        public String getfromserver()
        {
            
            using (WebClient wc = new WebClient())
                {
                     var json = wc.DownloadString(Constants.address);
                    // Console.WriteLine(json[0]);
                     Console.WriteLine("blablabla");
                     var json2 = JArray.Parse(json);
                     List<Object> Gps_coordinnates = new List<Object>(100);
                   
                    

                for (int i = 0; i < json2.Count; i++)
                {
            
                    Gps_coordinnates.Add(json2[i].SelectToken("gps_lat"));
                    Gps_coordinnates.Add(json2[i].SelectToken("gps_long"));
                    Gps_coordinnates.Add(json2[i].SelectToken("student_message"));
            
                }

                for(int i = 0; i < Gps_coordinnates.Count; i++)
                {
                    Console.WriteLine(Gps_coordinnates[i]);
                }

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
                return   json.ToString();
                    
                }

                 

     
        }

        void ButtonClicked(object sender, EventArgs e)
        {

            (sender as Button).Text = "clicked!";
  
            label3.Text = "ListOfMessages";
            label.Text = "";
            label2.Text = getfromserver();

        }

    
    }
}
