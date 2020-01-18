﻿
using Newtonsoft.Json;
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

        ActivityIndicator activityIndicator = new ActivityIndicator
        {
            IsRunning = false
        };

        public MainPage()
        {
            InitializeComponent();
            //Xamarin.FormsMaps.Init("INSERT_AUTHENTICATION_TOKEN_HERE");
            //Xamarin.Forms.Maps
            RefreshMessageList();
        }

        class Message
        {
            public Message(string Id, string StudentId, string GpsLat, string GpsLng, string StudentMessage)
            {
                this.Id = Id;
                this.StudentId = StudentId;
                this.GpsLat = GpsLat;
                this.GpsLng = GpsLng;
                this.StudentMessage = StudentMessage;
            }

            public string Id { get; set; }
            public string StudentId { get; set; }
            public string GpsLat { get; set; }
            public string GpsLng { get; set; }
            public string StudentMessage { get; set; }
        }

        public string getMessages()
        {
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(Constants.address);
                return json;
            }
        }

        void RefreshMessageList()
        {
            activityIndicator.IsRunning = true;
            var messages = getMessages();
            activityIndicator.IsRunning = false;

            ShowMessageList(messages);

            // Refresh message list each 30 seconds
            Device.StartTimer(TimeSpan.FromSeconds(30), () => {
                Device.BeginInvokeOnMainThread(() => ShowMessageList(messages));
                return true;
            });
        }

        void ButtonClicked(object sender, EventArgs e)
        {
            activityIndicator.IsRunning = true;
            var messages = getMessages();
            activityIndicator.IsRunning = false;

            ShowMessageList(messages);
        }

        void ShowMessageList(string messages)
        {
            Label header = new Label
            {
                Text = "Message List",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            Button refreshButton = new Button
            {
                Text = "Refresh list",
                TextColor = Xamarin.Forms.Color.White,
                BackgroundColor = Xamarin.Forms.Color.SlateBlue,
                CornerRadius = 20,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };

            refreshButton.Clicked += ButtonClicked;

            JArray messageArray = JArray.Parse(messages);

            List<Message> messageList = new List<Message>();

            foreach (var message in messageArray) {
                messageList.Add(new Message(
                    (string)message.SelectToken("id"),
                    (string)message.SelectToken("student_id"),
                    (string)message.SelectToken("gps_lat"),
                    (string)message.SelectToken("gps_long"),
                    (string)message.SelectToken("student_message")
                ));
            }

            ListView listView = new ListView
            {
                // Source of data items.
                ItemsSource = messageList,
                
                RowHeight = 100,

                // Define template for displaying each item.
                // (Argument of DataTemplate constructor is called for 
                //      each item; it must return a Cell derivative.)
                ItemTemplate = new DataTemplate(() =>
                {
                    // Create views with bindings for displaying each property.
                    /*                    Label idLabel = new Label();
                                        idLabel.SetBinding(Label.TextProperty, "id");
                    */

                    Label idLabel = new Label();
                    idLabel.SetBinding(Label.TextProperty, "Id");

                    Label studentIdLabel = new Label();
                    studentIdLabel.SetBinding(Label.TextProperty, "StudentId");
                    studentIdLabel.FontAttributes = FontAttributes.Bold;

                    Label latitudeLabel = new Label();
                    latitudeLabel.SetBinding(Label.TextProperty, "GpsLat");

                    Label longitudeLabel = new Label();
                    longitudeLabel.SetBinding(Label.TextProperty, "GpsLng");

                    Label messageLabel = new Label();
                    messageLabel.SetBinding(Label.TextProperty, "StudentMessage");
                    messageLabel.LineBreakMode = LineBreakMode.TailTruncation; // trucate message
                    
                    // Return an assembled ViewCell.
                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Padding = new Thickness(0, 10),
                            Orientation = StackOrientation.Horizontal,
                            Children =
                            {
                                new StackLayout
                                {
                                    VerticalOptions = LayoutOptions.Center,
                                    Spacing = 10,
                                    Children =
                                    {
                                        studentIdLabel,
                                        messageLabel
                                    }
                                }
                            }
                        }
                    };
                })
            };
            // Accomodate iPhone status bar.
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            // Build the page.
            this.Content = new StackLayout
            {
                Spacing = 15,
                Children =
                {
                    header,
                    refreshButton,
                    listView
                }
            };
        }
    }
}
