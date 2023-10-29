using System;
using AutoMapper;

namespace Practice20GrapQL.Model
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductModel, Product>().ReverseMap();
            CreateMap<ProductGroupModel, ProcuctGroup>().ReverseMap();
        }
    }
}

