using System;
using System.Windows.Forms;

namespace Rammendo
{
    public partial class Settings : Form
    {
        public Settings() {
            InitializeComponent();
            textBox1.Text = Store.Default.Url;
        }

        private void BtnOk_Click(object sender, EventArgs e) {
            Store.Default.Url = textBox1.Text;
            Store.Default.Save();
            Close();
        }

        private void BtnClose_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
