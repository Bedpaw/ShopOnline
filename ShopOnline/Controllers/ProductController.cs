using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public class ProductController : ControllerBase
    {
        /*private readonly IProductRepository _productRepository;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
        
        public ProductController(IProductRepository productRepository,
            ILoggerService logger,
            IMapper mapper)
        {
            _productRepository= = ProductRepository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAuthors()
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.LogInfo($"{location}: Attempted Call");
                var authors = await _productRepository.FindAll();
                var response = _mapper.Map<IList<ProductDTO>>(authors);
                _logger.LogInfo($"{location}: Successful");
                return Ok(response);
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
        }*/
    }
}