using AutoMapper;
using EastCoastEducation.Dto;
using EastCoastEducation.Interfaces;
using EastCoastEducation.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace EastCoastEducation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : Controller
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public CoursesController(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper= mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Course>))]
        public IActionResult GetCourses()
        {
            var courses = _mapper.Map<List<CourseDto>>(_courseRepository.GetAllCourses());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(courses);
        }

        [HttpGet("{courseId}")]
        [ProducesResponseType(200, Type = typeof(Course))]
        [ProducesResponseType(400)]
        public IActionResult GetCourseById(int courseId)
        {
            if (!_courseRepository.CourseExists(courseId))
                return NotFound();

            var course = _mapper.Map<CourseDto>(_courseRepository.GetCourse(courseId)); 

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(course);
        }

            

    }
}
