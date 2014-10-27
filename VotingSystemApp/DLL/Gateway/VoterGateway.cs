using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingSystemApp.DLL.DAO;

namespace VotingSystemApp.DLL.Gateway
{
    class VoterGateway
    {
        Voter aVoter=new Voter();

        private SqlConnection connection;
        public bool HasThisMail(string mail)
        {
            connection.Open();
            string query = string.Format("SELECT * FROM t_voter WHERE Email='{0}'", aVoter.Email);
            SqlCommand aCommand = new SqlCommand(query, connection);
            SqlDataReader aReader = aCommand.ExecuteReader();

            if (aReader.HasRows)
            {
                return true;
            }
            return false;
        }
    }
}
