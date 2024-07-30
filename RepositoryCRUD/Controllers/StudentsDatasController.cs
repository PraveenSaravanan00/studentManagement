using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryCRUD.Data;
using RepositoryCRUD.Models;
using RepositoryCRUD.Students.Interface;

namespace RepositoryCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsDatasController : ControllerBase
    {
        private readonly RepositoryCRUDContext _context;
        private readonly IStudentData _StudentData;
        public StudentsDatasController(RepositoryCRUDContext context, IStudentData StudentData)
        {
            _context = context;
            _StudentData = StudentData;
        }

        // GET: api/StudentsDatas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentsData>>> GetStudentsData()
        {
            return await _StudentData.GetStudentsData();
        }

        // GET: api/StudentsDatas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentsData>> GetStudentsData(int id)
        {

            return await _StudentData.GetStudentsData(id);
        }

        // PUT: api/StudentsDatas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentsData(int id, StudentsData studentsData)
        {
            

            return await _StudentData.PutStudentsData(id, studentsData);
        }

        // POST: api/StudentsDatas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentsData>> PostStudentsData(StudentsData studentsData)
        {

            return await _StudentData.PostStudentsData(studentsData);
        }

        // DELETE: api/StudentsDatas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentsData(int id)
        {


            return await _StudentData.DeleteStudentsData(id);
        }


    }
}
