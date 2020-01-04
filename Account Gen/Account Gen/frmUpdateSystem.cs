using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Extras;
using System.Net;
using System.Diagnostics;

namespace Account_Gen
{
    public partial class frmUpdateSystem : DevExpress.XtraEditors.XtraForm
    {

        Stopwatch sw = new Stopwatch();
        public frmUpdateSystem()
        {
            InitializeComponent();
        }

        ApXRPCUpdater ApXRPCUpdater = new ApXRPCUpdater("1.0.0.2");
        private void btnCheckUpdates_Click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);

            switch (ApXRPCUpdater.CheckVersion())
            {
                case UpdateResponse.Correct:
                    DevExpress.XtraEditors.XtraMessageBox.Show("Die Version is Up to Date!", "Kein neues Update!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.progressBar1.Visible = false;
                    break;
                case UpdateResponse.Incorrect:
                    if (DevExpress.XtraEditors.XtraMessageBox.Show("Möchtest du die neue Version von Account Generator runterladen?", "Neues Update Verfügbar!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        // Starts the download
                        client.DownloadFileAsync(new Uri("http://alivemoddingteam.square7.ch/updates/Account Generator/Account Generator by Mr. Nobody.rar"), "Account Generator by Mr. Nobody.rar");
                        this.progressBar1.Visible = true;
                        ApXRPCUpdater.getUpdate("Account Generator by Mr. Nobody.rar", "Erfolgreich runtergeladen von Account Generator Update! Es wurde in das Verzeichnis gespeichert als \"Account Generator by Mr. Nobody.rar\"");
                    }
                    break;
                case UpdateResponse.NetworkInactive:
                    DevExpress.XtraEditors.XtraMessageBox.Show("Dein Netzwerk hat sich als inaktiv ergeben, überprüfen bitte deine Verbindung und versuchen es erneut!", "Netzwerk inaktive!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            sw.Reset();
            DevExpress.XtraEditors.XtraMessageBox.Show("Heruntergeladen! Siehe in dein Ordener wo du es Entpackt hast!!");
        }

        private void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            sw.Start();
            // Calculate download speed and output it to labelSpeed.
            labelSpeed.Text = string.Format("{0} kb/s", (e.BytesReceived / 1024d / sw.Elapsed.TotalSeconds).ToString("0.00"));

            // Update the progressbar percentage only when the value is not the same.
            progressBar1.Value = e.ProgressPercentage;

            // Show the percentage on our label.
            labelPerc.Text = e.ProgressPercentage.ToString() + "%";

            // Update the label with how much data have been downloaded so far and the total size of the file we are currently downloading
            labelDownloaded.Text = string.Format("{0} MB's / {1} MB's",
                (e.BytesReceived / 1024 / 1024).ToString("0.00"),
                (e.TotalBytesToReceive / 1024 / 1024).ToString("0.00"));
        }
    }
}