using System;
using System.Collections.Generic;
using System.Text;

namespace Ocean.Application.ViewModel
{
    public class QueryDto : IQueryDto
    {
        public int PageNum { get; set; }
        public int CurrentPage { get; set; }
        public string Sort { get; set; }
        public string Order { get; set; }
    }
}
