using CMS.application.Categorias.Interfaces;
using CMS.application.Categorias.Models;
using CMS.domain.Categorias;
using CMS.infraestructure.Repositorios.Categorias.Interfaces;


namespace CMS.application.Categorias
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoriaRepositorio _categoriesRepository;
        public CategoryService (ICategoriaRepositorio categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }
        public async Task<LeerCategoriaDto> Create(CrearCategoriaDto category)
        {
            var entity = new Categoria
            {
                Nombre = category.Nombre,
            };
            entity = await _categoriesRepository.Create(entity);
            var mappedEntity = new LeerCategoriaDto
            {
                Id = entity.Id,
                Nombre = entity.Nombre,
                FechaCreacion = entity.FechaCreacion
            };
            return mappedEntity;

        }

        public async Task<bool> Delete(int id)
        {
            var result = await _categoriesRepository.Delete(id);
            return result;
        }

        public async Task<LeerCategoriaDto> Get(int id)
        {
            var entity = await _categoriesRepository.Get(id);
            var mappedEntity = new LeerCategoriaDto
            {
                Id = entity.Id,
                Nombre = entity.Nombre,
                FechaCreacion = entity.FechaCreacion
            };
            return mappedEntity;
        }

        public async Task<ICollection<LeerCategoriaDto>> GetAll()
        {
            var entities = await _categoriesRepository.GetAll();
            return entities.Select(x => new LeerCategoriaDto
            {
                Id = x.Id,
                Nombre = x.Nombre,
                FechaCreacion = x.FechaCreacion
            }).ToList();
        }

        public async Task<LeerCategoriaDto> Update(LeerCategoriaDto categoria)
        {
            var entityToUpdate = await _categoriesRepository.Get(categoria.Id);

            entityToUpdate.Id = categoria.Id;
            entityToUpdate.Nombre = categoria.Nombre;
            entityToUpdate.FechaCreacion = categoria.FechaCreacion;

            entityToUpdate = await _categoriesRepository.Update(entityToUpdate);
            var mappedEntity = new LeerCategoriaDto
            {
                Id = entityToUpdate.Id,
                Nombre = entityToUpdate.Nombre,
                FechaCreacion = entityToUpdate.FechaCreacion
            };
            return mappedEntity;
        }

    }
}
