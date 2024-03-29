﻿using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CleanArchMvc.Web.Ui.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetCategories();

            return View(categories);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(CategoryDTO category)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.Add(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var categoryDto = await _categoryService.GetById(id.Value);
            if (categoryDto == null) return NotFound();

            return View(categoryDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryDTO categoryDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _categoryService.Update(categoryDTO);
                }
                catch (Exception)
                {

                    throw;
                }
                return RedirectToAction(nameof(Index));
            }

            return View(categoryDTO);
        }

        [HttpGet]
        public async Task<IActionResult>Delete (int? id)
        {
            if (id == null) return NotFound();
            var categoryDto = await _categoryService.GetById(id.Value);
            if (categoryDto == null) return NotFound();
            return View(categoryDto);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult>DeletedConfirmed(int id)
        {
            await _categoryService.Remove(id);
            return RedirectToAction("Index");   
         
        }

        [HttpGet]
        public async Task<IActionResult>Details (int? id)
        {
            if (id == null) return NotFound();
            var categoryDto = await _categoryService.GetById(id.Value);

            if (categoryDto == null) return NotFound();
            return View(categoryDto);
        }



    }
}
