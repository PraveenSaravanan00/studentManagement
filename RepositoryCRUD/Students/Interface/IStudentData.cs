using Microsoft.AspNetCore.Mvc;
using RepositoryCRUD.Models;

namespace RepositoryCRUD.Students.Interface
{
    public interface IStudentData
    {
        Task<ActionResult<IEnumerable<StudentsData>>> GetStudentsData();
        Task<ActionResult<StudentsData>> GetStudentsData(int id);
        Task<IActionResult> PutStudentsData(int id, StudentsData studentsData);
        Task<ActionResult<StudentsData>> PostStudentsData(StudentsData studentsData);
        Task<IActionResult> DeleteStudentsData(int id);
    }
}
