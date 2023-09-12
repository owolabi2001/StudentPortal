using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentPortal.Dto;
using StudentPortal.Dto.response;
using StudentPortal.Service;

namespace StudentPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService courseService;
        public CourseController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        public ActionResult<GenericResponse> addCourse([FromBody] List<CourseDto> courseDtos)
        {
            var response = courseService.registerCourses(courseDtos);

            return Ok(response);
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<GenericResponse> getCourseByCourseCode([FromQuery] string courseCode)
        {

            GenericResponse response = courseService.getCourseByCourseCode(courseCode); 
            if(response.Code == "11")
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }

}
