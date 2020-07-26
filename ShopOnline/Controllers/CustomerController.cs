using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Contracts;
using ShopOnline.Contracts.BusinessLogic;
using ShopOnline.Data;
using ShopOnline.DTOs;

namespace ShopOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerLogic _businessLogic;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerLogic businessLogic, ILoggerService logger, IMapper mapper)
        {
            _businessLogic = businessLogic;
            _logger = logger;
            _mapper = mapper;
        }
         /// <summary>
            /// Create new Customer in db
            /// </summary>
            /// <param name="CustomerDTO"></param>
            /// <returns></returns>
            [HttpPost]
            [ProducesResponseType(StatusCodes.Status201Created)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<IActionResult> Create([FromBody] CustomerCreateDTO customerDTO)
            {
                var location = GetControllerActionNames();
                try
                {
                    _logger.LogInfo($"{location}: Create Attempted");
                    if (customerDTO == null)
                    {
                        _logger.LogWarn($"{location}: Empty Request was submitted");
                        return BadRequest(ModelState);
                    }
                    if (!ModelState.IsValid)
                    {
                        _logger.LogWarn($"{location}: Data was Incomplete");
                        return BadRequest(ModelState);
                    }
                    var customer = _mapper.Map<Customer>(customerDTO);
                    var isSuccess = await _businessLogic.Add(customer);
                    if (!isSuccess)
                    {
                        return InternalError($"{location}: Creation failed");
                    }
                    _logger.LogInfo($"{location}: Creation was successful");
                    return Created("Create", new { customer });
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
                return StatusCode(500, "Something went wrong. Please contact the Administrator");
            }
    }


}