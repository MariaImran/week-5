using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace week_5_PD.bl
{
    class ship
    {
        public string serialNo;
        public angle latitude;
        public angle longitude;

        public ship(string serial, angle lat, angle lon)
        {
            serialNo = serial;
            latitude = lat;
            longitude = lon;
        }
        public void PrintPosition()
        {
            Console.WriteLine("Latitude : {0} \n Lomgitude : {1}", latitude, longitude);
        }
        public void PrintSerialNo()
        {
            Console.WriteLine("serialNo :{0}", serialNo);
        }
    }
    
   
}
