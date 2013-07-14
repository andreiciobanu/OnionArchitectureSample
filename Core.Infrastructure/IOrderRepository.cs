using Core.Domain;
using System;
using System.Collections.Generic;

namespace Core.Infrastructure
{
    public interface IOrderRepository
    {
        void Save(Order order);

        IEnumerable<Order> GetAll();

        void Delete(Order order);

        void DeleteAll(IEnumerable<Order> orders);

        Order GetById(Guid orderId);
    }
}
