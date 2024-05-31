using Log_in_roda_putar;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainMenu_Roda_putar_88
{
    public partial class History_Mainmenu : Form
    {
        public History_Mainmenu()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e) //mainmenu button
        {
            this.Close();
            FormMainMenu formMainMenu = new FormMainMenu();
            formMainMenu.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e) // order button
        {
            this.Close();
            Order_Main_Menu ordermenu = new Order_Main_Menu();
            ordermenu.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e) // products button
        {
            this.Close();
            Products_Main_Menu products_Main_Menu = new Products_Main_Menu();
            products_Main_Menu.Show();
        }

        private void History_Mainmenu_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            DataTable SalesHistory = new DataTable();       
            FormLogin.sqlquery = "select t.Tanggal_transaksi as `Date`, l.nama as `Name`, concat(\"Rp.\",t.Total_harga) as `Amount`, l.email as `Email`, l.nomortelpon as `Contact`\r\nfrom transaksi t, login l\r\nwhere t.User_id = l.ID_user\r\norder by t.Tanggal_transaksi asc;";
            FormLogin.sqlcommand = new MySqlCommand(FormLogin.sqlquery, FormLogin.sqlconnect);
            FormLogin.mySqlDataAdapter = new MySqlDataAdapter(FormLogin.sqlcommand);
            FormLogin.mySqlDataAdapter.Fill(SalesHistory);
            dgv_saleshistory.DataSource = SalesHistory;
        }

        private void label38_Click(object sender, EventArgs e)
        {
            this.Close();
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
        }

        private void label39_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // click to search based on name

            string search = txtbox_search.Text;

            if (string.IsNullOrEmpty(search))
            {
                DataTable SalesHistory = new DataTable();
                FormLogin.sqlquery = "select t.Tanggal_transaksi as `Date`, l.nama as `Name`, concat(\"Rp.\",t.Total_harga) as `Amount`, l.email as `Email`, l.nomortelpon as `Contact`\r\nfrom transaksi t, login l\r\nwhere t.User_id = l.ID_user\r\norder by t.Tanggal_transaksi asc;";
                FormLogin.sqlcommand = new MySqlCommand(FormLogin.sqlquery, FormLogin.sqlconnect);
                FormLogin.mySqlDataAdapter = new MySqlDataAdapter(FormLogin.sqlcommand);
                FormLogin.mySqlDataAdapter.Fill(SalesHistory);
                dgv_saleshistory.DataSource = SalesHistory;
            }
            else
            {
                DataTable SalesHistory = new DataTable();
                FormLogin.sqlquery = "select t.Tanggal_transaksi as `Date`, l.nama as `Name`, concat(\"Rp.\",t.Total_harga) as `Amount`, l.email as `Email`, l.nomortelpon as `Contact`\r\nfrom transaksi t, login l\r\nwhere t.User_id = l.ID_user and l.nama = '" + search + "'\r\norder by t.Tanggal_transaksi asc;";
                FormLogin.sqlcommand = new MySqlCommand(FormLogin.sqlquery, FormLogin.sqlconnect);
                FormLogin.mySqlDataAdapter = new MySqlDataAdapter(FormLogin.sqlcommand);
                FormLogin.mySqlDataAdapter.Fill(SalesHistory);
                dgv_saleshistory.DataSource = SalesHistory;

            }

        }

        private void txtbox_search_Click(object sender, EventArgs e)
        {
            txtbox_search.Text = String.Empty;
        }

        private void txtbox_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                pictureBox2_Click(this, new EventArgs());
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Manage_Goods_Main_Menu manage_Goods_Main_Menu = new Manage_Goods_Main_Menu();
            manage_Goods_Main_Menu.Show();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            this.Close();
            Raw_material raw_Material = new Raw_material();
            raw_Material.Show();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            this.Close();
            StockOpnameMenu stockOpnameMenu = new StockOpnameMenu();
            stockOpnameMenu.Show();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            this.Close();
            BalanceSheet balanceSheet = new BalanceSheet();
            balanceSheet.Show();
        }
    }
}
