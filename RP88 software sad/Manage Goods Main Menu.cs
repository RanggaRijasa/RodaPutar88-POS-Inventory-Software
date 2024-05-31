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

namespace MainMenu_Roda_putar_88
{
    public partial class Manage_Goods_Main_Menu : Form
    {
        public Manage_Goods_Main_Menu()
        {
            InitializeComponent();
        }

        public int availstokcelup = 0;
        public int availstokpouch = 0;



        public int penampungcelup = 0;
        public int penampungpouch = 0;



        private void guna2TextBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox26_TextChanged(object sender, EventArgs e)
        {

        }

        private void Manage_Goods_Main_Menu_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;


            DataTable SalesHistory = new DataTable();
            FormLogin.sqlquery = "select tanggalproduksi, concat(\"Rp \", hargabeli) as `Harga`, namabahan, stock, PembelianatauPengunaan\r\nfrom PembelianBahanMentah\r\norder by 1 asc;";
            FormLogin.sqlcommand = new MySqlCommand(FormLogin.sqlquery, FormLogin.sqlconnect);
            FormLogin.mySqlDataAdapter = new MySqlDataAdapter(FormLogin.sqlcommand);
            FormLogin.mySqlDataAdapter.Fill(SalesHistory);
            dgv_purchase.DataSource = SalesHistory;

            /*
            DataTable latepcsavail = new DataTable();
            FormLogin.sqlquery = "select  stock as STOCK\r\nfrom produk\r\nwhere ID_Produk = 1 or ID_Produk = 2 or ID_Produk = 3;";
            FormLogin.sqlcommand = new MySqlCommand(FormLogin.sqlquery, FormLogin.sqlconnect);
            FormLogin.mySqlDataAdapter = new MySqlDataAdapter(FormLogin.sqlcommand);
            FormLogin.mySqlDataAdapter.Fill(latepcsavail);

            //kopilatelabelavail.Text = latepcsavail.Rows[0][0].ToString();
            labelavailpouchbubuk.Text = latepcsavail.Rows[1][0].ToString();
            labelavailcelupdukuh.Text = latepcsavail.Rows[2][0].ToString();
            */
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            //mainmenu button
            this.Close();
            FormMainMenu formMainMenu = new FormMainMenu();
            formMainMenu.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            //order button
            this.Close();
            Order_Main_Menu ordermenu = new Order_Main_Menu();
            ordermenu.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            //product button
            this.Close();
            Products_Main_Menu products_Main_Menu = new Products_Main_Menu();
            products_Main_Menu.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            //history button
            this.Close();
            History_Mainmenu history_Mainmenu = new History_Mainmenu();
            history_Mainmenu.Show();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            //rawmaterial button

            this.Close();
            Raw_material raw_Material = new Raw_material();
            raw_Material.Show();
        }

        private void label38_Click(object sender, EventArgs e)
        {
            //logout button

            this.Close();
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
        }

        private void label39_Click(object sender, EventArgs e)
        {
            //exit button

            Application.Exit();
        }

        private void guna2Shapes7_Click(object sender, EventArgs e)
        {

        }

        private void guna2Shapes9_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton3_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton1_Click_1(object sender, EventArgs e)
        {


        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton4_Click(object sender, EventArgs e)
        {

        }

        private void btn_confirmeditcelup_Click(object sender, EventArgs e)
        {


        }

        private void btn_confirmeditppuch_Click(object sender, EventArgs e)
        {

        }

        private void dgv_saleshistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            this.Close();
            StockOpnameMenu stockOpnameMenu = new StockOpnameMenu();
            stockOpnameMenu.Show();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            this.Close();
            BalanceSheet balanceSheet = new BalanceSheet();
            balanceSheet.Show();
        }
    }
}
