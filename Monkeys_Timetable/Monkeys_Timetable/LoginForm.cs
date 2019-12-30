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

    //运行图界面类，实现输入到发时刻数据后，绘制可缩放的运行图，最好站名线根据用户输入确定
    public partial class LoginForm : Form
    {
        Button login;
        static int login_Width =1300;
        static int login_Height = 750;
        //string file;

        public LoginForm()
        {
            InitializeComponent();


            this.Size = new Size(login_Width, login_Height);
            this.Text = "高速铁路运行图冲突检测与评估系统 V1.0";

            login = new Button();
            login.Size = new Size(70, 35);
            login.Text = "确认";
            login.Font= new Font("楷体", 18, FontStyle.Bold);
            login.Location = new Point(this.Width / 2, this.Height*4/ 5);

            label1.ForeColor = Color.Black;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("楷体",18,FontStyle.Bold);
            label1.Location = new Point(480,520);
            label1.Location = new Point(this.Width* 7/16, this.Height *5/ 7);

            label2.ForeColor = Color.Black;
            label2.BackColor = Color.Transparent;
            label2.Location = new Point(500,550);
            label2.Font = new Font("楷体", 18, FontStyle.Bold);
            label2.Location = new Point(this.Width * 7/16, this.Height * 6 / 8);


            label3.Text = "高速铁路运行图冲突检测与评估系统";
            label3.ForeColor = Color.White;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("华文行楷",60, FontStyle.Bold);
            label3.Location = new Point(this.Width/11,this.Height/9);

            textBox1.Location= new Point(label1.Location.X+90, label1.Location.Y + 5);
            textBox1.Size = new Size(160, 60);

            textBox2.Location = new Point(label2.Location.X+90, label2.Location.Y+5);
            textBox2.Size = new Size(160, 60);

            button1.Size = new Size(70, 35);
            button1.Font = new Font("楷体", 18, FontStyle.Bold);
            button1.Location = new Point(this.Width*3/7, this.Height * 8/9);

            button2.Size = new Size(70, 35);
            button2.Text = "取消";
            button2.Font = new Font("楷体", 18, FontStyle.Bold);
            button2.Location = new Point(this.Width *6/13, this.Height * 4 / 5);

            this.Controls.Add(login);

            login.Click += login_Click;
        }
        public void login_Click(object sender,EventArgs e)
        {
            string Accessfilename = @"\\注册用户表.mdb";
            string Constr = "Provider=Microsoft.ace.OLEDB.12.0;Data Source=" + Application.StartupPath + Accessfilename;
            OleDbConnection con = new OleDbConnection(Constr);
            con.Open();
            string selectsql1 = "Select * from UsersDat where Users='" + textBox1.Text.ToString() + "'" ;
            string selectsql2 = "Select * from PasswordDat where password='" + textBox2.Text.ToString() + "'";
            OleDbCommand odc1 = new OleDbCommand(selectsql1,con);
            OleDbCommand odc2 = new OleDbCommand(selectsql2, con);
            OleDbDataReader odr1;
            OleDbDataReader odr2;
            odr1 = odc1.ExecuteReader();
            odr2 = odc2.ExecuteReader();
            if (odr1.Read()&&odr2.Read())
            {
                PaintForm paintForm = new PaintForm();
                paintForm.Owner = this;
                paintForm.Show();
            }
            else
            {
                MessageBox.Show("用户名或密码错误！");
                return;
            }
            con.Close();

            if (textBox1.Text.Trim()=="")
            {
                MessageBox.Show("用户名不能为空！");
            }
            if(textBox2.Text.Trim()=="")
            {
                MessageBox.Show("密码不能为空！");
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
