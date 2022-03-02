using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LoginForm
{
    public partial class formLoggedIn : Form
    {
        public static TextBox txtBox { get; set; }

        public formLoggedIn()
        {
            InitializeComponent();
            DataFunction.ShowData(listBox1, listBox2, listBox3, label5);
            txtBox = textBox2;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            formLogin form = new formLogin();
            DataFunction.HideShowForm(this, form);
        }

        private void label7_Click(object sender, EventArgs e)
        {
            DataFunction.DeleteData(textBox1);
        }

        private void label8_Click(object sender, EventArgs e)
        {
            if(textBox2.Text != string.Empty)
            {
                this.Hide();
                UpdateForm updateForm = new UpdateForm();
                updateForm.Show();
            }
            else
            {
                MessageBox.Show("Enter a value!");
            }
        }
    }
}
