using MVC_Assignment.Context;
using MVC_Assignment.Models;

namespace MVC_Assignment.Repository
{
    public class RequestRepository : IRequestInterface
    {
        TrainingDbContext db;

        public RequestRepository(TrainingDbContext _db)
        {
            db = _db;
        }
        public void CreateRequest(Request request)
        {
            db.Requests.Add(request);
            db.SaveChanges();
        }

        public void DeleteRequest(int id)
        {
            Request obj = db.Requests.Find(id);
            if (obj != null)
            {
                db.Requests.Remove(obj);
                db.SaveChanges();
            }
        }

        public void EditRequest(int id, Request request)
        {
            Request obj = db.Requests.Find(id);
            if (obj != null)
            {
                db.Requests.Update(request);
                db.SaveChanges();
            }
        }

        public Request GetRequestById(int id)
        {
            Request obj = db.Requests.Find(id);
            return obj;
        }

        public List<Request> GetRequests()
        {
            return db.Requests.ToList();
        }
    }
}
