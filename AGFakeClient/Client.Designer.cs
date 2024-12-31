using System.Windows.Forms;
using System;

namespace AGRunner
{
    partial class Client
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Client));
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Sendbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.textBoxOutput.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxOutput.ForeColor = System.Drawing.Color.White;
            this.textBoxOutput.Location = new System.Drawing.Point(0, 0);
            this.textBoxOutput.Multiline = true;
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.ReadOnly = true;
            this.textBoxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxOutput.Size = new System.Drawing.Size(782, 393);
            this.textBoxOutput.TabIndex = 0;
            this.textBoxOutput.TextChanged += new System.EventHandler(this.textBoxOutput_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(0, 399);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(698, 29);
            this.textBox1.TabIndex = 1;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // Sendbtn
            // 
            this.Sendbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Sendbtn.BackColor = System.Drawing.Color.MediumBlue;
            this.Sendbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Sendbtn.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sendbtn.ForeColor = System.Drawing.Color.White;
            this.Sendbtn.Location = new System.Drawing.Point(704, 399);
            this.Sendbtn.Name = "Sendbtn";
            this.Sendbtn.Size = new System.Drawing.Size(78, 29);
            this.Sendbtn.TabIndex = 2;
            this.Sendbtn.Text = "Send";
            this.Sendbtn.UseVisualStyleBackColor = false;
            this.Sendbtn.Click += new System.EventHandler(this.Sendbtn_Click);
            // 
            // Client
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(47)))), ((int)(((byte)(63)))));
            this.ClientSize = new System.Drawing.Size(782, 432);
            this.Controls.Add(this.Sendbtn);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBoxOutput);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Client";
            this.Text = "Output";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Client_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.TextBox textBoxOutput;
        private TextBox textBox1;
        private Button Sendbtn;
    }

        #endregion
    }

