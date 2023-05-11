using MicroForum.Models.PostModels;

namespace MicroForum.Models.Home
{
    public class HomeIndexModel
    {
        public string SearchQuery { get; set; }

        public IEnumerable<PostListingModel> LatestPosts { get; set; }

    }
}
