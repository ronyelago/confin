using AutoMapper;
using confin.api.models;
using Confin.Domain.Entities;

namespace confin.api.mappings;
public class ContaProfile : Profile
{
    public ContaProfile()
    {
        CreateMap<Conta, NovaContaModel>().ReverseMap();
    }
}