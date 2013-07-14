using Core.Domain;
using Core.Infrastructure;
using Infrastructure.Services;
using System;
using System.Linq;

namespace Services
{
    public class OrderService : IOrderService
    {
        private IOrderRepository orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public void SaveOrder(Order order)
        {
            // Business rule(logic) : we can save an order only if it has items in it.
            if (order.Items.Any())
            {
                orderRepository.Save(order);
            }
        }

        public Order GetOrder(Guid orderId)
        {
           return orderRepository.GetById(orderId);
        }
    }
}
