using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geta.ImageOptimization.Messaging
{
    public class KrakenRequest
    {

        public Auth auth { get; set; }
      
        public string url { get; set; }

        public bool wait { get; set; }

        public bool  lossy { get; set; }

    }

    public class Auth
    {
        public string api_key { get; set; }

        public string api_secret { get; set; }
    }
}