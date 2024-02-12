using Microsoft.AspNetCore.Mvc;
using Pizza.API.Models;
using Pizza.API.Repositories.Interfaces;

namespace Pizza.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IRepository<PizzaModel> _pizzaRepository;

        public PizzaController(IRepository<PizzaModel> pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }

        // GET: api/Pizza
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PizzaModel>>> GetAllPizzas()
        {
            var pizzas = await _pizzaRepository.GetAllAsync();
            return Ok(pizzas);
        }

        // GET: api/Pizza/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<PizzaModel>> GetPizza(int id)
        {
            var pizza = await _pizzaRepository.GetByIdAsync(id);

            if (pizza == null)
            {
                return NotFound();
            }

            return Ok(pizza);
        }

        // POST: api/Pizza
        [HttpPost]
        public async Task<ActionResult<PizzaModel>> CreatePizza(PizzaModel pizza)
        {
            await _pizzaRepository.AddAsync(pizza);
            return CreatedAtAction(nameof(GetPizza), new { id = pizza.Id }, pizza);
        }

        // PUT: api/Pizza/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePizza(int id, PizzaModel pizza)
        {
            if (id != pizza.Id)
            {
                return BadRequest();
            }

            try
            {
                await _pizzaRepository.UpdateAsync(pizza);
            }
            catch
            {
                var existingPizza = await _pizzaRepository.GetByIdAsync(id);
                if (existingPizza == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Pizza/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePizza(int id)
        {
            var pizza = await _pizzaRepository.GetByIdAsync(id);
            if (pizza == null)
            {
                return NotFound();
            }

            await _pizzaRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}