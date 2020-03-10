using System;
using System.Drawing;
using System.Windows.Forms;

namespace NameDayRestClient
{
    public partial class FormNameDayRestClient
    {
        private MainMenu mainMenu;
        private MenuItem menuItemFile;
        private MenuItem menuItemExit;
        private MenuItem menuItemRun;
        private MenuItem menuItemSearch;
        private MenuItem menuItemInfo;
        private MenuItem menuItemAbout;

        private TextBox queryTextBox;
        private Button searchButton;
        private Label resultLabel;
        private Panel resultPanel;

        private readonly Size panelSizeDiff = new Size(42, 90);

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
            // File menu items
            this.menuItemExit = new MenuItem("E&xit");
            this.menuItemExit.Click += new EventHandler(this.menuItemExitClick);

            this.menuItemFile = new MenuItem("&File");
            this.menuItemFile.MenuItems.Add(this.menuItemExit);

            // Run menu items
            this.menuItemSearch = new MenuItem("Se&arch");
            this.menuItemSearch.Click += new EventHandler(this.menuItemSearchClick);

            this.menuItemRun = new MenuItem("&Run");
            this.menuItemRun.MenuItems.Add(this.menuItemSearch);

            // Info menu items
            this.menuItemAbout = new MenuItem("&About");
            this.menuItemAbout.Click += new EventHandler(this.menuItemAboutClick);

            this.menuItemInfo = new MenuItem("&Info");
            this.menuItemInfo.MenuItems.Add(this.menuItemAbout);

            // final menu bar
            this.mainMenu = new MainMenu();
            this.mainMenu.MenuItems.Add(this.menuItemFile);
            this.mainMenu.MenuItems.Add(this.menuItemRun);
            this.mainMenu.MenuItems.Add(this.menuItemInfo);

            return mainMenu;
        }

        private void InitializaBody()
        {
            // queryTextBox
            this.queryTextBox = new TextBox();
            this.queryTextBox.Name = "queryTextBox";
            this.queryTextBox.Text = "";
            this.queryTextBox.Location = new Point(20, 22);
            this.queryTextBox.Size = new Size(240, 25);
            this.queryTextBox.TabIndex = 0;
            this.queryTextBox.AcceptsReturn = false;
            this.queryTextBox.AcceptsTab = false;
            this.queryTextBox.Multiline = false;
            this.queryTextBox.KeyDown += new KeyEventHandler(this.queryTextBoxKeyDown);

            // searchButton
            this.searchButton = new Button();
            this.searchButton.Name = "searchButton";
            this.searchButton.Text = "Search";
            this.searchButton.Location = new Point(280, 20);
            this.searchButton.Size = new Size(90, 25);
            this.searchButton.TabIndex = 2;
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new EventHandler(this.searchButtonClick);

            // resultLabel
            this.resultLabel = new Label();
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Text = "";
            this.resultLabel.TabIndex = 4;
            this.resultLabel.AutoSize = true;

            // resultPanel
            this.resultPanel = new Panel();
            this.resultPanel.Name = "resultPanel";
            this.resultPanel.Location = new Point(20, 65);
            this.resultPanel.Size = new Size(450, 560);
            this.resultPanel.TabIndex = 3;
            this.resultPanel.BackColor = Color.White;
            this.resultPanel.ForeColor = Color.Black;
            this.resultPanel.BorderStyle = BorderStyle.FixedSingle;
            this.resultPanel.AutoScroll = true;
            this.resultPanel.Controls.Add(this.resultLabel);

            // final body
            this.Controls.Add(this.queryTextBox);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.resultPanel);

            this.ClientSize = Size.Add(this.resultPanel.Size, panelSizeDiff);
            this.Resize += new EventHandler(this.FormNameDayRestClientResize);
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
            InitializaBody();

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
