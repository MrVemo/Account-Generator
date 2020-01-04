using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Extras
{
    class ApXRPCUpdater
    {
        private string _currentVersion = "";
        public string _returnedVersion = "";
        private string _client_response;
        private string _version_address = "";
        private string _update_address = "";
        private WebClient _client = new WebClient();
        private bool _noDownload = false;

        public ApXRPCUpdater(string current_version)
        {
            this._currentVersion = current_version;
            this._version_address = "http://alivemoddingteam.square7.ch/updates/Account Generator/Version.txt";
            this._update_address = _client.DownloadString(new Uri("http://alivemoddingteam.square7.ch/updates/Account Generator/Update.txt"));   
        }
        
        public ApXRPCUpdater(string current_version, string version_location)
        {
            this._currentVersion = current_version;
            this._version_address = version_location;
            this._noDownload = true;
        }
        
        public UpdateResponse CheckVersion()
        {
            ICS_e flags = 0;
            bool online = InternetGetConnectedState(ref flags, 0);
            _client_response = _client.DownloadString(_version_address);
            if (_client_response.Contains(_currentVersion)) return UpdateResponse.Correct;
            else return UpdateResponse.Incorrect;
        }
        
        public string getResponse()
        {
            return this._client_response;
        }
        

        public void getUpdate(string save_location)
        {
            if (this._noDownload)
            {
                Dispose();
                return;
            }
            _client.DownloadFileAsync(new Uri(_update_address), save_location);
        }
        
        public void getUpdate(string save_location, string confirm_message)
        {
            if (this._noDownload) return;
            _client_download_message = confirm_message;
            _client.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(_client_DownloadFileCompleted);
            _client.DownloadFileAsync(new Uri(_update_address), save_location);
        }
        
        public void Dispose()
        {
            _client.Dispose();
        }

        private string _client_download_message = "Fertig Rutergeladen!";
        private void _client_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            DevExpress.XtraEditors.XtraMessageBox.Show(_client_download_message, Form.ActiveForm.Name);
            Dispose();
        }
        
        [DllImport("wininet.dll", CharSet = CharSet.Auto)]
        private extern static bool InternetGetConnectedState(ref ICS_e lpdwFlags, int dwReserved);
        [Flags]
        enum ICS_e : int
        {
            INTERNET_CONNECTION_MODEM = 0x1,
            INTERNET_CONNECTION_LAN = 0x2,
            INTERNET_CONNECTION_PROXY = 0x4,
            INTERNET_RAS_INSTALLED = 0x10,
            INTERNET_CONNECTION_OFFLINE = 0x20,
            INTERNET_CONNECTION_CONFIGURED = 0x40
        }
    }
    public enum UpdateResponse
    {
        NetworkInactive,
        Correct,
        Incorrect,
    }
}
