using Application.UseCase.Products.Commands.Create;
using Domain.Dtos.Products;
using Domain.Dtos.Products.Categories;
using Domain.Dtos.Products.Discounts;
using Domain.Dtos.Products.Inventories;
using Domain.Entities.Categories;
using Domain.Entities.Products;
using Domain.Entities.Products.Discounts;
using Domain.Entities.Products.Inventories;
using Microsoft.AspNetCore.Routing.Constraints;

namespace Application.Mappings;

public class AutoMapper : Profile
{
    public AutoMapper()
    {
        #region Commands to Entities
        CreateMap<CreateProductCommand, Product>()
            .ReverseMap();
        #endregion

        #region Entities to Dtos
        CreateMap<ProductDto, Product>()
            .ReverseMap();

        CreateMap<InventoryDto, Inventory>()
            .ReverseMap();

        CreateMap<DiscountDto, Discount>()
            .ReverseMap();

        CreateMap<CategoryDto, Category>()
            .ReverseMap();
        #endregion
    }
}