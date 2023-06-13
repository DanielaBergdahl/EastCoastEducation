using Microsoft.AspNetCore.Mvc;
using EastCoastEducation.Model;
using EastCoastEducation.Interfaces;
using EastCoastEducation.Dto;
using AutoMapper;

namespace EastCoastEducation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;

        public TeachersController(ITeacherRepository teacherRepository, IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _mapper = mapper;
        }

        // GET: api/Teachers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetTeachers()
        {
          return Ok(await _teacherRepository.GetTeachers());
        }

        // GET: api/Teachers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher>> GetTeacher(int id)
        {
            var result = await _teacherRepository.GetTeacher(id);
            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // PUT: api/Teachers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeacher(TeacherDto teacherDto)
        {
            try
            {
                await _teacherRepository.UpdateTeacher(_mapper.Map<Teacher>(teacherDto));
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // POST: api/Teachers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Teacher> PostTeacher(TeacherDto teacherDto)
        {
            try
            {
                var createdTeacher = _teacherRepository.CreateTeacher(_mapper.Map<Teacher>(teacherDto));
                return Ok(createdTeacher);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
