using MVC_Assignment.Context;
using MVC_Assignment.Models;

namespace MVC_Assignment.Repository
{
    public class CourseRepository : ICourseInterface
    {

        TrainingDbContext db;

        public CourseRepository(TrainingDbContext _db)
        {
            db = _db;
        }
        public void CreateCourse(Course course)
        {
            db.Courses.Add(course);
            db.SaveChanges();
        }

        public void DeleteCourse(int id)
        {
            Course obj = db.Courses.Find(id);
            if(obj != null)
            {
                db.Courses.Remove(obj);
                db.SaveChanges();
            }

        }

        public void EditCourse(int id, Course course)
        {
            Course obj = db.Courses.Find(id);
            if(obj != null)
            {
                db.Courses.Update(course);
                db.SaveChanges();
            }
        }

        public Course GetCourseById(int id)
        {
            Course obj = db.Courses.Find(id);
            return obj;
        }

        public List<Course> GetCourses()
        {
            List<Course> courses = db.Courses.ToList();
            return courses;
        }
    }
}
