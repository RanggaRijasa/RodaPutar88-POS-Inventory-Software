using Log_in_roda_putar;
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
    public partial class FormMainMenu : Form
    {
        public FormMainMenu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Order_Main_Menu ordermenu = new Order_Main_Menu();
            ordermenu.Show();
            
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Products_Main_Menu products_Main_Menu = new Products_Main_Menu();
            products_Main_Menu.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.Close();
            History_Mainmenu history_Mainmenu = new History_Mainmenu();
            history_Mainmenu.Show();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Manage_Goods_Main_Menu manage_Goods_Main_Menu = new Manage_Goods_Main_Menu();
            manage_Goods_Main_Menu.Show();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            this.Close();
            Raw_material raw_Material = new Raw_material();
            raw_Material.Show();

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

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
        }
    }
}
