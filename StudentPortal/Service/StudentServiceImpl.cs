using Microsoft.AspNetCore.Mvc;
using StudentPortal.Dto;
using StudentPortal.Dto.response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using StudentPortal.Model;

namespace StudentPortal.Service
{
    public class StudentServiceImpl : StudentService
    {

        private readonly ApplicationDbContext db;
        private readonly ILogger<StudentServiceImpl> logger;

        public StudentServiceImpl(ApplicationDbContext db, ILogger<StudentServiceImpl> logger)
        {
            this.db = db;
            this.logger = logger;
        }

        public GenericResponse SaveStudent(StudentDto student)
        {
            Student StudentCheck = db.Students
                .Where(student1 => student1.MatricNo == student.MatricNo)
                .SingleOrDefault();

            if (StudentCheck == null)
            {
                Student newStudent = new()
                {
                    Name = student.Name,
                    Programme = student.Programme,
                    MatricNo = student.MatricNo,
                    CreatedDate = DateTime.Now,
                };
                db.Students.Add(newStudent);
                db.SaveChanges();

                
                return new()
                {
                    Code = "00",
                    Message = "Student with the name " + student.Name + "has been added",
                    Data = newStudent,
                    MetaData = null
                };
            }

            
            return new()
            {
                Code = "11",
                Message = "Student already exist",
                Data = student,
                MetaData = null
            };
        }


        public GenericResponse getStudentById(int id)
        {
            var studentCheck = db.Students.Find(id);

            if (studentCheck == null)
            {
                return new()
                {
                    Code = "11",
                    Message = "No student with Id: " + id,
                    Data = null,
                    MetaData = null
                };
            }

            return new GenericResponse()
            {
                Code = "00",
                Message = "Student with Id " + id + " is shown below",
                Data = studentCheck,
                MetaData = null
            };
        }


        public GenericResponse getAllStudent()
        {
            List<Student> students = db.Students.ToList();

            return new()
            {
                Code = "00",
                Message = "The Students available in the database are:",
                Data = students,
                MetaData = null
            };
        }

        public GenericResponse registercourse(List<string> courseCodes, string matricNo)
        {
            logger.LogInformation("API to register course is life in action");
            
            Student student = db.Students.SingleOrDefault(s => s.MatricNo == matricNo);

            List<Course> courseList = new List<Course>();
            List<string> unAvailalbe = new List<string>();
            foreach (string courseCode in courseCodes)
            {
                logger.LogInformation("Course Code is: " + courseCode);
                Course course = db.Courses.Where(c=>c.Coursecode==courseCode).SingleOrDefault();

                logger.LogInformation("The course  information: " + course.ToString);
                
                if(course == null)
                {
                    unAvailalbe.Add(courseCode);
                    continue;
                }
                else
                {
                    courseList.Add(course);

                }
                
                
            }

            Student updatedStudent = new Student()
            {
                Name = student.Name,
                Courses = courseList,
                Programme = student.Programme,
                MatricNo = student.MatricNo,

            };
            db.Students.Update(updatedStudent);
            db.SaveChanges();
            return new 
                GenericResponse("00","Courses have been added to the particular student",null,null);


        }
    }
}
