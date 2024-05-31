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
    public partial class Raw_material : Form
    {
        public Raw_material()
        {
            InitializeComponent();
        }

        private void Raw_material_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            
            DataTable amountraw = new DataTable();
            FormLogin.sqlquery = "select StockBahanMentah\r\nfrom bahanmentahgudang;";
            FormLogin.sqlcommand = new MySqlCommand(FormLogin.sqlquery, FormLogin.sqlconnect);
            FormLogin.mySqlDataAdapter = new MySqlDataAdapter(FormLogin.sqlcommand);
            FormLogin.mySqlDataAdapter.Fill(amountraw);

            lblamountkardus.Text = amountraw.Rows[2][0].ToString() + " Pcs";
            lblamountcups.Text = amountraw.Rows[3][0].ToString() + " Pcs";
            lblamountbeans.Text = amountraw.Rows[0][0].ToString() + " Kg";
            lblamountpouch.Text = amountraw.Rows[1][0].ToString() + " Pcs";

            if (Convert.ToInt32(amountraw.Rows[0][0].ToString()) <= Products_Main_Menu.lowstokalert || Convert.ToInt32(amountraw.Rows[1][0].ToString()) <= Products_Main_Menu.lowstokalert || Convert.ToInt32(amountraw.Rows[2][0].ToString()) <= Products_Main_Menu.lowstokalert || Convert.ToInt32(amountraw.Rows[3][0].ToString()) <= Products_Main_Menu.lowstokalert)
            {
                MessageBox.Show("Stok sudah menipis harap, diisi kembali", "Low Stock Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            //btn raw material
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            //btn sales

            this.Close();
            History_Mainmenu history_Mainmenu = new History_Mainmenu();
            history_Mainmenu.Show();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            //btn purchase

            this.Close();
            Manage_Goods_Main_Menu manage_Goods_Main_Menu = new Manage_Goods_Main_Menu();
            manage_Goods_Main_Menu.Show();

        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            //btn balance sheet
            this.Close();
            BalanceSheet balanceSheet = new BalanceSheet();
            balanceSheet.Show();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            //btn stock opname
            this.Close();
            StockOpnameMenu stockOpnameMenu = new StockOpnameMenu();
            stockOpnameMenu.Show();
        }

        private void dgv_purchasehistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {
            this.Close();
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
        }
    }
}
