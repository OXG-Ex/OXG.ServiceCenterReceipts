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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text += " руб.";
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
            using (var context = new ServiceCenterDbContext())
            {
                label2.Text = $"{context.MasterReceipts.Sum(r => r.MyMoney)} руб.";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new ServiceCenterDbContext())
            {
                if (!String.IsNullOrWhiteSpace(textBox1.Text))
                {
                    var debitReceipt = new MasterReceipt(888, "Списание", 0 - Int32.Parse(textBox1.Text));
                    context.MasterReceipts.Add(debitReceipt);
                    label2.Text = $"{context.MasterReceipts.Sum(r => r.MyMoney)} руб.";
                }
                else
                {
                    MessageBox.Show("Ошибка: введите сумму для списания:");
                }
            }
        }

        private void debitFormClosing(object sender, FormClosingEventArgs e)
        {
            var f1 = new Form1();
            f1.Show();
            this.Hide();
        }
    }
}
