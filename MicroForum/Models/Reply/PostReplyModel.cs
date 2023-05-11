namespace MicroForum.Models.Reply
{
    public class PostReplyModel
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string? AuthorImageUrl { get; set; }
        public int AuthorRating { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ReplyContent { get; set; }
        public bool IsAdmin { get; set; }
        public int PostId { get; set; }
    }
}
