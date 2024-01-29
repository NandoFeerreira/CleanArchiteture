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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Category> AdicionarAsync(Category input)
        {
            _context.Add(input);
            await _context.SaveChangesAsync();
            return input;
        }

        public async Task<Category> AtualizarAsync(Category input)
        {
            _context.Update(input);
            await _context.SaveChangesAsync();
            return input;
        }

        public async Task<Category> ObterCategoryByIdAsync(int? id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<IEnumerable<Category>> ObterTodosAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> RemoverAsync(Category input)
        {
            _context.Remove(input);
            await _context.SaveChangesAsync(); 
            return input;
        }
    }
}
