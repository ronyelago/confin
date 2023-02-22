using AutoMapper;
using confin.api.models;
using confin.domain;

namespace confin.api.mappings
{
    public class CompraProfile : Profile
    {
        public CompraProfile()
        {
            CreateMap<Compra, NovaCompraModel>().ReverseMap();
        }
    }
}