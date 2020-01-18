using System;
using System.Collections.Generic;
using System.Text;

namespace message_hub_xamarin.models
{
    public class Message
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
}
