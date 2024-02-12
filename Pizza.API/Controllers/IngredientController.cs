using AutoMapper;
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
        private readonly IMapper _mapper;

        public IngredientController(IRepository<IngredientModel> ingredientRepository, IMapper mapper)
        {
            _ingredientRepository = ingredientRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IngredientDTO>>> GetAllIngredients()
        {
            var ingredients = await _ingredientRepository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<IngredientDTO>>(ingredients));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IngredientDTO>> GetIngredient(int id)
        {
            var ingredient = await _ingredientRepository.GetByIdAsync(id);
            if (ingredient == null) return NotFound();
            return Ok(_mapper.Map<IngredientDTO>(ingredient));
        }

        [HttpPost]
        public async Task<ActionResult<IngredientDTO>> CreateIngredient(IngredientDTO ingredientDto)
        {
            var ingredient = _mapper.Map<IngredientModel>(ingredientDto);
            await _ingredientRepository.AddAsync(ingredient);
            return CreatedAtAction(nameof(GetIngredient), new { id = ingredient.Id }, _mapper.Map<IngredientDTO>(ingredient));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateIngredient(int id, IngredientDTO ingredientDto)
        {
            if (id != ingredientDto.Id) return BadRequest();
            var ingredientToUpdate = await _ingredientRepository.GetByIdAsync(id);
            if (ingredientToUpdate == null) return NotFound();
            _mapper.Map(ingredientDto, ingredientToUpdate);
            await _ingredientRepository.UpdateAsync(ingredientToUpdate);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngredient(int id)
        {
            await _ingredientRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}