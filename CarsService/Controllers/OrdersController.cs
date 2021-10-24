using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarsCore.Models;

namespace CarsPresentationLayer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreatOrder(List<OrderItem> orderItems)
        {
            await Task.CompletedTask;
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(Guid id)
        {
            await Task.CompletedTask;
            return Ok();
        }

        [HttpGet("query")]
        public async Task<IActionResult> GetOrderByQueryString(Guid id)
        {
            await Task.CompletedTask;
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> PayOrderById(Guid id)
        {
            await Task.CompletedTask;
            return Ok();
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UppdateOrderById(Guid id, List<OrderItem> orderItems)
        {
            await Task.CompletedTask;
            return Ok();
        }

        [HttpPut("take")]
        public async Task<IActionResult> TakeOrderById(Guid id)
        {
            await Task.CompletedTask;
            return Ok();
        }

        [HttpPut("cancel")]
        public async Task<IActionResult> CancelOrderById(Guid id)
        {
            await Task.CompletedTask;
            return Ok();
        }
    }
}
