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
    public partial class UpdateForm : Form
    {
        public UpdateForm()
        {
            InitializeComponent();
            DataFunction.UpdateShow(textBox1, textBox2, formLoggedIn.txtBox);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegisterForm form = new RegisterForm();
            DataFunction.UpdateData(textBox1, textBox2, formLoggedIn.txtBox, this, form);
        }
    }
}
