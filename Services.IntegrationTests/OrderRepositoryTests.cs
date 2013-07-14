using Core.Domain;
using Infrastructure.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Services.IntegrationTests
{
    [TestClass]
    public class OrderRepositoryTests
    {
        OrderRepository orderRepository;

        [TestInitialize]
        public void Initialize()
        {
            orderRepository = new OrderRepository();
            orderRepository.DeleteAll(orderRepository.GetAll().ToList());
        }

        [TestCleanup]
        public void CleanUp()
        {
            orderRepository.DeleteAll(orderRepository.GetAll().ToList());
            orderRepository.Dispose();
        }

        [TestMethod]
        public void SaveOrder()
        {
            var order = new Order
            {
                Description = "First order",
                Id = Guid.NewGuid()
            };

            orderRepository.Save(order);

            //Assert
            Assert.AreEqual(orderRepository.GetAll().Count(), 1);

            orderRepository.Delete(order);
        }
    }
}
