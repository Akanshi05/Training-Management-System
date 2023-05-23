using MVC_Assignment.Context;
using MVC_Assignment.Models;

namespace MVC_Assignment.Repository
{
    public class UserRepository : IUserInterface
    {
        TrainingDbContext db;

        public UserRepository(TrainingDbContext _db)
        {
            db = _db;
        }
        public void CreateUser(User user)
        {
            user.IsActive = true;
           db.Users.Add(user);
            db.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            User obj = db.Users.Find(id);   
            if(obj != null)
            {
                obj.IsActive = false;
                db.SaveChanges();
            }
        }

        public void EditUser(int id, User user)
        {
           User obj = db.Users.Find(id);
            if(obj != null)
            {
                db.Users.Update(user);
                db.SaveChanges();
            }
        }

        public User GetUserById(int id)
        {
            User obj = db.Users.Find(id);
            
                return obj;
            
        }

        public List<UserViewModel> GetUsers()
        {
            var list = (from x in db.Users
                        join y in db.Users
                on x.ManagerName equals y.UserName
                        select new UserViewModel
                        {

                            UserName = x.UserName,
                            ManagerName = y.UserName

                        }).ToList();
            return list;
        }
    }
}
