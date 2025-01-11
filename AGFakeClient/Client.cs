using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AGRunner
{
    public partial class Client : Form
    {
        private StringBuilder chat = new StringBuilder();
        private string username;
        private ClientHandler client;
        public Client(string username,ClientHandler client)
        {
            
            InitializeComponent();
            this.client = client;
            this.username = username;
            this.Text = username;
        }


            public void AppendText(string text)
            {
            this.Text = $"UserName : {username} PiD: {client.process.Id}";
            if (!string.IsNullOrEmpty(text))
            {
                chat.AppendLine(text);
                var lines = chat.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                if (lines.Length > 185)
                {
                    chat.Clear();
                    chat.Append(string.Join(Environment.NewLine, lines.Skip(lines.Length - 50)));
                }
                textBoxOutput.Text = chat.ToString();
               textBoxOutput.SelectionStart = textBoxOutput.Text.Length;
                textBoxOutput.ScrollToCaret();
            }
        }



        private void Sendbtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))  
            {
                client.SendCommand(textBox1.Text);
                textBox1.Clear();  
            }

        }




        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    client.SendCommand(textBox1.Text);
                    textBox1.Clear();
                }

                e.Handled = true; 
            }
        }

        private void Client_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (!client.process.HasExited)
                {
                    client.process.Kill();
                }
                client.Connectionstat = "Connection Failed Close";


            }
            catch (Exception)
            {
                this.Close();
            }
        }
    }
}
