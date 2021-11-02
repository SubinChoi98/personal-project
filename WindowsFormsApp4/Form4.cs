using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();

            button1.Click += Button1_Click;
            button2.Click += Button2_Click;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("Id를 입력해주세요");
            }
            else if (textBox2.Text.Trim() == "")
            {
                MessageBox.Show("Password를 입력해주세요");
            }
            else
            {
                try
                {
                    Manager manager = DataManager.Managers.Single((x) => x.Id == textBox1.Text);
                    if (manager.Id == textBox1.Text && manager.Password == textBox2.Text)
                    {
                        this.Visible = false;
                        new Form1().ShowDialog();
                        Close();
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("아이디 또는 비밀번호가 올바르지 않습니다.");
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            new Form5().ShowDialog();
        }

    }
}
