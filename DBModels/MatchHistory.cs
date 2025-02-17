namespace RockPaperScissors.DBModels
{
    public class MatchHistory
    {
        public Guid Id { get; set; }
        public Guid Player1Id { get; set; }
        public Guid Player2Id { get; set; }
        public string Player1Turn { get; set; }
        public string Player2Turn { get; set; }
        public uint Bet { get; set; }
        public Guid WinnerId { get; set; }
        public DateTime PlayedAt { get; set; }
    }
}
