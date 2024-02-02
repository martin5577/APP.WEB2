

namespace CMS.application.Respuestas.Models
{
    public class CrearRespuestaDto
    {
        public string Respuesta { get; set; }
        public DateTime FechaRespuesta { get; set; }
        public string UserId { get; set; }
        public int PreguntaId { get; set; }

    }
}
