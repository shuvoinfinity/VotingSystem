namespace VotingSystemApp
{
    internal class Candidate
    {
        public int CandidateID { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public static int numberOfWinner { set; private get; }
    
        

        public Candidate(string name, string symbol):this()
        {
            Name = name;
            Symbol = symbol;
        }

        public Candidate()
        {
        }
    }
}