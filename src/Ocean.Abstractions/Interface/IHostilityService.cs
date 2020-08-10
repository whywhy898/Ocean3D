using Ocean.Application.EventSourcing;
using Ocean.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ocean.Application.Interface
{
    public interface IHostilityService
    {
        Task<List<HostilityListDto>> GetAllHostility(QueryHostilityDto dto);

        Task SetSurpass(string Id);

        Task AddHostilityInfo(CreateHostilityDto model);

        Task<List<HostilityHistoryData>> GetHistory(Guid Id);
    }
}
