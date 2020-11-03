using Domain.Business;
using Repository.Context;
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
        private readonly ExampleRepository _repo;
        private readonly DataContext _context;
       
        public ExampleService()
        {
            _context = new DataContext();
            _repo = new ExampleRepository(_context);
        }

        public void Add(ExampleClass example)
        {
            _repo.Inserir(example);

            _repo.Savechanges();
        }
    }
}
