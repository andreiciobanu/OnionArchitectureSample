using Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace OrderManagement.Controllers
{
    public class OrderController : ApiController
    {
        IOrderService orderService;

        public OrderController(IOrderService orderservice)
        {
            this.orderService = orderservice;
        }

        // GET api/order1
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/order1/5
        public string Get(Guid id)
        {
            // get it from the service
            var order = orderService.GetOrder(id);
            //ToDo : from here put it to the UI in some way, maybe transform to a orderModel, etc

            return "value";
        }

        // POST api/order1
        public void Post([FromBody]string value)
        {
        }

        // PUT api/order1/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/order1/5
        public void Delete(int id)
        {
        }
    }
}
