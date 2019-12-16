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
            this.检测ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.显示冲突列车数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.运行图标记冲突ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.计算ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.开行方案ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.显示开行方案数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开行方案图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.计算ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.读取文件ToolStripMenuItem,
            this.绘制ToolStripMenuItem,
            this.检测ToolStripMenuItem,
            this.计算ToolStripMenuItem1,
            this.开行方案ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(1810, 26);
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
            this.读取文件ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.读取文件ToolStripMenuItem.Text = "读取文件";
            this.读取文件ToolStripMenuItem.Click += new System.EventHandler(this.读取文件ToolStripMenuItem_Click);
            // 
            // 读取时刻表信息ToolStripMenuItem
            // 
            this.读取时刻表信息ToolStripMenuItem.Name = "读取时刻表信息ToolStripMenuItem";
            this.读取时刻表信息ToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this.读取时刻表信息ToolStripMenuItem.Text = "读取时刻表信息";
            this.读取时刻表信息ToolStripMenuItem.Click += new System.EventHandler(this.读取时刻表信息ToolStripMenuItem_Click);
            // 
            // 读取车站信息ToolStripMenuItem1
            // 
            this.读取车站信息ToolStripMenuItem1.Name = "读取车站信息ToolStripMenuItem1";
            this.读取车站信息ToolStripMenuItem1.Size = new System.Drawing.Size(212, 26);
            this.读取车站信息ToolStripMenuItem1.Text = "读取车站信息";
            this.读取车站信息ToolStripMenuItem1.Click += new System.EventHandler(this.读取车站信息ToolStripMenuItem1_Click);
            // 
            // 读取列车间隔信息ToolStripMenuItem
            // 
            this.读取列车间隔信息ToolStripMenuItem.Name = "读取列车间隔信息ToolStripMenuItem";
            this.读取列车间隔信息ToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this.读取列车间隔信息ToolStripMenuItem.Text = "读取列车间隔信息";
            this.读取列车间隔信息ToolStripMenuItem.Click += new System.EventHandler(this.读取列车间隔信息ToolStripMenuItem_Click);
            // 
            // 绘制ToolStripMenuItem
            // 
            this.绘制ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.绘制运行图ToolStripMenuItem});
            this.绘制ToolStripMenuItem.Name = "绘制ToolStripMenuItem";
            this.绘制ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.绘制ToolStripMenuItem.Text = "绘制";
            this.绘制ToolStripMenuItem.Click += new System.EventHandler(this.绘制ToolStripMenuItem_Click);
            // 
            // 绘制运行图ToolStripMenuItem
            // 
            this.绘制运行图ToolStripMenuItem.Name = "绘制运行图ToolStripMenuItem";
            this.绘制运行图ToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.绘制运行图ToolStripMenuItem.Text = "绘制运行图";
            this.绘制运行图ToolStripMenuItem.Click += new System.EventHandler(this.绘制运行图ToolStripMenuItem_Click_1);
            // 
            // 检测ToolStripMenuItem
            // 
            this.检测ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.显示冲突列车数据ToolStripMenuItem,
            this.运行图标记冲突ToolStripMenuItem});
            this.检测ToolStripMenuItem.Name = "检测ToolStripMenuItem";
            this.检测ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.检测ToolStripMenuItem.Text = "检测";
            this.检测ToolStripMenuItem.Click += new System.EventHandler(this.检测ToolStripMenuItem_Click);
            // 
            // 显示冲突列车数据ToolStripMenuItem
            // 
            this.显示冲突列车数据ToolStripMenuItem.Name = "显示冲突列车数据ToolStripMenuItem";
            this.显示冲突列车数据ToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this.显示冲突列车数据ToolStripMenuItem.Text = "显示冲突列车数据";
            this.显示冲突列车数据ToolStripMenuItem.Click += new System.EventHandler(this.显示冲突列车数据ToolStripMenuItem_Click);
            // 
            // 运行图标记冲突ToolStripMenuItem
            // 
            this.运行图标记冲突ToolStripMenuItem.Name = "运行图标记冲突ToolStripMenuItem";
            this.运行图标记冲突ToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this.运行图标记冲突ToolStripMenuItem.Text = "运行图标记冲突";
            this.运行图标记冲突ToolStripMenuItem.Click += new System.EventHandler(this.运行图标记冲突ToolStripMenuItem_Click);
            // 
            // 计算ToolStripMenuItem1
            // 
            this.计算ToolStripMenuItem1.Name = "计算ToolStripMenuItem1";
            this.计算ToolStripMenuItem1.Size = new System.Drawing.Size(53, 24);
            this.计算ToolStripMenuItem1.Text = "计算";
            this.计算ToolStripMenuItem1.Click += new System.EventHandler(this.计算ToolStripMenuItem1_Click);
            // 
            // 开行方案ToolStripMenuItem
            // 
            this.开行方案ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.显示开行方案数据ToolStripMenuItem,
            this.开行方案图ToolStripMenuItem});
            this.开行方案ToolStripMenuItem.Name = "开行方案ToolStripMenuItem";
            this.开行方案ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.开行方案ToolStripMenuItem.Text = "开行方案";
            // 
            // 显示开行方案数据ToolStripMenuItem
            // 
            this.显示开行方案数据ToolStripMenuItem.Name = "显示开行方案数据ToolStripMenuItem";
            this.显示开行方案数据ToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.显示开行方案数据ToolStripMenuItem.Text = "开行方案数据";
            this.显示开行方案数据ToolStripMenuItem.Click += new System.EventHandler(this.显示开行方案数据ToolStripMenuItem_Click);
            // 
            // 开行方案图ToolStripMenuItem
            // 
            this.开行方案图ToolStripMenuItem.Name = "开行方案图ToolStripMenuItem";
            this.开行方案图ToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.开行方案图ToolStripMenuItem.Text = "开行方案图";
            // 
            // 计算ToolStripMenuItem
            // 
            this.计算ToolStripMenuItem.Name = "计算ToolStripMenuItem";
            this.计算ToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.计算ToolStripMenuItem.Text = "计算";
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(1220, 6);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(64, 20);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "上行";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.Location = new System.Drawing.Point(1292, 6);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(64, 20);
            this.checkBox2.TabIndex = 0;
            this.checkBox2.Text = "下行";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.panel1.Location = new System.Drawing.Point(16, 34);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1794, 887);
            this.panel1.TabIndex = 7;
            // 
            // PaintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1710, 928);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PaintForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "运行图显示及检测分析工具V1.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
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
        private System.Windows.Forms.ToolStripMenuItem 检测ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 计算ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 计算ToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem 显示冲突列车数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 运行图标记冲突ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开行方案ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 显示开行方案数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开行方案图ToolStripMenuItem;
    }
}
