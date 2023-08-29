using Domain.Dtos.Orders.Items;

namespace Domain.Dtos.Orders;

public class OrderDto
{
    public long CustomerId { get; set; }  
    public List<OrderItemDto> OrderItems { get; set; } 
}