﻿using System;
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
    public partial class formLogin : Form
    {
        public formLogin()
        {
            InitializeComponent();

        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            formLoggedIn formLoggedIn = new formLoggedIn();
            DataFunction.CheckCredential(usernameTxtBox, passwordTxtBox, formLoggedIn, this);
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            RegisterForm form2 = new RegisterForm();
            DataFunction.HideShowForm(this, form2);
        }
    }
}
