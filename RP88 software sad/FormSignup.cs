using Log_in_roda_putar;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sign_up_roda_putar_88
{
    public partial class Formsignup : System.Windows.Forms.Form
    {
        public Formsignup()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void txtbx_usernamesignup_TextChanged(object sender, EventArgs e)
        { 

        }

        private void txtbx_usernamesignup_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void txtbx_usernamesignup_Click(object sender, EventArgs e)
        {
            txtbx_usernamesignup.Text = String.Empty;
        }

        private void txtbx_passwordsignup_Click(object sender, EventArgs e)
        {
            txtbx_passwordsignup.Text = String.Empty;
        }

        private void txtbx_confirmpass_Click(object sender, EventArgs e)
        {
            txtbx_confirmpass.Text = String.Empty;
        }

        private void txtbx_email_Click(object sender, EventArgs e)
        {
            txtbx_email.Text = String.Empty;
        }

        private void btn_signup_Click(object sender, EventArgs e)
        {
            
            string newusername = txtbx_usernamesignup.Text;
            string newemail = txtbx_email.Text;
            string newpassword = txtbx_passwordsignup.Text;
            string confirmpass = txtbx_confirmpass.Text;

            if(checkbox_iagree.Checked == false || String.IsNullOrWhiteSpace(newusername) || String.IsNullOrWhiteSpace(newemail) || String.IsNullOrWhiteSpace(newpassword) || String.IsNullOrWhiteSpace(confirmpass))
            {
                MessageBox.Show("Please fill all the required information");
            }
            else
            {


                if (newpassword == confirmpass)
                {
                    FormLogin.sqlquery = $"insert into login (nama, email, userpass)\r\nvalues\r\n('{newusername}','{newemail}','{newpassword}');";

                    try
                    {
                        FormLogin.sqlconnect.Open();
                        FormLogin.sqlcommand = new MySqlCommand(FormLogin.sqlquery, FormLogin.sqlconnect);
                        FormLogin.mySqlDataReader = FormLogin.sqlcommand.ExecuteReader();

                        txtbx_usernamesignup.Clear();
                        txtbx_passwordsignup.Clear();
                        txtbx_email.Clear();
                        txtbx_confirmpass.Clear();

                        MessageBox.Show("Sign Up is Successful");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        FormLogin.sqlconnect.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Confirm password does not match with the password");
                }
            }


            
        }

        private void lblbtn_login_Click(object sender, EventArgs e)
        {
            this.Close();
            //this.Visible = false;
            FormLogin formlogin = new FormLogin();
            formlogin.Show();
        }
    }
}
