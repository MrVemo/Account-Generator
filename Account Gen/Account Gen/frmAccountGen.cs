using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using SaveRestoreSkinSettings;
using System.Data.Odbc;
using System.IO;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Account_Gen
{
    public partial class frmAccountGen : DevExpress.XtraEditors.XtraForm
    {
        public frmAccountGen()
        {
            InitializeComponent();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Visual Studio 2013 Dark");
        }

        string cs = @"Data Source=134.255.234.181;Integrated Security=False;User ID=sa;Password=]WAw[7Kv|iMmRq!f5f;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Gebe dein Username ein", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
                xtraTabPage2.PageVisible = false;
                groupControl8.Visible = false;
                xtraTabPage3.PageVisible = false;
                return;
            }
            if (txtPassword.Text == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Gebe dein Passwort ein", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                xtraTabPage2.PageVisible = false;
                groupControl8.Visible = false;
                xtraTabPage3.PageVisible = false;
                return;
            }
            try
            {
                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand("SELECT [Username],[Passwort],[HWID] FROM [Login].[dbo].[Accounts] WHERE Username = @Username AND Passwort = @Passwort AND HWID = @HWID", con);

                SqlParameter uName = new SqlParameter("@Username", SqlDbType.VarChar);
                SqlParameter uPassword = new SqlParameter("@Passwort", SqlDbType.VarChar);
                SqlParameter uHWID = new SqlParameter("@HWID", SqlDbType.VarChar);

                uName.Value = txtUsername.Text;
                uPassword.Value = txtPassword.Text;
                uHWID.Value = txtHWID.Text;

                cmd.Parameters.Add(uName);
                cmd.Parameters.Add(uPassword);
                cmd.Parameters.Add(uHWID);

                con.Open();

                SqlDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                if (myReader.Read() == true)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Danke für dein Einkauf bei Mr. Nobody", "Erfolgreiche Anmeldung", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    groupControl8.Visible = true;
                    xtraTabPage2.PageVisible = true;
                    panelControl1.Visible = false;
                    xtraTabPage3.PageVisible = true;
                    this.Text = "Account Generator by Mr. Nobody v1.0.0.2 - " + txtUsername.Text;
                    NewsTicker.Start();
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Login Fehlgeschlagen... Versuche es später noch einmal!", "Login Fehlgeschlagen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    xtraTabPage2.PageVisible = false;
                    groupControl8.Visible = false;
                    xtraTabPage3.PageVisible = false;
                    base.Close();
                    ;
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Dispose();
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Fehlermeldung", MessageBoxButtons.OK, MessageBoxIcon.Error);
                xtraTabPage2.PageVisible = false;
                groupControl8.Visible = false;
                xtraTabPage3.PageVisible = false;
            }
        }

        private void frmAccountGen_Load(object sender, EventArgs e)
        {
            txtHWID.Text = (HWID.Method_1(HWID.Method_0(HWID.Generate_1() + HWID.Generate_2())));
            panelControl1.Visible = true;
            groupControl8.Visible = false;
            loadtheme();
            comboBoxEdit1.EditValue = DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName;
            foreach (DevExpress.Skins.SkinContainer cnt in DevExpress.Skins.SkinManager.Default.Skins)
            {

                comboBoxEdit1.Properties.Items.Add(cnt.SkinName);
            }
            DevExpress.UserSkins.BonusSkins.Register();
            //xtraTabPage2.PageVisible = true;
            xtraTabPage2.PageVisible = false;
            groupControl8.Visible = false;
            xtraTabPage3.PageVisible = false;
            NewsTicker.Start();
            if (System.IO.File.Exists("AuthCode.txt"))
            {
                System.IO.StreamReader reader = new System.IO.StreamReader("AuthCode.txt");
                txtUsername.Text = reader.ReadLine();
                txtPassword.Text = reader.ReadLine();
                reader.Close();
            }
        }

        private void frmAccountGen_FormClosed(object sender, FormClosedEventArgs e)
        {
            savetheme();
        }

        private void savetheme()
        {
            LookAndFeelSettings.Save("Theme");
        }

        private void loadtheme()
        {
            LookAndFeelSettings.Load("Theme");
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = comboBoxEdit1.Text;
        }

        private void btnNetflix_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string strSQL = "SELECT TOP 1 [Netflix] FROM [Login].[dbo].[Netflix] ORDER BY NEWID()";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            con.Open();

            SqlDataReader myReader = cmd.ExecuteReader();

            while (myReader.Read())
            {
                txtNetflix.Text = (myReader["Netflix"].ToString());
            }
            myReader.Close();
            con.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.facebook.com/MrNobodyModShop/");
        }

        private void facebookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.facebook.com/MrNobodyModShop/");
        }

        private void skypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.XtraMessageBox.Show("tazzy.modshop aka Mr. Nobody", "Kontakt", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSpotify_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string strSQL = "SELECT TOP 1 [Spotify] FROM [Login].[dbo].[Spotify] ORDER BY NEWID()";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            con.Open();
            SqlDataReader myReader = cmd.ExecuteReader();

            while (myReader.Read())
            {
                txtSpotify.Text = (myReader["Spotify"].ToString());
            }
            myReader.Close();
            con.Close();
        }

        private void btnSpotifyWEB_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string strSQL = "SELECT TOP 1 [Windows7] FROM [Login].[dbo].[Windows7] ORDER BY NEWID()";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            con.Open();
            SqlDataReader myReader = cmd.ExecuteReader();

            while (myReader.Read())
            {
                txtSpotifyWEB.Text = (myReader["Windows7"].ToString());
            }
            myReader.Close();
            con.Close();
        }

        private void btnBrazzers_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string strSQL = "SELECT TOP 1 [Brazzers] FROM [Login].[dbo].[Brazzers] ORDER BY NEWID()";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            con.Open();
            SqlDataReader myReader = cmd.ExecuteReader();

            while (myReader.Read())
            {
                txtBrazzers.Text = (myReader["Brazzers"].ToString());
            }
            myReader.Close();
            con.Close();
        }

        private void btnWWE_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string strSQL = "SELECT TOP 1 [SpotifyWebLogin] FROM [Login].[dbo].[SpotWEB] ORDER BY NEWID()";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            con.Open();
            SqlDataReader myReader = cmd.ExecuteReader();

            while (myReader.Read())
            {
                txtWWE.Text = (myReader["SpotifyWebLogin"].ToString());
            }
            myReader.Close();
            con.Close();
        }

        private void btnAmazon_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string strSQL = "SELECT TOP 1 [Amazon] FROM [Login].[dbo].[Amazon] ORDER BY NEWID()";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            con.Open();
            SqlDataReader myReader = cmd.ExecuteReader();

            while (myReader.Read())
            {
                txtAmazon.Text = (myReader["Amazon"].ToString());
            }
            myReader.Close();
            con.Close();
        }

        private void aufUpdatesÜberprüfenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmUpdateSystem().Show();
        }

        private void wieGehtDasAllesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.XtraMessageBox.Show("Es ist ganz einfach " + Environment.NewLine + "1.du gehts erst auf Accounts suchst dir ein raus was du gerne haben willst und klickst auf Generieren" + Environment.NewLine + "die Account daten erscheinen in der Texbox", "Hilfe Stellung", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void wasIstNeuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.XtraMessageBox.Show("[Added]Minecraft Accounts" + Environment.NewLine + "[Fix]Design änderungen" + Environment.NewLine + "[Added]LiveTicker" + Environment.NewLine + "[Fix]Code reinigung" + Environment.NewLine + "[Added]AVG Internet Security 2015 (Premium)" + Environment.NewLine + "[Added]WWE Network" + Environment.NewLine + "[Added]Imgur", "Was ist Neu? v1.0.0.2", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDezzer_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string strSQL = "SELECT TOP 1 [Dezzer] FROM [Login].[dbo].[Deezer] ORDER BY NEWID()";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            con.Open();
            SqlDataReader myReader = cmd.ExecuteReader();

            while (myReader.Read())
            {
                txtDezzer.Text = (myReader["Dezzer"].ToString());
            }
            myReader.Close();
            con.Close();
        }

        private void btnOrigin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string strSQL = "SELECT TOP 1 [Origin] FROM [Login].[dbo].[Origin] ORDER BY NEWID()";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            con.Open();
            SqlDataReader myReader = cmd.ExecuteReader();

            while (myReader.Read())
            {
                txtOrigin.Text = (myReader["Origin"].ToString());
            }
            myReader.Close();
            con.Close();
        }

        private void NewsTicker_Tick(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string strSQL = "SELECT TOP 1 [NewsTicker] FROM [Login].[dbo].[NewsTicker] ORDER BY NEWID()";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            con.Open();
            SqlDataReader myReader = cmd.ExecuteReader();

            while (myReader.Read())
            {
                lblNews.Text = (myReader["NewsTicker"].ToString());
                lblTicker.Text = (myReader["NewsTicker"].ToString());
            }
            myReader.Close();
            con.Close();
        }

        private void btnMinecraft_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string strSQL = "SELECT TOP 1 [Minecraft] FROM [Login].[dbo].[Minecraft] ORDER BY NEWID()";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            con.Open();
            SqlDataReader myReader = cmd.ExecuteReader();

            while (myReader.Read())
            {
                txtMinecraft.Text = (myReader["Minecraft"].ToString());
            }
            myReader.Close();
            con.Close();
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit1.Checked)
            {
                System.IO.StreamWriter writer = new System.IO.StreamWriter("AuthCode.txt");
                writer.WriteLine(txtUsername.Text);
                writer.WriteLine(txtPassword.Text);
                writer.Close();
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {

            if (txtUsername.Text == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Gebe dein Username ein", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
                xtraTabPage2.PageVisible = false;
                groupControl8.Visible = false;
                xtraTabPage3.PageVisible = false;
                return;
            }
            if (txtPassword.Text == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Gebe dein Passwort ein", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                xtraTabPage2.PageVisible = false;
                groupControl8.Visible = false;
                xtraTabPage3.PageVisible = false;
                return;
            }
            try
            {
                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand("INSERT INTO [Login].[dbo].[Accounts] ([Username], [Passwort]) VALUES (@Username, @Passwort)", con);

                SqlParameter uName = new SqlParameter("@Username", SqlDbType.VarChar, 50);
                SqlParameter uPassword = new SqlParameter("@Passwort", SqlDbType.VarChar, 50);

                uName.Value = txtUsername.Text;
                uPassword.Value = txtPassword.Text;

                cmd.Parameters.Add(uName);
                cmd.Parameters.Add(uPassword);

                con.Open();

                SqlDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                if (myReader.Read() == true)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Registriert als", "Registrierung Erfolgreich" + Environment.NewLine + txtUsername.Text);
                    groupControl8.Visible = true;
                    xtraTabPage2.PageVisible = true;
                    panelControl1.Visible = false;
                    xtraTabPage3.PageVisible = true;
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Registriert als" + Environment.NewLine + txtUsername.Text, "Registrierung Erfolgreich");
                    xtraTabPage2.PageVisible = false;
                    groupControl8.Visible = false;
                    xtraTabPage3.PageVisible = false;
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Dispose();
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Fehlermeldung", MessageBoxButtons.OK, MessageBoxIcon.Error);
                xtraTabPage2.PageVisible = false;
                groupControl8.Visible = false;
                xtraTabPage3.PageVisible = false;
            }
        }

        private void btnAVG_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string strSQL = "SELECT TOP 1 [AVG Internet Security 2015] FROM [Login].[dbo].[AVG] ORDER BY NEWID()";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            con.Open();
            SqlDataReader myReader = cmd.ExecuteReader();

            while (myReader.Read())
            {
                txtAVG.Text = (myReader["AVG Internet Security 2015"].ToString());
            }
            myReader.Close();
            con.Close();
        }

        private void btnWWENetwork_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string strSQL = "SELECT TOP 1 [WWE Accounts] FROM [Login].[dbo].[WWE] ORDER BY NEWID()";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            con.Open();
            SqlDataReader myReader = cmd.ExecuteReader();

            while (myReader.Read())
            {
                txtNetwork.Text = (myReader["WWE Accounts"].ToString());
            }
            myReader.Close();
            con.Close();
        }

        private void btnImgur_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string strSQL = "SELECT TOP 1 [Imgur Accounts] FROM [Login].[dbo].[Imgur] ORDER BY NEWID()";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            con.Open();
            SqlDataReader myReader = cmd.ExecuteReader();

            while (myReader.Read())
            {
                txtImgur.Text = (myReader["Imgur Accounts"].ToString());
            }
            myReader.Close();
            con.Close();
        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {
            Process.Start("http://api.hostinger.de/redir/6372546");
        }

        private void pictureEdit1_Click(object sender, EventArgs e)
        {
            Process.Start("http://api.hostinger.de/redir/6372546");
        }
    }
}

        
    

        
    
