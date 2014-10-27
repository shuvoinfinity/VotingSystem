using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingSystemApp.DLL.DAO;
using VotingSystemApp.DLL.Gateway;

namespace VotingSystemApp.BLL
{
   public class VoterBLL
    {
      VoterGateway aVoterGateway=new VoterGateway();


       public string Vote(Voter aVoter)
       {
           if (!HisThisEmail(aVoter.Email))
           {
               return "This Email is not recorded.";
           }
           return aVoterGateway.Vote(aVoter);
       }

       private bool HisThisEmail(string email)
       {
           return aVoterGateway.HasThisMail(email);
       }
    }
}
