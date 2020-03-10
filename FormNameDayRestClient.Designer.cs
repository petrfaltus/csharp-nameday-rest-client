using System;
using System.Windows.Forms;

namespace NameDayRestClient
{
    public partial class FormNameDayRestClient
    {
        private MainMenu mainMenu;
        private MenuItem menuItemInfo;
        private MenuItem menuItemAbout;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private MainMenu InitializeMenu()
        {
            // Info menu items
            this.menuItemAbout = new MenuItem("&About");
            this.menuItemAbout.Click += new EventHandler(this.menuItemAboutClick);

            this.menuItemInfo = new MenuItem("&Info");
            this.menuItemInfo.MenuItems.Add(this.menuItemAbout);

            // final menu bar
            this.mainMenu = new MainMenu();
            this.mainMenu.MenuItems.Add(this.menuItemInfo);

            return mainMenu;
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            //
            // FormNameDayRestClient
            //
            this.SuspendLayout();
            this.Name = "NameDayRestClient";
            this.Text = "Name day REST client";

            this.Menu = InitializeMenu();

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
