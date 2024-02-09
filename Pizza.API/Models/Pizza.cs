namespace Pizza.API.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? Overview { get; set; }
        public Categorie Categorie { get; set; }
    }

    public enum Categorie { PizzaClassique, PizzaVegetarienne, PizzaPiquante, Calzone}
}
