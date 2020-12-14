namespace Models
{
    public class UserRoom
    {
        public int Id { get; set; }

        public string RoomId { get; set; }
        public virtual Room Room { get; set; }

        public virtual string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}