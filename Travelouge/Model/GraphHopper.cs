using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Travelouge.Model
{
    internal class GraphHopper
    {
        private string apiKey = "ca28dd3c-03d1-4da1-a05f-f9436d645b6e";

        public async Task<bool> VerifyLocation(string location)
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

                if (geocodingResult.Hits.Length == 0)
                {
                    return false;
                }

                return true;
            }
        }
    }

}
