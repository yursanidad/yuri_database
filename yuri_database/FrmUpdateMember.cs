using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yuri_database
{
    public partial class FrmUpdateMember : Form
    {
        public FrmUpdateMember()
        {
            InitializeComponent();
        }
        private SqlConnection sqlConnect;
        private SqlCommand sqlCommand;
        private SqlDataReader sqlReader;
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=C:\USERS\CAIRO\DOCUMENTS\CLUBDB.MDF;Integrated Security=True;Connect Timeout=30";
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            sqlConnect.Open();
            sqlCommand = new SqlCommand("UPDATE ClubMembers SET FirstName=@FirstName, MiddleName=@MiddleName, LastName=@LastName, Age=@Age, Gender=@Gender, Program=@Program WHERE StudentId=@StudentId", sqlConnect);
            sqlCommand.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
            sqlCommand.Parameters.AddWithValue("@MiddleName", txtMiddleName.Text);
            sqlCommand.Parameters.AddWithValue("@LastName", txtLastName.Text);
            sqlCommand.Parameters.AddWithValue("@Age", int.Parse(txtAge.Text));
            sqlCommand.Parameters.AddWithValue("@Gender", cmbGender.Text);
            sqlCommand.Parameters.AddWithValue("@Program", cmbProgram.Text);
            sqlCommand.Parameters.AddWithValue("@StudentId", cmbStudentId.Text);

            sqlCommand.ExecuteNonQuery();
            sqlConnect.Close();

            MessageBox.Show("Member updated successfully!");
        }
        private void LoadStudentIds()
        {
            cmbStudentId.Items.Clear();
            sqlConnect.Open();
            sqlCommand = new SqlCommand("SELECT StudentId FROM ClubMembers", sqlConnect);
            sqlReader = sqlCommand.ExecuteReader();
            while (sqlReader.Read())
            {
                cmbStudentId.Items.Add(sqlReader["StudentId"].ToString());
            }
            sqlReader.Close();
            sqlConnect.Close();
        }
        private void cmbStudentId_SelectedIndexChanged(object sender, EventArgs e)
        {
            sqlConnect.Open();
            sqlCommand = new SqlCommand("SELECT * FROM ClubMembers WHERE StudentId=@StudentId", sqlConnect);
            sqlCommand.Parameters.AddWithValue("@StudentId", cmbStudentId.Text);
            sqlReader = sqlCommand.ExecuteReader();
            if (sqlReader.Read())
            {
                txtFirstName.Text = sqlReader["FirstName"].ToString();
                txtMiddleName.Text = sqlReader["MiddleName"].ToString();
                txtLastName.Text = sqlReader["LastName"].ToString();
                txtAge.Text = sqlReader["Age"].ToString();
                cmbGender.Text = sqlReader["Gender"].ToString();
                cmbProgram.Text = sqlReader["Program"].ToString();
            }
            sqlReader.Close();
            sqlConnect.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cmbGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbProgram_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtMiddleName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAge_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmUpdateMember_Load(object sender, EventArgs e)
        {
            sqlConnect = new SqlConnection(connectionString);
            LoadStudentIds();


            cmbGender.Items.AddRange(new string[] { "Male", "Female", "Other" });
            cmbProgram.Items.AddRange(new string[] { "BSIT", "BSCS", "BSIS" });
        }
    }
}
