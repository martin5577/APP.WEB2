using CMS.application.Seguridad.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.application.Seguridad.Interfaces
{
    public interface IRoleServicio
    {
        Task<RoleDto> Add(AgregarRoleDto role);

        Task<RoleDto> Update(RoleDto role);

        Task<RoleDto> Get(Guid id);

        Task<bool> Delete(Guid id);

        Task<ICollection<RoleDto>> GetAll();

        Task<IList<string>> GetRolesByUser(UsuarioDto user);
        Task<ICollection<RoleDto>> GetRolesByUserId(Guid userId);

        Task<bool> AsignRoleToUser(Guid userId, Guid roleId);
        Task<bool> RemoveRoleToUser(Guid userId, Guid roleId);
    }
}
