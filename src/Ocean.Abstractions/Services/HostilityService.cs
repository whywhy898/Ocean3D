using Ocean.Application.Interface;
using Ocean.Application.ViewModel;
using Ocean.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Ocean.Domain.Hostility.Command;
using Ocean.Domain.Core.Bus;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Ocean.Application.Dapper;
using Ocean.Application.EventSourcing;
using Ocean.Infrastructure.Repositorys.store;

namespace Ocean.Application.Services
{
  public class HostilityService : IHostilityService
    {

        private IMediatorHandler _mediatR;
        private IConfiguration _configuration;
        private IEventStoreRepository _eventStoreRepository;
        private IHostilityRepository _hostilityRepository;


        public HostilityService(
            IHostilityRepository hostilityRepository,IMediatorHandler mediatR
            ,IConfiguration configuration, IEventStoreRepository eventStoreRepository) {
            _mediatR = mediatR;
            _eventStoreRepository = eventStoreRepository;
            _configuration = configuration;
            _hostilityRepository = hostilityRepository;
        }
        public async Task<List<HostilityListDto>> GetAllHostility(QueryHostilityDto dto)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("MsSqlServer")))
            {
                var sqlstr = @"select HostilityId,QQNumber,HostilityName,RoleLevel,
                               MilitaryPower,HostilityLevel,IsSurpass,Remark,CreateTime 
                               from Hostility where 1=1";

                //模仿城里人微软的玩法
                var (sql,param) = DapperHandle.CreateQueryHandle(sqlstr, dto)
                                      .AddCondition(a => !string.IsNullOrEmpty(a.QQNumber), " and QQNumber like @QQNumber")
                                      .AddCondition(a => !string.IsNullOrEmpty(a.HostilityName), " and HostilityName like @HostilityName")
                                      .BuilderPage(orderby:"HostilityId");

                return (List<HostilityListDto>)await connection.QueryAsync<HostilityListDto>(sql, param);
            }
        }

        public async Task SetSurpass(string Id)
        {
            var setSurpassCommand = new SetSurpassCommand(Id);
            await _mediatR.SendCommand(setSurpassCommand);
        }

        public async Task AddHostilityInfo(CreateHostilityDto model)
        {
            var AddCommand = new AddHostilityCommand(model.QQNumber,model.HostilityName,
                model.RoleLevel,model.MilitaryPower,model.HostilityLevel,model.Remark);

            await _mediatR.SendCommand(AddCommand);
        }

        public async Task<List<HostilityHistoryData>> GetHistory(Guid Id)
        {
            var result= EventHistoryResolve.ToJavaScriptHistory<HostilityHistoryData>(await _eventStoreRepository.All(Id));

            return result.ToList();
        }
    }
}
