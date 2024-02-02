using CMS.infraestructure.Repositorios.Respuestas;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CMS.infraestructure.Repositorios.Respuestas.Interfaces;
using CMS.infrastructure.Repositorios.Preguntas.Interfaces;
using CMS.infraestructure.Repositorios.Categorias.Interfaces;
using CMS.infraestructure.Repositories.Categories;
using CMS.infrastructure.Repositorios.Preguntas;
using CMS.infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using CMS.infraestructure.Repositorios.Seguridad.Interfaces;
using CMS.infraestructure.Repositorios.Seguridad;

namespace CMS.infraestructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection servicios, IConfiguration configuracion)
        {
            servicios.AddDbContext<CMSContext>(opciones => opciones.UseSqlServer(configuracion.GetConnectionString("DefaultConnection")));
            servicios.AddIdentityCore<IdentityUser<Guid>>()
                .AddRoles<IdentityRole<Guid>>()
                .AddEntityFrameworkStores<CMSContext>()
                .AddDefaultTokenProviders();


            servicios.AddTransient<IPreguntasRepositorio, PreguntasRepositorio>();
            servicios.AddTransient<IRespuestaRepositorio, RespuestaRepositorio>();
            servicios.AddTransient<ICategoriaRepositorio, CategoryRepository>();
            servicios.AddTransient<IUsuarioRepositorio, UsuarioRepositorio>();
            servicios.AddTransient<IRoleRepositorio, RoleRepositorio>();

            return servicios;
        }

    }
}
