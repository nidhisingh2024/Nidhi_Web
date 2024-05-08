using Microsoft.AspNetCore.Mvc;
using MvcCore_Test.Repository;
using MvcCore_Test.Models;
using System;

namespace MvcCore_Test.Controllers
{
    public class OrderController : Controller
    {
        private readonly IEkartRepositoryInterface _ekartRepository;

        public OrderController(IEkartRepositoryInterface ekartRepository)
        {
            _ekartRepository = ekartRepository;
        }

        public IActionResult PlaceOrder(Order newOrder)
        {
            if (newOrder == null)
                return BadRequest();

            var order = _ekartRepository.PlaceOrder(newOrder);

            return Ok(order);
        }

        public IActionResult GetOrderDetails(int orderId)
        {
            var order = _ekartRepository.GetOrderDetails(orderId);
            if (order == null)
                return NotFound();

            return Ok(order);
        }

        public IActionResult DisplayBill(int orderId)
        {
            var bill = _ekartRepository.DisplayBill(orderId);
            if (bill == null)
                return NotFound();

            return Ok(bill);
        }

        public IActionResult GetCustomersByOrderDate(DateTime orderDate)
        {
            var customers = _ekartRepository.GetCustomersByOrderDate(orderDate);

            return Ok(customers);
        }

        public IActionResult GetCustomerWithHighestOrder()
        {
            var customer = _ekartRepository.GetCustomerWithHighestOrder();

            return Ok(customer);
        }
    }
}
