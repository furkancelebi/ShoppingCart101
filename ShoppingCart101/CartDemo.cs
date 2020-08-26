using System;
using Infrastructure.Services;
using Infrastructure.Models;
using ShoppingCart101.Helper;
using System.Collections.Generic;

namespace ShoppingCart101
{
    class CartDemo
    {
        private readonly ICategoryService _categoryService;
        public CartDemo(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public void Run()
        {
            PrintHelper.PrintLine("Welcome to ShoppingCart101 Demo", PrintHelper.PrintType.Level0);
            PrintHelper.PrintBlankLine(2);

            CreateCategories();

            CreateCarts();
        }

        private void CreateCarts()
        {
            var hede = new List<Cart>();

            hede.Add(CartHelper.Cart1());
            hede.Add(CartHelper.Cart2());
            hede.Add(CartHelper.Cart3());
            PrintHelper.Print(hede);
        }

        private void CreateCategories()
        {
            _categoryService.AddCategory(CategoryHelper.GetBookCategory());
            _categoryService.AddCategory(CategoryHelper.GetDVDCategory());
            PrintHelper.Print(_categoryService.GetCategories());
        }

        private void CreateCart()
        {
            _categoryService.AddCategory(new Category("Category1"));
            _categoryService.AddCategory(new Category("Category2"));

            foreach (var item in _categoryService.GetCategories())
            {
                Console.WriteLine(item.Title);
            }
        }
    }
}
