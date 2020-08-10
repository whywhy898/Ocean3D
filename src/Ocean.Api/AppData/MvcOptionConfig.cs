using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Ocean.Api.AppData
{
    internal class MvcOptionConfig : IConfigureOptions<MvcOptions>
    {
        public void Configure(MvcOptions option)
        {
            option.Filters.Add(typeof(DataWrapperFilter));
            option.Filters.Add(new AuthorizeFilter());
        }
    }
}
