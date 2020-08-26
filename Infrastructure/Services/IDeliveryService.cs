using Infrastructure.Models;

namespace Infrastructure.Services
{
    public interface IDeliveryService
    {
        double CalculateDeliveryCost(Cart cart);
    }
}