using CleanArchMvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> ObterTodosAsync();

        Task<Product> ObterProdutoByIdAsync(int? id);

        Task<Product> AdicionarAsync(Product input);

        Task<Product> AtualizarAsync(Product input);

        Task<Product> RemoverAsync(Product input);
    }
}
