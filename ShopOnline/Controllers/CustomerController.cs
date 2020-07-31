using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Contracts;
using ShopOnline.Contracts.BusinessLogic;
using ShopOnline.Data;
using ShopOnline.DTOs;
using ShopOnline.Utils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        ///     Create new Customer in db
        /// </summary>
        /// <param name="CustomerDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CustomerCreateDTO CustomerDTO)
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.LogInfo($"{location}: Create Attempted");
                if (CustomerDTO == null)
                {
                    _logger.LogWarn($"{location}: Empty Request was submitted");
                    return BadRequest(ModelState);
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogWarn($"{location}: Data was Incomplete");
                    return BadRequest(ModelState);
                }

                var customer = _mapper.Map<Customer>(CustomerDTO);
                var result = await _businessLogic.Add(customer);
                if (result.IsFailed) return InternalError($"{location}: Creation failed");

                _logger.LogInfo($"{location}: Creation was successful");
                return Created("Create", new { customer });
            }
            catch (Exception e)
            {
                return InternalError($"{location}: {e.Message} - {e.InnerException}");
            }
        }

        /// <summary>
        ///     Gets all customers from db
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCustomers()
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.LogInfo($"{location}: Attempted Call");
                var customers = await _businessLogic.GetAll();

                var response = _mapper.Map<IList<CustomerDTO>>(customers);
                _logger.LogInfo($"{location}: Successful");
                return Ok(response);
            }
            catch (Exception e)
            {
                return InternalError($"{location}: {e.Message} - {e.InnerException}");
            }
        }

        /// <summary>
        ///     Removes a customer by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.LogInfo($"{location}: Delete Attempted on record with id: {id} ");
                if (id < 1)
                {
                    _logger.LogWarn($"{location}: Delete failed with bad data - id: {id}");
                    return BadRequest();
                }

                var result = await _businessLogic.Delete(id);
                if (result.IsFailed) return InternalError($"{location}: Delete failed for record with id: {id}");

                _logger.LogInfo($"{location}: Record with id: {id} successfully deleted");
                return NoContent();
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
            return StatusCode(500, CustomErrors.InternalServerError);
        }
    }
}