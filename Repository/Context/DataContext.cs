using Domain.Business;
using Repository.Context.Configuration;
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
            :base(@"Server=HED-GAMINGPC\SQLEXPRESS;Database=DB_MVC_Currency;Trusted_Connection=True;User Id=sa;Password=!01pq92ow")
        {

        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Configurations.Add(new ExampleConfiguration());
        }
        public virtual DbSet<ExampleClass> ExampleClasses { get; set; }
    }
}
