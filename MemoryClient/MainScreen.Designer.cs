
namespace MemoryClient
{
    partial class MainScreen
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isPrivate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Players = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.begun = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.clsBtn = new System.Windows.Forms.Button();
            this.logoutBtn = new System.Windows.Forms.Button();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.createBtn = new System.Windows.Forms.Button();
            this.joinRoomBtn = new System.Windows.Forms.Button();
            this.txtUsername = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.isPrivate,
            this.Players,
            this.begun});
            this.dataGridView1.Location = new System.Drawing.Point(133, 60);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(443, 156);
            this.dataGridView1.TabIndex = 0;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // isPrivate
            // 
            this.isPrivate.HeaderText = "isPrivate";
            this.isPrivate.Name = "isPrivate";
            this.isPrivate.ReadOnly = true;
            // 
            // Players
            // 
            this.Players.HeaderText = "Players";
            this.Players.Name = "Players";
            this.Players.ReadOnly = true;
            // 
            // begun
            // 
            this.begun.HeaderText = "Game started";
            this.begun.Name = "begun";
            this.begun.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Available rooms:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(133, 245);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 39);
            this.button2.TabIndex = 3;
            this.button2.Text = "Start solo game";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // clsBtn
            // 
            this.clsBtn.Location = new System.Drawing.Point(645, 296);
            this.clsBtn.Name = "clsBtn";
            this.clsBtn.Size = new System.Drawing.Size(75, 23);
            this.clsBtn.TabIndex = 4;
            this.clsBtn.Text = "Close";
            this.clsBtn.UseVisualStyleBackColor = true;
            this.clsBtn.Click += new System.EventHandler(this.clsBtn_Click);
            // 
            // logoutBtn
            // 
            this.logoutBtn.Location = new System.Drawing.Point(564, 296);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Size = new System.Drawing.Size(75, 23);
            this.logoutBtn.TabIndex = 5;
            this.logoutBtn.Text = "Logout";
            this.logoutBtn.UseVisualStyleBackColor = true;
            this.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click);
            // 
            // refreshBtn
            // 
            this.refreshBtn.Location = new System.Drawing.Point(609, 60);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(75, 23);
            this.refreshBtn.TabIndex = 6;
            this.refreshBtn.Text = "Refresh";
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // createBtn
            // 
            this.createBtn.Location = new System.Drawing.Point(609, 99);
            this.createBtn.Name = "createBtn";
            this.createBtn.Size = new System.Drawing.Size(96, 23);
            this.createBtn.TabIndex = 7;
            this.createBtn.Text = "Create a room";
            this.createBtn.UseVisualStyleBackColor = true;
            this.createBtn.Click += new System.EventHandler(this.createBtn_Click);
            // 
            // joinRoomBtn
            // 
            this.joinRoomBtn.Location = new System.Drawing.Point(609, 140);
            this.joinRoomBtn.Name = "joinRoomBtn";
            this.joinRoomBtn.Size = new System.Drawing.Size(85, 23);
            this.joinRoomBtn.TabIndex = 8;
            this.joinRoomBtn.Text = "Join room";
            this.joinRoomBtn.UseVisualStyleBackColor = true;
            this.joinRoomBtn.Click += new System.EventHandler(this.joinRoomBtn_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.AutoSize = true;
            this.txtUsername.Location = new System.Drawing.Point(130, 19);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(0, 13);
            this.txtUsername.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Welcome back ";
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 331);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.joinRoomBtn);
            this.Controls.Add(this.createBtn);
            this.Controls.Add(this.refreshBtn);
            this.Controls.Add(this.logoutBtn);
            this.Controls.Add(this.clsBtn);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "MainScreen";
            this.Text = "MainScreen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainScreen_FormClosing);
            this.Load += new System.EventHandler(this.MainScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button clsBtn;
        private System.Windows.Forms.Button logoutBtn;
        private System.Windows.Forms.Button refreshBtn;
        private System.Windows.Forms.Button createBtn;
        private System.Windows.Forms.Button joinRoomBtn;
        private System.Windows.Forms.Label txtUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn isPrivate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Players;
        private System.Windows.Forms.DataGridViewTextBoxColumn begun;
    }
}