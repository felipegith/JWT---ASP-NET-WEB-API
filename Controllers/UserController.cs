using Jesstw.Model;
using Jesstw.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Jesstw.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Email))
            {
                return BadRequest("Informe um email");
            }
            else if (string.IsNullOrWhiteSpace(user.Password))
            {
                return BadRequest("Informe uma senha");
            }
            var createUser = _userRepository.Create(user);

            if (createUser != null)
            {
                return Ok(createUser);
            }
            return NotFound();
        }
    }
}