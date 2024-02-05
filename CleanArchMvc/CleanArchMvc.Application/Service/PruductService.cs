using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Service
{
    public class PruductService : IProductService
    {
        private readonly IProductRepository _productRepository; 
        private readonly IMapper _mapper;   

        public PruductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async  Task Add(ProductDTO productDto)
        {
            var productentity = _mapper.Map<Product>(productDto);
            await _productRepository.AdicionarAsync(productentity);
        }

        public async Task<ProductDTO> GetById(int? id)
        {
            var productEntity = await _productRepository.ObterProdutoByIdAsync(id);
            return _mapper.Map<ProductDTO>(productEntity);  
        }

        public async Task<ProductDTO> GetProductCategory(int? id)
        {
            var productEntity = await _productRepository.ObterProductCategoryAsync(id);
            return _mapper.Map<ProductDTO>(productEntity);  
        }

        public async  Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productsEntity  = await _productRepository.ObterTodosAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);
        }

        public async Task Remove(int? id)
        {
            var productEntity = await _productRepository.ObterProdutoByIdAsync(id);
            if (productEntity != null)
            {
                await _productRepository.RemoverAsync(productEntity);
            }
        }

        public async Task Update(ProductDTO productDto)
        {
            var productEntity = await _productRepository.ObterProdutoByIdAsync(productDto.Id);
            if (productEntity != null)
            {
                var product = _mapper.Map<Product>(productDto);
                await _productRepository.AtualizarAsync(product);
            }
        }
    }
}
