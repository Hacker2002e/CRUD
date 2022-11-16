using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD
{
    internal class Crud
    {
        private static SqlConnection connection = new SqlConnection(Data.DS);



        public static void Add(string ID, string Name, string Surname, string  Salary,  string Email, string Gender)
        {
            try
            {


                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("insert into Work (ID,Name,Surname,Salary,Email,Gender) values('" + ID + "','" + Name + "','" + Surname + "','" + Salary + "','" + Email + "','" + Gender + "')", connection);
                sqlCommand.ExecuteNonQuery();
                connection.Close();



            }
            catch
            {
                MessageBox.Show("Something is wrong", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }



        public static void Delete(string ID)
        {
            try
            {


                connection.Open();
                int ID_prm = Int32.Parse(ID);
                SqlCommand sqlCommand = new SqlCommand("delete from Work where ID=(" + ID + ")", connection);
                sqlCommand.ExecuteNonQuery();
                connection.Close();


            }
            catch
            {
                MessageBox.Show("Something is wrong", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        public static void Update(string ID, string Name, string Surname, string Salary,  string Email, string Gender)
        {
            try
            {


                connection.Open();
                int ID_prm = Int32.Parse(ID);
                SqlCommand sqlCommand = new SqlCommand("Update Work set ID ='" + ID + "', Name = '" + Name + "',Surname='" + Surname + "',Salary='" + Salary + "',Email='" + Email + "',Gender='" + Gender + "'", connection);
                sqlCommand.ExecuteNonQuery();
                connection.Close();


            }
            catch
            {


                MessageBox.Show("Something is wrong", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
        }
    }
}
