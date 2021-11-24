﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _18._11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Не выбран объект для удаления");
            }
            else
            {
                int k = listBox1.SelectedIndex;
                listBox1.Items.RemoveAt(k);
                if (listBox1.Items.Count == 0)
                {
                    button5.Enabled = false;
                }
                button2.Enabled = false;
                button3.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            //f.Show();
            if (f.ShowDialog() == DialogResult.OK)
            {
                string fio = f.textBox2.Text;
                string r = f.textBox3.Text;
                int v = Convert.ToInt32(f.textBox4.Text);
                ycheniki p = new ycheniki();
                p.FIO = fio;
                p.group = r;
                p.ocenka = v;
                listBox1.Items.Add(p);

                button5.Enabled = false;
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                for (int i= 0; i < listBox1.Items.Count; i++)
                {
                    ycheniki p = listBox1.Items[i] as ycheniki;
                    sw.WriteLine(p.FIO);
                    sw.WriteLine(p.group);
                    sw.WriteLine(p.ocenka);

                }
                sw.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Не выбран объект для редактирования");
            }
            else
            {
                int k = listBox1.SelectedIndex;
                ycheniki p = listBox1.Items[k] as ycheniki;
                Form2 f = new Form2();
                f.textBox2.Text = p.FIO;
                f.textBox3.Text = p.group.ToString();
                f.textBox4.Text = p.ocenka.ToString();
                if (f.ShowDialog() == DialogResult.OK)
                {
                    p.FIO = f.textBox2.Text;
                    p.group = f.textBox3.Text;
                    p.ocenka = Convert.ToInt32(f.textBox4.Text);
                    listBox1.Items[k] = p;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int sum = 0;
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                ycheniki p = listBox1.Items[i] as ycheniki;
                sum += p.ocenka;

            }
            MessageBox.Show((sum * 1.0 / listBox1.Items.Count).ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button3.Enabled = false;
            button5.Enabled = false;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex != -1)
            {
                button2.Enabled = true;
                button3.Enabled = true;
                button5.Enabled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                while (!sr.EndOfStream)
                {
                    ycheniki p = new ycheniki();
                    p.FIO = sr.ReadLine();
                    p.group = sr.ReadLine();
                    p.ocenka = Convert.ToInt32(sr.ReadLine());
                    listBox1.Items.Add(p);
                }
                sr.Close();
            }
        }
    }
}
