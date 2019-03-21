using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Server;
using Client;

namespace FileCopyDaemon {
    public class Program : Form {
        FCDServer FCDServ = new FCDServer();
        FCDClient FCDCl = new FCDClient();

        private NotifyIcon trayIcon;
        private ContextMenu trayMenu;

        [STAThread]
        public static void Main() {
            Application.Run(new Program());
        }

        public Program() {
            // Create a simple tray menu with only one item.
            trayMenu = new ContextMenu();
            trayMenu.MenuItems.Add("Test", Test);
            trayMenu.MenuItems.Add("Settings", Settings);
            trayMenu.MenuItems.Add("Exit", OnExit);

            // Create a tray icon. In this example we use a
            // standard system icon for simplicity, but you
            // can of course use your own custom icon too.
            trayIcon = new NotifyIcon();
            trayIcon.Text = "FileCopyDaemon";
            trayIcon.Icon = new Icon("D:/dotNET/FileCopyDaemon/Icons/IconBlue.ico", 40, 40);

            //NB!
            //To use when filecopy is active or maybe when link is made to server on the other side
            //trayIcon.Icon = new Icon("D:/dotNET/FileCopyDaemon/Icons/IconGreen.ico", 40, 40);

            // Add menu to tray icon and show it.
            trayIcon.ContextMenu = trayMenu;
            trayIcon.Visible = true;
        }

        protected override void OnLoad(EventArgs e) {
            Visible = false; // Hide form window.
            ShowInTaskbar = false; // Remove from taskbar.

            base.OnLoad(e);
        }

        private void Test(object sender, EventArgs e) {
            FCDCl.SendFile();

            Debug.WriteLine("Send");
        }

        private void Settings(object sender, EventArgs e) {
            Form settings = new Settings();
            settings.Show();

            Debug.WriteLine("Hej");
        }

        private void OnExit(object sender, EventArgs e) {
            Application.Exit();
        }

        protected override void Dispose(bool isDisposing) {
            if (isDisposing) {
                // Release the icon resource.
                trayIcon.Dispose();
            }

            base.Dispose(isDisposing);
        }
    }
}