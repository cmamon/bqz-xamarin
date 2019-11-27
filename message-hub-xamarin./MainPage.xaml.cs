
using System;
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
              
       
        }

        public String getfromserver()
        {

                 using (WebClient wc = new WebClient())
                {
                    var json = wc.DownloadString(Constants.address);

                    string[] words = json.Split(':');
                    Console.WriteLine(words);
                    Console.Read();
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
