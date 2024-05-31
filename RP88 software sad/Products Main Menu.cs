using Log_in_roda_putar;
using MySql.Data.MySqlClient;
using RP88_software_sad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace MainMenu_Roda_putar_88
{
    public partial class Products_Main_Menu : Form
    {
        public Products_Main_Menu()
        {
            InitializeComponent();
        }

        public static int lowstokalert = 10;
        private void forAllButtons_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
            FormMainMenu formMainMenu = new FormMainMenu();
            formMainMenu.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Order_Main_Menu ordermenu = new Order_Main_Menu();
            ordermenu.Show();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Products_Main_Menu_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            DataTable harga = new DataTable();
            FormLogin.sqlquery = "select concat(\"Rp. \", Harga_jual, \"/Pcs\") as `harga`\r\nfrom produk;";
            FormLogin.sqlcommand = new MySqlCommand(FormLogin.sqlquery, FormLogin.sqlconnect);
            FormLogin.mySqlDataAdapter = new MySqlDataAdapter(FormLogin.sqlcommand);
            FormLogin.mySqlDataAdapter.Fill(harga);


            DataTable latepcsavail = new DataTable();
            FormLogin.sqlquery = "select  stock as STOCK\r\nfrom produk\r\nwhere ID_Produk = 1 or ID_Produk = 2 or ID_Produk = 3;";
            FormLogin.sqlcommand = new MySqlCommand(FormLogin.sqlquery, FormLogin.sqlconnect);
            FormLogin.mySqlDataAdapter = new MySqlDataAdapter(FormLogin.sqlcommand);
            FormLogin.mySqlDataAdapter.Fill(latepcsavail);

            lblstockpouch.Text = latepcsavail.Rows[1][0].ToString() + " Pcs in stock";
            lblstockcelup.Text = latepcsavail.Rows[2][0].ToString() + " Pcs in stock";

            kopilatelabelavail.Text = harga.Rows[0][0].ToString();
            pouchlabelavail.Text = harga.Rows[1][0].ToString();
            celuplabelavail.Text = harga.Rows[2][0].ToString();


            if (Convert.ToInt32(latepcsavail.Rows[1][0]) <= lowstokalert || Convert.ToInt32(latepcsavail.Rows[2][0]) <= lowstokalert)
            {
                MessageBox.Show("Stok sudah menipis harap, diisi kembali", "Low Stock Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void guna2Button15_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button16_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button14_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnkopilatepcssold_Click(object sender, EventArgs e)
        {

        }

        private void btnkopilatepcsavailable_Click(object sender, EventArgs e)
        {



        }

        private void btnkopilatepcsavailable_MouseHover(object sender, EventArgs e)
        {

        }

        private void kopilatelabelavail_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            this.Close();
            History_Mainmenu history_Mainmenu = new History_Mainmenu();
            history_Mainmenu.Show();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            this.Close();
            Manage_Goods_Main_Menu manage_Goods_Main_Menu = new Manage_Goods_Main_Menu();
            manage_Goods_Main_Menu.Show();
        }

        private void btncelupdukupcsavailable_Click(object sender, EventArgs e)
        {

        }

        private void celuplabelavail_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button14_Click_1(object sender, EventArgs e)
        {
            FormEditPrice formEditPrice = new FormEditPrice();
            formEditPrice.Show();
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            this.Close();
            Raw_material raw_Material = new Raw_material();
            raw_Material.Show();
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            this.Close();
            StockOpnameMenu stockOpnameMenu = new StockOpnameMenu();
            stockOpnameMenu.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.Close();
            BalanceSheet balanceSheet = new BalanceSheet();
            balanceSheet.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
        }

        private void guna2Button9_Click_1(object sender, EventArgs e)
        {

        }
    }
}
