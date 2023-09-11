﻿using Microsoft.AspNetCore.Http;
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

            if(response.Code == "11")
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

    }
}
