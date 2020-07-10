using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Magic8Ball.Models.Interfaces
{
    public interface IMagic8Message
    {
        Task<string> GetMagic8Message();

    }
}
