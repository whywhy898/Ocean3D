using AutoMapper;
using Ocean.Application.ViewModel;
using Ocean.Domain.Hostility.Command;

namespace Ocean.Application.AutoMapper
{
    public class ViewModelToDomainProfile : Profile
    {
        public ViewModelToDomainProfile()
        {
            CreateMap<CreateHostilityDto, AddHostilityCommand>();
        }
    }
}
