namespace 路径
{
    partial class Form
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.bt_Search = new System.Windows.Forms.Button();
            this.lb_Name = new System.Windows.Forms.Label();
            this.txt_Input = new System.Windows.Forms.TextBox();
            this.lb_Result = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bt_Search
            // 
            this.bt_Search.Location = new System.Drawing.Point(490, 178);
            this.bt_Search.Name = "bt_Search";
            this.bt_Search.Size = new System.Drawing.Size(78, 38);
            this.bt_Search.TabIndex = 0;
            this.bt_Search.Text = "搜索";
            this.bt_Search.UseVisualStyleBackColor = true;
            this.bt_Search.Click += new System.EventHandler(this.bt_Search_Click);
            // 
            // lb_Name
            // 
            this.lb_Name.AutoSize = true;
            this.lb_Name.Location = new System.Drawing.Point(249, 190);
            this.lb_Name.Name = "lb_Name";
            this.lb_Name.Size = new System.Drawing.Size(67, 15);
            this.lb_Name.TabIndex = 1;
            this.lb_Name.Text = "节点名称";
            // 
            // txt_Input
            // 
            this.txt_Input.Location = new System.Drawing.Point(322, 187);
            this.txt_Input.Name = "txt_Input";
            this.txt_Input.Size = new System.Drawing.Size(149, 25);
            this.txt_Input.TabIndex = 2;
            // 
            // lb_Result
            // 
            this.lb_Result.AutoSize = true;
            this.lb_Result.Location = new System.Drawing.Point(353, 257);
            this.lb_Result.Name = "lb_Result";
            this.lb_Result.Size = new System.Drawing.Size(55, 15);
            this.lb_Result.TabIndex = 3;
            this.lb_Result.Text = "result";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lb_Result);
            this.Controls.Add(this.txt_Input);
            this.Controls.Add(this.lb_Name);
            this.Controls.Add(this.bt_Search);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_Search;
        private System.Windows.Forms.Label lb_Name;
        private System.Windows.Forms.TextBox txt_Input;
        private System.Windows.Forms.Label lb_Result;
    }
}

