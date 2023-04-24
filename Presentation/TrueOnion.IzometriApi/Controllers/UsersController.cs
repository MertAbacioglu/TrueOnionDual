
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TrueOnion.APPLICATION.DTOs;
using TrueOnion.APPLICATION.Services;
using TrueOnion.APPLICATION.Wrappers;
using TrueOnion.DOMAIN.Entities.Concretes;
using TrueOnion.INFRASTRUCTURE.INNER.Services;

namespace TrueOnion.IzometriApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<User> result = await _userService.GetAllUsersWithDepartmentAsync();
            List<UserDTO> response = result
                .Select(x => new UserDTO
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    DepartmentDTO = x.Department != null ? new DepartmentDTO { Name = x.Department.Name,Id=x.Id } : null
                

                }).ToList();
            return Ok(Response<List<UserDTO>>.Success(200, response));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            User user = await _userService.GetUserWithDepartmentAsync(id);
            UserDTO userDTO = new()
            {
                FirstName = user.FirstName,
                DepartmentDTO = user.Department != null ? new DepartmentDTO { Name = user.Department.Name, Id = user.Id } : null
            };
            return Ok(Response<UserDTO>.Success(201, userDTO));

        }

        [HttpPost]
        public async Task<IActionResult> Create(UserCreateDTO userCreateDTO)
        {
            User user = new() { FirstName = userCreateDTO.FirstName,LastName=userCreateDTO.LastName ,Email = userCreateDTO.Email };
            User result = await _userService.AddAsync(user);
            UserDTO userDTO = new()
            {
                FirstName = result.FirstName,
                LastName = result.LastName,
                Email = result.Email,
            };
            return Ok(Response<UserDTO>.Success(204, userDTO));
        }

        [HttpPost("CreateUserWithDepartment")]
        public async Task<IActionResult> CreateUserWithDepartment(AddUserWithDepartmentDTO dto)
        {
            User user = new() { FirstName = dto.FirstName, Email = dto.Email, DepartmentId = dto.DepartmentId };
            User result = await _userService.AddUserWithDepartmentAsync(user);
            UserDTO userDTO = new()
            {
                FirstName = result.FirstName,
                LastName = result.LastName,
                Email = result.Email,
                DepartmentDTO = user.Department != null ? new DepartmentDTO { Name = user.Department.Name } : null
            };
            return Ok(Response<UserDTO>.Success(200, userDTO));
        }



        [HttpPut("Update")]
        public async Task<IActionResult> Update(UserUpdateDTO userUpdateDTO)
        {
            User user = new()
            {
                Id = userUpdateDTO.Id,
                FirstName = userUpdateDTO.FirstName,
                LastName = userUpdateDTO.LastName,
                Email = userUpdateDTO.Email,
                DepartmentId = userUpdateDTO.DepartmentId
            };


            return Ok(Response<NoContent>.Success(200));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            _userService.Remove(id);
            return Ok(Response<NoContent>.Success(204));
        }

    }
}
