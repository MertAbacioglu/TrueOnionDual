﻿using Microsoft.AspNetCore.Mvc;
using TrueOnion.APPLICATION.Services;
using TrueOnion.APPLICATION.ViewModels.Category;
using TrueOnion.APPLICATION.ViewModels.Product;
using TrueOnion.APPLICATION.Wrappers;
using TrueOnion.DOMAIN.Entities.Concrates;
using TrueOnion.WEB.Filters;

namespace TrueOnion.WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var a = await _categoryService.GetCategoriesWithChildren();
            return View(await _categoryService.GetCategories());           
        }

        public async Task<IActionResult> Add()
        {
            Result<List<CategoryVM>> categories = await _categoryService.GetActives();
            return View(new CategorySaveVM { CategoryVMs= categories.Data });
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategorySaveVM viewModel)
        {
            await _categoryService.AddAsync(viewModel);
            return RedirectToAction(nameof(Index));
        }

        [ServiceFilter(typeof(NotFoundFilter<CategorySaveVM, CategoryVM, Category>))]
        public async Task<IActionResult> Update(int id)
        {
            Result<List<CategoryVM>> categories = await _categoryService.GetActives();
            CategorySaveVM category = (await _categoryService.FindAsync(id)).Data;
            category.CategoryVMs = categories.Data;
            return View(category);

        }

        [HttpPost]
        public async Task<IActionResult> Update(CategorySaveVM viewModel)
        {
            await _categoryService.UpdateAsync(viewModel);
            return RedirectToAction(nameof(Index));
        }

        [ServiceFilter(typeof(NotFoundFilter<CategorySaveVM, CategoryVM, Category>))]
        public async Task<IActionResult> Remove(int id)
        {
            await _categoryService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}