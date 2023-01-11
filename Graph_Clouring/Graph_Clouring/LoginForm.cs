using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graph_Clouring
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtusername.Text) == true)
            {
                txtusername.Focus();
                errorProvider1.SetError(this.txtusername, "Please Enter Your UserName ");
            }
            else if (string.IsNullOrEmpty(txtpassword.Text) == true)
            {
                errorProvider1.Clear();
                txtpassword.Focus();

                errorProvider2.SetError(this.txtpassword, "Please Enter Your Password");

            }
            else
            {
                errorProvider2.Clear();

                //string userName = "";
                //string userPassword = "";
                SqlConnection con = new SqlConnection(cs);
                string query = "select * from login_tbl where username=@user and password=@pass";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@user", txtusername.Text);
                cmd.Parameters.AddWithValue("@pass", txtpassword.Text);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    dr.Read();
                    string userNameFromDb = dr["username"].ToString();
                    string passwordFromDb = dr["password"].ToString();
                    dr.Close();
                    if (userNameFromDb == txtusername.Text && passwordFromDb == txtpassword.Text)
                    {
                        MessageBox.Show("Login Succesful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //username = txtUserName.Text;
                        con.Close();
                        this.Hide();
                        Dashboard dashboard = new Dashboard();
                        dashboard.Show();
                    }
                    else
                    {
                        MessageBox.Show("Username And Password Incorrect\nPlease Double Check Your UserName And Password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }
                else
                {
                    MessageBox.Show("Username And Password Incorrect\nPlease Double Check Your UserName And Password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                con.Close();
            }
        }
    }
}
