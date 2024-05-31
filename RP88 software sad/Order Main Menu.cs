using Log_in_roda_putar;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Guna.UI2.WinForms.Suite.Descriptions;

namespace MainMenu_Roda_putar_88
{
    public partial class Order_Main_Menu : Form
    {

        public static int nominal;
        public static int jumlahkopilatte; //labelq1
        public static int jumlahpouch;      //labelq3
        public static int jumlahdukuh;      //labelq4

        public static int hargalatte;
        public static int hargapouchh;
        public static int hargadukuh;

        public static int sqlhargalatte;
        public static int sqlhargapouchh;
        public static int sqlhargadukuh;

        public bool P1 = false;
        public bool p2 = false;
        public bool p3 = false;
        public static int latteterjual;
        public static int pouchterjual;
        public static int dukuhterjual;
        public static int jumlahRP;

        public static int jumlahstockcelup;
        public static int jumlahstockpouch;

        public static int idtrans;
       
        //DateTime dt = new DateTime();
        public string dt = DateTime.Now.ToString("yyyy-MM-dd");

        

        public Order_Main_Menu()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
            FormMainMenu formMainMenu = new FormMainMenu();
            formMainMenu.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Products_Main_Menu products_Main_Menu = new Products_Main_Menu();
            products_Main_Menu.Show();
        }

        private void Order_Main_Menu_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            //dgvcart.Columns.Add("Namaprod", "hargaprod");
            //dgvcart.Columns.Add();

            DataTable latepcsavail = new DataTable();
            FormLogin.sqlquery = "select  stock as STOCK\r\nfrom produk\r\nwhere ID_Produk = 1 or ID_Produk = 2 or ID_Produk = 3;";
            FormLogin.sqlcommand = new MySqlCommand(FormLogin.sqlquery, FormLogin.sqlconnect);
            FormLogin.mySqlDataAdapter = new MySqlDataAdapter(FormLogin.sqlcommand);
            FormLogin.mySqlDataAdapter.Fill(latepcsavail);

            DataTable harga = new DataTable();
            FormLogin.sqlquery = "select Harga_jual\r\nfrom produk;";
            FormLogin.sqlcommand = new MySqlCommand(FormLogin.sqlquery, FormLogin.sqlconnect);
            FormLogin.mySqlDataAdapter = new MySqlDataAdapter(FormLogin.sqlcommand);
            FormLogin.mySqlDataAdapter.Fill(harga);

            DataTable hargadisplay = new DataTable();
            FormLogin.sqlquery = "select concat(\"Rp. \", Harga_jual, \"/Pcs\") as `harga`\r\nfrom produk;";
            FormLogin.sqlcommand = new MySqlCommand(FormLogin.sqlquery, FormLogin.sqlconnect);
            FormLogin.mySqlDataAdapter = new MySqlDataAdapter(FormLogin.sqlcommand);
            FormLogin.mySqlDataAdapter.Fill(hargadisplay);


            label6.Text = hargadisplay.Rows[0][0].ToString();
            label7.Text = hargadisplay.Rows[1][0].ToString();
            label8.Text = hargadisplay.Rows[2][0].ToString();


            sqlhargalatte = Convert.ToInt32(harga.Rows[0][0]);
            sqlhargapouchh = Convert.ToInt32(harga.Rows[1][0]);
            sqlhargadukuh = Convert.ToInt32(harga.Rows[2][0]);

            //kopilatelabelavail.Text = latepcsavail.Rows[0][0].ToString();
            lblstockpouch.Text = latepcsavail.Rows[1][0].ToString() + " Pcs Available";
            lblstock_celup.Text = latepcsavail.Rows[2][0].ToString() + " Pcs Available";

            cmbbx_tipepembelian.Items.Add("Qris");
            cmbbx_tipepembelian.Items.Add("Transfer");
            cmbbx_tipepembelian.Items.Add("Cash");

            jumlahstockpouch = Convert.ToInt32(latepcsavail.Rows[1][0].ToString());
            jumlahstockcelup = Convert.ToInt32(latepcsavail.Rows[2][0].ToString());

            if (jumlahstockpouch == 0)
            {
                MessageBox.Show("Stock Pouch Bubuk Habis");
                guna2CircleButton4.Enabled = false;
            }
            else if (jumlahstockcelup == 0)
            {
                MessageBox.Show("Stock Celup Dukuh Habis");
                guna2CircleButton6.Enabled = false;
            }
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e) //+ button kopi latte
        {
            nominal += sqlhargalatte;
            jumlahkopilatte += 1;
            labelquantkopilate.Text = jumlahkopilatte.ToString();
            rupiahsubtotal.Text = $"Rp. {nominal.ToString()}";
            hargalatte += sqlhargalatte;
            labelQ1.Text = "X "+jumlahkopilatte.ToString();
            labelH1.Text = "Rp. " + hargalatte.ToString();
            ///sdata.SetInfo("Rp. " + hargalatte.ToString());

            var kopilate = new Label
            {
                // Location = new Point(145 - 36, 113 - 21),
                //Location = new Point(panelcart.Controls.Count + 245),
                Location = new Point(panelcart.Controls.Count + 200, panelcart.Controls.Count * 60),
                Text = "Kopi Latte",
                AutoSize = true,
                BackColor = Color.FromArgb(252, 236, 221),
                ForeColor = Color.FromArgb(96, 45, 25),
                Font = new Font("Segoe UI", 14, FontStyle.Bold)

            };
            var hargakopilate = new Label
            {
                //Location = new Point(145 - 36, 151 - 21),
                Location = new Point(panelcart.Controls.Count + 200, kopilate.Bottom + 8),
                Text = $"Rp. {hargalatte.ToString()}", 
                AutoSize = true,
                BackColor = Color.FromArgb(252, 236, 221),
                ForeColor = Color.FromArgb(96, 45, 25),
                Font = new Font("Segoe UI", 14, FontStyle.Bold)

            };

            var gambarlatte = new PictureBox
            {
                Size = new Size(150, 150),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = pictureBox3.Image,
            };
            gambarlatte.Location = new Point(35, panelcart.Controls.Count * 60);

            if (jumlahkopilatte > 1 )
            {
                
            }
            else
            {
                panelPERTAMA.Visible = true;
                pictureBox5.Image = pictureBox3.Image;
                labelPPertama.Text = "Kopi Latte";
                labelH1.Text = $"Rp. {hargalatte.ToString()}";
                labelQ1.Text = $"X {jumlahkopilatte.ToString()}";
                //panelcart.Controls.Add(kopilate);
                //panelcart.Controls.Add(hargakopilate);
                //panelcart.Controls.Add(gambarlatte);

            }
            

        }
        private void guna2CircleButton2_Click(object sender, EventArgs e) //- button kopi latte
        {
            

            var kopilate = new Label
            {
                // Location = new Point(145 - 36, 113 - 21),
                //Location = new Point(panelcart.Controls.Count + 245),
                Location = new Point(150, panelcart.Controls.Count * 60),
                Text = "Kopi Latte",
                AutoSize = true,
                BackColor = Color.FromArgb(252, 236, 221),
                ForeColor = Color.FromArgb(96, 45, 25),
                Font = new Font("Segoe UI", 12, FontStyle.Bold)

            };
            var hargakopilate = new Label
            {
                //Location = new Point(145 - 36, 151 - 21),
                Location = new Point(150, kopilate.Bottom + 8),
                Text = $"Rp. {hargalatte.ToString()}",
                AutoSize = true,
                BackColor = Color.FromArgb(252, 236, 221),
                ForeColor = Color.FromArgb(96, 45, 25),
                Font = new Font("Segoe UI", 12, FontStyle.Bold)

            };

            var gambarlatte = new PictureBox
            {
                Size = new Size(100, 100),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = pictureBox3.Image,
            };
            gambarlatte.Location = new Point(35, panelcart.Controls.Count * 60);

            if (jumlahkopilatte < 1)
            {
                panelPERTAMA.Controls.Clear();
                ///panelcart.Controls.Remove(kopilate);
                //panelcart.Controls.Remove(gambarlatte);
                ///panelcart.Controls.Remove(hargakopilate);
            }
            else
            {
                nominal -= sqlhargalatte;
                jumlahkopilatte -= 1;
                labelquantkopilate.Text = jumlahkopilatte.ToString();
                rupiahsubtotal.Text = $"Rp. {nominal.ToString()}";
                hargalatte -= sqlhargalatte;
                labelQ1.Text = "X " + jumlahkopilatte.ToString();
                labelH1.Text = "Rp. " + hargalatte.ToString();
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2CircleButton4_Click(object sender, EventArgs e) //+ button pouch
        {
            nominal += sqlhargapouchh;
            jumlahpouch += 1;
            labelquantpouch.Text = jumlahpouch.ToString();
            rupiahsubtotal.Text = $"Rp. {nominal.ToString()}";
            hargapouchh += sqlhargapouchh;


            labelQ3.Text = "X " + jumlahpouch.ToString();
            labelH2.Text = "Rp. " + hargapouchh.ToString();
            
            if(Convert.ToInt32(labelquantpouch.Text) == jumlahstockpouch)
            {
                MessageBox.Show("Stock Max");
                guna2CircleButton4.Enabled = false;
            }
            else
            {
                var pouch = new Label
                {
                    // Location = new Point(145 - 36, 223 - 21),
                    Location = new Point(panelcart.Controls.Count + 200, panelcart.Controls.Count * 60),
                    Text = "Pouch Bubuk",
                    AutoSize = true,
                    BackColor = Color.FromArgb(252, 236, 221),
                    ForeColor = Color.FromArgb(96, 45, 25),
                    Font = new Font("Segoe UI", 14, FontStyle.Bold)

                };
                var hargapouch = new Label
                {
                    //Location = new Point(145 - 36, 261 - 21),
                    Location = new Point(panelcart.Controls.Count + 200, pouch.Bottom + 8),
                    Text = $"Rp. {hargapouchh.ToString()}",
                    AutoSize = true,
                    BackColor = Color.FromArgb(252, 236, 221),
                    ForeColor = Color.FromArgb(96, 45, 25),
                    Font = new Font("Segoe UI", 14, FontStyle.Bold)

                };
                var gambarpouch = new PictureBox
                {
                    Size = new Size(150, 150),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Image = pictureBox2.Image,
                };
                gambarpouch.Location = new Point(35, panelcart.Controls.Count * 60);

                if (jumlahpouch > 1)
                {

                }
                else
                {
                    panelKedua.Visible = true;
                    pictureBox6.Image = pictureBox2.Image;
                    labelPKedua.Text = "Pouch Bubuk";
                    labelH2.Text = $"Rp. {hargapouchh.ToString()}";
                    labelQ3.Text = $"X {jumlahpouch.ToString()}";

                    // panelcart.Controls.Add(pouch);
                    //panelcart.Controls.Add(hargapouch);
                    // panelcart.Controls.Add(gambarpouch);
                }
            }




        }

        private void guna2CircleButton3_Click(object sender, EventArgs e) //- button pouch
        {

            if (Convert.ToInt32(labelquantpouch.Text) <= jumlahstockpouch)
            {
                guna2CircleButton4.Enabled = true;
            }

            var pouch = new Label
            {
                // Location = new Point(145 - 36, 223 - 21),
                Location = new Point(panelcart.Controls.Count + 200, panelcart.Controls.Count * 60),
                Text = "Pouch Bubuk",
                AutoSize = true,
                BackColor = Color.FromArgb(252, 236, 221),
                ForeColor = Color.FromArgb(96, 45, 25),
                Font = new Font("Segoe UI", 14, FontStyle.Bold)

            };
            var hargapouch = new Label
            {
                //Location = new Point(145 - 36, 261 - 21),
                Location = new Point(panelcart.Controls.Count + 200, pouch.Bottom + 8),
                Text = $"Rp. {hargapouchh.ToString()}",
                AutoSize = true,
                BackColor = Color.FromArgb(252, 236, 221),
                ForeColor = Color.FromArgb(96, 45, 25),
                Font = new Font("Segoe UI", 14, FontStyle.Bold)

            };
            var gambarpouch = new PictureBox
            {
                Size = new Size(150, 150),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = pictureBox2.Image,
            };
            gambarpouch.Location = new Point(35, panelcart.Controls.Count * 60);
            if (jumlahpouch < 1)
            {
                panelKedua.Controls.Clear();
               // panelcart.Controls.Clear();
            }
            else
            {
                nominal -= sqlhargapouchh;
                jumlahpouch -= 1;
                labelquantpouch.Text = jumlahpouch.ToString();
                rupiahsubtotal.Text = $"Rp. {nominal.ToString()}";
                hargapouchh -= sqlhargapouchh;
                labelQ3.Text = "X " + jumlahpouch.ToString();
                labelH2.Text = "Rp. " + hargapouchh.ToString();
            }
        }

        private void guna2CircleButton6_Click(object sender, EventArgs e) //+ button celup
        {
            nominal += sqlhargadukuh;
            jumlahdukuh += 1;
            labelquantcelup.Text = jumlahdukuh.ToString();
            rupiahsubtotal.Text = $"Rp. {nominal.ToString()}";
            hargadukuh += sqlhargadukuh;

            labelQ4.Text = "X " + jumlahdukuh.ToString();
            labelH3.Text = "Rp. " + hargadukuh.ToString();

            if (Convert.ToInt32(labelquantcelup.Text) == jumlahstockcelup)
            {
                MessageBox.Show("Stock Max");
                guna2CircleButton6.Enabled = false;
            }
            else
            {
                var celup = new Label
                {
                    Location = new Point(panelcart.Controls.Count + 200, panelcart.Controls.Count * 60),
                    Text = "Celup Dukuh",
                    AutoSize = true,
                    BackColor = Color.FromArgb(252, 236, 221),
                    ForeColor = Color.FromArgb(96, 45, 25),
                    Font = new Font("Segoe UI", 14, FontStyle.Bold)

                };
                var hargacelup = new Label
                {
                    Location = new Point(panelcart.Controls.Count + 200, celup.Bottom + 8),
                    Text = $"Rp. {hargadukuh.ToString()}",
                    AutoSize = true,
                    BackColor = Color.FromArgb(252, 236, 221),
                    ForeColor = Color.FromArgb(96, 45, 25),
                    Font = new Font("Segoe UI", 14, FontStyle.Bold)

                };
                var gambardukuh = new PictureBox
                {
                    Size = new Size(150, 150),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Image = pictureBox4.Image,
                };
                gambardukuh.Location = new Point(35, panelcart.Controls.Count * 60);

                if (jumlahdukuh > 1)
                {

                }
                else
                {
                    panelKETIGA.Visible = true;
                    pictureBox7.Image = pictureBox4.Image;
                    labelPKetiga.Text = "Celup Dukuh";
                    labelH3.Text = $"Rp. {hargadukuh.ToString()}";
                    labelQ4.Text = $"X {jumlahdukuh.ToString()}";

                    //  panelcart.Controls.Add(celup);
                    //panelcart.Controls.Add(hargacelup);
                    ///panelcart.Controls.Add(gambardukuh);
                }
            }
            
        }

        private void guna2CircleButton5_Click(object sender, EventArgs e) //- button celup
        {
            if (Convert.ToInt32(labelquantcelup.Text) <= jumlahstockcelup)
            {
                guna2CircleButton6.Enabled = true;
            }
            var celup = new Label
            {
                Location = new Point(panelcart.Controls.Count + 200, panelcart.Controls.Count * 60),
                Text = "Celup Dukuh",
                AutoSize = true,
                BackColor = Color.FromArgb(252, 236, 221),
                ForeColor = Color.FromArgb(96, 45, 25),
                Font = new Font("Segoe UI", 14, FontStyle.Bold)

            };
            var hargacelup = new Label
            {
                Location = new Point(panelcart.Controls.Count + 200, celup.Bottom + 8),
                Text = $"Rp. {hargadukuh.ToString()}",
                AutoSize = true,
                BackColor = Color.FromArgb(252, 236, 221),
                ForeColor = Color.FromArgb(96, 45, 25),
                Font = new Font("Segoe UI", 14, FontStyle.Bold)

            };
            var gambardukuh = new PictureBox
            {
                Size = new Size(150, 150),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = pictureBox4.Image,
            };
            gambardukuh.Location = new Point(35, panelcart.Controls.Count * 60);
            if (jumlahdukuh < 1)
            {
                panelcart.Controls.Remove(celup);
                panelcart.Controls.Remove(hargacelup);
                panelcart.Controls.Remove(gambardukuh);
                panelcart.Controls.Clear();

                panelKETIGA.Controls.Clear();
            }
            else
            {
                nominal -= sqlhargadukuh;
                jumlahdukuh -= 1;
                labelquantcelup.Text = jumlahdukuh.ToString();
                rupiahsubtotal.Text = $"Rp. {nominal.ToString()}";
                hargadukuh -= sqlhargadukuh;

                labelQ4.Text = "X " + jumlahdukuh.ToString();
                labelH3.Text = "Rp. " + hargadukuh.ToString();
            }
      
        }

        private void label9_Click(object sender, EventArgs e)
        {

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

        private void guna2Button7_Click(object sender, EventArgs e)
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

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            this.Close();
            BalanceSheet balanceSheet = new BalanceSheet();
            balanceSheet.Show();
        }

        private void panelPERTAMA_Paint(object sender, PaintEventArgs e)
        {

        }

        private void OrderNow_Click(object sender, EventArgs e)
        {
            //pakai lateterjual, dukuh terjual, pouch terjual untuk pengurangan stok di tabel produk.
            //masukan juga di detail trans dengan idnya, trans juga masukin, jumlahrp untuk total trans

            //String.Format("{0:MM/dd/yyyy}", dt);
            latteterjual += jumlahkopilatte;
            dukuhterjual += jumlahdukuh;
            pouchterjual += jumlahpouch;
            jumlahRP += nominal;
            /*
            BalanceSheet.kopilatte = latteterjual.ToString();
            BalanceSheet.pouch = pouchterjual.ToString();
            BalanceSheet.dukuh = dukuhterjual.ToString();
            BalanceSheet.nominal = jumlahRP.ToString();
            */
            nominal = 0;
            jumlahdukuh = 0;
            jumlahkopilatte = 0;
            jumlahpouch = 0;
            hargadukuh = 0;
            hargalatte = 0;
            hargapouchh = 0;
            rupiahsubtotal.Text = "Rp. " + nominal;
            labelquantkopilate.Text = jumlahkopilatte.ToString();
            labelquantpouch.Text = jumlahpouch.ToString();
            labelquantcelup.Text = jumlahdukuh.ToString();
            panelPERTAMA.Visible = false;
            panelKedua.Visible = false;
            panelKETIGA.Visible = false;

            if (cmbbx_tipepembelian.SelectedItem == null)
            {
                MessageBox.Show("fill all the required data");

                latteterjual = 0;
                dukuhterjual = 0;
                pouchterjual = 0;
                jumlahRP = 0;
            }
            else
            {


                DataTable inserttrans = new DataTable();
                FormLogin.sqlquery = "insert into `transaksi` (User_id, Tanggal_transaksi, Total_harga, Type_pembelian)\r\nvalues\r\n((SELECT ID_user FROM `login` WHERE nama = '" + FormLogin.username + "'), '" + dt + "', '" + jumlahRP + "', '" + cmbbx_tipepembelian.SelectedItem.ToString() + "');";
                FormLogin.sqlcommand = new MySqlCommand(FormLogin.sqlquery, FormLogin.sqlconnect);
                FormLogin.mySqlDataAdapter = new MySqlDataAdapter(FormLogin.sqlcommand);
                FormLogin.mySqlDataAdapter.Fill(inserttrans);

                DataTable getidtrans = new DataTable();
                FormLogin.sqlquery = "SELECT Transaksi_id\r\nFROM db_rodaputar88.transaksi\r\norder by 1 desc;";
                FormLogin.sqlcommand = new MySqlCommand(FormLogin.sqlquery, FormLogin.sqlconnect);
                FormLogin.mySqlDataAdapter = new MySqlDataAdapter(FormLogin.sqlcommand);
                FormLogin.mySqlDataAdapter.Fill(getidtrans);

                idtrans = Convert.ToInt32(getidtrans.Rows[0][0]);

                for (int i = 0; i < latteterjual; i++)
                {
                    dgvcart.Rows.Add(idtrans, "Kopi Latte", sqlhargalatte);
                }

                for (int j = 0; j < pouchterjual; j++)
                {
                    dgvcart.Rows.Add(idtrans, "Pouch Bubuk", sqlhargapouchh);
                }

                for (int k = 0; k < dukuhterjual; k++)
                {
                    dgvcart.Rows.Add(idtrans, "Celup Dukuh", sqlhargadukuh);
                }

                //DataTable dtcart = (DataTable)(dgvcart.DataSource);

                for (int i = 0; i < dgvcart.Rows.Count; i++)
                {

                    int id = Convert.ToInt32(dgvcart.Rows[i].Cells["Column1"].Value);       
                    string prodName = Convert.ToString(dgvcart.Rows[i].Cells["Column2"].Value);
                    int prodPrice = Convert.ToInt32(dgvcart.Rows[i].Cells["Column3"].Value);

                    
                    FormLogin.sqlquery = "insert into `detail transaksi` (Transaksi_id, Produk_id, Harga_satuan)\r\nvalues\r\n((SELECT Transaksi_id FROM transaksi WHERE Transaksi_id = '" + id + "'), (SELECT ID_Produk FROM produk WHERE namaproduk = '" + prodName + "'), '" + prodPrice + "');";
                    try
                    {
                        FormLogin.sqlconnect.Open();
                        FormLogin.sqlcommand = new MySqlCommand(FormLogin.sqlquery, FormLogin.sqlconnect);
                        FormLogin.mySqlDataReader = FormLogin.sqlcommand.ExecuteReader();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        FormLogin.sqlconnect.Close();
                    }
                    

                    //MessageBox.Show(i.ToString() + " " + id.ToString() + " " + prodName.ToString() + " " + prodPrice.ToString() + " ");
                }

                dgvcart.Rows.Clear();
                dgvcart.Refresh();


                DataTable updatestok = new DataTable();
                FormLogin.sqlquery = "UPDATE produk\r\nSET stock = CASE \r\n    WHEN namaproduk = 'Kopi Latte' THEN stock - '" + latteterjual + "'\r\n    WHEN namaproduk = 'Pouch Bubuk' THEN stock - '" + pouchterjual + "'\r\n    WHEN namaproduk = 'Celup Dukuh' THEN stock - '" + dukuhterjual + "'\r\n    ELSE stock\r\nEND\r\nWHERE namaproduk IN ('Kopi Latte', 'Pouch Bubuk','Celup Dukuh');";
                FormLogin.sqlcommand = new MySqlCommand(FormLogin.sqlquery, FormLogin.sqlconnect);
                FormLogin.mySqlDataAdapter = new MySqlDataAdapter(FormLogin.sqlcommand);
                FormLogin.mySqlDataAdapter.Fill(updatestok);

                //MessageBox.Show(latteterjual.ToString() + " Latte, " + dukuhterjual.ToString() + " Dukuh, " + pouchterjual.ToString() + " Pouch, " + jumlahRP.ToString() + " Subtotal. " + cmbbx_tipepembelian.SelectedItem.ToString() + " " + dt);




                latteterjual = 0;
                dukuhterjual = 0;
                pouchterjual = 0;
                jumlahRP = 0;
            }

        }

        private void label11_Click(object sender, EventArgs e)
        {
            this.Close();
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
        }

        private void kopilatelabelavail_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panelorder_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelquantpouch_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
