using CMS.domain.Categorias;
using CMS.domain.Common;
using CMS.domain.Respuestas;

namespace CMS.domain.Preguntas
{
    public class Pregunta : AuditEntity
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Prioridad { get; set; }
        public DateTime FechaDeComentario { get; set; }
        public ICollection<Respuesta> Respuestas { get; set; }
        public ICollection<Categoria> Categorias { get; set; }
    }
}
