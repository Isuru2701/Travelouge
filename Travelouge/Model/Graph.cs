using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Travelouge.Model
{
    //using an adjacency matrix
    //limited to 5 locations for now
    class Graph
    {
        private Dictionary<Location, Dictionary<Location, double>> adjacencyList;

        public Graph()
        {
            adjacencyList = new Dictionary<Location, Dictionary<Location, double>>();
        }

        public void addLocation(Location location)
        {
            if(!adjacencyList.ContainsKey(location))
            {
                adjacencyList[location] = new Dictionary<Location, double>();
            }
        }

        public void addEdge(Location location, double distance)
        {
            
        }





        /**
         * calculates distance based on the Haversine formula
         * dont mind this too much
         */
        public double calculateDisplacement(Location l1, Location l2)
        {
            
            var r = 6371; // Radius of the earth in km
            var dLat = deg2rad(l2.lat - l1.lat);
            var dLon = deg2rad(l2.lng - l1.lng);
            var a =
            Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
            Math.Cos(deg2rad(l1.lat)) * Math.Cos(deg2rad(l2.lat)) *
            Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var d = r * c; // Distance in km
            return d;

        }

        private double deg2rad(double deg)
        {
            return deg * (Math.PI / 180);
        }

        
    }

    public class Edge
    {
        public Location Source { get; }
        public Location Target { get; }
        public double Weight { get; }

        public Edge(Location source, Location target, double weight)
        {
            Source = source;
            Target = target;
            Weight = weight;
        }
    }
}
