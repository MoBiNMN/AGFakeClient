using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace AGRunner
{
    public partial class Dialog : Form
    {
        private string Info;
        private string Title;
        private int Styleid;
        private int Dialogid;
        private string Btn1;
        private string Btn2;
        private ClientHandler Client;

        public Dialog(ClientHandler client,string info, string title, int styleid, int dialogid, string btn1, string btn2)
        {
            InitializeComponent();
            this.Client = client;
            this.Info = info;
            this.Title = title;
            this.Styleid = styleid;
            this.Dialogid = dialogid;
            this.Btn1 = btn1;
            this.Btn2 = btn2;
            
        }


        private void Dialog_Load(object sender, EventArgs e)
        {
            this.Text = $"({Dialogid}) {Title}";

            if (Styleid == 0)
            {
                listView1.Visible = false;
                textBox2.Visible = false;
                textBox1.Visible = true;
                textBox1.Text = Info;
                Titlee.Text = Title;
                button1.Text = Btn1;
                button2.Text = Btn2;
            }
            else if (Styleid == 1 || Styleid == 3)
            {
                listView1.Visible = false;
                textBox2.Visible = true;
                textBox1.Visible= true;
                textBox1.Text = Info;
                Titlee.Text = Title;
                button1.Text = Btn1;
                button2.Text = Btn2;
            }
            else if (Styleid == 2 || Styleid == 4 || Styleid == 5) {
                textBox1.Visible = false;
                textBox2.Visible = false;
                listView1.Visible= true;
                Titlee.Text = Title;
                button1.Text = Btn1;
                button2.Text = Btn2;
                listView1.View = View.List;

                foreach (string line in Info.Split(new[] { "||" }, StringSplitOptions.None))
                {
                    ListViewItem item = new ListViewItem(line); 
                    listView1.Items.Add(item); 
                }
                if (listView1.SelectedItems.Count == 0 && listView1.Items.Count > 0)
                {
                    listView1.Items[0].Selected = true;
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int listitem = 0;
            string response = string.IsNullOrEmpty(textBox2.Text) ? "0" : textBox1.Text; 
            if (Styleid == 2 || Styleid == 4 || Styleid == 5)
            {
                if (listView1.SelectedItems.Count == 0) return;
                listitem = listView1.SelectedItems[0].Index;
            }
            Client.SendCommand($"!dr {Dialogid.ToString()} 1 {listitem.ToString()} {response}");
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            int listitem = 0;
            string response = string.IsNullOrEmpty(textBox2.Text) ? "0" : textBox1.Text;
            if (Styleid == 2 || Styleid == 4 || Styleid == 5)
            {
                if (listView1.SelectedItems.Count == 0) return;
                listitem = listView1.SelectedItems[0].Index;
            }
            Client.SendCommand($"!dr {Dialogid.ToString()} 0 {listitem.ToString()} {response}");
            this.Close();
        }

        private void Dialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            Client.DialogForm=null;
        }

        private void Titlee_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
