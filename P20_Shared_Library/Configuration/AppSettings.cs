using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P20_Shared_Library.Configuration
{
    public class AppSettings
    {
        public string BaseApiUrl { get; set; }

        public BooksEndpoint BooksEndpoint { get; set; }
    }
}
