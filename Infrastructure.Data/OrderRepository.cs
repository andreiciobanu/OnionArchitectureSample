using Core.Infrastructure;
using Core.Domain;
using Raven.Client.Document;
using System.Linq;
using System;
using System.Collections.Generic;

namespace Infrastructure.Data
{
    public class OrderRepository : IOrderRepository,IDisposable
    {
        private DocumentStore documentStore;

        public OrderRepository()
        {
            Initialize();
        }

        private void Initialize()
        {
            documentStore = new DocumentStore 
            {
                Url = "http://localhost:8080/" 
            };

            documentStore.Initialize();
        }

        public void Save(Order order)
        {
            using (var session = documentStore.OpenSession())
            {
                session.Store(order);
                session.SaveChanges();
            }
        }

        public IEnumerable<Order> GetAll()
        {
            using (var session = documentStore.OpenSession())
            {
                return session.Query<Order>().ToList();
            }
        }

        public void Delete(Order order)
        {
            using (var session = documentStore.OpenSession())
            {
                session.Delete<Order>(order);
                session.SaveChanges();
            }
        }

        public void DeleteAll(IEnumerable<Order> orders)
        {
            foreach (var item in orders)
            {
                Delete(item);
            }
        }

        public void Dispose()
        {
            documentStore.Dispose();
        }


        public Order GetById(Guid orderId)
        {
            using (var session = documentStore.OpenSession())
            {
                return session.Load<Order>(orderId.ToString());
            }
        }
    }
}
