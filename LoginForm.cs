using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OXG.ServiceCenterReceipts
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private async void LoginForm_Shown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            List<string> LoadingMasters()
            {
                using (var context = new ServiceCenterDbContext())
                {
                    var s = new List<string>();
                    foreach (var item in context.MasterPasswords)
                    {
                        s.Add(item.Name);
                    }
                    return s;
                }

            }
            List<string> result = await Task.Factory.StartNew<List<string>>(() => LoadingMasters());

            var masters = new string[result.Count];
            for (int i = 0; i < result.Count; i++)
            {
                masters[i] = result[i];
            }

            MasterComboBox.Items.AddRange(masters);
            this.Cursor = Cursors.Default;
            MasterComboBox.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new ServiceCenterDbContext())
            {
                foreach (var item in context.MasterPasswords)
                {
                    if (PasswordTextBox.Text == item.Password && MasterComboBox.Text == item.Name)
                    {
                        var f = new Form1();
                        Master.Name = MasterComboBox.Text;
                        Master.Percent = item.Percent;
                        f.Show();
                        this.Hide();
                        return;
                    }
                }
                MessageBox.Show("Ошибка: Неверный пароль");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var f = new AddMasterForm();
            f.Show();
            this.Hide();
        }

        private void MasterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MasterComboBox.SelectedIndex>-1)
            {
                PasswordTextBox.Enabled = true;
                label2.Visible = true;
            }
        }

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            if (PasswordTextBox.TextLength>3)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }
    }
}
