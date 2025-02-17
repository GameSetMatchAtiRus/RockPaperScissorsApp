namespace RockPaperScissors.DBModels
{
    public class GameTransaction
    {
        public Guid Id { get; set; }
        public Guid FromUserId { get; set; }
        public Guid ToUserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public uint Amount { get; set; }
    }
}
