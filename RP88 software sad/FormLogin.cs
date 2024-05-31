using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.IO;
using RP88_software_sad;
using sign_up_roda_putar_88;
using MainMenu_Roda_putar_88;

namespace Log_in_roda_putar
{
    public partial class FormLogin : Form
    {

        public static MySqlConnection sqlconnect;
        public static MySqlCommand sqlcommand;
        public static MySqlDataAdapter mySqlDataAdapter;
        public static MySqlDataReader mySqlDataReader;
        public static string connectionString;
        public static string sqlquery;
        public static string workingDirectory;
        public static string projectDirectory;
        public static string full_url;
        public static string username;

        public FormLogin()
        {
            InitializeComponent();
            FormLogin.workingDirectory = Environment.CurrentDirectory;
            FormLogin.projectDirectory = Directory.GetParent(FormLogin.workingDirectory).Parent.FullName;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connectionString = "server=localhost;uid=root;pwd=rangga123;database=db_rodaputar88"; //ini ganti conection string kalian
            sqlconnect = new MySqlConnection(connectionString);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            // btn_login.Enabled = false;


            username = txtbx_username.Text;
            string password = txtbox_password.Text;
            string encryptedPassword = EncryptPassword(password).ToLower(); // Ensure lowercase

            DataTable Login = new DataTable();
            string sqlquery = "SELECT COUNT(*) FROM login WHERE nama COLLATE utf8mb4_bg_0900_as_cs  LIKE '" + username + "' AND userpass = @encryptedPassword;";
            using (MySqlCommand sqlcommand = new MySqlCommand(sqlquery, FormLogin.sqlconnect))
            {
                sqlcommand.Parameters.AddWithValue("@username", username);
                sqlcommand.Parameters.AddWithValue("@encryptedPassword", encryptedPassword);

                using (MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(sqlcommand))
                {
                    mySqlDataAdapter.Fill(Login);
                }
            }

            if (Login.Rows[0][0].ToString() == "1")
            {
                // Login success
                this.Hide();
                //MessageBox.Show("Success");


                //this.Visible = false;

                FormMainMenu formmainmenu = new FormMainMenu();
                formmainmenu.Show();
            }
            else
            {
                // Login failed
                MessageBox.Show("Invalid username or password");
            }

            /*
            username = txtbx_username.Text;
            string password = txtbox_password.Text;
            string encryptedPassword = EncryptPassword(password);

            DataTable Login = new DataTable();
            FormLogin.sqlquery = "SELECT COUNT(*) FROM login WHERE nama COLLATE utf8mb4_bg_0900_as_cs  LIKE '" + username + "' COLLATE utf8mb4_bg_0900_as_cs AND userpass COLLATE utf8mb4_bg_0900_as_cs = '" + encryptedPassword + "' COLLATE utf8mb4_bg_0900_as_cs;";
            FormLogin.sqlcommand = new MySqlCommand(FormLogin.sqlquery, FormLogin.sqlconnect);
            FormLogin.mySqlDataAdapter = new MySqlDataAdapter(FormLogin.sqlcommand);
            FormLogin.mySqlDataAdapter.Fill(Login);



            
            if (Login.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                //MessageBox.Show("Success");

                
                //this.Visible = false;

                FormMainMenu formmainmenu = new FormMainMenu();
                formmainmenu.Show();
                

            }
            else
            {
                
                string incorrectlogin = Form1.projectDirectory + "\\Sound effect ALP\\639427__laurenponder__incorrect-chime.wav";

                System.Media.SoundPlayer player = new System.Media.SoundPlayer(incorrectlogin);
                player.Play();
                
                

                MessageBox.Show("Invalid username or password");
            }
            */




        }

        private void lbl_signup_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Formsignup formsign = new Formsignup();
            formsign.Show();
        }

        private void lbl_forgotpass_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void txtbx_username_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtbx_username_ChangeUICues(object sender, UICuesEventArgs e)
        {

        }

        private void txtbx_username_Click(object sender, EventArgs e)
        {
            txtbx_username.Text = String.Empty;
        }

        static string EncryptPassword(string password)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(password);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
