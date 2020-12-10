using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Ocean.Api.AppData
{
    internal class MvcOptionConfig : IConfigureOptions<MvcOptions>
    {
        private readonly IConfiguration  _configuration;
        public MvcOptionConfig(IConfiguration configuration) => _configuration = configuration;
        public void Configure(MvcOptions option)
        {
       
            option.Filters.Add(typeof(DataWrapperFilter));

            var authoriztion = _configuration.GetValue<bool>("Switch:IsOpenAuthorization");
            if (authoriztion)
            {
                option.Filters.Add(new AuthorizeFilter());
            }
        }
    }
}
