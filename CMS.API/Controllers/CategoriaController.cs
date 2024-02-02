using CMS.application.Categorias.Interfaces;
using CMS.application.Categorias.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CMS.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase
    {

        private readonly ILogger<CategoriaController> _logger;
        private readonly ICategoryService _categoriaService;
        public CategoriaController(ILogger<CategoriaController> logger, ICategoryService categoriaService)
        {
            _logger = logger;
            _categoriaService = categoriaService;

        }

        /// <summary>
        /// www.test.com/api/category/Create
        /// </summary>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync([FromBody] CrearCategoriaDto categoria)
        {
            try
            {
                var categoryResult = await _categoriaService.Create(categoria);
                return StatusCode((int)HttpStatusCode.Created, categoryResult);

            }
            catch(Exception e)
            {
                _logger.LogError("CategoriaController error: CreateAsync" + e.Message);
                return BadRequest("Bad Request, contact administrator");
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] LeerCategoriaDto categoria)
        {
            try
            {
                var categoryResult = await _categoriaService.Update(categoria);
                return new OkObjectResult(categoryResult);
            }
            catch(Exception e)
            {
                _logger.LogError("CategoriaController error: Update" + e.Message);
                return BadRequest("Bad Request, contact administrator");
            }

        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var result = await _categoriaService.Delete(id);

            return new OkObjectResult(new { deleted = result });
            }
            catch (Exception e)
            {
                _logger.LogError("CategoriaController error: Delete" + e.Message);
                return BadRequest("Bad Request, contact administrator");
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var categories = await _categoriaService.GetAll();

                return new OkObjectResult(categories);

            }
            catch(Exception)
            {
                var categories = await _categoriaService.GetAll();

                return new OkObjectResult(categories);
            }
                        
        }
        [HttpGet("(id)")]
        public async Task<IActionResult> GetByIdAsync([FromRoute]int id)
        {
            try
            {
                var category = await _categoriaService.Get(id);

                return new OkObjectResult(category);

            }
            catch (InvalidOperationException e)
            {
                _logger.LogInformation($"Categoria with id {id} not found" + e.Message);
                return NotFound($"Categoria with id {id} not found");
            }
            catch (Exception e)
            {
                _logger.LogError("CategoriaController error: GetById" + e.Message);
                return BadRequest("Bad Request, contact administrator");
            }
        }
    }
}
