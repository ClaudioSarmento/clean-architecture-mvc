using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Application.Mappings;

public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile()
    {
        CreateMap<Category, CategoryDTO>().ReverseMap();
        CreateMap<Product, ProductDTO>().ReverseMap();
        CreateMap<ProductDTO, ProductCreateCommand>().ReverseMap();
        CreateMap<ProductDTO, ProductUpdateCommand>().ReverseMap();
    }
}
