using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace SeenITMovieTV.Views
{
    public partial class WatchNowView : MetroForm
    {
        public ChromiumWebBrowser chromeBrowser;

        public WatchNowView(string URL)
        {
            InitializeComponent();
            InitialiseChromium(URL);
        }

        private void InitialiseChromium(string link)
        {
            InitialiseCefWithSettings();

            //Create a browser component.
            chromeBrowser = new ChromiumWebBrowser(link);

            //Add browser to controls form.
            this.Controls.Add(chromeBrowser);

            //Make the browser fill the form.
            chromeBrowser.Dock = DockStyle.Fill;
        }

        private static void InitialiseCefWithSettings()
        {
            string PepFlashPath = ( (Application.StartupPath) + ("\\pepflashplayer32_29_0_0_113.dll") );

            if (Cef.IsInitialized == false)
            {               
                //Create and define new settings.
                CefSettings settings = new CefSettings();

                settings.CachePath = "cache";
                settings.CefCommandLineArgs.Add("ppapi-flash-path", @PepFlashPath);
                settings.CefCommandLineArgs.Add("ppapi-flash-version", "29.0.0.113");

                //Initialise Cef with the provided settings.
                Cef.Initialize(settings);
            }
        }

        private void WatchNowView_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
