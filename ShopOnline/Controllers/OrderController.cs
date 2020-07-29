using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Contracts;
using ShopOnline.Contracts.BusinessLogic;
using ShopOnline.Contracts.Repository;
using ShopOnline.Data;
using ShopOnline.DTOs;
using ShopOnline.Utils;

namespace ShopOnline.Controllers
{
 
        [Route("api/[controller]")]
        [ApiController]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public class OrderController : ControllerBase
        {
            private readonly IOrderLogic _businessLogic;
            private readonly ILoggerService _logger;
            private readonly IMapper _mapper;
        
            public OrderController(IOrderLogic businessLogic , ILoggerService logger, IMapper mapper)
            {
                _businessLogic = businessLogic;
                _logger = logger;
                _mapper = mapper;
            }
            /// <summary>
            /// Gets all orders from db
            /// </summary>
            /// <returns></returns>
            [HttpGet]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<IActionResult> GetOrders()
            {
                var location = GetControllerActionNames();
                try
                {
                    _logger.LogInfo($"{location}: Attempted Call");
                    var orders = await _businessLogic.GetAll();
                    
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
            [ProducesResponseType(CustomErrors.StatusCode450)]
        public async Task<IActionResult> Create([FromBody] OrderCreateDTO orderCreateDTO)
            {
                var location = GetControllerActionNames();
                try
                {
                    _logger.LogInfo($"{location}: Create Attempted");
                    if (orderCreateDTO == null)
                    {
                        _logger.LogWarn($"{location}: Empty Request was submitted");
                        return BadRequest(ModelState);
                    }
                    if (!ModelState.IsValid)
                    {
                        _logger.LogWarn($"{location}: Data was Incomplete");
                        return BadRequest(ModelState);
                    }
                    var order = _mapper.Map<Order>(orderCreateDTO);
                    var result = await _businessLogic.Add(order);
                    if (result.IsFailed)
                    {
                        return StatusCode(450, result.Errors[0].Message);
                    }
                    _logger.LogInfo($"{location}: Creation was successful");
                    return Created("Create", 1);
                }
                catch (Exception e)
                {
                    return InternalError($"{location}: {e.Message} - {e.InnerException}");
                }
            }
            private string GetControllerActionNames()
            {
                var controller = ControllerContext.ActionDescriptor.ControllerName;
                var action = ControllerContext.ActionDescriptor.ActionName;

                return $"{controller} - {action}";
            }
            private ObjectResult InternalError(string message)
            {
                _logger.LogError(message);
                return StatusCode(500,  CustomErrors.InternalServerError);
            }
            
    }
}