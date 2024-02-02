using CMS.application.Seguridad.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.application.Seguridad.Interfaces
{
    public interface IUsuarioServicio
    {
        public Task<UsuarioDto> Add(AgregarUsuarioDto user);

        Task<UsuarioDto> Update(UsuarioDto user);

        Task<UsuarioDto> Get(Guid id);

        Task<bool> Delete(Guid id);

        Task<ICollection<UsuarioDto>> GetAll();

        Task<UsuarioDto> Login(LoggeoDto login);
    }
}
