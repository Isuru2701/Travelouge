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
        private Dictionary<string, List<Edge>> adjacencyList;

        public Graph()
        {
            adjacencyList = new Dictionary<string,List<Edge>>();
        }

        public void addLocation(string location)
        {
            //if location already exists, no point in adding one again
            if(!adjacencyList.ContainsKey(location))
            {
                adjacencyList[location] = new List<Edge>();
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
                adjacencyList[source].Add(new Edge(dest, distance));
                adjacencyList[dest].Add(new Edge(source, distance));
            }
        }

        public void removeLocation(string location)
        {
            if (adjacencyList.ContainsKey(location))
            {
                adjacencyList.Remove(location);

                foreach (var adjacentLocation in adjacencyList.Values)
                {
                    //goes inside each list of edges, and removes the edge that has the location as its destination
                    adjacentLocation.RemoveAll(edge => edge.Destination == location);
                }
            }
            
        }

        public bool Contains(string location)
        {
            return adjacencyList.ContainsKey(location);
        }


        public void printGraph()
        {
            foreach(string key in adjacencyList.Keys)
            {
                Console.WriteLine(key + " : ");

                foreach(Edge dest in adjacencyList[key])
                {
                    Console.WriteLine(dest.Destination) ;
                }
            }
            
        }

        public Graph Kruskal()
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
        public string Destination { get; }
        public double Weight { get; }

        public Edge(string target, double weight)
        {
            Destination = target;
            Weight = weight;
        }
    }

    public class DisjointSet
    {
        private Dictionary<string, string> parent;

        public DisjointSet()
        {
            parent = new Dictionary<string, string>();
        }

        public void MakeSet(string vertex)
        {
            parent[vertex] = vertex;
        }

        public string Find(string vertex)
        {
            if (parent[vertex] != vertex)
            {
                // Path compression
                parent[vertex] = Find(parent[vertex]);
            }

            return parent[vertex];
        }

        public void Union(string vertex1, string vertex2)
        {
            string root1 = Find(vertex1);
            string root2 = Find(vertex2);

            if (root1 != root2)
            {
                parent[root2] = root1;
            }
        }
    }
}
