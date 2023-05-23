using MVC_Assignment.Models;

namespace MVC_Assignment
{
    public interface ICourseInterface
    {
        public List<Course> GetCourses();
        public void CreateCourse(Course course);

        public void EditCourse(int id,Course course);

        public void DeleteCourse(int id);

        public Course GetCourseById(int id);
    }
}
