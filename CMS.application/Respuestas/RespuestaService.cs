using CMS.application.Respuestas.Interfaces;
using CMS.application.Respuestas.Models;
using CMS.domain.Respuestas;
using CMS.infraestructure.Repositorios.Respuestas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CMS.application.Respuestas
{
    public class RespuestaService : IRespuestaService

    {
        private readonly IRespuestaRepositorio _respuestaRepositorio;
        public RespuestaService(IRespuestaRepositorio commentRepository)
        {
            _respuestaRepositorio = commentRepository;
        }

        public async Task<LeerRespuestaDto> Create(CrearRespuestaDto respuesta)
        {
            var entity = new Respuesta
            {
                PreguntaId = respuesta.PreguntaId,
                FechaRespuesta = respuesta.FechaRespuesta,
                Respuestas = respuesta.Respuesta
            };
            entity = await _respuestaRepositorio.Create(entity);
            var mappedEntity = new LeerRespuestaDto
            {
                Id = entity.Id,
                Respuesta = entity.Respuestas,
                FechaRespuesta = entity.FechaRespuesta,
                PreguntaId = respuesta.PreguntaId,
                UserId = respuesta.UserId

            };
            return mappedEntity;

        }

        public async Task<bool> Delete(int id)
        {
            var result = await _respuestaRepositorio.Delete(id);
            return result;
        }

        public async Task<LeerRespuestaDto> Get(int id)
        {
            var entity = await _respuestaRepositorio.Get(id);
            var mappedEntity = new LeerRespuestaDto
            {
                Id = entity.Id,
                Respuesta = entity.Respuestas,
                FechaRespuesta = entity.FechaRespuesta,
                PreguntaId = entity.PreguntaId,
                UserId = entity.UserId
            };
            return mappedEntity;
        }

        public async Task<ICollection<LeerRespuestaDto>> GetAll()
        {
            var entities = await _respuestaRepositorio.GetAll();
            return entities.Select(x => new LeerRespuestaDto
            {
                Id = x.Id,
                Respuesta = x.Respuestas,
                FechaRespuesta = x.FechaRespuesta,
                PreguntaId = x.PreguntaId,
                UserId = x.UserId
            }).ToList();
        }

        public async Task<LeerRespuestaDto> Update(LeerRespuestaDto category)
        {
            var entity = new Respuesta
            {
                Id = category.Id,

            };
            entity = await _respuestaRepositorio.Update(entity);
            var mappedEntity = new LeerRespuestaDto
            {
                Id = entity.Id,
                Respuesta = entity.Respuestas,
                FechaRespuesta = entity.FechaRespuesta,
                PreguntaId = entity.PreguntaId,
                UserId = entity.UserId
            };
            return mappedEntity;
        }
    }
}
    
