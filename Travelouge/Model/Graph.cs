using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Travelouge.Model
{
    class Graph
    {

        private Dictionary<string, Dictionary<string, double>> adjacencyList;

        public Graph()
        {
            adjacencyList = new Dictionary<string, Dictionary<string, double>>();
        }

        public void AddLocation(string location)
        {
            if (!adjacencyList.ContainsKey(location))
                adjacencyList[location] = new Dictionary<string, double>();
        }

        public void AddDistance(string location1, string location2, double distance)
        {
            AddLocation(location1);
            AddLocation(location2);

            adjacencyList[location1][location2] = distance;
            adjacencyList[location2][location1] = distance;
        }

        public List<Edge> GetEdges()
        {
            List<Edge> edges = new List<Edge>();

            foreach (var source in adjacencyList)
            {
                foreach (var target in source.Value)
                {
                    edges.Add(new Edge(source.Key, target.Key, target.Value));
                }
            }

            return edges;
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
        public string Source { get; }
        public string Target { get; }
        public double Weight { get; }

        public Edge(string source, string target, double weight)
        {
            Source = source;
            Target = target;
            Weight = weight;
        }
    }
}
