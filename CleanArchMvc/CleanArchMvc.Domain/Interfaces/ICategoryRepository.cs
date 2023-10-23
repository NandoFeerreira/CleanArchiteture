using CleanArchMvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> ObterTodosAsync();

        Task<Category> ObterCategoryByIdAsync(int? id );

        Task<Category> AdicionarAsync(Category input);

        Task<Category> AtualizarAsync(Category input);

        Task<Category> RemoverAsync(Category input);

    }
}
