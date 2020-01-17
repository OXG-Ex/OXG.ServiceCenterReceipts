﻿using System;
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
    
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        internal ComponentList componentList = new ComponentList();
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

            if (this.Height >= 412 || this.Height <= 215)
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
            using(var context = new ServiceCenterDbContext())
            {
                var receipt = new MasterReceipt(Int32.Parse(textBox1.Text), textBox2.Text, Int32.Parse(textBox3.Text),checkBox1.Checked);
                context.MasterReceipts.Add(receipt);
                context.SaveChanges();
                context.ComponentsLists.Add();
                label6.Text = $"Записей в базе: {context.MasterReceipts.Count()}";
            }
        }
        


        private void Form1Show(object sender, EventArgs e)
        {
            using (var context = new ServiceCenterDbContext())
            {
                label6.Text = $"Записей в базе: {context.MasterReceipts.Count()}";
            }
        }

        private void NowTimerTick(object sender, EventArgs e)
        {
            label7.Text = $"{ DateTime.Now}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var f2 = new Form2();
            f2.Show();
            this.Hide();
        }
        

        private void button3_Click(object sender, EventArgs e)
        {
           
            if (!String.IsNullOrWhiteSpace(textBox4.Text) && !String.IsNullOrWhiteSpace(textBox5.Text))
            {
                var component = new Component(textBox4.Text,Int32.Parse(textBox5.Text));
                listView1.Items.Add(component.Name);
                componentList.Components.Add(component);
            }
            else
            {
                MessageBox.Show("Ошибка заполнения");
            }
        }
    }
}