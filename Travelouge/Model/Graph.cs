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
            adjacencyList = new Dictionary<string, List<Edge>>();
        }

        public void AddLocation(string location)
        {
            //if location already exists, no point in adding one again
            if (!adjacencyList.ContainsKey(location))
            {
                adjacencyList[location] = new List<Edge>();
            }
        }

        public void AddEdge(string source, string dest, double distance, double time)
        {
            if (!adjacencyList.ContainsKey(source) || !adjacencyList.ContainsKey(dest))
            {
                throw new Exception("One or more of the locations does not exist");
            }
            else
            {

                //since the graph is undirected, we add the edge to both the source and destination
                adjacencyList[source].Add(new Edge(dest, distance, time));
                adjacencyList[dest].Add(new Edge(source, distance, time));
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
            foreach (string location in adjacencyList.Keys)
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

            foreach (string key in adjacencyList.Keys)
            {
                reply += $"\t src {key}:\n";

                foreach (Edge dest in adjacencyList[key])
                {
                    reply += $"\t\t(dest {dest.Destination}, weight {dest.Weight})";
                }
                reply += "\n";
            }
            return reply;

        }

        public void Reset()
        {
            adjacencyList.Clear();
        }

        
        public List<string> FindShortestRoute(out double totalDistance, out double totalTime)
        {
            //using the Nearest neighbour technique

            /**
             * 1. Pick an arbitrary starting point
             * 2. Find the nearest unvisited point from the current point
             * 3. Move to that point
             * 4. Add location to the list, and mark it as visited and increment distance travelled
             * 5. Repeat steps 2-4 until all locations have been visited
             * 6. Do not return to starting point
             */
            totalDistance = 0;
            totalTime = 0;
            //list of locations that have been visited
            //this'll contain the order in in which the locations are visited
            List<string> tours = new List<string>();

            List<string> locations = GetLocations();


            //pick an arbitrary starting point
            string currentLocation = locations[0];

            foreach (string location in locations)
            {
                //find the nearest unvisited point from the current point
                double minDistance = double.MaxValue;
                string nearestLocation = "";

                foreach (Edge edge in adjacencyList[currentLocation])
                {
                    if (!tours.Contains(edge.Destination) && edge.Weight < minDistance)
                    {
                        minDistance = edge.Weight;
                        nearestLocation = edge.Destination;
                    }
                }

                
                totalTime += adjacencyList[currentLocation].Find(edge => edge.Destination == nearestLocation).Time;

                //move to that point
                currentLocation = nearestLocation;

                //add location to the list, and mark it as visited and increment distance travelled
                tours.Add(currentLocation);
                totalDistance += minDistance;
                
            }
   
            return tours;
        }

        


        private double CalculateTotalDistance(List<Edge> route)
        {
            double totalDistance = 0;

            for (int i = 0; i < route.Count - 1; i++)
            {
                totalDistance += route[i].Weight;
            }

            return totalDistance;
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

        public double Time { get; }

        public Edge(string target, double weight, double time)
        {
            Destination = target;
            Weight = weight;
            Time = time;
        }
    }
}
