using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Context
{
    public class DataContext : DbContext
    {
        public DataContext()
            :base("name=connectionString")
        {

        }
        //protected override void OnModelCreating(DbModelBuilder builder)
        //{
        //    builder.Configurations.Add(new ConfigurationClass());
        //}
        //public virtual DbSet<class> ClassRepresentation { get; set; }
    }
}
