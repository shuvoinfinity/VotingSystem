using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingSystemApp.DLL.DAO
{
    public class Voter
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public int CandidateId { get; set; }

        public Voter(int id, string email):this()
        {
            ID = id;
            Email = email;
        }

        public Voter()
        {
        }
    }
}
