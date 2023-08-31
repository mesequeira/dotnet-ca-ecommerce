using Application.Common.Interfaces.Payment;
using MercadoPago.Client.Preference;
using MercadoPago.Config;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Services.Payments;

internal sealed class PaymentService : IPaymentService
{
    private readonly IConfiguration _configuration;

    public PaymentService(IConfiguration configuration)
    {
        _configuration = configuration;
        MercadoPagoConfig.AccessToken = _configuration.GetSection("MercadoPago:AccessToken").Value;
    }

    public async Task<string> CreateReferenceAsync(List<PreferenceItemRequest> items)
    {
        var request = new PreferenceRequest
        {
            Items = items,
        };

        var client = new PreferenceClient();

        var reference = await client.CreateAsync(request);

        return reference.Id;
    }
}
