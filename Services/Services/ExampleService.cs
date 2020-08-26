using Domain.Business;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ExampleService
    {
        private ExampleRepository repo;
       
        public ExampleService()
        {
            repo = new ExampleRepository();
        }

        public void Add(ExampleClass example)
        {
            repo.Inserir(example);

            repo.Savechanges();
        }
    }
}
