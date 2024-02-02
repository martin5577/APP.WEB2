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
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly UserManager<IdentityUser<Guid>> _usuariorAdministrador;

        public UsuarioRepositorio(CMSContext context, UserManager<IdentityUser<Guid>> userManager)
        {
            _usuariorAdministrador = userManager;
        }

        public async Task<IdentityUser<Guid>> Add(IdentityUser<Guid> user, string password)
        {
            IdentityResult result = await _usuariorAdministrador.CreateAsync(user, password);

            if (result.Succeeded)
            {
                return user;
            }
            else
            {
                var errors = "";
                foreach (var error in result.Errors)
                {
                    errors += error.Code + " " + error.Description;
                }
                throw new Exception(errors);
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            var user = await _usuariorAdministrador.FindByIdAsync(id.ToString());
            var result = await _usuariorAdministrador.DeleteAsync(user);
            return result.Succeeded;
        }

        public async Task<IdentityUser<Guid>> Get(Guid Id)
        {
            var user = await _usuariorAdministrador.FindByIdAsync(Id.ToString());
            return user;
        }

        public async Task<ICollection<IdentityUser<Guid>>> GetAll()
        {
            var users = await _usuariorAdministrador.Users.ToListAsync();
            return users;
        }

        public async Task<IdentityUser<Guid>> Login(string username, string password)
        {
            var identityUsr = await _usuariorAdministrador.FindByNameAsync(username);

            var is_valid_user = false;
            if (await _usuariorAdministrador.CheckPasswordAsync(identityUsr, password))
            {
                is_valid_user = true;
            }

            return (is_valid_user == true) ? identityUsr : null;
        }

        public async Task<IdentityUser<Guid>> Update(IdentityUser<Guid> user)
        {
            var result = await _usuariorAdministrador.UpdateAsync(user);
            if (!result.Succeeded)
                return null;
            return user;
        }
    }

}
