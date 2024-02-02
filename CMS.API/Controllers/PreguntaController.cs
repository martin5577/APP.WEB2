using CMS.application.Preguntas;
using CMS.application.Preguntas.Interfaces;
using CMS.application.Preguntas.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;


namespace APP.WEB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PreguntasController : ControllerBase
    {

        private readonly ILogger<PreguntasController> _logger;
        private readonly IPreguntaService _preguntaService;
        public PreguntasController(ILogger<PreguntasController> logger, IPreguntaService preguntaService)
        {
            _logger = logger;
            _preguntaService = preguntaService;

        }

        /// <summary>
        /// www.test.com/api/post/Create
        /// </summary>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<IActionResult> Post([FromBody] PreguntasCreacionDto pregunta)
        {
            try
            {
                var createdPregunta = await _preguntaService.Create(pregunta);
                return StatusCode((int)HttpStatusCode.Created, createdPregunta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] PreguntasLecturaDto pregunta)
        {
            try
            {
                var updatedPregunta = await _preguntaService.Update(pregunta);
                return new OkObjectResult(updatedPregunta);
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
                var result = await _preguntaService.Delete(id);
                return new OkObjectResult(new { deleted = result });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest($"Could not delete post with {id}");
            }

        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var preguntas = await _preguntaService.GetAll();

                return new OkObjectResult(preguntas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var preguntas = await _preguntaService.Get(id);

                return new OkObjectResult(preguntas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("publishDate")]
        public async Task<IActionResult> GetByPublishDate([FromQuery] DateTime publishDate)
        {
            try
            {
                var preguntas = await _preguntaService.GetPreguntaFechaPublicacion(publishDate);

                return new OkObjectResult(preguntas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}