using Magic8Ball.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace Magic8Ball.Models.Services
{
    public class Magic8BallMessage : IMagic8Message
    {
        private static readonly HttpClient client = new HttpClient();

        private readonly Delegator8BallService _8Ball;

        public Magic8BallMessage()
            : this(new Delegator8BallService())
        {
        }

        public Magic8BallMessage(Delegator8BallService service)
        {
            _8Ball = service;
        }

        public async Task<Magic8> GetMagic8Message()
        {
            //return _8Ball.GetAnswer("??");
            //set destination
            //var baseUrl = @"https://localhost:44323/api";
            var baseUrl = @"https://8ball.delegator.com/magic/json";
            string route = "question";

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var streamTask = await client.GetStreamAsync($"{baseUrl}/{route}");

            //readcontentasstring.Async 

            //convert to C# from JSON
            Magic8 result = await JsonSerializer.DeserializeAsync<Magic8>(streamTask);

            return result;

            //throw new NotImplementedException();
        }
    }

    public class Delegator8BallService
    {
        public virtual string GetAnswer(string question)
        {
            return null;
        }
    }

    public class Test8Ball : Delegator8BallService
    {
        public override string GetAnswer(string question)
        {
            // Replace with custom answser
            return base.GetAnswer(question);
        }

    }

    public class MyTests
    {
        public void Test1()
        {
            var svc = new Magic8BallMessage(new Test8Ball());

        }
    }
}
