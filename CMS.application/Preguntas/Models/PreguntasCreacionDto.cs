

namespace CMS.application.Preguntas.Models
{
    public class PreguntasCreacionDto
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Prioridad { get; set; }
        public DateTime FechaDeComentario { get; set; }
        public ICollection<int> CategoriasIds { get; set; }
    }

}
