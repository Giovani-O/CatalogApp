using AutoMapper;
using CatalogApp.Application.DTOs;
using CatalogApp.Domain.Entities;

namespace CatalogApp.Application.Mappings;

public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile()
    {
        CreateMap<Category, CategoryDTO>().ReverseMap();
        CreateMap<Product, ProductDTO>().ReverseMap();
    }
}
