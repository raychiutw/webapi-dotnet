using System;
using System.Linq;
using System.Linq.Expressions;
using Sample.Repository.Models;

namespace Sample.Repository.Interface
{
    public interface IBologRepository
    {
        IQueryable<Blog> Get(Expression<Func<Blog, bool>> predicate);

        void Update(Blog blog);

        void Add(Blog blog);

        void Remove(int id);
    }
}