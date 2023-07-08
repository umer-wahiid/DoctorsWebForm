namespace DoctorsWebFourm.Models
{
    public class Query
    {
        public int QueryId { get; set; }

        public int UserId { get; set; }
        
        public string QueryText { get; set; }
        
        public DateTime Timestamp { get; set; }

        public User User { get; set; }
        
        public ICollection<Reply> Replies { get; set; }
    }
}
