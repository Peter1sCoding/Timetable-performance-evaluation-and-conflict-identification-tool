namespace Monkeys_Timetable
{
    partial class PaintForm
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.读取文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.读取时刻表信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.读取车站信息ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.读取列车间隔信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.绘制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.绘制运行图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.计算ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.冲突检测ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.冲突检测数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.运行图显示冲突ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.计算ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.读取文件ToolStripMenuItem,
            this.绘制ToolStripMenuItem,
            this.计算ToolStripMenuItem1,
            this.冲突检测ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(1370, 29);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // 读取文件ToolStripMenuItem
            // 
            this.读取文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.读取时刻表信息ToolStripMenuItem,
            this.读取车站信息ToolStripMenuItem1,
            this.读取列车间隔信息ToolStripMenuItem});
            this.读取文件ToolStripMenuItem.Name = "读取文件ToolStripMenuItem";
            this.读取文件ToolStripMenuItem.Size = new System.Drawing.Size(90, 27);
            this.读取文件ToolStripMenuItem.Text = "读取文件";
            this.读取文件ToolStripMenuItem.Click += new System.EventHandler(this.读取文件ToolStripMenuItem_Click);
            // 
            // 读取时刻表信息ToolStripMenuItem
            // 
            this.读取时刻表信息ToolStripMenuItem.Name = "读取时刻表信息ToolStripMenuItem";
            this.读取时刻表信息ToolStripMenuItem.Size = new System.Drawing.Size(226, 28);
            this.读取时刻表信息ToolStripMenuItem.Text = "读取时刻表信息";
            this.读取时刻表信息ToolStripMenuItem.Click += new System.EventHandler(this.读取时刻表信息ToolStripMenuItem_Click);
            // 
            // 读取车站信息ToolStripMenuItem1
            // 
            this.读取车站信息ToolStripMenuItem1.Name = "读取车站信息ToolStripMenuItem1";
            this.读取车站信息ToolStripMenuItem1.Size = new System.Drawing.Size(226, 28);
            this.读取车站信息ToolStripMenuItem1.Text = "读取车站信息";
            this.读取车站信息ToolStripMenuItem1.Click += new System.EventHandler(this.读取车站信息ToolStripMenuItem1_Click);
            // 
            // 读取列车间隔信息ToolStripMenuItem
            // 
            this.读取列车间隔信息ToolStripMenuItem.Name = "读取列车间隔信息ToolStripMenuItem";
            this.读取列车间隔信息ToolStripMenuItem.Size = new System.Drawing.Size(226, 28);
            this.读取列车间隔信息ToolStripMenuItem.Text = "读取列车间隔信息";
            this.读取列车间隔信息ToolStripMenuItem.Click += new System.EventHandler(this.读取列车间隔信息ToolStripMenuItem_Click);
            // 
            // 绘制ToolStripMenuItem
            // 
            this.绘制ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.绘制运行图ToolStripMenuItem});
            this.绘制ToolStripMenuItem.Name = "绘制ToolStripMenuItem";
            this.绘制ToolStripMenuItem.Size = new System.Drawing.Size(56, 27);
            this.绘制ToolStripMenuItem.Text = "绘制";
            this.绘制ToolStripMenuItem.Click += new System.EventHandler(this.绘制ToolStripMenuItem_Click);
            // 
            // 绘制运行图ToolStripMenuItem
            // 
            this.绘制运行图ToolStripMenuItem.Name = "绘制运行图ToolStripMenuItem";
            this.绘制运行图ToolStripMenuItem.Size = new System.Drawing.Size(175, 28);
            this.绘制运行图ToolStripMenuItem.Text = "绘制运行图";
            // 
            // 计算ToolStripMenuItem1
            // 
            this.计算ToolStripMenuItem1.Name = "计算ToolStripMenuItem1";
            this.计算ToolStripMenuItem1.Size = new System.Drawing.Size(56, 27);
            this.计算ToolStripMenuItem1.Text = "计算";
            // 
            // 冲突检测ToolStripMenuItem
            // 
            this.冲突检测ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.冲突检测数据ToolStripMenuItem,
            this.运行图显示冲突ToolStripMenuItem});
            this.冲突检测ToolStripMenuItem.Name = "冲突检测ToolStripMenuItem";
            this.冲突检测ToolStripMenuItem.Size = new System.Drawing.Size(90, 27);
            this.冲突检测ToolStripMenuItem.Text = "冲突检测";
            this.冲突检测ToolStripMenuItem.Click += new System.EventHandler(this.冲突检测ToolStripMenuItem_Click);
            // 
            // 冲突检测数据ToolStripMenuItem
            // 
            this.冲突检测数据ToolStripMenuItem.Name = "冲突检测数据ToolStripMenuItem";
            this.冲突检测数据ToolStripMenuItem.Size = new System.Drawing.Size(209, 28);
            this.冲突检测数据ToolStripMenuItem.Text = "冲突检测数据";
            this.冲突检测数据ToolStripMenuItem.Click += new System.EventHandler(this.冲突检测数据ToolStripMenuItem_Click);
            // 
            // 运行图显示冲突ToolStripMenuItem
            // 
            this.运行图显示冲突ToolStripMenuItem.Name = "运行图显示冲突ToolStripMenuItem";
            this.运行图显示冲突ToolStripMenuItem.Size = new System.Drawing.Size(209, 28);
            this.运行图显示冲突ToolStripMenuItem.Text = "运行图显示冲突";
            // 
            // 计算ToolStripMenuItem
            // 
            this.计算ToolStripMenuItem.Name = "计算ToolStripMenuItem";
            this.计算ToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.计算ToolStripMenuItem.Text = "计算";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(18, 38);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1334, 633);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint_1);
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(1020, 7);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 23);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "上行";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.Location = new System.Drawing.Point(1101, 7);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(72, 23);
            this.checkBox2.TabIndex = 0;
            this.checkBox2.Text = "下行";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(18, 38);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1334, 633);
            this.panel2.TabIndex = 0;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(18, 38);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1334, 633);
            this.panel3.TabIndex = 0;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // PaintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 688);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PaintForm";
            this.Load += new System.EventHandler(this.PaintForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 读取文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 读取时刻表信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 读取车站信息ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 读取列车间隔信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 绘制ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 绘制运行图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 计算ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 计算ToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStripMenuItem 冲突检测ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 冲突检测数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 运行图显示冲突ToolStripMenuItem;
    }
}
