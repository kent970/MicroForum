using MicroForum.Models.Reply;

namespace MicroForum.Models.PostModels
{
    public class PostIndexModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string? AuthorImageUrl { get; set; }
        public int AuthorRating { get; set; }
        public DateTime CreatedDate { get; set; }
        public string PostContent { get; set; }
        public bool IsAdmin { get; set; }


        public IEnumerable<PostReplyModel> Replies { get; set; }
    }
}
