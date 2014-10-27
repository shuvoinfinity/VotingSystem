using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VotingSystemApp.BLL;
using VotingSystemApp.DLL.DAO;

namespace VotingSystemApp
{
    public partial class VoteUi : Form
    {
        public VoteUi()
        {
            InitializeComponent();
            
        }
        CandidateEntryBLL aCandidateEntryBll = new CandidateEntryBLL();
        private VoterBLL aVoterBll = new VoterBLL();
        private Voter aVoter;

        public void ShowCandidatesSymbolInComboBox()
        {
            Candidate aCandidate = new Candidate();
            List<Candidate> candidates = aCandidateEntryBll.ShowCandidates();
            foreach (Candidate candidate in candidates)
            {
                selectSymbolOfCandidateComboBox.Items.Add(candidate);
            }
            selectSymbolOfCandidateComboBox.ValueMember = "CandidateID";
            selectSymbolOfCandidateComboBox.DisplayMember = "Symbol";
        }

        private void castButton_Click(object sender, EventArgs e)
        {
            aVoter = new Voter();
            aVoter.Email = votersEmailAddressTextBox.Text;
            Candidate aCandidate = (Candidate)selectSymbolOfCandidateComboBox.SelectedItem;
            aVoter.CandidateId = aCandidate.CandidateID;
            string msg = aVoterBll.Vote(aVoter);
            MessageBox.Show(msg);


        }

        private void VoteUi_Load(object sender, EventArgs e)
        {
            ShowCandidatesSymbolInComboBox();
        }
        
    }
}
