using CMS.application.Seguridad.Dto;
using CMS.application.Seguridad.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APP.WEB.Controllers.Seguridad
{
    [ApiController]
    [Authorize(Roles = "ADMINISTRATOR")]
    [Route("api/[controller]")]
    public class RoleControlador : ControllerBase
    {
        private readonly IRoleServicio _roleService;
        private readonly ILogger<RoleControlador> _logger;
        public RoleControlador(IRoleServicio roleService, ILogger<RoleControlador> logger)
        {
            _roleService = roleService;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var roles = await _roleService.GetAll();
                var response = new
                {
                    Code = "200",
                    Data = roles,
                    Message = "Ok",
                    StackTrace = ""
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error executing GetAll Roles: {ex.Message} {ex.StackTrace}");
                var response = new { Code = "500", Message = "Bad", StackTrace = ex.StackTrace };
                return BadRequest(response);
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var role = await _roleService.Get(id);
                var response = new
                {
                    Code = "200",
                    Data = role,
                    Message = "Ok",
                    StackTrace = ""
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error executing Get Role {id}: {ex.Message} {ex.StackTrace}");
                var response = new { Code = "500", Message = "Bad", StackTrace = ex.StackTrace };
                return BadRequest(response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(AgregarRoleDto role)
        {
            try
            {
                var p = await _roleService.Add(role);
                var response = new { Code = "200", Message = "Ok", Data = p };
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error executing Adding Role: {ex.Message} {ex.StackTrace}");
                var response = new { Code = "500", Message = "Bad", StackTrace = ex.StackTrace };
                return BadRequest(response);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(RoleDto role)
        {
            try
            {
                var p = await _roleService.Update(role);
                var response = new { Code = "200", Message = "Ok", Data = p };
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error executing Update Role: {ex.Message} {ex.StackTrace}");
                var response = new { Code = "500", Message = "Bad", StackTrace = ex.StackTrace };
                return BadRequest(response);
            }

        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var isDeleted = await _roleService.Delete(id);
                var response = new
                {
                    Code = "200",
                    Data = "",
                    Message = "Ok",
                    StackTrace = ""
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error executing Delete Role {id}: {ex.Message} {ex.StackTrace}");
                var response = new { Code = "500", Message = "Bad", StackTrace = ex.StackTrace };
                return BadRequest(response);
            }

        }

        [HttpGet("GetRolesByUserId/{userId:guid}")]
        public async Task<IActionResult> GetRolesByUserId(Guid userId)
        {
            try
            {
                var roles = await _roleService.GetRolesByUserId(userId);
                var response = new
                {
                    Code = "200",
                    Data = roles,
                    Message = "Ok",
                    StackTrace = ""
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error executing Get Role by userId {userId}: {ex.Message} {ex.StackTrace}");
                var response = new { Code = "500", Message = "Bad", StackTrace = ex.StackTrace };
                return BadRequest(response);
            }
        }

        [HttpPost("AssignRoleToUser")]
        public async Task<IActionResult> AssignRoleToUser([FromBody] UsuarioRoleDto role)
        {
            try
            {
                var isAssigned = await _roleService.AsignRoleToUser(role.UserId, role.RoleId);
                if (isAssigned)
                {
                    var response = new
                    {
                        Code = "200",
                        Data = "",
                        Message = "Ok",
                        StackTrace = ""
                    };
                    return Ok(response);
                }
                else
                {
                    var response = new
                    {
                        Code = "400",
                        Data = "",
                        Message = "Role couldn't be assign",
                        StackTrace = ""
                    };
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error executing Assing Role: user: {role.UserId} role: {role.RoleId}: {ex.Message} {ex.StackTrace}");
                var response = new { Code = "500", Message = "Bad", StackTrace = ex.StackTrace };
                return BadRequest(response);
            }
        }

        [HttpDelete("RemoveRoleToUser")]
        public async Task<IActionResult> RemoveRoleToUser([FromBody] UsuarioRoleDto role)
        {
            try
            {
                var isAssigned = await _roleService.RemoveRoleToUser(role.UserId, role.RoleId);
                if (isAssigned)
                {
                    var response = new
                    {
                        Code = "200",
                        Data = "",
                        Message = "Ok",
                        StackTrace = ""
                    };
                    return Ok(response);
                }
                else
                {
                    var response = new
                    {
                        Code = "400",
                        Data = "",
                        Message = "Role couldn't be assign",
                        StackTrace = ""
                    };
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error executing Assing Role: user: {role.UserId} role: {role.RoleId}: {ex.Message} {ex.StackTrace}");
                var response = new { Code = "500", Message = "Bad", StackTrace = ex.StackTrace };
                return BadRequest(response);
            }
        }
    }
}
