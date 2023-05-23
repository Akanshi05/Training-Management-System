using MVC_Assignment.Models;

namespace MVC_Assignment
{
    public interface IUserInterface
    {
        public List<UserViewModel> GetUsers();
        public void CreateUser(User user);

        public void EditUser(int id, User user);

        public void DeleteUser(int id);

        public User GetUserById(int id);
    }
}
