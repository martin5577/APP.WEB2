using CMS.infraestructure.Data;
using CMS.infraestructure.Repositorios.Seguridad.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.infraestructure.Repositorios.Seguridad
{
    public class RoleRepositorio : IRoleRepositorio
    {
        private readonly CMSContext _context;
        private readonly RoleManager<IdentityRole<Guid>> _roleAdministrador;
        private readonly UserManager<IdentityUser<Guid>> _usuarioAdministrador;
        public RoleRepositorio(CMSContext context, RoleManager<IdentityRole<Guid>> roleManager, UserManager<IdentityUser<Guid>> userManager)
        {
            _context = context;
            _roleAdministrador = roleManager;
            _usuarioAdministrador = userManager;
        }

        public async Task<IdentityRole<Guid>> Add(IdentityRole<Guid> role)
        {
            var aux = await _roleAdministrador.CreateAsync(role);
            return role;
        }

        public async Task<bool> Delete(Guid id)
        {
            var role = _roleAdministrador.Roles.First(x => x.Id == id);
            var result = await _roleAdministrador.DeleteAsync(role);
            return result.Succeeded;
        }

        public async Task<IdentityRole<Guid>> Get(Guid Id)
        {
            return await _roleAdministrador.Roles.FirstAsync(x => x.Id == Id);
        }

        public async Task<ICollection<IdentityRole<Guid>>> GetAll()
        {
            return await _roleAdministrador.Roles.ToListAsync();
        }

        public async Task<IdentityRole<Guid>> Update(IdentityRole<Guid> role)
        {
            await _roleAdministrador.UpdateAsync(role);
            return role;
        }

        public async Task<IList<string>> GetRolesByUser(string username)
        {
            var user = await _usuarioAdministrador.FindByEmailAsync(username);
            var roles = await _usuarioAdministrador.GetRolesAsync(user);
            List<string> normalizedRoles = new List<string>();
            foreach (var item in roles)
            {
                var role = _context.Roles.FirstOrDefault(x => x.Name.Equals(item));
                normalizedRoles.Add(role.NormalizedName);
            }

            return normalizedRoles;
        }

        public async Task<ICollection<IdentityRole<Guid>>> GetRolesByUserId(Guid userId)
        {
            var userRoles = _context.UserRoles.Where(x => x.UserId == userId).ToList();
            List<IdentityRole<Guid>> roles = new List<IdentityRole<Guid>>();
            foreach (var userRole in userRoles)
            {
                var role = await _roleAdministrador.FindByIdAsync(userRole.RoleId.ToString());
                roles.Add(role);
            }

            return roles;
        }

        public async Task<bool> AsignRoleToUser(Guid userId, Guid roleId)
        {
            var user = await _usuarioAdministrador.FindByIdAsync(userId.ToString());
            var role = await _roleAdministrador.FindByIdAsync(roleId.ToString());
            var result = await _usuarioAdministrador.AddToRoleAsync(user, role.NormalizedName);

            return result.Succeeded;
        }

        public async Task<bool> RemoveRoleToUser(Guid userId, Guid roleId)
        {
            var user = await _usuarioAdministrador.FindByIdAsync(userId.ToString());
            var role = await _roleAdministrador.FindByIdAsync(roleId.ToString());

            var result = await _usuarioAdministrador.RemoveFromRoleAsync(user, role.NormalizedName);
            return result.Succeeded;
        }
    }
}
