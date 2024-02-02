using CMS.domain.Respuestas;
using CMS.infraestructure.Repositorios.Respuestas.Interfaces;

namespace CMS.infraestructure.Repositorios.Respuestas
{
    public class RespuestaRepositorio : IRespuestaRepositorio
    {
        private ICollection<Respuesta> TestData;

        public RespuestaRepositorio()
        {
            TestData = new List<Respuesta>();
            TestData.Add(new Respuesta
            {
                Id = 1,
                Respuestas = "Respuesta Test",
                PreguntaId = 1,
                FechaRespuesta = DateTime.Now,
                UserId = Guid.NewGuid().ToString(),
            });
            TestData.Add(new Respuesta
            {
                Id = 2,
                Respuestas = "Respuesta Test 2",
                PreguntaId = 2,
                FechaRespuesta = DateTime.Now,
                UserId = Guid.NewGuid().ToString(),
            });
        }

        public async Task<Respuesta> Create(Respuesta respuesta)
        {
            TestData.Add(respuesta);
            return await Task.FromResult(respuesta);
        }

        public async Task<bool> Delete(int id)
        {
            var entity = TestData.First(x => x.Id == id);
            TestData.Remove(entity);
            return await Task.FromResult(true);
        }

        public async Task<Respuesta> Get(int id)
        {
            var respuesta = TestData.First(x => x.Id == id);
            return await Task.FromResult(respuesta);
        }

        public async Task<ICollection<Respuesta>> GetAll()
        {
            return await Task.FromResult(TestData);
        }

        public async Task<Respuesta> Update(Respuesta respuesta)
        {
            var updateEntity = TestData.First(x => x.Id == respuesta.Id);
            updateEntity = respuesta;

            return await Task.FromResult(updateEntity);
        }
    }
}
