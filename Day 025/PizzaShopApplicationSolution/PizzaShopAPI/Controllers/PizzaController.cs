﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaShopAPI.Interfaces;
using PizzaShopAPI.Models.DTOs;
using PizzaShopAPI.Services;

namespace PizzaShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly ILogger<PizzaController> _logger;
        private readonly IPizzaService _pizzaService;

        public PizzaController(IPizzaService pizzaService, ILogger<PizzaController> logger)
        {
            _logger = logger;
            _pizzaService = pizzaService;
        }

        [Authorize]
        [HttpGet("Get Pizzas In Stock")]
        [ProducesResponseType(typeof(PizzaDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(PizzaDTO), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrderDTO>> Get()
        {
            try
            {
                var result = await _pizzaService.GetAllPizza();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound(new
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = "Pizzas not found"
                });
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("Add Pizza")]
        [ProducesResponseType(typeof(PizzaDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(PizzaDTO), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OrderDTO>> Add(PizzaDTO pizzaDTO)
        {
            try
            {
                var result = await _pizzaService.AddPizza(pizzaDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound(new
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = "Unable to add pizza"
                });
            }
        }

        [HttpPut("Update Stock")]
        [ProducesResponseType(typeof(PizzaDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(PizzaDTO), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrderDTO>> Update([FromBody] int id, int stock)
        {
            try
            {
                var result = await _pizzaService.UpdatePizzaStock(id,stock);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound(new
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = "Pizzas not found"
                });
            }
        }
    }
}
