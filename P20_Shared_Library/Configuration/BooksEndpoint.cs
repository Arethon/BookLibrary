using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P20_Shared_Library.Configuration
{
    public  class BooksEndpoint
    {
        public string BaseUrl { get; set; }
        public string GetBooks { get; set; }

        public string PostBook { get; set; }
    }
}
