using CMS.domain.Preguntas;

namespace CMS.infrastructure.Repositorios.Preguntas.Interfaces
{
    public interface IPreguntasRepositorio
    {
        public Task<ICollection<Pregunta>> GetAll();
        public Task<Pregunta> Get(int id);
        public Task<Pregunta> Create(Pregunta pregunta);
        public Task<Pregunta> Update(Pregunta pregunta);
        public Task<bool> Delete(int id);

        public Task<ICollection<Pregunta>> GetPreguntaFechaPublicacion(DateTime publishDate);

    }
}
