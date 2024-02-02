using CMS.domain.Respuestas;

namespace CMS.infraestructure.Repositorios.Respuestas.Interfaces
{
    public interface IRespuestaRepositorio
    {
        public Task<ICollection<Respuesta>> GetAll();
        public Task<Respuesta> Get(int id);
        public Task<Respuesta> Create(Respuesta respuesta);
        public Task<Respuesta> Update(Respuesta respuesta);
        public Task<bool> Delete(int id);

    }
}
