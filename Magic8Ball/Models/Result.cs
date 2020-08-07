using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Magic8Ball.Models
{
    public class Result
    {

        [JsonPropertyName("magic")]
        public Magic8 Magic { get; set; }

    }
}
