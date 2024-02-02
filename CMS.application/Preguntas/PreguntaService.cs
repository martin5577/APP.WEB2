using CMS.application.Preguntas.Interfaces;
using CMS.application.Preguntas.Models;
using CMS.domain.Preguntas;
using CMS.infrastructure.Repositorios.Preguntas.Interfaces;
using System.Linq;


namespace CMS.application.Preguntas
{
    public class PreguntaService : IPreguntaService
    {
        private readonly IPreguntasRepositorio _postRepository;
        public PreguntaService(IPreguntasRepositorio postRepositorio) 
        {
            _postRepository = postRepositorio;
        }
        public async Task<PreguntasLecturaDto> Create(PreguntasCreacionDto pregunta)
        {
            Pregunta preguntaEntidad = new Pregunta();
            preguntaEntidad.Prioridad = pregunta.Prioridad;
            preguntaEntidad.Nombre = pregunta.Nombre;

            preguntaEntidad = await _postRepository.Create(preguntaEntidad);

            PreguntasLecturaDto result = new PreguntasLecturaDto
            {
                Id = preguntaEntidad.Id,
                Nombre = preguntaEntidad.Nombre
            };
            return await Task.FromResult(result);
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PreguntasLecturaDto> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<PreguntasLecturaDto>> GetAll()
        {
            var preguntas = await _postRepository.GetAll();
            var preguntasLista = preguntas.Select(x => new PreguntasLecturaDto { Nombre = x.Nombre }).ToList();
            return await Task.FromResult(preguntasLista);
        }

        public Task<ICollection<PreguntasLecturaDto>> GetPreguntaFechaPublicacion(DateTime publishDate)
        {
            throw new NotImplementedException();
        }

        public Task<PreguntasLecturaDto> Update(PreguntasLecturaDto pregunta)
        {
            throw new NotImplementedException();
        }
    }
}
