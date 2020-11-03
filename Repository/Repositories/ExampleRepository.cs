using Domain.Business;
using System.Data.Entity;

namespace Repository.Repositories
{
    public class ExampleRepository : BaseRepository<ExampleClass>
    {
        public ExampleRepository(DbContext context = null) : base(context)
        {
        }
    }
}
