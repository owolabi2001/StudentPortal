using Microsoft.AspNetCore.Mvc;
using StudentPortal.Dto;
using StudentPortal.Dto.response;

namespace StudentPortal.Service
{
    public interface StudentService
    {
        public GenericResponse getAllStudent();
        public GenericResponse getStudentById(int id);
        public GenericResponse SaveStudent(StudentDto student);
    }
}
