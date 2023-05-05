using MicroForum.Models.PostModels;

namespace MicroForum.Models.ForumModels
{
    public class ForumTopicModel
    {
        public ForumListingModel Forum { get; set; }
        public IEnumerable<PostListingModel> Posts { get; set; }

    }
}
