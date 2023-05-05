using MicroForum.Data;
using MicroForum.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroForum.Services
{
    public class ForumService:IForum
    {

        private readonly ApplicationDbContext _context;
        public ForumService(ApplicationDbContext context)
        {
            _context = context;

        }
        public Forum GetById(int id)
        {
            var forum = _context.Forums
                .Include(f => f.Posts)
                .ThenInclude(f => f.User)
                .FirstOrDefault(f => f.Id == id);

            return forum;
        }

        public IEnumerable<Forum> GetAll()
        {
            return _context.Forums.Include(forum => forum.Posts);
        }

        public ICollection<ApplicationUser> getAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task Create(Forum forum)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int forumId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTitle(int forumId, string newTitle)
        {
            throw new NotImplementedException();
        }

        public Task UpdateDescription(int forumId, string newDescription)
        {
            throw new NotImplementedException();
        }
    }
}
