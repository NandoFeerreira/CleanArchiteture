﻿using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            var categories = await _categoryService.GetCategories();

            if (categories == null )
            {
                return NotFound("Categories Not Found");
            }

            return Ok(categories);  
        }

        [HttpGet("{id:int}", Name ="GetCategory")]
        public async Task<ActionResult<CategoryDTO>> Get(int id)
        {
            var category = await _categoryService.GetById(id);
            
            if (category == null) { NotFound("Categorie not found"); }
            return Ok(category);    

        }


        [HttpPost]
        public async Task<ActionResult>Post([FromBody]CategoryDTO categoryDTO)
        {
            if (categoryDTO == null) { BadRequest("Dados Inválidos"); }

            await _categoryService.Add(categoryDTO);

            return new CreatedAtRouteResult("GetCategory", new  { id = categoryDTO.Id}, categoryDTO);
        }
    }
}
