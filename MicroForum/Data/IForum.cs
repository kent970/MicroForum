using MicroForum.Models;

namespace MicroForum.Data
{
    public interface IForum
    {
        Forum GetById(int id);
        IEnumerable<Forum> GetAll();
        ICollection<ApplicationUser> getAllUsers ();

        Task Create(Forum forum);
        Task Delete(int forumId);
        Task UpdateTitle(int forumId,string newTitle );
        Task UpdateDescription(int forumId,string newDescription);
    }
}
