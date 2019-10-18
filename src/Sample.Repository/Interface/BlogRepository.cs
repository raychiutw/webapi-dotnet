using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Sample.Repository.Implement;
using Sample.Repository.Models;

namespace Sample.Repository.Interface
{
    public class BlogRepository : IBologRepository, IDisposable
    {
        private BloggingEntities _db;

        private bool _disposed = false;

        public BlogRepository()
        {
            this._db = new BloggingEntities();
        }

        private bool BlogExists(int id)
        {
            return this._db.Blogs.Count(e => e.BlogId == id) > 0;
        }

        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this._disposed)
            {
                // If disposing equals true, dispose all managed
                // and unmanaged resources.
                if (disposing)
                {
                    // Dispose managed resources.
                    this._db.Dispose();
                }

                // Note disposing has been done.
                this._disposed = true;
            }
        }

        public void Remove(int id)
        {
            Blog blog = this._db.Blogs.Find(id);
            if (blog == null)
            {
                throw new Exception("Not fund blog");
            }

            this._db.Blogs.Remove(blog);
            this._db.SaveChanges();
        }

        public IQueryable<Blog> Get(Expression<Func<Blog, bool>> predicate)
        {
            return this._db.Blogs.Where(predicate);
        }

        public void Update(Blog blog)
        {
            this._db.Entry(blog).State = EntityState.Modified;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Add(Blog blog)
        {
            this._db.Blogs.Add(blog);
            this._db.SaveChanges();
        }
    }
}