using StudentPortal.Dto;
using StudentPortal.Dto.response;
using StudentPortal.Model;

namespace StudentPortal.Service
{
    public class CourseService: ICourseService
    {

        private readonly ApplicationDbContext db;
        private readonly ILogger<CourseService> logger;

        public CourseService(ApplicationDbContext db, ILogger<CourseService> logger)
        {
            this.db = db;
            this.logger = logger;
        }



        public GenericResponse registerCourses(List<CourseDto> courseDtos)
        {
            foreach (var item in courseDtos)
            {
                Course course = db.Courses
                    .Where(course => course.Coursecode==item.Coursecode)
                    .SingleOrDefault();

                Console.WriteLine("the course gotten is shown below: " + course);

                if(course != null )
                {
                    continue;
                }
                Course newCourse = new()
                {
                    Coursecode = item.Coursecode,
                    CourseName = item.CourseName,
                    CourseUnit = item.CourseUnit,
                };
                db.Courses.Add(newCourse);
                db.SaveChanges();
            }
            return new()
            {
                Code = "00",
                Message = "Inputed courses registered",
                Data = courseDtos,
                MetaData = null
            };
        }



        public GenericResponse getCourseByCourseCode(String courseCode)
        {

            var courseCheck = db.Courses.SingleOrDefault(u => u.Coursecode == courseCode);
            logger.LogInformation("API to get coursecode by student");
            if(courseCheck == null)
            {
                return new()
                {
                    Code = "11",
                    Message = "There is not course with the CourseCode: " + courseCode + " In the data base",
                    Data = null,
                    MetaData = null
                };
            }

            return new()
            {
                Code = "00",
                Message = "The Course with the coursecode " + courseCode + "is shown below",
                Data = courseCheck,
                MetaData = null
            };
        }
    }
}
