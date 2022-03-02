using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm
{
    class DataFunction
    {
       public static void ShowData(ListBox listBox1, ListBox listBox2, ListBox listBox3, Label label5)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-VGJQ4HL;Initial Catalog=UserLogin;Integrated Security=True");
            string query = "select * from logins";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlcon);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            label5.Text = dataTable.Rows[4][2].ToString();

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                listBox1.Items.Add(dataTable.Rows[i][0]);
                listBox2.Items.Add(dataTable.Rows[i][1]);
                listBox3.Items.Add(dataTable.Rows[i][2]);
            }
        }

        public static void CheckCredential(TextBox usernameTxtBox, TextBox passwordTxtBox, formLoggedIn objFormLog, formLogin formLogin)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-VGJQ4HL;Initial Catalog=UserLogin;Integrated Security=True");
            string query = "select * from logins where username = '" + usernameTxtBox.Text.Trim() + "' and password='" + passwordTxtBox.Text.Trim() + "'";
            SqlDataAdapter sqlData = new SqlDataAdapter(query, sqlcon);
            DataTable dataTable = new DataTable();
            sqlData.Fill(dataTable);
            if (dataTable.Rows.Count == 1)
            {
                HideShowForm(formLogin, objFormLog);
            }

            else
            {
                MessageBox.Show("Please check your username and password!");
            }
        }

        public static void HideShowForm(Form formToHide, Form formToShow)
        {
            formToHide.Hide();
            formToShow.Show();
        }

        public static void RegisterData(TextBox textBox1, TextBox textBox2, Form form1, Form form2)
        {
            int idCount;
            SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-VGJQ4HL;Initial Catalog=UserLogin;Integrated Security=True");
            string sample = "select * from logins";
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlData1 = new SqlDataAdapter(sample, sqlcon);
            bool havedublicate = false;
            sqlData1.Fill(dataTable);

            for(int i = 0; i < dataTable.Rows.Count; i++)
            {
                if (dataTable.Rows[i][1] == textBox1.Text.Trim())
                {
                    havedublicate = true;
                }
            }
            if (!havedublicate)
            {
                idCount = dataTable.Rows.Count + 1;
                string query = "insert into logins values(" + idCount + ", '" + textBox1.Text.Trim() + "', '" + textBox2.Text.Trim() + "')";
                DataSet data = new DataSet();
                SqlDataAdapter sqlData = new SqlDataAdapter(query, sqlcon);
                sqlData.Fill(data);
                textBox1.Clear();
                textBox2.Clear();
                MessageBox.Show("Registration Complete.");
                HideShowForm(form1, form2);
                sqlcon.Close();
            }
            else
            {
                MessageBox.Show("Choose another username!");
                
            }
            
        }

        public static void DeleteData(TextBox textBox)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-VGJQ4HL;Initial Catalog=UserLogin;Integrated Security=True");
            string deletequery = "delete from logins where userID = "+textBox.Text;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(deletequery, sqlcon);
            DataSet dataSet = new DataSet();
            if(textBox.Text == string.Empty)
            {
                MessageBox.Show("Enter value!");
            }
            else
            {
                sqlDataAdapter.Fill(dataSet);
                MessageBox.Show("User with userID '"+textBox.Text+"' had been deleted.");
            }
        }

        public static void UpdateShow(TextBox textBox1, TextBox textBox2, TextBox textBox3)
        {
                SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-VGJQ4HL;Initial Catalog=UserLogin;Integrated Security=True");
                string selectquery = "select username, password from logins where userID=" + textBox3.Text.Trim();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectquery, sqlcon);
                DataTable data = new DataTable();
                sqlDataAdapter.Fill(data);
                textBox1.Text = data.Rows[0][0].ToString();
                textBox2.Text = data.Rows[0][1].ToString();
        }

        public static void UpdateData(TextBox textBox1, TextBox textBox2, TextBox textBox3, Form thisForm, Form loginForm)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-VGJQ4HL;Initial Catalog=UserLogin;Integrated Security=True");
            string updatequery = "update logins set username='"+textBox1.Text.Trim()+"', password='"+textBox2.Text.Trim()+"' where userID ="+textBox3.Text.Trim();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(updatequery, sqlcon);
            DataSet dataSet = new DataSet();
            if (textBox3.Text == string.Empty)
            {
                MessageBox.Show("Enter value!");
            }
            else
            {
                sqlDataAdapter.Fill(dataSet);
                MessageBox.Show("Update successfully!");
                thisForm.Hide();
                loginForm.Show();

            }
        }
    }
}
