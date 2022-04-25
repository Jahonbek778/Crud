using Microsoft.EntityFrameworkCore;

namespace Crud
{
    public class Data : DbContext
    {
        public Data(DbContextOptions<Data> options) 
            : base(options)
        {   
        }

        public DbSet<Model> Models { get; set; }
    }
}
