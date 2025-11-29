using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yuri_database
{
    public partial class FrmClubRegistration : Form
    {
        public FrmClubRegistration()
        {
            InitializeComponent();
        }
        private ClubRegistrationQuery clubRegistrationQuery;
        private int ID = 0, Age, count = 0;
        private long StudentId;
        private void RefreshListOfClubMembers()
        {
            clubRegistrationQuery.DisplayList();
            dataGridView.DataSource = clubRegistrationQuery.bindingSource;
        }

        private int RegistrationID()
        {
            return ++count;
        }
        private void FrmClubRegistration_Load(object sender, EventArgs e)
        {
            clubRegistrationQuery = new ClubRegistrationQuery();
            RefreshListOfClubMembers();

            cmbGender.Items.Add("Male");
            cmbGender.Items.Add("Female");
            cmbGender.Items.Add("Other");


            cmbProgram.Items.Add("BSIT");
            cmbProgram.Items.Add("BSCS");
            cmbProgram.Items.Add("BSIS");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmUpdateMember frmUpdateMember = new FrmUpdateMember();
            frmUpdateMember.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RefreshListOfClubMembers();
        }

        private string FirstName, MiddleName, LastName, Gender, Program;
        private void button1_Click(object sender, EventArgs e)
        {
            ID = RegistrationID();
            StudentId = long.Parse(txtStudentID.Text);
            FirstName = txtFirstName.Text;
            MiddleName = txtMiddleName.Text;
            LastName = txtLastName.Text;
            Age = int.Parse(txtAge.Text);
            Gender = cmbGender.Text;
            Program = cmbProgram.Text;

            clubRegistrationQuery.RegisterStudent(ID, StudentId, FirstName, MiddleName, LastName, Age, Gender, Program);
            RefreshListOfClubMembers();
        }
    }
}
