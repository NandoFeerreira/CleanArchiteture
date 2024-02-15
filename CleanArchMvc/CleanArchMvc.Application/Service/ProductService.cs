using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Application.Products.Queries;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Service
{
    public class ProductService : IProductService
    {
        
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;


        public ProductService( IMapper mapper, IMediator mediator)
        {           
            _mapper = mapper;
            _mediator = mediator;
        }

        public async  Task Add(ProductDTO productDto)
        {
            var productAdd = _mapper.Map<ProductCreateCommand>(productDto);  
            await _mediator.Send(productAdd);
        }

        public async Task<ProductDTO> GetById(int? id)
        {
            var productByidQuery = new GetProductByIdQuery(id.Value);

            if (productByidQuery == null)
            {
                throw new Exception($"Entity coul no be loaded.");
            }

            var result = await _mediator.Send(productByidQuery);

            return _mapper.Map<ProductDTO>(result);  
        }

        //public async Task<ProductDTO> GetProductCategory(int? id)
        //{
        //    var productByidQuery = new GetProductByIdQuery(id.Value);

        //    if (productByidQuery == null)
        //    {
        //        throw new Exception($"Entity coul no be loaded.");
        //    }

        //    var result = await _mediator.Send(productByidQuery);

        //    return _mapper.Map<ProductDTO>(result);
        //}

        public async  Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productsQuery = new GetProductsQuery();

            var reuslt = await _mediator.Send(productsQuery);

            return  _mapper.Map<IEnumerable<ProductDTO>>(reuslt);
            
        }

        public async Task Remove(int? id)
        {
            var productRemoveCommand = new ProductRemoveCommand(id.Value);
            if (productRemoveCommand == null)
            {
                throw new Exception($"Entity coul no be loaded.");
            }
            await _mediator.Send(productRemoveCommand);
        }

        public async Task Update(ProductDTO productDto)
        {
            var productAdd = _mapper.Map<ProductCreateCommand>(productDto);
            await _mediator.Send(productAdd);
        }
    }
}
