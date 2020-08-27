﻿using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Models;

namespace ShoppingCart101.Helper
{
    public static class PrintHelper
    {
        public static void Print(this List<Coupon> coupons)
        {
            PrintLine($"Creating coupons", PrintType.Level1);

            foreach (var coupon in coupons)
            {
                PrintLine($"'{coupon.Description}' created", PrintType.Level2);
            }

            PrintSeperatorLine();
        }

        public static void Print(this List<Category> categories)
        {
            foreach (var category in categories)
            {
                PrintLine($"'{category.Title}' created", PrintType.Level1);

                foreach (var campaign in category.Campaigns)
                {
                    PrintLine($"'{campaign.Description}' applied to {category.Title}", PrintType.Level2);
                }
                PrintBlankLine();
            }

            PrintSeperatorLine();
        }

        public static void Print(this Cart cart)
        {
            var cartCategories = cart.GetCartCategories();

            PrintLine($"Cart ID:{cart.Id}", PrintType.Level1);

            foreach (var cartCategory in cartCategories)
            {
                PrintLine(cartCategory.category.Title, PrintType.Level2);

                foreach (var cartItem in cartCategory.products)
                {
                    PrintLine($"{cartItem.Product.Title.PadRight(15, ' ')} - ({cartItem.Product.Price} TL x {cartItem.Quantity} Adet)", PrintType.Level3);
                }

                PrintLine($"Total Price      : {cartCategory.categoryTotalAmount} TL", PrintType.Level4);
                PrintLine($"Total Discount   : {cartCategory.categoryDiscountAmount} TL", PrintType.Level4);
                PrintLine($"Applied Campaign : {cartCategory.appliedCampaign?.Description}", PrintType.Level4);
                PrintBlankLine();
            }

            PrintLine($"Total Cart Amount      : {cart.GetCartTotalAmount()}", PrintType.Level1);
            PrintLine($"Total Campaign Amount  : {cart.GetCampaignDiscount()}", PrintType.Level1);
            PrintLine($"Coupon Applied Amount  : {cart.GetCouponDiscount()}", PrintType.Level1);
            PrintLine($"Delivery Cost          : {cart.GetDeliveryCost()}", PrintType.Level1);
            PrintLine($"Total Amount           : {cart.GetCartTotalAmountAfterDiscounts()}", PrintType.Level1);
        }

        internal static void Print(this List<Cart> carts)
        {
            foreach (var cart in carts)
            {
                cart.Print();
                PrintSeperatorLine();
            }
        }

        public static void PrintLine(string text, PrintType printType)
        {
            Console.WriteLine("-".PadLeft((int)printType, '-') + "> " + text);
        }

        internal static void PrintBlankLine(int lineCount = 1)
        {
            for (int i = 0; i < lineCount; i++)
            {
                Console.WriteLine();
            }
        }

        internal static void PrintSeperatorLine(int lineCount = 1)
        {
            PrintBlankLine();
            for (int i = 0; i < lineCount; i++)
            {
                Console.WriteLine("".PadRight(100,'-'));
            }
            PrintBlankLine();
        }

        public enum PrintType
        {
            Level0 = 0,
            Level1 = 2,
            Level2 = 4,
            Level3 = 6,
            Level4 = 8,
        }
    }
}