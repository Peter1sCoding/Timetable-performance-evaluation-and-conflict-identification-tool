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
        TextBox ID;
        TextBox password;
        Label IDLabel;
        Label pasLabel;
        string file;
        public LoginForm()
        {
            InitializeComponent();

            this.Size = new Size(1300, 700);
            this.Text = "高速铁路运行图冲突检测与评估系统 V1.0";

            login = new Button();
            login.Size = new Size(70, 35);
            login.Text = "确认";
            login.Location = new Point(680, 600);

            ID = new TextBox();
            ID.Size = new Size(160, 60);
            ID.Location = new Point(640, 530);

            password = new TextBox();
            password.Size = new Size(160, 60);
            password.Location = new Point(640, 560);

            IDLabel = new Label();
            IDLabel.Size = new Size(80, 40);
            IDLabel.Location = new Point(560, 535);
            IDLabel.Text = "用户名:";

            pasLabel = new Label();
            pasLabel.Size = new Size(80, 40);
            pasLabel.Location = new Point(560, 565);
            pasLabel.Text = "密码:";

            this.Controls.Add(login);
            this.Controls.Add(ID);
            this.Controls.Add(pasLabel);
            this.Controls.Add(IDLabel);
            this.Controls.Add(password);

            login.Click += login_Click;
        }
        public void login_Click(object sender,EventArgs e)
        {
            if ((ID.Text == "Admin") && (password.Text == "123456"))
            {
                PaintForm pf = new PaintForm();
                pf.Show();
            }
            else
            {
                MessageBox.Show("密码错误！");
            }
        }
    }
}
