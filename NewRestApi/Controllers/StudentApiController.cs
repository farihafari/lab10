using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewRestApi.Models;

namespace NewRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentApiController : ControllerBase
    {
        private readonly CrudDbContext context;

        public StudentApiController(CrudDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetAllStudents()
        {
            // Fix: Use ToListAsync() instead of ToList() for asynchronous operation
            var students = await context.Students.ToListAsync();
            return Ok(students);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Student>>> GetStudentsById(int id)
        {
            // Fix: Use ToListAsync() instead of ToList() for asynchronous operation
            var student = await context.Students.FindAsync(id);
            if(student == null)
            {
                return NotFound();
            }   
            return Ok(student);
        }
    }
}
