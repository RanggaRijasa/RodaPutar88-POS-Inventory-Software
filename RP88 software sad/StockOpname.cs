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
using static Guna.UI2.Native.WinApi;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MainMenu_Roda_putar_88
{
    public partial class StockOpnameMenu : Form
    {
        public StockOpnameMenu()
        {
            InitializeComponent();
        }

        public int difference = 0;
        public int stockwarehouse = 0;
        public int stocksystem = 0;
        public string valuecmbopname;
        public string reason;

        public string dt = DateTime.Now.ToString("yyyy-MM-dd");

        private void StockOpnameMenu_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            //txtbox_stocksystem.Text = "400";
            txtbox_stocksystem.ReadOnly = true;
            txtbox_stocksystem.Enabled = false;

            txtbox_diff.ReadOnly = true;
            txtbox_diff.Enabled = false;

            cmbbox_stockopname.SelectedItem = null;
            cmbbox_pilihjenisproduk.SelectedItem = null;

            cmbbox_pilihjenisproduk.Items.Add("Product");
            cmbbox_pilihjenisproduk.Items.Add("Raw Material");


            //cmbbox_stockopname.Items.Add("Kopi Latte");


        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            //btn main menu
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
            this.Close();
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

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            //btn balance sheet
            this.Close();
            BalanceSheet balanceSheet = new BalanceSheet();
            balanceSheet.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtbox_stocksystem_Enter(object sender, EventArgs e)
        {

        }

        private void txtbox_stockwarehouse_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtbox_diff_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btn_confirmstockopname_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbox_price.Text))
            {
                if (string.IsNullOrWhiteSpace(txtbox_stockwarehouse.Text) || string.IsNullOrWhiteSpace(txtbox_reason.Text) || cmbbox_stockopname.SelectedItem == null)
                {
                    MessageBox.Show("fill all the required data");
                }
                else
                {
                    valuecmbopname = cmbbox_stockopname.SelectedItem.ToString();
                    reason = txtbox_reason.Text;
                    stocksystem = Convert.ToInt32(txtbox_stocksystem.Text);
                    stockwarehouse = Convert.ToInt32(txtbox_stockwarehouse.Text);
                    DateTime now = DateTime.Now;

                    if (stocksystem > stockwarehouse)
                    {
                        difference = stocksystem - stockwarehouse;
                        txtbox_diff.Text = difference.ToString();
                    }
                    else if (stockwarehouse > stocksystem)
                    {
                        difference = stockwarehouse - stocksystem;
                        txtbox_diff.Text = difference.ToString();
                    }
                    else if (stockwarehouse == stocksystem)
                    {
                        difference = 0;
                        txtbox_diff.Text = difference.ToString();
                    }


                    DataTable inserttableopname = new DataTable();
                    FormLogin.sqlquery = "insert into `StokOpname` (Username,JenisBarang, TanggalWaktu_opnam, Stok_system, Stok_real, Diff, keterangan)\r\nvalues\r\n('" + FormLogin.username + "','" + valuecmbopname + "', '" + now + "', '" + stocksystem + "', '" + stockwarehouse + "', '" + difference + "', '" + reason + "');";
                    FormLogin.sqlcommand = new MySqlCommand(FormLogin.sqlquery, FormLogin.sqlconnect);
                    FormLogin.mySqlDataAdapter = new MySqlDataAdapter(FormLogin.sqlcommand);
                    FormLogin.mySqlDataAdapter.Fill(inserttableopname);

                    if (valuecmbopname == "Kopi Latte" || valuecmbopname == "Pouch Bubuk" || valuecmbopname == "Celup Dukuh")
                    {
                        DataTable updatestockproduk = new DataTable();
                        FormLogin.sqlquery = "UPDATE produk\r\nSET stock = '" + stockwarehouse + "'\r\nWHERE namaproduk = '" + valuecmbopname + "';";
                        FormLogin.sqlcommand = new MySqlCommand(FormLogin.sqlquery, FormLogin.sqlconnect);
                        FormLogin.mySqlDataAdapter = new MySqlDataAdapter(FormLogin.sqlcommand);
                        FormLogin.mySqlDataAdapter.Fill(updatestockproduk);

                        MessageBox.Show("Success");
                        //MessageBox.Show(FormLogin.username + " success " + cmbbox_stockopname.Text + " " + txtbox_reason.Text + " " + now + " yes");
                    }
                    else if (valuecmbopname == "biji kopi" || valuecmbopname == "pouch" || valuecmbopname == "box" || valuecmbopname == "cup")
                    {
                        DataTable updatestockbahanmentah = new DataTable();
                        FormLogin.sqlquery = "UPDATE bahanmentahgudang\r\nSET StockBahanMentah = '" + stockwarehouse + "'\r\nWHERE namaBahan = '" + valuecmbopname + "';";
                        FormLogin.sqlcommand = new MySqlCommand(FormLogin.sqlquery, FormLogin.sqlconnect);
                        FormLogin.mySqlDataAdapter = new MySqlDataAdapter(FormLogin.sqlcommand);
                        FormLogin.mySqlDataAdapter.Fill(updatestockbahanmentah);

                        MessageBox.Show("Success");

                        //MessageBox.Show(FormLogin.username + " success " + cmbbox_stockopname.Text + " " + txtbox_reason.Text + " " + now + " no");
                    }

                    txtbox_stocksystem.Clear();
                    txtbox_stockwarehouse.Clear();
                    txtbox_diff.Clear();
                    txtbox_reason.Clear();
                    txtbox_price.Clear();
                    //MessageBox.Show(FormLogin.username + " success " + cmbbox_stockopname.Text + " " + txtbox_reason.Text + " " + now);
                }
            }
            else //kalau isi txtbox price
            {
                if (string.IsNullOrWhiteSpace(txtbox_stockwarehouse.Text) || string.IsNullOrWhiteSpace(txtbox_reason.Text) || cmbbox_stockopname.SelectedItem == null)
                {
                    MessageBox.Show("fill all the required data");
                }
                else
                {
                    valuecmbopname = cmbbox_stockopname.SelectedItem.ToString();
                    reason = txtbox_reason.Text;
                    stocksystem = Convert.ToInt32(txtbox_stocksystem.Text);
                    stockwarehouse = Convert.ToInt32(txtbox_stockwarehouse.Text);
                    DateTime now = DateTime.Now;

                    if (stocksystem > stockwarehouse)
                    {
                        difference = stocksystem - stockwarehouse;
                        txtbox_diff.Text = difference.ToString();
                    }
                    else if (stockwarehouse > stocksystem)
                    {
                        difference = stockwarehouse - stocksystem;
                        txtbox_diff.Text = difference.ToString();
                    }
                    else if (stockwarehouse == stocksystem)
                    {
                        difference = 0;
                        txtbox_diff.Text = difference.ToString();
                    }


                    DataTable inserttableopname = new DataTable();
                    FormLogin.sqlquery = "insert into `StokOpname` (Username,JenisBarang, TanggalWaktu_opnam, Stok_system, Stok_real, Diff, keterangan)\r\nvalues\r\n('" + FormLogin.username + "','" + valuecmbopname + "', '" + now + "', '" + stocksystem + "', '" + stockwarehouse + "', '" + difference + "', '" + reason + "');";
                    FormLogin.sqlcommand = new MySqlCommand(FormLogin.sqlquery, FormLogin.sqlconnect);
                    FormLogin.mySqlDataAdapter = new MySqlDataAdapter(FormLogin.sqlcommand);
                    FormLogin.mySqlDataAdapter.Fill(inserttableopname);

                    DataTable inserttablebelibahanmentah = new DataTable();
                    FormLogin.sqlquery = "insert into `PembelianBahanMentah`(namabahan, hargabeli, stock, tanggalproduksi, PembelianatauPengunaan)\r\nvalues\r\n('" + cmbbox_stockopname.SelectedItem.ToString() + "', '" + Convert.ToInt32(txtbox_price.Text) + "','" + Convert.ToInt32(txtbox_diff.Text) + "','" + dt + "',\"Available\");";
                    FormLogin.sqlcommand = new MySqlCommand(FormLogin.sqlquery, FormLogin.sqlconnect);
                    FormLogin.mySqlDataAdapter = new MySqlDataAdapter(FormLogin.sqlcommand);
                    FormLogin.mySqlDataAdapter.Fill(inserttablebelibahanmentah);



                    if (valuecmbopname == "Kopi Latte" || valuecmbopname == "Pouch Bubuk" || valuecmbopname == "Celup Dukuh")
                    {
                        DataTable updatestockproduk = new DataTable();
                        FormLogin.sqlquery = "UPDATE produk\r\nSET stock = '" + stockwarehouse + "'\r\nWHERE namaproduk = '" + valuecmbopname + "';";
                        FormLogin.sqlcommand = new MySqlCommand(FormLogin.sqlquery, FormLogin.sqlconnect);
                        FormLogin.mySqlDataAdapter = new MySqlDataAdapter(FormLogin.sqlcommand);
                        FormLogin.mySqlDataAdapter.Fill(updatestockproduk);

                        MessageBox.Show("Success");
                        //MessageBox.Show(FormLogin.username + " success " + cmbbox_stockopname.Text + " " + txtbox_reason.Text + " " + now + " yes");
                    }
                    else if (valuecmbopname == "biji kopi" || valuecmbopname == "pouch" || valuecmbopname == "box" || valuecmbopname == "cup")
                    {
                        DataTable updatestockbahanmentah = new DataTable();
                        FormLogin.sqlquery = "UPDATE bahanmentahgudang\r\nSET StockBahanMentah = '" + stockwarehouse + "'\r\nWHERE namaBahan = '" + valuecmbopname + "';";
                        FormLogin.sqlcommand = new MySqlCommand(FormLogin.sqlquery, FormLogin.sqlconnect);
                        FormLogin.mySqlDataAdapter = new MySqlDataAdapter(FormLogin.sqlcommand);
                        FormLogin.mySqlDataAdapter.Fill(updatestockbahanmentah);

                        MessageBox.Show("Success");

                        //MessageBox.Show(FormLogin.username + " success " + cmbbox_stockopname.Text + " " + txtbox_reason.Text + " " + now + " no");
                    }

                    txtbox_stocksystem.Clear();
                    txtbox_stockwarehouse.Clear();
                    txtbox_diff.Clear();
                    txtbox_reason.Clear();
                    txtbox_price.Clear();
                    //MessageBox.Show(FormLogin.username + " success " + cmbbox_stockopname.Text + " " + txtbox_reason.Text + " " + now);
                }
            }
            

           
        }

        private void cmbbox_stockopname_SelectedIndexChanged(object sender, EventArgs e)
        {
            valuecmbopname = cmbbox_stockopname.SelectedItem.ToString();

            DataTable valuestockinvent = new DataTable();
            FormLogin.sqlquery = "select p.stock\r\nfrom (SELECT namaproduk AS nama, stock\r\nFROM produk\r\nUNION ALL\r\nSELECT namabahan AS nama, SUM(stock) AS total_stock\r\nFROM PembelianBahanMentah\r\nWHERE PembelianatauPengunaan = 'Available'\r\nGROUP BY namabahan) p\r\nwhere nama = '" + valuecmbopname + "';";
            FormLogin.sqlcommand = new MySqlCommand(FormLogin.sqlquery, FormLogin.sqlconnect);
            FormLogin.mySqlDataAdapter = new MySqlDataAdapter(FormLogin.sqlcommand);
            FormLogin.mySqlDataAdapter.Fill(valuestockinvent);

            txtbox_stocksystem.Text = valuestockinvent.Rows[0][0].ToString();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            this.Close();
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
        }

        private void cmbbox_pilihjenisproduk_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbbox_pilihjenisproduk.SelectedItem == "Product")
            {
                labelprice.Visible = false;
                labelnoteprice.Visible = false;
                txtbox_price.Visible = false;

                cmbbox_stockopname.Items.Clear();
                cmbbox_stockopname.Items.Add("Pouch Bubuk");
                cmbbox_stockopname.Items.Add("Celup Dukuh");
            }
            else if (cmbbox_pilihjenisproduk.SelectedItem == "Raw Material")
            {
                labelprice.Visible = true;
                labelnoteprice.Visible = true;
                txtbox_price.Visible = true;

                cmbbox_stockopname.Items.Clear();
                cmbbox_stockopname.Items.Add("biji kopi");
                cmbbox_stockopname.Items.Add("pouch");
                cmbbox_stockopname.Items.Add("box");
                cmbbox_stockopname.Items.Add("cup");
            }
        }
    }
}
