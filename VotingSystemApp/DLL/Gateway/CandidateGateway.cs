using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingSystemApp.DLL.Gateway
{
    
    class CandidateGateway
    {
        private SqlConnection connection;
        public CandidateGateway()
        {
            connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        }

        public string Save(Candidate aCandidate)
        {
            connection.Open();
            string query = string.Format("INSERT INTO t_Candidate VALUES('{0}','{1}')", aCandidate.Name,
                aCandidate.Symbol);

           SqlCommand aCommand = new SqlCommand(query, connection);
           int affectedRow =  aCommand.ExecuteNonQuery();
            connection.Close();
            if (affectedRow>0)
            
                return "Save Successful";
            return "Save Failed.";

        }

        public List<Candidate> ShowCandidates()
        {
            connection.Open();
            string query = string.Format("SELECT * FROM t_Candidate");
            SqlCommand aCommand = new SqlCommand(query, connection);
            SqlDataReader aReader = aCommand.ExecuteReader();

            List<Candidate> candidates = new List<Candidate>();
            if (aReader.HasRows)
            {

                while (aReader.Read())
                {
                    Candidate aCandidate = new Candidate();
                    
                    aCandidate.CandidateID = (int)aReader[0];
                    aCandidate.Name = aReader[1].ToString();
                    aCandidate.Symbol = aReader[2].ToString();

                    candidates.Add(aCandidate);
                }
                
            }
            connection.Close();
            return candidates;
        }

        public bool HasthisName(string name)
        {
            connection.Open();
            string query = string.Format("SELECT * FROM t_Candidate WHERE Name = '{0}'", name);
            SqlCommand aSqlCommand = new SqlCommand(query, connection);
            SqlDataReader aReader = aSqlCommand.ExecuteReader();
            bool Hasrow = aReader.HasRows;
            connection.Close();
            return Hasrow;
        }

        public bool HasThisSymbol(string symbol)
        {
            connection.Open();
            string query = string.Format("SELECT * FROM t_Candidate WHERE Symbol = '{0}'", symbol);
            SqlCommand aSqlCommand = new SqlCommand(query, connection);
            SqlDataReader aReader = aSqlCommand.ExecuteReader();
            bool Hasrow = aReader.HasRows;
            connection.Close();
            return Hasrow;
        }
    }
}
