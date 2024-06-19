using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DAL
{
    public interface IGenericRepos<IEntity> where IEntity : class 
    {

        List<IEntity> GetAll(params Expression<Func<IEntity, object>>[] includeProperties);

        IEntity? getById(string id);   
        IEntity? GetByIdWithInclude(Expression<Func<IEntity, bool>> expression,  Expression<Func<IEntity, object>> includeProperties );

        void Update(IEntity entity);
        void Add(IEntity entity);   
    }
    
}
