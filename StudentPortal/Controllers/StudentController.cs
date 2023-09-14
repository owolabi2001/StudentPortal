using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentPortal.Dto;
using StudentPortal.Dto.response;
using StudentPortal.Service;

namespace StudentPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> logger;
        private readonly StudentService studentService;
        


        public StudentController(ILogger<StudentController> logger, StudentService studentService) { 
            this.logger = logger;
            this.studentService = studentService;
        }



        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<GenericResponse> RegisterStudent([FromBody] StudentDto student)
        {
            //return Ok(studentService.SaveStudent(student));
            GenericResponse response = studentService.SaveStudent(student);
            logger.LogInformation("API designed to save student "+ student.MatricNo);
            if(response.Code == "11")
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("{Id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public ActionResult<GenericResponse> getStudentById(int id)
        {
            GenericResponse response = studentService.getStudentById(id);
            logger.LogInformation("API to get Student with the Id of: " + id);

            if(response.Code == "11")
            {
                return BadRequest(response);
            }
            return Accepted(response);

        }


        [HttpGet]
        public ActionResult<GenericResponse> getAllStudent()
        {
            var response = studentService.getAllStudent();
            return Ok(response);
        }



        [HttpPut("/courseRegistration/{matricNo}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public ActionResult<GenericResponse> 
            courseRegisteration([FromBody] List<string> courseCodes,string matricNo)
        {
            var response = studentService.registercourse(courseCodes,matricNo);

            return Accepted(response);
        }

        [HttpGet("/getcourses/{matricNo}")]
        public ActionResult<GenericResponse> getCourseByStudent(string matricNo)
        {
            return Ok(studentService.findCoursesByStudent(matricNo));
        }
    }
}
