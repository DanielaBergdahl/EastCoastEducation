using AutoMapper;
using EastCoastEducation.Dto;
using EastCoastEducation.Interfaces;
using EastCoastEducation.Model;
using EastCoastEducation.Repository;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace EastCoastEducation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentsController2 : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentsController2(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Student>))]
        public IActionResult GetStudents()
        {
            var students = _mapper.Map<List<Student>>(_studentRepository.GetStudents());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(students);
        }

        [HttpGet("{studentId}")]
        [ProducesResponseType(200, Type = typeof(Student))]
        [ProducesResponseType(400)]
        public IActionResult GetStudentById(int studentId)
        {
            if (!_studentRepository.StudentExists(studentId))
                return NotFound();

            var student = _mapper.Map<StudentDto>(_studentRepository.GetStudent(studentId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(student);
        }


        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public IActionResult CreateStudent([FromQuery] int courseId, [FromBody] StudentDto studentCreate)
        {
            if (studentCreate == null)
                return BadRequest(ModelState);

            var students = _studentRepository.GetStudents()
                .Where(s => s.StudentId == studentCreate.StudentId)
                .FirstOrDefault();

            if (students != null)
            {
                ModelState.AddModelError("", "Student already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var studentMap = _mapper.Map<Student>(studentCreate);

            if (!_studentRepository.CreateStudent(courseId, studentMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }



    }
}
