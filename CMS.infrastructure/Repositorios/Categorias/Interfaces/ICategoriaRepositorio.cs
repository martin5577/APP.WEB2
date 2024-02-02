using CMS.domain.Categorias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.infraestructure.Repositorios.Categorias.Interfaces
{
    public interface ICategoriaRepositorio
    {
        public Task<ICollection<Categoria>> GetAll();
        public Task<Categoria> Get(int id);
        public Task<Categoria> Create(Categoria categoria);
        public Task<Categoria> Update(Categoria categoria);
        public Task<bool> Delete(int id);
    }
}
