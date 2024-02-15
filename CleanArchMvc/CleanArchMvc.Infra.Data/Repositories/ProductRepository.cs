using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> AdicionarAsync(Product input)
        {
            _context.Add(input);
            await _context.SaveChangesAsync();
            return input;
        }

        public async Task<Product> AtualizarAsync(Product input)
        {
            _context.Remove(input);
            await _context.SaveChangesAsync();
            return input;
        }

        public async Task<Product> ObterProdutoByIdAsync(int? id)
        {
            return await _context.Products.Include(c => c.Category).SingleOrDefaultAsync(p => p.Id == id);

        }

        public async Task<IEnumerable<Product>> ObterTodosAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> RemoverAsync(Product input)
        {
            _context.Remove(input);
            await _context.SaveChangesAsync();
            return input;
        }
    }
}
