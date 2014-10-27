using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingSystemApp.DLL.Gateway;

namespace VotingSystemApp.BLL
{
   public class VoterBLL
    {
      VoterGateway aVoterGateway=new VoterGateway();

       public string CheckThisEmailValid(string mail)
       {
           if (!HasThisMail(mail))
           {
               return "mail already exists";
           }
           return " ";
       }

       public bool HasThisMail(string mail)
       {
           return aVoterGateway.HasThisMail(mail);
       }
    }
}
