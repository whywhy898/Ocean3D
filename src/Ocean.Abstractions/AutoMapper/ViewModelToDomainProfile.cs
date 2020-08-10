using AutoMapper;
using Ocean.Application.ViewModel;
using Ocean.Domain.Hostility.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ocean.Application.AutoMapper
{
    public class ViewModelToDomainProfile : Profile
    {
        public ViewModelToDomainProfile()
        {
            CreateMap<HostilityEntity, HostilityListDto>();
        }
    }
}
