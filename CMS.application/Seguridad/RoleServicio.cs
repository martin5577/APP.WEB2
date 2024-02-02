﻿using CMS.application.Seguridad.Dto;
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
    public class RoleService : IRoleServicio
    {
        private readonly IRoleRepositorio _roleRepository;
        public RoleService(IRoleRepositorio roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<RoleDto> Add(AgregarRoleDto role)
        {
            var roleEntity = new IdentityRole<Guid>
            {
                Name = role.Name,
                NormalizedName = role.NormalizedName,
            };

            var createdRole = await _roleRepository.Add(roleEntity);
            return new RoleDto
            {
                Priority = role.Priority,
                NormalizedName = role.NormalizedName,
                Name = createdRole.Name,
                Id = createdRole.Id
            };
        }

        public Task<bool> Delete(Guid id)
        {
            return _roleRepository.Delete(id);
        }

        public async Task<RoleDto> Get(Guid id)
        {
            var role = await _roleRepository.Get(id);
            return new RoleDto
            {
                Id = role.Id,
                Name = role.Name,
                NormalizedName = role.NormalizedName,
            };
        }

        public async Task<ICollection<RoleDto>> GetAll()
        {
            var roles = await _roleRepository.GetAll();
            return roles.Select(x => new RoleDto
            {
                Id = x.Id,
                Name = x.Name,
                NormalizedName = x.NormalizedName,
            }).ToList();
        }

        public async Task<RoleDto> Update(RoleDto role)
        {
            var roleEntity = await _roleRepository.Get(role.Id);
            roleEntity.NormalizedName = role.NormalizedName;
            roleEntity.Name = role.Name;

            var updatedRole = await _roleRepository.Update(roleEntity);
            return new RoleDto
            {
                Id = updatedRole.Id,
                Name = updatedRole.Name,
                NormalizedName = updatedRole.NormalizedName
            };
        }

        #region security access
        public async Task<IList<string>> GetRolesByUser(UsuarioDto user)
        {
            var roles = await _roleRepository.GetRolesByUser(user.Email);
            return roles;
        }

        public async Task<ICollection<RoleDto>> GetRolesByUserId(Guid userId)
        {
            var roles = await _roleRepository.GetRolesByUserId(userId);
            return roles.Select(x => new RoleDto
            {
                Id = x.Id,
                Name = x.Name,
                NormalizedName = x.NormalizedName,
            }).ToList();
        }

        public async Task<bool> AsignRoleToUser(Guid userId, Guid roleId)
        {
            var result = await _roleRepository.AsignRoleToUser(userId, roleId);
            return result;
        }

        public async Task<bool> RemoveRoleToUser(Guid userId, Guid roleId)
        {
            var result = await _roleRepository.RemoveRoleToUser(userId, roleId);
            return result;
        }

        #endregion
    }
}
