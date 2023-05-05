using MicroForum.Data;
using MicroForum.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace MicroForum.Services
{
    public class PostService:IPost
    {
        private readonly ApplicationDbContext _context;

        public PostService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Post GetById(int id)
        {
            return _context.Posts.Include(p => p.User).FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Post> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetFiltered(string searchQuery)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetByForum(int id)
        {
            return _context.Forums.First(forum => forum.Id == id).Posts;
        }

        public Task Add(Post post)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditContent(int id, string newContent)
        {
            throw new NotImplementedException();
        }
    }
}
