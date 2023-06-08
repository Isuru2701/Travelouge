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
    internal class GraphHopper
    {
        private string apiKey = "ca28dd3c-03d1-4da1-a05f-f9436d645b6e";

        public async Task<Location> VerifyLocation(string location)
        {
            using (var client = new HttpClient())
            {
                var url = $"https://graphhopper.com/api/1/geocode?q={Uri.EscapeDataString(location)}&key={apiKey}";

                var response = await client.GetAsync(url);
                var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error: {content}");
                }

                var geocodingResult = JsonConvert.DeserializeObject<GeocodingResult>(content);

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

}
