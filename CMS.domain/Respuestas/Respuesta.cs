using CMS.domain.Common;
using CMS.domain.Preguntas;

namespace CMS.domain.Respuestas
{
    public class Respuesta : AuditEntity
    {
        public string Respuestas { get; set; }
        public DateTime FechaRespuesta { get; set; }
        public string UserId { get; set; }
        public int PreguntaId { get; set; }
        public Pregunta Pregunta { get; set; }

    }
}
