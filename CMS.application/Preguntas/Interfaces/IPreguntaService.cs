using CMS.application.Preguntas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.application.Preguntas.Interfaces
{
    public interface IPreguntaService
    {
        public Task<ICollection<PreguntasLecturaDto>> GetAll();
        public Task<PreguntasLecturaDto> Get(int id);
        public Task<PreguntasLecturaDto> Create(PreguntasCreacionDto pregunta);
        public Task<PreguntasLecturaDto> Update(PreguntasLecturaDto pregunta);
        public Task<bool> Delete(int id);

        public Task<ICollection<PreguntasLecturaDto>> GetPreguntaFechaPublicacion(DateTime publishDate);
    }
}
