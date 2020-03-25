using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OXG.ServiceCenterReceipts
{

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }


        private void timerTick(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                this.Height += 5;
            }
            else
            {
                this.Height -= 5;
            }

            if (this.Height >= 422 || this.Height <= 235)
            {
                timer1.Stop();
            }
        }

        private void ComponentChecked(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void AddClick(object sender, EventArgs e)
        {
            using (var context = new ServiceCenterDbContext())
            {
                try
                {
                    var receipt = new MasterReceipt(Int32.Parse(textBox1.Text), textBox2.Text, Int32.Parse(textBox3.Text), checkBox1.Checked);
                    context.MasterReceipts.Add(receipt);
                    context.SaveChanges();

                    foreach (var item in componentList)
                    {
                        item.MasterReceiptID = receipt.ID;
                    }

                    context.Components.AddRange(componentList);
                    context.SaveChanges();
                    
                    var masterSum = context.MasterReceipts.Where(m => m.MasterName == Master.Name);
                    if (masterSum == null)
                    {
                        toolStripStatusLabel2.Text = $"Записей: {0} | {0} руб.";
                    }
                    else
                    {
                        var k = $"{masterSum.Sum(r => r.MyMoney)}";
                        var s = masterSum.Count();

                        toolStripStatusLabel2.Text = $"Записей: {s} | {k} руб.";
                    }
                }
                catch
                {

                    MessageBox.Show("Ошибка: заполните все поля");
                }
            }
        }



        private async void Form1Show(object sender, EventArgs e)
        {
            string LoadingData()
            {

                using (var context = new ServiceCenterDbContext())
                {
                    var k = "";
                    var s = 0;
                    var masterSum = context.MasterReceipts.Where(m => m.MasterName == Master.Name);
                    if (masterSum.Count() == 0)
                    {
                        k = "";
                        s = 0;
                    }
                    else
                    {
                       k = $"{masterSum.Sum(r => r.MyMoney)}";
                       s = masterSum.Count();

                        
                    }
                    return ($"Записей: {s}  |  {k} руб.");
                }
            }

            string result = await Task.Factory.StartNew<string>(() => LoadingData());
           
            toolStripStatusLabel2.Text = result;
            toolStripStatusLabel1.Text = $"{Master.Name}";
        }

        private void NowTimerTick(object sender, EventArgs e)
        {

            label7.Text = DateTime.Now.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var f2 = new Form2();
            f2.Show();
            this.Hide();
        }

        internal List<Component> componentList = new List<Component>();
        private void button3_Click(object sender, EventArgs e)
        {

            if (!String.IsNullOrWhiteSpace(textBox4.Text) && !String.IsNullOrWhiteSpace(textBox5.Text))
            {
                var component = new Component(textBox4.Text, Int32.Parse(textBox5.Text));

                componentList.Add(component);
                listView1.Items.Add(component.Name);

            }
            else
            {
                MessageBox.Show("Ошибка заполнения");
            }
        }

        private void Exit(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}