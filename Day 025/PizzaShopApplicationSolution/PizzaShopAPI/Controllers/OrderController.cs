﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaShop.Services;
using PizzaShopAPI.Interfaces;
using PizzaShopAPI.Models.DTOs;

namespace PizzaShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService, ILogger<OrderController> logger)
        {
            _logger = logger;
            _orderService = orderService;
        }

        [HttpPost("Place Order")]
        [ProducesResponseType(typeof(OrderDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(OrderDTO), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OrderDTO>> Add(OrderDTO orderDTO)
        {
            try
            {
                var result = await _orderService.AddOrder(orderDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound(new
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = "Unable to add order"
                });
            }
        }


        [HttpGet("Get Orders")]
        [ProducesResponseType(typeof(OrderDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(OrderDTO), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrderDTO>> Get()
        {
            try
            {
                var result = await _orderService.GetOrders();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound(new
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = "Order not found"
                });
            }
        }
    }
}
