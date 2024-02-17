using AutoMapper;
using confin.api.models;
using Confin.Domain.Entities;

namespace confin.api.mappings;
public class CompraProfile : Profile
{
    public CompraProfile()
    {
        CreateMap<Compra, NovaCompraModel>().ReverseMap();
    }
}