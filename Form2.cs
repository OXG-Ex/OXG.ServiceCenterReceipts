using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OXG.ServiceCenterReceipts
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }


        private async void Form2_Shown(object sender, EventArgs e)
        {
            string LoadData()
            {
                using (var context = new ServiceCenterDbContext())
                {
                    var s = "";
                    var masterSum = context.MasterReceipts.Where(m => m.MasterName == Master.Name);
                    s = $"{masterSum.Sum(r => r.MyMoney)} руб.";
                    return s;
                }
            }
            string result = await Task.Factory.StartNew<string>(() => LoadData());
            label2.Text = result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new ServiceCenterDbContext())
            {
                if (!String.IsNullOrWhiteSpace(textBox1.Text))
                {
                    var debitReceipt = new MasterReceipt(888, "Списание", 0);
                    debitReceipt.MyMoney = 0 - Int32.Parse(textBox1.Text);
                    context.MasterReceipts.Add(debitReceipt);
                    context.SaveChanges();
                    textBox1.Text = "";
                    var masterSum = context.MasterReceipts.Where(m => m.MasterName == Master.Name);
                    label2.Text = $"{masterSum.Sum(r => r.MyMoney )} руб.";
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ошибка: введите сумму для списания");
                }
            }
        }

        private void debitFormClosing(object sender, FormClosingEventArgs e)
        {
            var f1 = new Form1();
            f1.Show();
        }
    }
}
