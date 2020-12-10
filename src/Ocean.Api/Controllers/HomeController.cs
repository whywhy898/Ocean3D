using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ocean.Application.Interface;
using Ocean.Application.ViewModel;
using Ocean.Infrastructure.JwtBreare;
using Ocean.Infrastructure.Tools.Services;

namespace Ocean.Api.Controllers
{
    /// <summary>
    /// 系统主配置
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private ITokenService _tokenService;
        private IUserService _userService;
        private readonly IServiceProvider _serviceProvider;

        public HomeController(ITokenService tokenService, IUserService userService,IServiceProvider serviceProvider) {
            _tokenService = tokenService;
            _userService = userService;
            _serviceProvider = serviceProvider;
        }
      
        /// <summary>
        /// 系统登录
        /// </summary>
        /// <returns></returns>
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody]LoginUserDto loginUser)
        {
            if (!ModelState.IsValid) return BadRequest("用户名或密码不允许位空！");
            var (id, userName) = await _userService.GetLoginInfo(loginUser);
            var claims = new Claim[] {
                new Claim(JwtClaimTypes.Name,userName),
                new Claim(JwtClaimTypes.Role,"admin"),
                new Claim(JwtClaimTypes.Id,id),
            };
            var token = _tokenService.CreateToken(claims);

            return Ok(token);
        }

        /// <summary>
        /// 刷新Token
        /// </summary>
        /// <returns></returns>
        [HttpGet("RefreshToken")]
        [Authorize(policy:"refresh")]
        public IActionResult RefreshToken()
        {
            var AccessToken= _tokenService.RefreshToken(HttpContext.User);
            return Ok(AccessToken);
        }

        [HttpGet("GetHash")]
        public IActionResult GetHash()
        {

            return Ok($"当前请求管道hash:{_serviceProvider.GetHashCode()},父级别容器hash：{GlobalServiceProvider.serviceProvider.GetHashCode()}");
        }

    }
}
