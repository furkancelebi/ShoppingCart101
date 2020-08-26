using Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infrastructure.Models
{
    public class Product : BaseEntity
    {
        [Required(AllowEmptyStrings = false)]
        public string Title { get; }
        [Required, IsPositive(ErrorMessage = "Price must be positive")]
        public double Price { get; }
        public Category Category;

        public Product(string title, double price, Category category)
        {
            Title = title;
            Price = price;
            Category = category;

            ValidationHelper.Validate(this);
        }
    }
}