using Domain.Entities.Orders.Items;
using MercadoPago.Client.Preference;

namespace Application.Mappings.Payments;

internal sealed class ReferenceMapper : Profile
{
    public ReferenceMapper()
    {
        CreateMap<OrderItem, PreferenceItemRequest>()
            .ForMember(src => src.CurrencyId, opt => opt.MapFrom(src => "ARS"))
            //.ForMember(src => src.Quantity, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(src => src.UnitPrice, opt => opt.MapFrom(src => src.Product.Price))
            .ForMember(src => src.Title, opt => opt.MapFrom(src => src.Product.Name));
    }
}
