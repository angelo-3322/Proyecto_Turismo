using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Turismo.Application.Contracts.Repositories
{
    public interface IRepository<T>
        where T : class
    {
        //predicate: S => S.Id = 100
        // T => s
        // bool => s.Id == 100
        T Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes);


        void Instert(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Save();

    }
}

