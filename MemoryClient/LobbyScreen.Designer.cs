
namespace MemoryClient
{
    partial class LobbyScreen
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
            this.rdyBtn = new System.Windows.Forms.Button();
            this.lobbyGridView = new System.Windows.Forms.DataGridView();
            this.leaveBtn = new System.Windows.Forms.Button();
            this.Login = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isReady = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRoomId = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.lobbyGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // rdyBtn
            // 
            this.rdyBtn.Location = new System.Drawing.Point(83, 200);
            this.rdyBtn.Name = "rdyBtn";
            this.rdyBtn.Size = new System.Drawing.Size(75, 23);
            this.rdyBtn.TabIndex = 0;
            this.rdyBtn.Text = "Ready";
            this.rdyBtn.UseVisualStyleBackColor = true;
            // 
            // lobbyGridView
            // 
            this.lobbyGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lobbyGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Login,
            this.isReady});
            this.lobbyGridView.Location = new System.Drawing.Point(83, 64);
            this.lobbyGridView.Name = "lobbyGridView";
            this.lobbyGridView.Size = new System.Drawing.Size(243, 109);
            this.lobbyGridView.TabIndex = 1;
            // 
            // leaveBtn
            // 
            this.leaveBtn.Location = new System.Drawing.Point(251, 200);
            this.leaveBtn.Name = "leaveBtn";
            this.leaveBtn.Size = new System.Drawing.Size(75, 23);
            this.leaveBtn.TabIndex = 2;
            this.leaveBtn.Text = "Leave";
            this.leaveBtn.UseVisualStyleBackColor = true;
            // 
            // Login
            // 
            this.Login.HeaderText = "Login";
            this.Login.Name = "Login";
            this.Login.ReadOnly = true;
            // 
            // isReady
            // 
            this.isReady.HeaderText = "isReady";
            this.isReady.Name = "isReady";
            this.isReady.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Room Id: ";
            // 
            // txtRoomId
            // 
            this.txtRoomId.AutoSize = true;
            this.txtRoomId.Location = new System.Drawing.Point(139, 27);
            this.txtRoomId.Name = "txtRoomId";
            this.txtRoomId.Size = new System.Drawing.Size(0, 13);
            this.txtRoomId.TabIndex = 4;
            // 
            // LobbyScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 268);
            this.Controls.Add(this.txtRoomId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.leaveBtn);
            this.Controls.Add(this.lobbyGridView);
            this.Controls.Add(this.rdyBtn);
            this.Name = "LobbyScreen";
            this.Text = "LobbyScreen";
            ((System.ComponentModel.ISupportInitialize)(this.lobbyGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button rdyBtn;
        private System.Windows.Forms.DataGridView lobbyGridView;
        private System.Windows.Forms.Button leaveBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Login;
        private System.Windows.Forms.DataGridViewTextBoxColumn isReady;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtRoomId;
    }
}