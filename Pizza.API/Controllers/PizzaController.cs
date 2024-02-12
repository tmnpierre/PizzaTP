using AutoMapper;
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
        private readonly IMapper _mapper;

        public PizzaController(IRepository<PizzaModel> pizzaRepository, IMapper mapper)
        {
            _pizzaRepository = pizzaRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PizzaDTO>>> GetAllPizzas()
        {
            var pizzas = await _pizzaRepository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<PizzaDTO>>(pizzas));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PizzaDTO>> GetPizza(int id)
        {
            var pizza = await _pizzaRepository.GetByIdAsync(id);
            if (pizza == null) return NotFound();
            return Ok(_mapper.Map<PizzaDTO>(pizza));
        }

        [HttpPost]
        public async Task<ActionResult<PizzaDTO>> CreatePizza(PizzaDTO pizzaDto)
        {
            var pizza = _mapper.Map<PizzaModel>(pizzaDto);
            await _pizzaRepository.AddAsync(pizza);
            return CreatedAtAction(nameof(GetPizza), new { id = pizza.Id }, _mapper.Map<PizzaDTO>(pizza));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePizza(int id, PizzaDTO pizzaDto)
        {
            if (id != pizzaDto.Id) return BadRequest();
            var pizzaToUpdate = await _pizzaRepository.GetByIdAsync(id);
            if (pizzaToUpdate == null) return NotFound();
            _mapper.Map(pizzaDto, pizzaToUpdate);
            await _pizzaRepository.UpdateAsync(pizzaToUpdate);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePizza(int id)
        {
            await _pizzaRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
