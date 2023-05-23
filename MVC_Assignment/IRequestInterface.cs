using MVC_Assignment.Models;

namespace MVC_Assignment
{
    public interface IRequestInterface
    {
        public List<Request> GetRequests();
        public void CreateRequest(Request request);

        public void EditRequest(int id, Request request);

        public void DeleteRequest(int id);

        public Request GetRequestById(int id);
    }
}
