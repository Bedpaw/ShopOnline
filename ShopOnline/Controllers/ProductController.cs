using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Contracts;
using ShopOnline.Data;
using ShopOnline.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
        
        public ProductController(IProductRepository productRepository,
            ILoggerService logger,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _logger = logger;
            _mapper = mapper;
        }
        /// <summary>
        /// Gets all products from db
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProducts()
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.LogInfo($"{location}: Attempted Call");
                var products = await _productRepository.FindAll();
                var response = _mapper.Map<IList<ProductDTO>>(products);
                _logger.LogInfo($"{location}: Successful");
                return Ok(response);
            }
            catch (Exception e)
            {
                return InternalError($"{location}: {e.Message} - {e.InnerException}");
            }
        }
        /// <summary>
        /// Create new product type in db
        /// </summary>
        /// <param name="productDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] ProductCreateDTO productDTO)
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.LogInfo($"{location}: Create Attempted");
                if (productDTO == null)
                {
                    _logger.LogWarn($"{location}: Empty Request was submitted");
                    return BadRequest(ModelState);
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogWarn($"{location}: Data was Incomplete");
                    return BadRequest(ModelState);
                }
                var product = _mapper.Map<Product>(productDTO);
                var isSuccess = await _productRepository.Create(product);
                if (!isSuccess)
                {
                    return InternalError($"{location}: Creation failed");
                }
                _logger.LogInfo($"{location}: Creation was successful");
                return Created("Create", new { product });
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