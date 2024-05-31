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
    public partial class BalanceSheet : Form
    {
        StoredData sdata;
        public BalanceSheet()
        {
            InitializeComponent();
        }
        
        
        public int outcome = 0;
        public int income = 0;
        public int total = 0;
        public static string kopilatte;
        public static string pouch;
        public static string dukuh;
        public static string nominal;
        private void BalanceSheet_Load(object sender, EventArgs e)
        {

            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            DataTable soldlate = new DataTable();
            FormLogin.sqlquery = "select count(Produk_id) as soldlate\r\nfrom `detail transaksi`\r\nwhere Produk_id = 1;";
            FormLogin.sqlcommand = new MySqlCommand(FormLogin.sqlquery, FormLogin.sqlconnect);
            FormLogin.mySqlDataAdapter = new MySqlDataAdapter(FormLogin.sqlcommand);
            FormLogin.mySqlDataAdapter.Fill(soldlate);

            DataTable soldpouch = new DataTable();
            FormLogin.sqlquery = "select count(Produk_id) as soldpouch\r\nfrom `detail transaksi`\r\nwhere Produk_id = 2;";
            FormLogin.sqlcommand = new MySqlCommand(FormLogin.sqlquery, FormLogin.sqlconnect);
            FormLogin.mySqlDataAdapter = new MySqlDataAdapter(FormLogin.sqlcommand);
            FormLogin.mySqlDataAdapter.Fill(soldpouch);

            DataTable soldcelup = new DataTable();
            FormLogin.sqlquery = "select count(Produk_id) as soldcelup\r\nfrom `detail transaksi`\r\nwhere Produk_id = 3;";
            FormLogin.sqlcommand = new MySqlCommand(FormLogin.sqlquery, FormLogin.sqlconnect);
            FormLogin.mySqlDataAdapter = new MySqlDataAdapter(FormLogin.sqlcommand);
            FormLogin.mySqlDataAdapter.Fill(soldcelup);

            lblsoldlatte.Text = soldlate.Rows[0][0].ToString() + " Pcs Sold";
            lblsoldpouch.Text = soldpouch.Rows[0][0].ToString() + " Pcs Sold";
            lblsoldcelup.Text = soldcelup.Rows[0][0].ToString() + " Pcs Sold";

            DataTable totalout = new DataTable();
            FormLogin.sqlquery = "select sum(hargabeli) as outcome\r\nfrom pembelianbahanmentah\r\nwhere PembelianatauPengunaan = \"Available\";";
            FormLogin.sqlcommand = new MySqlCommand(FormLogin.sqlquery, FormLogin.sqlconnect);
            FormLogin.mySqlDataAdapter = new MySqlDataAdapter(FormLogin.sqlcommand);
            FormLogin.mySqlDataAdapter.Fill(totalout);

            DataTable totalin = new DataTable();
            FormLogin.sqlquery = "select sum(Total_harga) as income\r\nfrom transaksi;";
            FormLogin.sqlcommand = new MySqlCommand(FormLogin.sqlquery, FormLogin.sqlconnect);
            FormLogin.mySqlDataAdapter = new MySqlDataAdapter(FormLogin.sqlcommand);
            FormLogin.mySqlDataAdapter.Fill(totalin);

            lbloutcome.Text = "Rp " + totalout.Rows[0][0].ToString() ;
            lblincome.Text = "Rp " + totalin.Rows[0][0].ToString();

            outcome = Convert.ToInt32(totalout.Rows[0][0].ToString());
            income = Convert.ToInt32(totalin.Rows[0][0].ToString());

            total = income - outcome;

            lbltotal.Text = "Rp " + total.ToString();

            /*
            lblsoldlatte.Text = Order_Main_Menu.latteterjual.ToString() + " Pcs";
            lblsoldpouch.Text = Order_Main_Menu.pouchterjual.ToString() + " Pcs";
            lblincome.Text = "Rp. " +  Order_Main_Menu.jumlahRP.ToString();
            lblsoldcelup.Text = Order_Main_Menu.dukuhterjual.ToString() + " Pcs";
            */
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            //btn mainmenu
            this.Close();
            FormMainMenu formMainMenu = new FormMainMenu();
            formMainMenu.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            //btn order
            this.Close();
            Order_Main_Menu ordermenu = new Order_Main_Menu();
            ordermenu.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            //btn product
            this.Close();
            Products_Main_Menu products_Main_Menu = new Products_Main_Menu();
            products_Main_Menu.Show();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            //btn raw material
            this.Close();
            Raw_material raw_Material = new Raw_material();
            raw_Material.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            //btn sales
            History_Mainmenu history_Mainmenu = new History_Mainmenu();
            history_Mainmenu.Show();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            //btn purchase
            this.Close();
            Manage_Goods_Main_Menu manage_Goods_Main_Menu = new Manage_Goods_Main_Menu();
            manage_Goods_Main_Menu.Show();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            //btn balance sheet
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            //btn stockopname
            this.Close();
            StockOpnameMenu stockOpnameMenu = new StockOpnameMenu();
            stockOpnameMenu.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            this.Close();
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
