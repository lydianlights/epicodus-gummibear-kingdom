using System;
using System.Collections.Generic;
using System.Text;
using GummiBearKingdom.Models;

namespace GummiBearKingdom.Data
{
    public static class TestData
    {
        public static Product[] Products = {
            new Product {
                Id = 1,
                Name = "Gummi Hat",
                Cost = 4.99m,
                Description = "A cool gummi hat with cute gummi ears."
            },
            new Product {
                Id = 2,
                Name = "Gummi Shirt",
                Cost = 14.99m,
                Description = "A cool gummi shirt with a cute gummi bear."
            },
            new Product {
                Id = 3,
                Name = "Gummi Shoes",
                Cost = 12.99m,
                Description = "Gummi gummi gumshoes"
            },
            new Product {
                Id = 4,
                Name = "Gummi Sunglasses",
                Cost = 3.50m,
                Description = "Cool gummi shades that make you look super rad"
            },
        };

        public static Review[] Reviews = {
            new Review {
                Id = 1,
                Author = "xXxGummiKingxXx",
                ContentBody = "These gummi hats are kawaii af fam fo shizzle",
                Rating = 5,
                ProductId = 1
            },
            new Review {
                Id = 2,
                Author = "xXxGummiKingxXx",
                ContentBody = "This shirt is literally the best thing ever",
                Rating = 5,
                ProductId = 2
            },
            new Review {
                Id = 3,
                Author = "xXxGummiKingxXx",
                ContentBody = "These glasses make anyone look 200% more radical",
                Rating = 5,
                ProductId = 4
            },
            new Review {
                Id = 4,
                Author = "NotATroll69",
                ContentBody = "lame",
                Rating = 1,
                ProductId = 1
            },
            new Review {
                Id = 5,
                Author = "NotATroll69",
                ContentBody = "lame",
                Rating = 1,
                ProductId = 2
            },
            new Review {
                Id = 6,
                Author = "UltimateGummiFan92",
                ContentBody = "I'm unimpressed--the shape of the ears is slightly incorrect. You'd think the official merch manufacturer would know better. :/",
                Rating = 3,
                ProductId = 1
            },
            new Review {
                Id = 7,
                Author = "UltimateGummiFan92",
                ContentBody = "Quite good. I appreciate the effort to remain true to canon with this representation of Gummikind, though I give it a 4/5 for slightly incorrect coloring. Everygummi makes mistakes sometimes.",
                Rating = 4,
                ProductId = 2
            },
            new Review {
                Id = 8,
                Author = "LydianLights",
                ContentBody = "I need another test rating, sooooooo",
                Rating = 5,
                ProductId = 2
            },
        };
    }
}
