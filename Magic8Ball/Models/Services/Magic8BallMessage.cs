using Magic8Ball.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Magic8Ball.Models.Services
{
    public class Magic8BallMessage : IMagic8Message
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<string> GetMagic8Message()
        {
            //set destination
            var baseUrl = @"https://8ball.delegator.com/magic/JSON/?";
            string route = "question";

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var streamTask = await client.GetStreamAsync($"{baseUrl}/{route}");

            //convert to C# from JSON
            var result = await JsonSerializer.DeserializeAsync<string>(streamTask);

            return result;

            //throw new NotImplementedException();
        }
    }
}
