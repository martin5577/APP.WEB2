using CMS.domain.Categorias;
using CMS.infraestructure.Data;
using CMS.infraestructure.Repositorios.Categorias.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CMS.infraestructure.Repositories.Categories
{
    public class CategoryRepository : ICategoriaRepositorio
    {
        private readonly CMSContext _context;
        public CategoryRepository(CMSContext context)
        {
            _context = context;
        }

        public async Task<Categoria> Create(Categoria category)
        {
            await _context.Categorias.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
                    }

        public async Task<bool> Delete(int id)
        {
            var categoryEntity = await _context.Categorias.FirstAsync(x => x.Id == id);
            _context.Categorias.Remove(categoryEntity);
            var isDelete = await _context.SaveChangesAsync() > 0;
            return isDelete;
      
        }

        public async Task<Categoria> Get(int id)
        {
            var categoryEntity = await _context.Categorias.FirstAsync(x => x.Id == id);
            return categoryEntity;
        }

        public async Task<ICollection<Categoria>> GetAll()
        {
            var categoryEntities = await _context.Categorias.ToListAsync();
            return categoryEntities;
        }

        public async Task<Categoria> Update(Categoria categoria)
        {
            _context.Categorias.Update(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }
    }
}
