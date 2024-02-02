using CMS.application.Seguridad.Dto;
using CMS.application.Seguridad.Interfaces;
using CMS.infraestructure.Repositorios.Seguridad.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.application.Seguridad
{
    public class UserService : IUsuarioServicio
    {
        private readonly IUsuarioRepositorio _userRepository;
        public UserService(IUsuarioRepositorio userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UsuarioDto> Add(AgregarUsuarioDto user)
        {
            IdentityUser<Guid> userEntity = new IdentityUser<Guid>
            {
                Email = user.Email,
                UserName = user.Email
            };

            var result = await _userRepository.Add(userEntity, user.Password);

            return new UsuarioDto
            {
                Id = result.Id,
                Email = result.Email,
                Name = result.UserName
            };

        }

        public async Task<bool> Delete(Guid id)
        {
            return await _userRepository.Delete(id);
        }

        public async Task<UsuarioDto> Get(Guid id)
        {
            var user = await _userRepository.Get(id);
            return new UsuarioDto { Id = user.Id, Email = user.Email, Name = user.UserName };
        }

        public async Task<ICollection<UsuarioDto>> GetAll()
        {
            var users = await _userRepository.GetAll();
            return users.Select(x => new UsuarioDto
            {
                Id = x.Id,
                Email = x.Email,
                Name = x.UserName
            }).ToList();
        }

        public async Task<UsuarioDto> Login(LoggeoDto login)
        {
            var userEntity = await _userRepository.Login(login.Username, login.Password);
            UsuarioDto user = null;
            if (userEntity is not null)
                user = new UsuarioDto
                {
                    Id = userEntity.Id,
                    Email = userEntity.Email,
                    Name = userEntity.UserName
                };

            return user;
        }

        public async Task<UsuarioDto> Update(UsuarioDto user)
        {
            var userEntity = await _userRepository.Get(user.Id);
            userEntity.UserName = user.Email;
            userEntity.Email = user.Email;

            var result = _userRepository.Update(userEntity);
            if (result != null)
                return user;
            return null;
        }
    }
}
