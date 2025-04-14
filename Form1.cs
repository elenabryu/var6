using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace var6
{
    public partial class Form1 : Form
    {
        private string generatedcaptha;
        private bool passwordVisible = true;
        public Form1()
        {
            InitializeComponent();
            Generatedcaptha();
            textBox2.UseSystemPasswordChar = true;
        }

        private void Generatedcaptha()
        {
            string chars = "QAZCXSWEDVFRBGTNHYMJUKILOPzaqxswcdevfrbgtnhyjumkilop1234567890";
            Random random = new Random();
            generatedcaptha = new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(chars.Length)]).ToArray());

            label6.Text = generatedcaptha[0].ToString();
            label7.Text = generatedcaptha[1].ToString();
            label8.Text = generatedcaptha[2].ToString();
            label9.Text = generatedcaptha[3].ToString();
            label10.Text = generatedcaptha[4].ToString();
            label11.Text = generatedcaptha[5].ToString();

            foreach(var label in new[] {label6, label7, label8, label9, label10, label11})
            {
                label.Font = new Font(label.Font, FontStyle.Italic | FontStyle.Strikeout);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "user" && textBox2.Text == "user")
            {
                MainForm mainForm = new MainForm();
                mainForm.Show();
                this.Hide();
            }
            else
            {
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                label11.Visible = true;
                label5.Visible = true;
                MessageBox.Show("Неправильный логин или пароль");
                Generatedcaptha();
            }
        }

        private void TooglePasswordButton_Click(object sender, EventArgs e)
        {
            passwordVisible = !passwordVisible;
            textBox2.UseSystemPasswordChar = !passwordVisible;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
