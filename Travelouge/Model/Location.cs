using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travelouge.Model
{
    public class Location
    {
        public string Name { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }

        public Location(string name, double lat, double lng)
        {
            Name = name;
            this.lat = lat;
            this.lng = lng;
        }
    }

    

}
