using AutoMapper;
using confin.api.models;
using confin.domain;

namespace confin.api.mappings
{
    public class ContaProfile : Profile
    {
        public ContaProfile()
        {
            CreateMap<Conta, NovoCadastroContaModel>().ReverseMap();
        }
    }
}