using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Travelouge.Model
{
    //using an adjacency list
    class Graph
    {
        //this dict will contain a location, and a dict of all the locations it is connected to, with their distances
        private Dictionary<string, Dictionary<string, double>> adjacencyList;

        public Graph()
        {
            adjacencyList = new Dictionary<string, Dictionary<string, double>>();
        }

        public void addLocation(string location)
        {
            //if location already exists, no point in adding one again
            if(!adjacencyList.ContainsKey(location))
            {
                adjacencyList[location] = new Dictionary<string, double>();
            }
        }

        public void addEdge(string source, string dest, double distance)
        {
            if(!adjacencyList.ContainsKey(source) || !adjacencyList.ContainsKey(dest))
            {
                throw new Exception("One or more of the locations does not exist");
            }
            else
            {
                //since the graph is undirected, we add the edge to both the source and destination
                adjacencyList[source][dest] = distance;
                adjacencyList[dest][source] = distance;
            }
        }

        public void printGraph()
        {
            foreach(string key in adjacencyList.Keys)
            {
                Console.WriteLine(key + " : ");

                foreach(string dest in adjacencyList[key].Keys)
                {
                    Console.WriteLine(dest + " : " + adjacencyList[key][dest]);
                }
            }
            
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
