using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrueOnion.APPLICATION.Repositories;
using TrueOnion.APPLICATION.Services;
using TrueOnion.INFRASTRUCTURE.INNER.Services;
using TrueOnion.PERSISTINCE.Repositories.EntityFramework;

namespace TrueOnion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public HomeController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<DOMAIN.Entities.Concrates.User> a = await _userRepository.GetAll();
            return null;
        }
    }
}
