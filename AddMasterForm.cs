using System;
using System.Data.Entity.Validation;
using System.Windows.Forms;

namespace OXG.ServiceCenterReceipts
{
    public partial class AddMasterForm : Form
    {
        public AddMasterForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (true)
            {
                //TODO: Добавить проверку ввода и редактирование мастеров
                using (var context = new ServiceCenterDbContext())
                {
                    var master = new MasterPassword(NameTextBox.Text, PasswordTextBox.Text, double.Parse(PercentTextBox.Text));
                    context.MasterPasswords.Add(master);
                    try
                    {
                        context.SaveChanges();
                    }
                    catch (DbEntityValidationException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    NameTextBox.Text = "";
                    PasswordTextBox.Text = "";
                    PercentTextBox.Text = "";
                    MessageBox.Show("Мастер добавлен");
                }
            }
        }

        private void AddMasterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var f = new LoginForm();
            f.Show();
        }
    }
}
