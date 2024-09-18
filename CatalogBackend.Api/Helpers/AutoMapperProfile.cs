using AutoMapper;
using CatalogBackend.Api.Data.Entities;
using CatalogBackend.Api.Features.Categories;

namespace CatalogBackend.Api.Helpers
{
    public class AutoMapperProfile : Profile
  {
    public AutoMapperProfile()
    {
      CreateMap<Category, CategoryDto>();
    }
  }
}
