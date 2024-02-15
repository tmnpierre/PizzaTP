﻿namespace Pizza.Front.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public List<Ingredient>? Ingredients { get; set; }
        public string? ImageLink { get; set; }
    }
}