using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMS.Model
{
    public class ChatMember
    {
        [Key]
        public int ChatMemberId { get; set; }

        [Required]
        public int ChatId { get; set; }

        [Required]
        public string UserId { get; set; } 

        [ForeignKey("ChatId")]
        public Chat Chat { get; set; }
    }
}
