using Core.Domain;
using System;

namespace Infrastructure.Services
{
    // Here we have business logic, wich depends only on core!
    public interface IOrderService
    {
        void SaveOrder(Order order);

        Order GetOrder(Guid orderId);
    }
}
