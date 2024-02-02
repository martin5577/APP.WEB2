using CMS.domain.Preguntas;
using CMS.infrastructure.Repositorios.Preguntas.Interfaces;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace CMS.infrastructure.Repositorios.Preguntas
{
    public class PreguntasRepositorio : IPreguntasRepositorio
    {
        public async Task<Pregunta> Create(Pregunta pregunta)
        {

            Pregunta preguntaEntity = pregunta;

            return await Task.FromResult(preguntaEntity);
        
        }

        public async Task<bool> Delete(int id)
        {
            return await Task.FromResult(true);
        }

        public async Task<Pregunta> Get(int id)
        {
            List<Pregunta> preguntas = new List<Pregunta>();
            preguntas.Add(new Pregunta
            {
                Id = 1,
                Nombre = "Prueba de pregunta",
                Descripcion = "Descripcion test",
                Prioridad = 0,

            });

            var pregunta = preguntas.First(x=>x.Id == id);
            return await Task.FromResult(pregunta);
        }

        public async Task<ICollection<Pregunta>> GetAll()
        {
             List<Pregunta> preguntas = new List<Pregunta>();
             preguntas.Add(new Pregunta
                {
                    Id = 1,
                    Nombre = "Prueba de pregunta",
                    Descripcion = "Descripcion test",
                    Prioridad = 0,

             });

                return await Task.FromResult(preguntas);
            }

        public async Task<ICollection<Pregunta>> GetPreguntaFechaPublicacion(DateTime publishDate)
        {
            List<Pregunta> preguntas = new List<Pregunta>();
            preguntas.Add(new Pregunta
            {
                Id = 1,
                Nombre = "Prueba de pregunta",
                Descripcion = "Descripcion test",
                Prioridad = 0,

            });

            preguntas.Where(x=>x.FechaDeComentario == publishDate).ToList();

            return await Task.FromResult(preguntas);
        }

        public async Task<Pregunta> Update(Pregunta pregunta)
        {
            Pregunta preguntaEntidad = pregunta;

            return await Task.FromResult(preguntaEntidad);
        }
    }
}
