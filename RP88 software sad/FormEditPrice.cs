using Log_in_roda_putar;
using MainMenu_Roda_putar_88;
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

namespace RP88_software_sad
{
    public partial class FormEditPrice : Form
    {
        public FormEditPrice()
        {
            InitializeComponent();
        }

      

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormEditPrice_Load(object sender, EventArgs e)
        {
            DataTable namaproduk = new DataTable();
            FormLogin.sqlquery = "select namaproduk as `produk`\r\nfrom produk;";
            FormLogin.sqlcommand = new MySqlCommand(FormLogin.sqlquery, FormLogin.sqlconnect);
            FormLogin.mySqlDataAdapter = new MySqlDataAdapter(FormLogin.sqlcommand);
            FormLogin.mySqlDataAdapter.Fill(namaproduk);
            combobox_products.DataSource = namaproduk;
            combobox_products.DisplayMember = "produk";
            combobox_products.ValueMember = "produk";
        }

        private void btn_confirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_changeprice.Text) ||  combobox_products.SelectedItem == null)
            {
                MessageBox.Show("fill all the required data");
            }
            else
            {
                string namaprod = combobox_products.Text;
                int harga = Convert.ToInt32(txt_changeprice.Text);

                DataTable updateprice = new DataTable();
                FormLogin.sqlquery = "UPDATE produk\r\nSET Harga_jual = '" + harga + "'\r\nWHERE namaproduk = '" + namaprod + "';";
                FormLogin.sqlcommand = new MySqlCommand(FormLogin.sqlquery, FormLogin.sqlconnect);
                FormLogin.mySqlDataAdapter = new MySqlDataAdapter(FormLogin.sqlcommand);
                FormLogin.mySqlDataAdapter.Fill(updateprice);
            }

            
            //string harga = txt_changeprice.Text;

            /*
            Products_Main_Menu products_Main_Menu = new Products_Main_Menu();

            string hargalate = products_Main_Menu.kopilatelabelavail.Text;
            string hargapouch = products_Main_Menu.pouchlabelavail.Text;
            string hargacelup= products_Main_Menu.celuplabelavail.Text;
            */

            

            /*
            DataTable hargalabel = new DataTable();
            FormLogin.sqlquery = "select concat(\"Rp. \", Harga_jual, \"/Pcs\") as `harga`\r\nfrom produk;";
            FormLogin.sqlcommand = new MySqlCommand(FormLogin.sqlquery, FormLogin.sqlconnect);
            FormLogin.mySqlDataAdapter = new MySqlDataAdapter(FormLogin.sqlcommand);
            FormLogin.mySqlDataAdapter.Fill(hargalabel);


            hargalate = hargalabel.Rows[0][0].ToString();
            hargapouch = hargalabel.Rows[1][0].ToString();
            hargacelup = hargalabel.Rows[2][0].ToString();
            */
        }

        private void txt_changeprice_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_changeprice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
