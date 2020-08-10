using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ocean.Api.AppData
{
    public class ReponseResult
    {
        public int statusCode { get; set; } = 200;
        public bool isError { get; set; } = false;
        public string message { get; set; }
        public object result { get; set; }

    }
}
