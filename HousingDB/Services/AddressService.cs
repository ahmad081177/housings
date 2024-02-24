using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Text.Json;

namespace HousingDB.Services
{
    public class AddressService
    {
        public async Task<Tuple<double, double>> AddressToLatLong(string address)
        {
            try
            {
                //call Http to: https://nominatim.openstreetmap.org/search?addressdetails=1&q={address}&format=jsonv2&limit=1
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("User-Agent", "C# console program");
                var resp = await client.GetAsync($"https://nominatim.openstreetmap.org/search?addressdetails=1&q={address}&format=jsonv2&limit=1");
                //read resp as json
                string sresp = await resp.Content.ReadAsStringAsync();
                //parse the json to get lat and long
                var jresp = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(sresp);
                double lon = double.Parse(jresp[0]["lon"].ToString());
                double lat = double.Parse(jresp[0]["lat"].ToString());
                return new Tuple<double, double>(lat, lon);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new Tuple<double, double>(0, 0);
            }
        }
    }
}
