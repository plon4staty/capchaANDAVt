using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace capchaANDAVt
{
    public partial class Form1 : Form
    {
        DataBase DBc = new DataBase();
        int count = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
          

        }
        

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            SqlDataAdapter adap = new SqlDataAdapter();
            DataTable tbl = new DataTable();
            var log = textBox1.Text;
            var pass = textBox2.Text;
            
                string quer = $"select Login, Pass from UsersZD2 where Login = '{log}' and Pass = '{pass}'";
                SqlCommand cmd = new SqlCommand(quer, DBc.GetConnection());

                adap.SelectCommand = cmd;
                adap.Fill(tbl);
                if (tbl.Rows.Count == 1)
                {
                    MessageBox.Show("Вы успешно вошли!", "Отлично!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form2 fr2 = new Form2();
                    this.Hide();
                    fr2.ShowDialog();
                    this.Show();
                }
                else
                {
                    CheckCountClick();
                    MessageBox.Show("Такого аккаунта нету!", "Плохо!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            
            
        }
        private void CheckCountClick()
        {
            if(count >= 3)
            {
                captcha cp = new captcha();
                this.Hide();
                cp.ShowDialog();
                this.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            captcha cp = new captcha();
            this.Hide();
            cp.ShowDialog();
            this.Show();
        }
    }
}
