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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();

            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;

            bool IdOverlapCheck = false;

            button1.Click += (sender, e) =>
            {
                try
                {
                    if (textBox1.Text.Trim() == "")
                    {
                        label7.Visible = true;
                    }
                    else if (textBox2.Text.Trim() == "")
                    {
                        label5.Visible = true;
                    }
                    else if (textBox2.Text.Length < 4)
                    {
                        label5.Visible = true;
                    }
                    else if (IdOverlapCheck == false)
                    {
                        MessageBox.Show("아이디 중복확인을 해주십시오.");
                    }
                    else
                    {
                        Manager manager = new Manager()
                        {
                            Id = textBox1.Text,
                            Password = textBox2.Text
                        };
                        DataManager.Managers.Add(manager);
                        DataManager.Save();
                        MessageBox.Show("회원가입이 완료되었습니다.");
                        this.Visible = false;
                        new Form4().ShowDialog();
                        Close();
                    }
                }
                catch (Exception exception)
                {

                }
            };

            button2.Click += (sender, e) =>
            {
                try
                {
                    if (textBox1.Text.Trim() == "")
                    {
                        label4.Visible = false;
                        label6.Visible = false;
                        label7.Visible = false;
                        label7.Visible = true;
                    }
                    else if (DataManager.Managers.Exists((x) => x.Id == textBox1.Text))
                    {
                        label4.Visible = false;
                        label6.Visible = false;
                        label7.Visible = false;
                        label4.Visible = true;
                    }
                    else
                    {
                        label4.Visible = false;
                        label6.Visible = false;
                        label7.Visible = false;
                        label6.Visible = true;
                        IdOverlapCheck = true;
                    }
                }
                catch (Exception exception)
                {

                }
            };
        }


    }
}
