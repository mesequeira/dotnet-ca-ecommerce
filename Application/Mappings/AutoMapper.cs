using Application.UseCase.Products.Commands.Create;
using Domain.Dtos.Orders;
using Domain.Dtos.Orders.Items;
using Domain.Dtos.Products;
using Domain.Dtos.Products.Categories;
using Domain.Dtos.Products.Discounts;
using Domain.Dtos.Products.Inventories;
using Domain.Entities.Categories;
using Domain.Entities.Orders;
using Domain.Entities.Orders.Items;
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
            .ForMember(src => src.Id, opt => opt.MapFrom(src => src.ProductId))
            .ReverseMap();

        CreateMap<InventoryDto, Inventory>()
            .ReverseMap();

        CreateMap<DiscountDto, Discount>()
            .ReverseMap();

        CreateMap<CategoryDto, Category>()
            .ReverseMap();

        CreateMap<OrderDto, Order>()
            .ReverseMap();

        CreateMap<OrderItemDto, OrderItem>()
            .ReverseMap();
        #endregion
    }
}