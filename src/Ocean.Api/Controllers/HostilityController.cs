using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ocean.Application.Interface;
using Ocean.Application.ViewModel;

namespace Ocean.Api.Controllers
{
    /// <summary>
    /// 仇恨人员
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class HostilityController : ControllerBase
    {
        private IHostilityService _hostilityService;
        public HostilityController(IHostilityService hostilityService) {
            _hostilityService = hostilityService;
        }

        /// <summary>
        /// 获取所有的仇恨信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpGet("GetHostilityInfo")]
        public async Task<ActionResult> GetHostilityInfo([FromQuery]QueryHostilityDto dto)
        {
            return Ok(await _hostilityService.GetAllHostility(dto));
        }

        /// <summary>
        /// 设置战胜对手
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost("SetSurpuass")]
        public async Task<ActionResult> SetSurpuass([FromHeader(Name = "x-requestid")]string Id)
        {
            await _hostilityService.SetSurpass(Id);

            return Ok(true);
        }

        /// <summary>
        /// 创建仇恨人员信息
        /// </summary>
        /// <returns></returns>
        [HttpPost("CreateHostilityInfo")]
        public async Task<ActionResult> CreateHostilityInfo([FromBody] CreateHostilityDto model)
        {
            await _hostilityService.AddHostilityInfo(model);
            return Ok(true);
        }

        /// <summary>
        /// 获取事件历史信息
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        [HttpGet("HistoryInfo")]
        public async Task<ActionResult> HistoryInfo([FromQuery]Guid eventId)
        {
            return Ok(await _hostilityService.GetHistory(eventId));
        }

    }
}
