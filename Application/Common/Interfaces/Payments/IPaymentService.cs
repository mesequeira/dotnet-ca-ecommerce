using MercadoPago.Client.Preference;

namespace Application.Common.Interfaces.Payment;

public interface IPaymentService
{
    /// <summary>
    /// Create and return a reference used to process the payment in the client
    /// </summary>
    /// <param name="items"></param>
    /// <returns></returns>
    Task<string> CreateReferenceAsync(List<PreferenceItemRequest> items);
}
