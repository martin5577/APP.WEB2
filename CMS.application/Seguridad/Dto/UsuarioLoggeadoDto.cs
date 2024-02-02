using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.application.Seguridad.Dto
{
    public class UsuarioLoggeadoDto
    {
        public UsuarioDto User { get; set; }

        public string AccessToken { get; set; }
    }
}
