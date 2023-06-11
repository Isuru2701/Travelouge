using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Travelouge.Model
{
    /**
     * implementation of interaction logic with the graphhopper api
     * 
     * find the docs here :) https://docs.graphhopper.com/
     */

    class GraphHopper
    {
        //api key for graphhopper
        private string apiKey = "ca28dd3c-03d1-4da1-a05f-f9436d645b6e";

        //use to verify if a location exists
        public async Task<Location> VerifyLocation(string location)
        {
            if(location == null || location.Equals(""))
            {
                return null;
            }
            using (var client = new HttpClient())
            {
                var url = $"https://graphhopper.com/api/1/geocode?q={Uri.EscapeDataString(location)}&key={apiKey}";

                var response = await client.GetAsync(url);
                var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error: {content}");
                }

                if(content == null)
                {
                    return null;
                }
                var geocodingResult = JsonConvert.DeserializeObject<GeocodingResult>(content);

                //take first reply
                var fetchData= new Location(geocodingResult.Hits[0].Name,
                    geocodingResult.Hits[0].point.lat,
                    geocodingResult.Hits[0].point.lng);               
                if (geocodingResult.Hits.Length == 0)
                {
                    return null;
                }
                
                return fetchData;
            }
        }

        //used to find the routing distance between two locations
        public async Task<RouteResponsePath> FindDistance(string source, string dest)
        {
            using(var client = new HttpClient())
            {
                //get lat and lng info for source and dest
                var sourceLocation = await VerifyLocation(source);
                if(sourceLocation == null)
                {
                    return null;
                }

                var destLocation = await VerifyLocation(dest);
                if(destLocation == null)
                {
                    return null;
                }

                var url = $"https://graphhopper.com/api/1/route?point={sourceLocation.lat},{sourceLocation.lng}&point={destLocation.lat},{destLocation.lng}&vehicle=car&locale=en&key={apiKey}";

                var response = await client.GetAsync(url);
                var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {

                    MessageBox.Show(
                        "an error occured" + "\n" +
                        destLocation.Name + " " + sourceLocation.Name + " " +
                        "\ndest " + destLocation.lat + " " + destLocation.lng + " " +
                        "\nsource " + sourceLocation.lat + " " + sourceLocation.lng + "\n" +
                        content
                        );
                }

                if (content == null)
                {
                    return null;
                }
                MessageBox.Show(content);

                var json = JsonConvert.DeserializeObject<RoutingResult>(content);
                return json.paths;
            }
            
        }
    }

    class GeocodingResult
    {
        public Hit[] Hits { get; set; }
        public int Took { get; set; }

    }

    class Hit
    {
        public MapPoint point { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public string housenumber { get; set; }
        public string postcode { get; set; }

    }

    class MapPoint
    {
        public double lat { get; set; }
        public double lng { get; set; }

    }

    class RouteResponsePath
    {
        public double distance { get; set; }
        public int time { get; set; }

    }
    class RoutingResult
    {
        public RouteResponsePath paths { get; set; }
    }

}
