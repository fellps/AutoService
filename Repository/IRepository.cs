using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AutoService.Repository
{
    public interface IRepository
    {
        void Insert(object obj);
        void Update(object obj);
        void Delete(object obj);
        List<P> GetList<P>(Expression<Func<P, bool>> predicate) where P : new();
    }
}
