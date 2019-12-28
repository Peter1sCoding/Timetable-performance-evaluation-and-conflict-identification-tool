using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;

namespace Monkeys_Timetable
{
    public partial class RegisterForm : Form
    {
        /// <summary>
        /// 注册用户名的时间
        /// </summary>
        public DateTime registertime1;
        /// <summary>
        /// 注册密码的时间
        /// </summary>
        public DateTime registertime2;
        /// <summary>
        /// 密码强度设置的判断标准
        /// </summary>
        public int SURE = 0;

        public RegisterForm()
        {
            InitializeComponent();

            label1.Font = new Font("楷体", 18, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.BackColor = Color.Transparent;

            label2.Font = new Font("楷体", 18, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.BackColor = Color.Transparent;

            label3.Font = new Font("楷体", 18, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.BackColor = Color.Transparent;

            button1.Size = new Size(70, 35);
            button1.Font = new Font("楷体", 18, FontStyle.Bold);

            button2.Size = new Size(70, 35);
            button2.Font = new Font("楷体", 18, FontStyle.Bold);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim()=="")
            {
                MessageBox.Show("用户名不能为空！");
            }
            if(textBox2.Text.Trim ()=="")
            {
                MessageBox.Show("密码不能为空！");
            }
            if(System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "[A-Z]")&&(System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "[0-9]")) && (System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "[a-z]")))
            {
                SURE = 1;
            }
            else
            {
                MessageBox.Show("密码必须包含大小写字母和数字！");
            }
            if(textBox3.Text.Trim()=="")
            {
                MessageBox.Show("确认密码不能为空！");
            }
            if(textBox2.Text!=textBox3.Text)
            {
                MessageBox.Show("密码与确认密码不相符！");
            }
            string Accessfilename = @"\\注册用户表.mdb";
            string Constr = "Provider=Microsoft.ace.OLEDB.12.0;Data Source=" + Application.StartupPath + Accessfilename;
            OleDbConnection con = new OleDbConnection(Constr);
            con.Open();
            if((textBox1.Text!="")&&(textBox2.Text!="")&&(textBox3.Text!="")&&(textBox2.Text==textBox3.Text)&&(SURE==1))
            {
                string selectsql1 = "Select * from UsersDat where Users='" + textBox1.Text.ToString() + "'";
                OleDbCommand odc3 = new OleDbCommand(selectsql1, con);
                OleDbDataReader odr3;
                odr3 = odc3.ExecuteReader();
                if (odr3.Read())
                {
                    MessageBox.Show("该用户名已被注册！");
                }
                else
                {
                    registertime1 = DateTime.Now;
                    registertime2 = DateTime.Now;
                    string insertsql1 = "insert into UsersDat([Users],[Registertime])values('" + textBox1.Text + "','" + registertime1 + "')";
                    string insertsql2 = "insert into PasswordDat([Password],[Addtime])values('" + textBox2.Text + "','" + registertime2 + "')";
                    OleDbCommand odc1 = new OleDbCommand(insertsql1, con);
                    OleDbCommand odc2 = new OleDbCommand(insertsql2, con);
                    odc1.ExecuteNonQuery();
                    odc2.ExecuteNonQuery();
                    MessageBox.Show("注册成功，请前往登录界面登录！");
                    this.Close();
                }                   
            }
            con.Close();

        }
    }
}
