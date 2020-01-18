using System;
using System.IO;
using Xamarin.Forms;
using message_hub_xamarin.models;

namespace message_hub_xamarin
{
    public partial class MessageDetailPage : ContentPage 
    {
        Message message;

        public MessageDetailPage(Message message)
        {
            this.message = message;

            InitializeComponent();
            DisplayContent();
        }

        void DisplayContent ()
        {
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

            Console.WriteLine(this.message.StudentId);
            Console.WriteLine(this.message.StudentMessage);

            this.Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Spacing = 30,
                Children =
                {
                    studentIdLabel,
                    messageLabel
                }
            };
        }
    }
}