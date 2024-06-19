using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DAL
{
    public class GenericRepos<IEntity> : IGenericRepos<IEntity> where IEntity : class

    {
        private readonly HopitalContext db;

        public GenericRepos( HopitalContext db)
        {
            this.db = db;
        }

        public void Add(IEntity entity)
        {
           db.Add(entity);
            db.SaveChanges();
        }

        public List<IEntity> GetAll(params Expression<Func<IEntity, object>>[] includeProperties)
        {
            IQueryable<IEntity> query = db.Set<IEntity>();

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query.ToList();
        }

        public IEntity? getById(string id)
        {
            return db.Set<IEntity>().Find(id);
        }

        public IEntity? GetByIdWithInclude(Expression<Func<IEntity, bool>> id, Expression<Func<IEntity, object>> includeProperties)
        {

            IEntity? query = db.Set<IEntity>().Include(includeProperties).FirstOrDefault(id);

   

            return query;
        }
        public void Update(IEntity entity)
        {
            db.Set<IEntity>().Update(entity);
            db.SaveChanges();
        }


    }
}
