
namespace MemoryClient
{
    partial class LoginScreen
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
            this.texBoxLogin = new System.Windows.Forms.TextBox();
            this.textBoxPass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Button1 = new System.Windows.Forms.Button();
            this.regBtn = new System.Windows.Forms.Button();
            this.discBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // texBoxLogin
            // 
            this.texBoxLogin.Location = new System.Drawing.Point(165, 53);
            this.texBoxLogin.Name = "texBoxLogin";
            this.texBoxLogin.Size = new System.Drawing.Size(100, 20);
            this.texBoxLogin.TabIndex = 0;
            // 
            // textBoxPass
            // 
            this.textBoxPass.Location = new System.Drawing.Point(165, 94);
            this.textBoxPass.Name = "textBoxPass";
            this.textBoxPass.Size = new System.Drawing.Size(100, 20);
            this.textBoxPass.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username: ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(100, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password: ";
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(101, 130);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(75, 23);
            this.Button1.TabIndex = 4;
            this.Button1.Text = "Login";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // regBtn
            // 
            this.regBtn.Location = new System.Drawing.Point(190, 130);
            this.regBtn.Name = "regBtn";
            this.regBtn.Size = new System.Drawing.Size(75, 23);
            this.regBtn.TabIndex = 5;
            this.regBtn.Text = "Register";
            this.regBtn.UseVisualStyleBackColor = true;
            this.regBtn.Click += new System.EventHandler(this.Button2_Click);
            // 
            // discBtn
            // 
            this.discBtn.Location = new System.Drawing.Point(272, 164);
            this.discBtn.Name = "discBtn";
            this.discBtn.Size = new System.Drawing.Size(75, 23);
            this.discBtn.TabIndex = 6;
            this.discBtn.Text = "Disconnect";
            this.discBtn.UseVisualStyleBackColor = true;
            this.discBtn.Click += new System.EventHandler(this.discBtn_Click);
            // 
            // LoginScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 199);
            this.Controls.Add(this.discBtn);
            this.Controls.Add(this.regBtn);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPass);
            this.Controls.Add(this.texBoxLogin);
            this.Name = "LoginScreen";
            this.Text = "LoginScreen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginScreen_FormClosing);
            this.Load += new System.EventHandler(this.LoginScreen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox texBoxLogin;
        private System.Windows.Forms.TextBox textBoxPass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Button1;
        private System.Windows.Forms.Button regBtn;
        private System.Windows.Forms.Button discBtn;
    }
}