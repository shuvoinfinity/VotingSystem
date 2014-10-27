using System.Collections.Generic;
using VotingSystemApp.DLL.Gateway;

namespace VotingSystemApp
{
    class CandidateEntryBLL
    {
        CandidateGateway aCandidateGateway = new CandidateGateway();
        public string Save(Candidate aCandidate)
        {
            if (HasThisName(aCandidate.Name) || HasThisSymbol(aCandidate.Symbol))
            {
                return "This Name or Symbol is already incluted. Check Once";
            }
                return aCandidateGateway.Save(aCandidate);    
            
        }

        private bool HasThisSymbol(string symbol)
        {
            return aCandidateGateway.HasThisSymbol(symbol);
        }

        private bool HasThisName(string name)
        {
            return aCandidateGateway.HasthisName(name);
        }

        public List<Candidate> ShowCandidates()
        {
            return aCandidateGateway.ShowCandidates();
        }
    }
}