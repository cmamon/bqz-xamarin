using System;
using System.Collections.Generic;
using System.Text;

namespace message_hub_xamarin
{
   
    public class Clientinfo
{
    public string ID { get; set; }

    public string Student_ID { get; set; }

    public string latitude { get; set; }

    public string longitude { get; set; }

    public string Student_message { get; set; }

        public Clientinfo(string I, string S,string la,string lo, string st)
        {
            ID = I;
            Student_ID = S;
            latitude = la;
            longitude = lo;
            Student_message = st;
        }
 
    }

   
}
