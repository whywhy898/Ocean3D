using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ocean.Api.Infrastructure.Services;
using Ocean.Application.Interface;
using Ocean.Application.ViewModel;
using Ocean.Infrastructure.JwtBreare;
using Ocean.Infrastructure.Tools.Services;

namespace Ocean.Api.Controllers
{
    /// <summary>
    /// 账户信息
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IUserService _userService;
        private IIdentityService  _identityService;
        private readonly IServiceProvider _serviceProvider;

        public AccountController(IUserService userService, 
            IIdentityService identityService,IServiceProvider serviceProvider)
        {
            _userService = userService;
            _identityService = identityService;
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// 注册新用户
        /// </summary>
        /// <param name="register"></param>
        /// <returns></returns>
        [HttpPost("RegisterAccount")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterAccount([FromBody]RegisterUserDto  register)
        {
            await _userService.RegisterUserInfo(register);
            return Ok(true);
        }

        /// <summary>
        /// 获取当前登录用户
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetCurrentUserInfo")]
        public async Task<IActionResult> GetCurrentUserInfo()
        {
            var userId = _identityService.GetUserIdentity();
            var result=  await _userService.GetCurrentUse(userId);
            return Ok(result);
        }

    }
}
