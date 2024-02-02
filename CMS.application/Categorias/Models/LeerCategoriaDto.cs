using CMS.application.Common;

namespace CMS.application.Categorias.Models
{
    public class LeerCategoriaDto : BaseDto
    {
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }

    }
}
