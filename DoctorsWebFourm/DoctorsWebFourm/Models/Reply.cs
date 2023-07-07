using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoctorsWebFourm.Models
{
    public class Reply
    {

        //public int ReplyId { get; set; }
        //public int QueryId { get; set; }
        //public Query Query { get; set; }
        //public int UserId { get; set; }
        //public User User { get; set; }

        //[Required(ErrorMessage = "Reply is required")]
        //[MaxLength(400, ErrorMessage = "Only 400 characters are allowed")]
        //public string ReplyText { get; set; }
        //public DateTime Timestamp { get; set; }

        public int ReplyId { get; set; }
        public int QueryId { get; set; }
        public int UserId { get; set; }

        [Required(ErrorMessage = "Reply is required")]
        [MaxLength(400, ErrorMessage = "Only 400 characters are allowed")]
        public string ReplyText { get; set; }

        public DateTime Timestamp { get; set; }

        [ForeignKey("QueryId")]
        public Query Query { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }



    }
}
