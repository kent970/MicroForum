using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using IApplicationLifetime = Microsoft.AspNetCore.Hosting.IApplicationLifetime;

namespace MicroForum.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }

        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public  ApplicationUser User { get; set; }
        [Required]
        public  Forum Forum { get; set; }
       
        public  ICollection<PostReply>? Replies { get; set; }


    }
}
