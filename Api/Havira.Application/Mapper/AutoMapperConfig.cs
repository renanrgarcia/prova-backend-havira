using AutoMapper;
using Havira.Application.ViewModel.ContextoLocalizacao;
using Havira.Business.Models.ContextoLocalizacao;

namespace Havira.Application.Mapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Localizacao, LocalizacaoViewModel>()
                .ReverseMap();
        }
    }
}