using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MicroForum.Models
{
    public class Forum
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
            
        public string ImageUrl { get; set; }
        //public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Post> Posts { get; set; }


    }
}
