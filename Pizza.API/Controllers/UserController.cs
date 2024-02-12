using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pizza.API.Models;
using Pizza.API.Repositories.Interfaces;

namespace Pizza.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepository<UserModel> _userRepository;
        private readonly IMapper _mapper;

        public UserController(IRepository<UserModel> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsers()
        {
            var users = await _userRepository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<UserDTO>>(users));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(_mapper.Map<UserDTO>(user));
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> CreateUser(UserDTO userDto)
        {
            var user = _mapper.Map<UserModel>(userDto);
            await _userRepository.AddAsync(user);
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, _mapper.Map<UserDTO>(user));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserDTO userDto)
        {
            if (id != userDto.Id) return BadRequest();
            var userToUpdate = await _userRepository.GetByIdAsync(id);
            if (userToUpdate == null) return NotFound();
            _mapper.Map(userDto, userToUpdate);
            await _userRepository.UpdateAsync(userToUpdate);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
