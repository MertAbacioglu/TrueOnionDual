using Microsoft.AspNetCore.Mvc;
using TrueOnion.APPLICATION.DTOs;
using TrueOnion.APPLICATION.Services;
using TrueOnion.APPLICATION.Wrappers;
using TrueOnion.DOMAIN.Entities.Concretes;

namespace TrueOnion.IzometriApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Department> result = await _departmentService.GetAllAsync();
            List<DepartmentDTO> response = result.Select(x => new DepartmentDTO
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            return Ok(Response<List<DepartmentDTO>>.Success(200, response));
        }

        [HttpGet("GetAllPaged")]
        public async Task<IActionResult> GetAllPaged(int? skip, int? take)
        {
            List<Department> result = await _departmentService.GetAllAsync();
            List<DepartmentDTO> response = result.Select(x => new DepartmentDTO
            { Id=x.Id, Name = x.Name
            }).ToList();
            return Ok(Response<List<DepartmentDTO>>.Success(200, response));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartmentById(Guid id)
        {

            Department department = await _departmentService.GetByIdAsync(id);
            DepartmentDTO response = new() {Name = department.Name,Id=department.Id};
            return Ok(Response<DepartmentDTO>.Success(201, response));
        }

        [HttpPost]
        public async Task<IActionResult> Create(DepartmentCreateDTO departmentCreateDTO)
        {
            Department department = new() { Name = departmentCreateDTO.Name };
            Department result = await _departmentService.AddAsync(department);
            DepartmentDTO response = new DepartmentDTO { Id = department.Id,Name = result.Name };
            return Ok(Response<DepartmentDTO>.Success(204,response));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(DepartmentUpdateDTO departmentUpdateDTO)
        {
            Department department = new()
            {
                Id=departmentUpdateDTO.Id,
                Name = departmentUpdateDTO.Name
            };

            Department result =  await _departmentService.Update(department);
            DepartmentDTO response = new DepartmentDTO { Name = result.Name };
            return Ok(Response<DepartmentDTO>.Success(200, response));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            _departmentService.Remove(id);
            return Ok(204);
        }


    }
}