using Application.Helpers;
using Application.UseCase.Products.Commands.Create;
using Domain.Dtos.Customers;
using Domain.Dtos.Orders;
using Domain.Dtos.Orders.Items;
using Domain.Dtos.Products;
using Domain.Dtos.Products.Categories;
using Domain.Dtos.Products.Discounts;
using Domain.Dtos.Products.Inventories;
using Domain.Dtos.Roles;
using Domain.Entities.Categories;
using Domain.Entities.Customers;
using Domain.Entities.Customers.Roles;
using Domain.Entities.Orders;
using Domain.Entities.Orders.Items;
using Domain.Entities.Products;
using Domain.Entities.Products.Discounts;
using Domain.Entities.Products.Inventories;

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

        CreateMap<CustomerDto, Customer>()
            .ForMember(src => src.Password, opt => opt.MapFrom(src => PasswordHelper.HashPassword(src.Password)))
            .ReverseMap();

        CreateMap<RolDto, Rol>()
            .ReverseMap();

        #endregion
    }
}