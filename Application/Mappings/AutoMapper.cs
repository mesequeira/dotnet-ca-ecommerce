using Application.UseCase.Products.Commands.Create;
using AutoMapper;
using Domain.Entities.Products;

namespace Application.Mappings;

public class AutoMapper : Profile
{
    public AutoMapper()
    {
        CreateMap<CreateProductCommand, Product>();
    }
}
