using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingSystemApp.DLL.DAO;

namespace VotingSystemApp.DLL.Gateway
{
    class VoterGateway
    {


        private SqlConnection connection;

        public VoterGateway()
        {
            connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        }

        public bool HasThisMail(string email)
        {
            connection.Open();
            string query = string.Format("SELECT * FROM t_voter WHERE Email='{0}'", email);
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            bool Hasrow = aReader.HasRows;
            connection.Close();
            return Hasrow;
        }

        public string Vote(Voter aVoter)
        {
            connection.Open();
            string query = string.Format("INSERT INTO t_Elect VALUES ('{0}','{1}')", aVoter.CandidateId, aVoter.ID);
            SqlCommand command = new SqlCommand(query, connection);
            int affectedRow = command.ExecuteNonQuery();
            connection.Close();
            if (affectedRow > 0)
                return "You have Voted";
            return "Error";
        }
    }
}
