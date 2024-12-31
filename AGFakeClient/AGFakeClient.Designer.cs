using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace AGRunner
{
    partial class AGFakeClient
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AGFakeClient));
            this.Connectbtn = new System.Windows.Forms.Button();
            this.passb = new System.Windows.Forms.TextBox();
            this.userb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.caabtn = new System.Windows.Forms.Button();
            this.xmlbtn = new System.Windows.Forms.Button();
            this.aabtn = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Username = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Password = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Pin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clearbtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pinb = new System.Windows.Forms.TextBox();
            this.Acclistview = new System.Windows.Forms.ListView();
            this.Nickname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label4 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Connectbtn
            // 
            this.Connectbtn.BackColor = System.Drawing.Color.DarkGreen;
            this.Connectbtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Connectbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Connectbtn.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Connectbtn.ForeColor = System.Drawing.Color.White;
            this.Connectbtn.Location = new System.Drawing.Point(195, 19);
            this.Connectbtn.Name = "Connectbtn";
            this.Connectbtn.Size = new System.Drawing.Size(190, 42);
            this.Connectbtn.TabIndex = 0;
            this.Connectbtn.Text = "Connect";
            this.Connectbtn.UseVisualStyleBackColor = false;
            this.Connectbtn.Click += new System.EventHandler(this.Connectbtn_Click);
            // 
            // passb
            // 
            this.passb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.passb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.passb.ForeColor = System.Drawing.Color.White;
            this.passb.Location = new System.Drawing.Point(12, 82);
            this.passb.Name = "passb";
            this.passb.Size = new System.Drawing.Size(151, 26);
            this.passb.TabIndex = 2;
            // 
            // userb
            // 
            this.userb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.userb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userb.ForeColor = System.Drawing.Color.White;
            this.userb.Location = new System.Drawing.Point(12, 30);
            this.userb.Name = "userb";
            this.userb.Size = new System.Drawing.Size(151, 26);
            this.userb.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(7, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 21);
            this.label1.TabIndex = 5;
            this.label1.Text = "Username (required)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 21);
            this.label2.TabIndex = 6;
            this.label2.Text = "Password (required)";
            // 
            // caabtn
            // 
            this.caabtn.BackColor = System.Drawing.Color.DarkGreen;
            this.caabtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.caabtn.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.caabtn.ForeColor = System.Drawing.Color.White;
            this.caabtn.Location = new System.Drawing.Point(195, 392);
            this.caabtn.Name = "caabtn";
            this.caabtn.Size = new System.Drawing.Size(196, 46);
            this.caabtn.TabIndex = 7;
            this.caabtn.Text = "Connect all accounts";
            this.caabtn.UseVisualStyleBackColor = false;
            this.caabtn.Click += new System.EventHandler(this.ConnectAllAccounts);
            // 
            // xmlbtn
            // 
            this.xmlbtn.BackColor = System.Drawing.Color.MidnightBlue;
            this.xmlbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xmlbtn.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.xmlbtn.ForeColor = System.Drawing.Color.White;
            this.xmlbtn.Location = new System.Drawing.Point(219, 324);
            this.xmlbtn.Name = "xmlbtn";
            this.xmlbtn.Size = new System.Drawing.Size(144, 28);
            this.xmlbtn.TabIndex = 8;
            this.xmlbtn.Text = "Open Xml File";
            this.xmlbtn.UseVisualStyleBackColor = false;
            this.xmlbtn.Click += new System.EventHandler(this.xmlbtn_Click);
            // 
            // aabtn
            // 
            this.aabtn.BackColor = System.Drawing.Color.Navy;
            this.aabtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.aabtn.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aabtn.ForeColor = System.Drawing.Color.White;
            this.aabtn.Location = new System.Drawing.Point(219, 82);
            this.aabtn.Name = "aabtn";
            this.aabtn.Size = new System.Drawing.Size(144, 37);
            this.aabtn.TabIndex = 9;
            this.aabtn.Text = "Add Account";
            this.aabtn.UseVisualStyleBackColor = false;
            this.aabtn.Click += new System.EventHandler(this.aabtn_Click);
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Username,
            this.Password,
            this.Pin});
            this.listView1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.ForeColor = System.Drawing.Color.White;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(10, 227);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(177, 211);
            this.listView1.TabIndex = 10;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // Username
            // 
            this.Username.Text = "Username";
            this.Username.Width = 71;
            // 
            // Password
            // 
            this.Password.Text = "Password";
            this.Password.Width = 66;
            // 
            // Pin
            // 
            this.Pin.Text = "Pin";
            // 
            // clearbtn
            // 
            this.clearbtn.BackColor = System.Drawing.Color.MidnightBlue;
            this.clearbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.clearbtn.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.clearbtn.ForeColor = System.Drawing.Color.White;
            this.clearbtn.Location = new System.Drawing.Point(219, 358);
            this.clearbtn.Name = "clearbtn";
            this.clearbtn.Size = new System.Drawing.Size(144, 28);
            this.clearbtn.TabIndex = 11;
            this.clearbtn.Text = "Clear All Accounts";
            this.clearbtn.UseVisualStyleBackColor = false;
            this.clearbtn.Click += new System.EventHandler(this.clearbtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label3.Location = new System.Drawing.Point(12, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 21);
            this.label3.TabIndex = 13;
            this.label3.Text = "Pin (optional)";
            // 
            // pinb
            // 
            this.pinb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.pinb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pinb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.pinb.ForeColor = System.Drawing.Color.White;
            this.pinb.Location = new System.Drawing.Point(12, 144);
            this.pinb.Name = "pinb";
            this.pinb.Size = new System.Drawing.Size(152, 26);
            this.pinb.TabIndex = 12;
            // 
            // Acclistview
            // 
            this.Acclistview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.Acclistview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Nickname,
            this.Status});
            this.Acclistview.ForeColor = System.Drawing.Color.White;
            this.Acclistview.HideSelection = false;
            this.Acclistview.Location = new System.Drawing.Point(398, 25);
            this.Acclistview.Name = "Acclistview";
            this.Acclistview.Size = new System.Drawing.Size(207, 427);
            this.Acclistview.TabIndex = 14;
            this.Acclistview.UseCompatibleStateImageBehavior = false;
            this.Acclistview.View = System.Windows.Forms.View.Details;
            // 
            // Nickname
            // 
            this.Nickname.Text = "Nickname";
            this.Nickname.Width = 100;
            // 
            // Status
            // 
            this.Status.Text = "Status";
            this.Status.Width = 100;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label4.Location = new System.Drawing.Point(460, -2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 26);
            this.label4.TabIndex = 15;
            this.label4.Text = "AccountS";
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // AGFakeClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(47)))), ((int)(((byte)(63)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(606, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Acclistview);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pinb);
            this.Controls.Add(this.clearbtn);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.aabtn);
            this.Controls.Add(this.xmlbtn);
            this.Controls.Add(this.caabtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.userb);
            this.Controls.Add(this.passb);
            this.Controls.Add(this.Connectbtn);
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AGFakeClient";
            this.Text = "AGFakeClient";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AGRunner_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Connectbtn;
        private System.Windows.Forms.TextBox passb;
        private System.Windows.Forms.TextBox userb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button caabtn;
        private System.Windows.Forms.Button xmlbtn;
        private System.Windows.Forms.Button aabtn;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button clearbtn;
        private Label label3;
        private TextBox pinb;
        private ListView Acclistview;
        private Label label4;
        private Timer timer1;
        private ColumnHeader Username;
        private ColumnHeader Password;
        private ColumnHeader Pin;
        private ColumnHeader Nickname;
        private ColumnHeader Status;
    }
}

