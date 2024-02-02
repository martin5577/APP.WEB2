using CMS.domain.Common;

namespace CMS.domain.Categorias
{
    public class Categoria : BaseEntity
    {
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }

        public Categoria() 
        {
            FechaCreacion = DateTime.Now;
        }


    }
}
