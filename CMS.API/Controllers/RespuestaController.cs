using CMS.application.Respuestas.Interfaces;
using CMS.application.Respuestas.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace APP.WEB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RespuestaController : ControllerBase
    {
        private readonly ILogger<RespuestaController> _logger;
        private readonly IRespuestaService _respuestasService;
        public RespuestaController(ILogger<RespuestaController> logger, IRespuestaService respuestaService)
        {
            _logger = logger;
            _respuestasService = respuestaService;

        }

        /// <summary>
        /// www.test.com/api/comment/Create
        /// </summary>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync([FromBody] CrearRespuestaDto respuesta)
        {
            try
            {
                var respuestaResult = await _respuestasService.Create(respuesta);
                return StatusCode((int)HttpStatusCode.Created, respuestaResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] LeerRespuestaDto respuesta)
        {
            try
            {
                var respuestaResult = await _respuestasService.Update(respuesta);
                return new OkObjectResult(respuestaResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var result = await _respuestasService.Delete(id);

                return new OkObjectResult(new { deleted = result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var respuestas = await _respuestasService.GetAll();
                return new OkObjectResult(respuestas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            try
            {
                var respuestas = await _respuestasService.Get(id);
                return new OkObjectResult(respuestas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}