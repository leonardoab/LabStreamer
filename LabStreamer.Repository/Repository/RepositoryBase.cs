using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LabStreamer.Repository.Context;

namespace LabStreamer.Repository.Repository
{
    public abstract class RepositoryBase<T> where T : class, new()
    {
        private LabStreamerContext Context { get; set; }

        public RepositoryBase(LabStreamerContext Context)
        {
            this.Context = Context;
        }

        public void Save(T entity)
        {
            Context.Add(entity);
            Context.SaveChanges();
        }

        public void Update(T entity)
        {
            Context.Update(entity);
            Context.SaveChanges();
        }
        public void Delete(T entity)
        {
            Context.Remove(entity);
            Context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public T GetById(Guid id)
        {
            return Context.Set<T>().Find(id);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return Context.Set<T>().Where(expression);
        }

        public bool Exists(Expression<Func<T, bool>> expression)
        {
            return Find(expression).Any();
        }




    }
}
