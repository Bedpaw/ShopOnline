using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Contracts;
using ShopOnline.Data;
using ShopOnline.DTOs;

namespace ShopOnline.Controllers
{
 
        [Route("api/[controller]")]
        [ApiController]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public class OrderController : ControllerBase
        {
            private readonly IOrderRepository _orderRepository;
            private readonly ILoggerService _logger;
            private readonly IMapper _mapper;
        
            public OrderController(IOrderRepository orderRepository, ILoggerService logger, IMapper mapper)
            {
                _orderRepository = orderRepository;
                _logger = logger;
                _mapper = mapper;
            }
            
            /*
            public async Task<IActionResult> GetOrders()
            {
                var location = GetControllerActionNames();
                try
                {
                    _logger.LogInfo($"{location}: Attempted Call");
                    var orders = await _orderRepository.FindAll();
                    
                    var response = _mapper.Map<IList<OrderDTO>>(orders);
                    _logger.LogInfo($"{location}: Successful");
                    return Ok(response);
                }
                catch (Exception e)
                {
                    return InternalError($"{location}: {e.Message} - {e.InnerException}");
                }
            }
            /// <summary>
            /// Create new order in db
            /// </summary>
            /// <param name="orderDTO"></param>
            /// <returns></returns>
            [HttpPost]
            [ProducesResponseType(StatusCodes.Status201Created)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<IActionResult> Create([FromBody] OrderCreateDTO orderDTO)
            {
                var location = GetControllerActionNames();
                try
                {
                    _logger.LogInfo($"{location}: Create Attempted");
                    if (orderDTO == null)
                    {
                        _logger.LogWarn($"{location}: Empty Request was submitted");
                        return BadRequest(ModelState);
                    }
                    if (!ModelState.IsValid)
                    {
                        _logger.LogWarn($"{location}: Data was Incomplete");
                        return BadRequest(ModelState);
                    }
                    var order = _mapper.Map<Order>(orderDTO);
                    var isSuccess = await _orderRepository.Create(order);
                    if (!isSuccess)
                    {
                        return InternalError($"{location}: Creation failed");
                    }
                    _logger.LogInfo($"{location}: Creation was successful");
                    return Created("Create", new { order });
                }
                catch (Exception e)
                {
                    return InternalError($"{location}: {e.Message} - {e.InnerException}");
                }
            }*/
            private string GetControllerActionNames()
            {
                var controller = ControllerContext.ActionDescriptor.ControllerName;
                var action = ControllerContext.ActionDescriptor.ActionName;

                return $"{controller} - {action}";
            }
            private ObjectResult InternalError(string message)
            {
                _logger.LogError(message);
                return StatusCode(500, "Something went wrong. Please contact the Administrator");
            }
            
    }
}