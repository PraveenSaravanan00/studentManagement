using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryCRUD.Data;
using RepositoryCRUD.Models;


namespace RepositoryCRUD.Students.Interface
{
    public class StudentDataClass : ControllerBase,IStudentData
    {
        private readonly RepositoryCRUDContext _context;

        public StudentDataClass(RepositoryCRUDContext context)
        {
            _context = context;
        }

        //GET
        public async Task<ActionResult<IEnumerable<StudentsData>>> GetStudentsData()
        {
            return await _context.StudentsData.ToListAsync();
        }

        //GET BY ID
        public async Task<ActionResult<StudentsData>> GetStudentsData(int id)
        {
            var studentsData = await _context.StudentsData.FindAsync(id);

            if (studentsData == null)
            {
                return NotFound();
            }

            return studentsData;
        }

        //ADD USER DATA
        public async Task<IActionResult> PutStudentsData(int id, StudentsData studentsData)
        {
            if (id != studentsData.StudentId)
            {
                return BadRequest();
            }

            _context.Entry(studentsData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentsDataExists(id))
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

        //EDIT USER
        public async Task<ActionResult<StudentsData>> PostStudentsData(StudentsData studentsData)
        {
            _context.StudentsData.Add(studentsData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentsData", new { id = studentsData.StudentId }, studentsData);
        }

        //DELETE  USER
        public async Task<IActionResult> DeleteStudentsData(int id)
        {
            var studentsData = await _context.StudentsData.FindAsync(id);
            if (studentsData == null)
            {
                return NotFound();
            }

            _context.StudentsData.Remove(studentsData);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool StudentsDataExists(int id)
        {
            return _context.StudentsData.Any(e => e.StudentId == id);
        }
    }
}
