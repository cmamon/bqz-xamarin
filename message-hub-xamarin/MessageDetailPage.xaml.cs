using System;
using System.IO;
using Xamarin.Forms;
using message_hub_xamarin.models;
using System.Collections.Generic;

namespace message_hub_xamarin
{
    public partial class MessageDetailPage : ContentPage 
    {
        Message message;
        private List<Message> messageList;

        public MessageDetailPage(Message message, List<Message> messageList)
        {
            this.message = message;
            this.messageList = messageList;

            foreach (Message msg in this.messageList)
            {
                Console.WriteLine(msg.StudentMessage);
            }

            InitializeComponent();
            DisplayContent();
        }

        void DisplayContent ()
        {
            List<Message> messageListOfStudent = this.messageList.FindAll(
                delegate (Message message)
                {
                    return message.StudentId == this.message.StudentId && message.Id != this.message.Id;
                }
            );

            string descriptionLabelText = "Other messages from " + this.message.StudentId + ":";
            if (messageListOfStudent.Count < 1)
            {
                descriptionLabelText = this.message.StudentId + " did not send other messages";
            }

            Label studentIdLabel = new Label();
            studentIdLabel.Text = this.message.StudentId;
            studentIdLabel.FontAttributes = FontAttributes.Bold;
            studentIdLabel.FontSize = 15;
            studentIdLabel.HorizontalOptions = LayoutOptions.Center;

            Label messageLabel = new Label();
            messageLabel.Text = this.message.StudentMessage;
            messageLabel.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label));
            messageLabel.VerticalOptions = LayoutOptions.Center;
            messageLabel.HorizontalOptions = LayoutOptions.Center;

            Label descriptionLabel = new Label();
            descriptionLabel.Text = descriptionLabelText;
            descriptionLabel.FontSize = 15;
            descriptionLabel.VerticalOptions = LayoutOptions.Center;
            descriptionLabel.HorizontalOptions = LayoutOptions.Center;

            ListView listView = new ListView
            {
                // Source of data items.
                ItemsSource = messageListOfStudent,
                // Height of the items
                RowHeight = 100,

                // Define template for displaying each item.
                // (Argument of DataTemplate constructor is called for 
                //      each item; it must return a Cell derivative.)
                ItemTemplate = new DataTemplate(() =>
                {
                    // Create views with bindings for displaying each property.
                    Label idLabel = new Label();
                    idLabel.SetBinding(Label.TextProperty, "id");

                    Label messageLabel2 = new Label();
                    messageLabel2.SetBinding(Label.TextProperty, "StudentMessage");
                    messageLabel2.LineBreakMode = LineBreakMode.TailTruncation; // trucate message

                    // Return an assembled ViewCell.
                    ViewCell viewCell = new ViewCell
                    {
                        View = new StackLayout
                        {
                            Padding = new Thickness(0, 10),
                            Orientation = StackOrientation.Horizontal,
                            Children =
                            {
                                new StackLayout
                                {
                                    VerticalOptions =
                                    LayoutOptions.Center,
                                    Spacing = 10,
                                    Children =
                                    {
                                        messageLabel2
                                    }
                                }
                            }
                        }
                    };

                    return viewCell;
                })
            };

            // Accomodate iPhone status bar.
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    this.Padding = new Thickness(10, 0, 0, 0);
                    break;
                default:
                    this.Padding = new Thickness(10, 10, 5, 0);
                    break;
            }

            this.Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Spacing = 30,
                Children =
                {
                    studentIdLabel,
                    messageLabel,
                    descriptionLabel,
                    listView
                }
            };
        }
    }
}