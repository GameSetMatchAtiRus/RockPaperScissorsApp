namespace RockPaperScissors.DBModels
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
