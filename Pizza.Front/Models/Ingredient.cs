namespace Pizza.Front.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public int PizzaId { get; set; }
        public string? Name { get; set; }
    }
}