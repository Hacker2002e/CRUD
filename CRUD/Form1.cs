using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(Data.DS);

        

        public void ShowInTextBox()
        {

           
            txtName.Text = dataGridView.CurrentRow.Cells[0].Value.ToString();
            txtSurname.Text = dataGridView.CurrentRow.Cells[1].Value.ToString();
            txtEmail.Text = dataGridView.CurrentRow.Cells[2].Value.ToString();
            txtGender.Text = dataGridView.CurrentRow.Cells[3].Value.ToString();
            txtID.Text = dataGridView.CurrentRow.Cells[4].Value.ToString();
            txtSalary.Text = dataGridView.CurrentRow.Cells[5].Value.ToString();
        }
       public void ShowData(string data)
        {
            SqlDataAdapter da = new SqlDataAdapter(data, connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView.DataSource = ds.Tables[0];
        }
            private void Form1_Load(object sender, EventArgs e)
        {
            this.ActiveControl = lbl_name;
        }


        public void Strings()
        {

            string ID = txtID.Text;
            string Name = txtName.Text;
            string Surname = txtSurname.Text;
            string Salary = txtSalary.Text;
            string Email = txtEmail.Text;
            string Gender = txtGender.Text;

            Crud.Add( Name, Surname,Email,Gender, ID,Salary);

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnShow_Click(object sender, EventArgs e)
        {

            
            Watch();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Strings();
            textBoxClear();
            Watch();
        }
        private void textBoxClear()
        {
           
            txtName.Clear();
            txtSurname.Clear();
            txtEmail.Clear();
            txtGender.ResetText();
            txtID.Clear();
            txtSalary.Clear();
        }
        private void Watch()
        {

            string dates = "SELECT*from Work";

            SqlCommand s = new SqlCommand(dates, connection);

            SqlDataAdapter da = new SqlDataAdapter(s);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView.DataSource = dt;
            textBoxClear();


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string ID = txtID.Text;


            Crud.Delete(ID);
            textBoxClear();
            Watch();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           
            string Name = txtName.Text;
            string Surname = txtSurname.Text;
            string Email = txtEmail.Text;
            string Gender = txtGender.Text;
            string ID = txtID.Text;
            string Salary = txtSalary.Text;


            Crud.Update(ID, Name, Surname,Salary, Email, Gender);
            textBoxClear();
            Watch();

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
             textBoxClear();
        }

        private void btnShowWithID_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text == "")
                {
                    ShowData("Select*from Work");

                }
                else
                {
                    string X = txtID.Text;
                    ShowData("Select*from Work Where ID = '" + X + "'");
                }

            }
            catch
            {
                MessageBox.Show("Something is wrong", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            ShowInTextBox();
        }
    }
}
