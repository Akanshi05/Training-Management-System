using MVC_Assignment.Models;

namespace MVC_Assignment
{
    public interface IBatchInterface
    {
        public List<Batch> GetBatches();
        public void CreateBatch(Batch batch);

        public void EditBatch(int id, Batch batch);

        public void DeleteBatch(int id);

        public Batch GetBatchById(int id);
    }
}
