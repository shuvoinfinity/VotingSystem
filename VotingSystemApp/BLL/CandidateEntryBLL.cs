using System.Collections.Generic;
using VotingSystemApp.DLL.Gateway;

namespace VotingSystemApp
{
    class CandidateEntryBLL
    {
        CandidateGateway aCandidateGateway = new CandidateGateway();
        public string Save(Candidate aCandidate)
        {

            return aCandidateGateway.Save(aCandidate);
        }

        public List<Candidate> ShowCandidates()
        {
            return aCandidateGateway.ShowCandidates();
        }
    }
}