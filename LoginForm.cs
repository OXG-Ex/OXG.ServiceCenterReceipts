using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
                using(var context = new ServiceCenterDbContext())
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
                    MessageBox.Show("Ошибка: Неверный пароль");
                }
            }
        }
    }
}
