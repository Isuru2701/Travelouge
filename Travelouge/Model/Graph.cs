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

        public void AddLocation(string location)
        {
            //if location already exists, no point in adding one again
            if(!adjacencyList.ContainsKey(location))
            {
                adjacencyList[location] = new List<Edge>();
            }
        }

        public void AddEdge(string source, string dest, double distance)
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

        public void RemoveLocation(string location)
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

        public List<string> GetLocations()
        {
            List<string> locations = new List<string>();
            foreach(string location in adjacencyList.Keys)
            {
                locations.Add(location);
            }
            return locations;
        }
       

        public bool Contains(string location)
        {
            return adjacencyList.ContainsKey(location);
        }


        public override string ToString()
        {
            string reply = "graph\n";

            foreach(string key in adjacencyList.Keys)
            {
                reply += $"\t key {key}:";

                foreach(Edge dest in adjacencyList[key])
                {
                    reply += $"(value {dest.Destination}, weight {dest.Weight})";
                }
            }
            return reply;
            
        }

        public Graph Kruskal()
        {
            //create a new graph to store the MST
            Graph MST = new Graph();

            //create a new disjoint set to keep track of which vertices are connected
            DisjointSet set = new DisjointSet();

            //add all the vertices to the disjoint set
            foreach(string vertex in adjacencyList.Keys)
            {
                set.MakeSet(vertex);
            }

            //create a list of all the edges in the graph
            List<Edge> edges = new List<Edge>();

            foreach(string vertex in adjacencyList.Keys)
            {
                foreach(Edge edge in adjacencyList[vertex])
                {
                    edges.Add(edge);
                }
            }

            //sort the edges by weight
            edges.Sort((x, y) => x.Weight.CompareTo(y.Weight));

            //for each edge in the list of edges
            foreach(Edge edge in edges)
            {
                //if the edge connects two vertices that are not already connected
                if(set.Find(edge.Destination) != set.Find(edge.Destination))
                {
                    //add the edge to the MST
                    MST.AddEdge(edge.Destination, edge.Destination, edge.Weight);

                    //union the two vertices
                    set.Union(edge.Destination, edge.Destination);
                }
            }

            return MST;

            
        }


        /**
         * calculates distance based on the Haversine formula
         * dont mind this too much
         */
        public double CalculateDisplacement(Location l1, Location l2)
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
