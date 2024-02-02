using CMS.application.Respuestas.Models;

namespace CMS.application.Respuestas.Interfaces
{
    public interface IRespuestaService
    {
        public Task<ICollection<LeerRespuestaDto>> GetAll();
        public Task<LeerRespuestaDto> Get(int id);
        public Task<LeerRespuestaDto> Create(CrearRespuestaDto post);
        public Task<LeerRespuestaDto> Update(LeerRespuestaDto post);
        public Task<bool> Delete(int id);
    }
}
