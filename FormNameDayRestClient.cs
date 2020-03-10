using System;
using System.Drawing;
using System.Windows.Forms;

namespace NameDayRestClient
{
    public partial class FormNameDayRestClient : Form
    {
        public FormNameDayRestClient()
        {
            InitializeComponent();
        }

        private void aboutApplication()
        {
            Version dotNetVer = Environment.Version;
            OperatingSystem os = Environment.OSVersion;

            string message = "Author: Petr Faltus © March 2020";
            message += Environment.NewLine;
            message += Environment.NewLine;

            message += ".NET version: " + dotNetVer;
            message += Environment.NewLine;
            message += "Operating system: " + os.VersionString;
            message += Environment.NewLine;

            message += " ";

            string title = "About the " + this.Text;

            MessageBox.Show(message, title);
        }

        private void menuItemExitClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuItemAboutClick(object sender, EventArgs e)
        {
            aboutApplication();
        }

        private void FormNameDayRestClientResize(object sender, EventArgs e)
        {
            this.resultPanel.Size = Size.Subtract(this.ClientSize, panelSizeDiff);
        }
    }
}
