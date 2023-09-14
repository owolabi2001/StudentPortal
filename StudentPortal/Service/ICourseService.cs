using StudentPortal.Dto;
using StudentPortal.Dto.response;

namespace StudentPortal.Service
{
    public interface ICourseService
    {
        public GenericResponse getAllCourses();
        public GenericResponse getCourseByCourseCode(String courseCode);
        public GenericResponse registerCourses(List<CourseDto> courseDtos);
        
    }
}
