using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


using System.ComponentModel.DataAnnotations.Schema;

namespace MicroForum.Models
{
    public class PostReply

    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }

        [ForeignKey(nameof(UserId))]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        [ForeignKey(nameof(Post))]
        public int PostId { get; set; }

        public  Post Post { get; set; }
    }
}
