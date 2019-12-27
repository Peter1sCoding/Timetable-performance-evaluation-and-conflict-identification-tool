using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Monkeys_Timetable
{

    //运行图界面类，实现输入到发时刻数据后，绘制可缩放的运行图，最好站名线根据用户输入确定
    public partial class LoginForm : Form
    {
        Button login;
        //string file;

        public LoginForm()
        {
            InitializeComponent();


            Rectangle rect = System.Windows.Forms.SystemInformation.VirtualScreen;
            //Rectangle rect = SystemInformation.WorkingArea;
            this.Height = rect.Height;
            this.Width = rect.Width;
            this.Text = "高速铁路运行图冲突检测与评估系统 V1.0";

            login = new Button();
            login.Size = new Size(70, 35);
            login.Text = "确认";
            login.Font= new Font("楷体", 18, FontStyle.Bold);
            login.Location = new Point(615, 600);
            login.Location = new Point(this.Width / 2, this.Height*4/ 5);

            label1.ForeColor = Color.White;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("楷体",18,FontStyle.Bold);
            label1.Location = new Point(480,520);
            label1.Location = new Point(this.Width* 7/16, this.Height *5/ 7);

            label2.ForeColor = Color.White;
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

            this.Controls.Add(login);

            login.Click += login_Click;
        }
        public void login_Click(object sender,EventArgs e)
        {
            if ((textBox1.Text == "Admin") && (textBox2.Text == "123456"))
            {
                PaintForm pf = new PaintForm();
                pf.Show();
            }
            if (textBox1.Text.Trim()=="")
            {
                MessageBox.Show("用户名不能为空");
            }
            else if(textBox2.Text.Trim()=="")
            {
                MessageBox.Show("密码错误！");
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
    
        }
    }
}
