using System;
using System.Collections.Generic;
using System.Text;

namespace Ocean.Application.ViewModel
{
   public interface IQueryDto
    {
        int PageNum { get; set; }

        int CurrentPage { get; set; }
    }
}
