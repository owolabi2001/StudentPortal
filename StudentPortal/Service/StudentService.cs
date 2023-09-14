using Microsoft.AspNetCore.Mvc;
using StudentPortal.Dto;
using StudentPortal.Dto.response;

namespace StudentPortal.Service
{
    public interface StudentService
    {
        public GenericResponse findCoursesByStudent(string matricNo);
        public GenericResponse getAllStudent();
        public GenericResponse getStudentById(int id);
        public GenericResponse registercourse(List<string> courseCodes, string matricNo);
        public GenericResponse SaveStudent(StudentDto student);
    }
}
