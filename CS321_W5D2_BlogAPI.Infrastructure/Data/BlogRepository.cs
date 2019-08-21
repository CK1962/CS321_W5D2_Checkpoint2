using CS321_W5D2_BlogAPI.Core.Models;
using CS321_W5D2_BlogAPI.Core.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CS321_W5D2_BlogAPI.Infrastructure.Data
{
    public class BlogRepository : IBlogRepository
    {
        private readonly AppDbContext _dbContext;

        public BlogRepository(AppDbContext dbContext) 
        {
            // TODO: inject AppDbContext
            _dbContext = dbContext;
        }

        public IEnumerable<Blog> GetAll()
        {
            // TODO: Retrieve all blgs. Include Blog.User.
            return _dbContext.Blogs
               .Include(b => b.Posts)
               .Include(b => b.User)
               .ToList();
        }

        public Blog Get(int id)
        {
            // TODO: Retrieve the blog by id. Include Blog.User.
            return _dbContext.Blogs
                 .Include(b => b.Posts)
                 .Include(b => b.User)
                 .SingleOrDefault(b => b.Id == id);
        }

        public Blog Add(Blog blog)
        {
            // TODO: Add new blog
            _dbContext.Blogs.Add(blog);
            _dbContext.SaveChanges();
            return blog;
        }

        public Blog Update(Blog updatedBlog)
        {
            // TODO: update blog

            //var existingItem = _dbContext.Find(updatedItem.Id);
            var currentBlog = _dbContext.Blogs.Find(updatedBlog.Id);
            if (currentBlog == null) return null;
            //_dbContext.Entry(existingItem)
            //   .CurrentValues
            //   .SetValues(updatedItem);
            //return existingItem;
            _dbContext.Entry(currentBlog)
                .CurrentValues
                .SetValues(updatedBlog);

            // update the todo and save
            _dbContext.Blogs.Update(currentBlog);
            _dbContext.SaveChanges();
            return currentBlog;
        }

        public void Remove(int id)
        {
            var blogToDelete = Get(id);

            // TODO: remove blog
            _dbContext.Blogs.Remove(blogToDelete);
            _dbContext.SaveChanges();
        }
    }
}