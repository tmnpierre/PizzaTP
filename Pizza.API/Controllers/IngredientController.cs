using Microsoft.AspNetCore.Mvc;
using Pizza.API.Models;
using Pizza.API.Repositories.Interfaces;

namespace Pizza.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IRepository<IngredientModel> _ingredientRepository;

        public IngredientController(IRepository<IngredientModel> ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }

        // GET: api/Ingredient
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IngredientModel>>> GetAllIngredients()
        {
            var ingredients = await _ingredientRepository.GetAllAsync();
            return Ok(ingredients);
        }

        // GET: api/Ingredient/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<IngredientModel>> GetIngredient(int id)
        {
            var ingredient = await _ingredientRepository.GetByIdAsync(id);

            if (ingredient == null)
            {
                return NotFound();
            }

            return Ok(ingredient);
        }

        // POST: api/Ingredient
        [HttpPost]
        public async Task<ActionResult<IngredientModel>> CreateIngredient(IngredientModel ingredient)
        {
            await _ingredientRepository.AddAsync(ingredient);
            return CreatedAtAction(nameof(GetIngredient), new { id = ingredient.Id }, ingredient);
        }

        // PUT: api/Ingredient/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateIngredient(int id, IngredientModel ingredient)
        {
            if (id != ingredient.Id)
            {
                return BadRequest();
            }

            try
            {
                await _ingredientRepository.UpdateAsync(ingredient);
            }
            catch
            {
                var existingIngredient = await _ingredientRepository.GetByIdAsync(id);
                if (existingIngredient == null)
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

        // DELETE: api/Ingredient/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngredient(int id)
        {
            var ingredient = await _ingredientRepository.GetByIdAsync(id);
            if (ingredient == null)
            {
                return NotFound();
            }

            await _ingredientRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}