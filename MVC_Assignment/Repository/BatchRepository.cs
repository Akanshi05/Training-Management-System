using MVC_Assignment.Context;
using MVC_Assignment.Models;

namespace MVC_Assignment.Repository
{
    public class BatchRepository : IBatchInterface
    {
        TrainingDbContext db;

        public BatchRepository(TrainingDbContext _db)
        {
            db = _db;
        }
        public void CreateBatch(Batch batch)
        {
            db.Batches.Add(batch);
            db.SaveChanges();
        }

        public void DeleteBatch(int id)
        {
            Batch obj = db.Batches.Find(id);
            if (obj != null)
            {
                db.Batches.Remove(obj);
                db.SaveChanges();
            }
        }

        public void EditBatch(int id, Batch batch)
        {
            Batch obj = db.Batches.Find(id);
            if (obj != null)
            {
                db.Batches.Update(batch);
                db.SaveChanges();
            }
        }

        public Batch GetBatchById(int id)
        {
            Batch obj = db.Batches.Find(id);
            return obj;
        }

        public List<Batch> GetBatches()
        {
            List<Batch> batches = db.Batches.ToList();
            return batches;
        }
    }
}
