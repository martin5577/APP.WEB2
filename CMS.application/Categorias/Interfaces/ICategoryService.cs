using CMS.application.Categorias.Models;

namespace CMS.application.Categorias.Interfaces
{
    public interface ICategoryService
    {
        public Task<ICollection<LeerCategoriaDto>> GetAll();
        public Task<LeerCategoriaDto> Get(int id);
        public Task<LeerCategoriaDto> Create(CrearCategoriaDto category);
        public Task<LeerCategoriaDto> Update(LeerCategoriaDto category);
        public Task<bool> Delete(int id);
    }
}

