﻿using CMS.application.Seguridad;
using CMS.application.Seguridad.Dto;
using CMS.application.Seguridad.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APP.WEB.Controllers.Seguridad
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class UsuarioControlador : ControllerBase
    {
        private readonly ILogger<UsuarioControlador> _logger;
        private readonly IUsuarioServicio _userService;
        private readonly IConfiguration _configuration;

        public UsuarioControlador(ILogger<UsuarioControlador> logger, IUsuarioServicio userService, IConfiguration configuration)
        {
            _logger = logger;
            _userService = userService;
            _configuration = configuration;
        }

        [Authorize(Roles = "ADMINISTRATOR")]
        [HttpGet]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var user = await _userService.Get(id);

                return Ok(new
                {
                    Code = "200",
                    Message = "Ok",
                    Data = user
                });

            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    Code = "500",
                    Message = "Bad",
                    Data = "",
                    StackTrace = ex.Message + " " + ex.StackTrace + " " + ex.InnerException
                });
            }
        }

        [Authorize(Roles = "ADMINISTRATOR")]
        [HttpPost()]
        public async Task<IActionResult> Create(AgregarUsuarioDto user)
        {
            try
            {
                var result = await _userService.Add(user);

                return Ok(new
                {
                    Code = "200",
                    Message = "Ok",
                    Data = result,
                });

            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    Code = "500",
                    Message = "Bad",
                    Data = "",
                    StackTrace = ex.Message + " " + ex.StackTrace
                });
            }
        }

        [Authorize(Roles = "ADMINISTRATOR")]
        [HttpPut()]
        public async Task<IActionResult> Update(UsuarioDto user)
        {
            try
            {
                var result = await _userService.Update(user);

                return Ok(new
                {
                    Code = "200",
                    Message = "Ok",
                    Data = result,
                });

            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    Code = "500",
                    Message = "Bad",
                    Data = "",
                    StackTrace = ex.Message + " " + ex.StackTrace
                });
            }
        }

        [Authorize(Roles = "ADMINISTRATOR")]
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _userService.GetAll();

                return Ok(new
                {
                    Code = "200",
                    Message = "Ok",
                    Data = users
                });

            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Code = "500",
                    Message = "Bad",
                    Data = "",
                    StackTrace = ex.Message + " " + ex.StackTrace + " " + ex.InnerException
                });
            }

        }

        [HttpDelete]
        [Authorize(Roles = "ADMINISTRATOR")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var users = await _userService.Delete(id);

                return Ok(new
                {
                    Code = "200",
                    Message = "Ok",
                    Data = true
                });

            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    Code = "500",
                    Message = "Bad",
                    Data = "",
                    StackTrace = ex.Message + " " + ex.StackTrace + " " + ex.InnerException
                });
            }
        }

        [AllowAnonymous]
        [HttpPost("GetToken")]
        public async Task<IActionResult> GetToken(LoggeoDto user)
        {
            try
            {
                var loggedUser = await _userService.Login(user);

                if (loggedUser is not null)
                {
                    var roles = "ADMINISTRATOR";
                    var issuer = _configuration.GetSection("Jwt").GetSection("Issuer").Value;
                    var audience = _configuration.GetSection("Jwt").GetSection("Audience").Value;
                    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt").GetSection("Key").Value));
                    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Sid, loggedUser.Id.ToString()),
                        new Claim(ClaimTypes.Name, loggedUser.Email),
                        new Claim(ClaimTypes.Email, loggedUser.Email),
                    };

                    //loggedUser.Roles = roles;

                    foreach (var role in roles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, "ADMINISTRATOR"));
                    }

                    var token = new JwtSecurityToken(
                        issuer: issuer,
                        audience: audience,
                        expires: DateTime.Now.AddMinutes(10),
                        claims: claims,
                        signingCredentials: credentials
                    );
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var stringToken = tokenHandler.WriteToken(token);

                    HttpContext.Response.Cookies.Append("token", stringToken,
                    new CookieOptions
                    {
                        Expires = DateTime.Now.AddDays(7),
                        HttpOnly = true,
                        Secure = true,
                        IsEssential = true,
                        SameSite = SameSiteMode.None
                    });

                    UsuarioLoggeadoDto userLogged = new UsuarioLoggeadoDto
                    {
                        //AccessToken = stringToken,
                        User = loggedUser
                    };

                    return Ok(new
                    {
                        Code = "200",
                        Message = "Ok",
                        Data = userLogged
                    });
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    Code = "500",
                    Message = "Bad",
                    Data = "",
                    StackTrace = ex.Message + " " + ex.StackTrace + " " + ex.InnerException
                });
            }
        }

    }
}
