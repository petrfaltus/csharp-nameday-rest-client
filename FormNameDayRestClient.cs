using System;
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

        private void menuItemAboutClick(object sender, EventArgs e)
        {
            aboutApplication();
        }
    }
}
