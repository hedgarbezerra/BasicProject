using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;

namespace Repository.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Atualizar(T obj);
        void Dispose();
        T EncontrarPorId(int id);
        T Inserir(T obj);
        IEnumerable<T> Listar();
        IEnumerable<T> Listar(Expression<Func<T, bool>> expression = null);
        IEnumerable<T> Listar(Expression<Func<T, bool>> expression = null, Expression<Func<T, object>> order = null, int? count = 0, int? skip = 0, bool reverse = false);
        IEnumerable<T> ListarNoTracking();
        IEnumerable<T> ListarNoTracking(Expression<Func<T, bool>> expression = null);
        void Remover(T obj);
        DbContext RetornaContexto();
        void Savechanges();
    }
}