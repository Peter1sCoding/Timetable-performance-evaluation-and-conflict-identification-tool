namespace Monkeys_Timetable
{
    partial class AssessForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssessForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.绘制区间列车密度图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询列车停站信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询车站服务列车ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询站间服务列车ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.运行图综合指标ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.绘制区间列车密度图ToolStripMenuItem,
            this.查询列车停站信息ToolStripMenuItem,
            this.查询车站服务列车ToolStripMenuItem,
            this.查询站间服务列车ToolStripMenuItem,
            this.运行图综合指标ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(785, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 绘制区间列车密度图ToolStripMenuItem
            // 
            this.绘制区间列车密度图ToolStripMenuItem.Name = "绘制区间列车密度图ToolStripMenuItem";
            this.绘制区间列车密度图ToolStripMenuItem.Size = new System.Drawing.Size(128, 21);
            this.绘制区间列车密度图ToolStripMenuItem.Text = "绘制区间列车密度图";
            this.绘制区间列车密度图ToolStripMenuItem.Click += new System.EventHandler(this.绘制区间列车密度图ToolStripMenuItem_Click);
            // 
            // 查询列车停站信息ToolStripMenuItem
            // 
            this.查询列车停站信息ToolStripMenuItem.Name = "查询列车停站信息ToolStripMenuItem";
            this.查询列车停站信息ToolStripMenuItem.Size = new System.Drawing.Size(116, 21);
            this.查询列车停站信息ToolStripMenuItem.Text = "查询列车停站信息";
            this.查询列车停站信息ToolStripMenuItem.Click += new System.EventHandler(this.查询列车停站信息ToolStripMenuItem_Click);
            // 
            // 查询车站服务列车ToolStripMenuItem
            // 
            this.查询车站服务列车ToolStripMenuItem.Name = "查询车站服务列车ToolStripMenuItem";
            this.查询车站服务列车ToolStripMenuItem.Size = new System.Drawing.Size(116, 21);
            this.查询车站服务列车ToolStripMenuItem.Text = "查询车站服务列车";
            this.查询车站服务列车ToolStripMenuItem.Click += new System.EventHandler(this.查询车站服务列车ToolStripMenuItem_Click);
            // 
            // 查询站间服务列车ToolStripMenuItem
            // 
            this.查询站间服务列车ToolStripMenuItem.Name = "查询站间服务列车ToolStripMenuItem";
            this.查询站间服务列车ToolStripMenuItem.Size = new System.Drawing.Size(116, 21);
            this.查询站间服务列车ToolStripMenuItem.Text = "查询站间服务列车";
            this.查询站间服务列车ToolStripMenuItem.Click += new System.EventHandler(this.查询站间服务列车ToolStripMenuItem_Click);
            // 
            // 运行图综合指标ToolStripMenuItem
            // 
            this.运行图综合指标ToolStripMenuItem.Name = "运行图综合指标ToolStripMenuItem";
            this.运行图综合指标ToolStripMenuItem.Size = new System.Drawing.Size(104, 21);
            this.运行图综合指标ToolStripMenuItem.Text = "运行图综合指标";
            this.运行图综合指标ToolStripMenuItem.Click += new System.EventHandler(this.运行图综合指标ToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(785, 471);
            this.splitContainer1.SplitterDistance = 287;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer2.Size = new System.Drawing.Size(287, 471);
            this.splitContainer2.SplitterDistance = 186;
            this.splitContainer2.SplitterWidth = 3;
            this.splitContainer2.TabIndex = 0;
            // 
            // AssessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 496);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AssessForm";
            this.Text = "运行图指标统计";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 绘制区间列车密度图ToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ToolStripMenuItem 查询列车停站信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查询车站服务列车ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查询站间服务列车ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 运行图综合指标ToolStripMenuItem;
    }
}