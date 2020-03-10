using System;
using System.Drawing;
using System.Windows.Forms;

namespace NameDayRestClient
{
    public partial class FormNameDayRestClient : Form
    {
        private readonly string ERROR = "Error";
        private readonly string CONFIRMING = "Confirming";

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

        private void searching()
        {
            string messageConfirming = "Really start the searching ?";
            DialogResult confirmResult = MessageBox.Show(messageConfirming, CONFIRMING, MessageBoxButtons.YesNo);
            if (confirmResult != DialogResult.Yes)
            {
                return;
            }

            if (String.IsNullOrEmpty(queryTextBox.Text))
            {
                string messageIfEmpty = "The name or date cannot be empty";
                MessageBox.Show(messageIfEmpty, ERROR);

                queryTextBox.Focus();

                return;
            }

            string result = Search.run(queryTextBox.Text);
            if (result == null)
            {
                string messageError = Search.getLastError();
                MessageBox.Show(messageError, ERROR);

                queryTextBox.Focus();

                return;
            }

            resultLabel.Text = result;

            queryTextBox.Text = "";
            queryTextBox.Focus();
        }

        private void menuItemExitClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuItemSearchClick(object sender, EventArgs e)
        {
            searching();
        }

        private void menuItemAboutClick(object sender, EventArgs e)
        {
            aboutApplication();
        }

        private void searchButtonClick(object sender, EventArgs e)
        {
            searching();
        }

        private void FormNameDayRestClientResize(object sender, EventArgs e)
        {
            this.resultPanel.Size = Size.Subtract(this.ClientSize, panelSizeDiff);
        }
    }
}
