using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace AGRunner
{

    
    public partial class AGFakeClient : Form
    {
        private static AGClients AGclients = new AGClients();
        public AGFakeClient()
        {
            InitializeComponent();
        }
        public void refreshacclistview()
        {
            Acclistview.Items.Clear();
            for (int i  = AGclients.Clients.Count - 1; i >= 0; i--) 
            {
                if (!AGclients.Clients[i].Connectionstat.Contains("Connection Failed"))
                {
                        ListViewItem item = new ListViewItem(AGclients.Clients[i].Username);
                        item.SubItems.Add(AGclients.Clients[i].Connectionstat);
                        Acclistview.Items.Add(item);                  
                }
                else
                {
                    AGclients.Clients.Remove(AGclients.Clients[i]);
                }
            }

        }
        
        private void LoadAccounts()
        {

            listView1.Items.Clear();
            string xmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Accounts.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlPath);



            XmlNodeList users = doc.GetElementsByTagName("user");
            foreach (XmlNode userNode in users)
            {

                string username = userNode.Attributes["username"]?.Value;
                string password = userNode.Attributes["password"]?.Value;
                string pin = userNode.Attributes["pin"]?.Value;

                ListViewItem item = new ListViewItem(username);
                item.SubItems.Add(password);
                item.SubItems.Add(pin);

                listView1.Items.Add(item);
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {

            string exePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AGRak.exe");
            if (!File.Exists(exePath))
            {
                MessageBox.Show("AGRak.exe does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            string xmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Accounts.xml");
            if (!File.Exists(xmlPath))
            {
                try
                {

                    XmlWriterSettings settings = new XmlWriterSettings();
                    settings.Indent = true;

                    using (XmlWriter writer = XmlWriter.Create(xmlPath, settings))
                    {
                        writer.WriteStartDocument();
                        writer.WriteStartElement("users");
                        writer.WriteStartElement("user");
                        writer.WriteAttributeString("username", "testuser");
                        writer.WriteAttributeString("password", "testpass");
                        writer.WriteAttributeString("pin", "0");

                        writer.WriteEndElement();
                        writer.WriteStartElement("user");
                        writer.WriteAttributeString("username", "username");
                        writer.WriteAttributeString("password", "password");
                        writer.WriteAttributeString("pin", "1234");

                        writer.WriteEndElement();
                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                    }
                    try
                    {
                        LoadAccounts();
                        Process.Start(xmlPath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error opening file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Environment.Exit(0);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating XML file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                }

            }
            LoadAccounts();
            foreach (var process in System.Diagnostics.Process.GetProcesses())
            {
                if (process.ProcessName.Contains("AGRak"))
                {
                    process.Kill();
                }
            }
            timer1.Start();

        }

        private void Connectbtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(userb.Text))
            {
                MessageBox.Show("Password is empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(passb.Text))
            {
                MessageBox.Show("Username is empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string exePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AGRak.exe");
            if (!File.Exists(exePath))
            {
                MessageBox.Show("AGRak.exe does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ClientHandler client = new ClientHandler(userb.Text, passb.Text, pinb.Text);
            AGclients.Clients.Add(client);
            client.ConnectA(client);
            refreshacclistview();
        }

        private void ConnectAllAccounts(object sender, EventArgs e)
        {

            string xmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Accounts.xml");
            if (!System.IO.File.Exists(xmlPath))
            {
                MessageBox.Show("Accounts.xml does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(xmlPath);

            XmlNodeList userNodes = doc.GetElementsByTagName("user");

            foreach (XmlNode userNode in userNodes)
            {
                string username = userNode.Attributes["username"]?.Value;
                string password = userNode.Attributes["password"]?.Value;
                string pin = userNode.Attributes["pin"]?.Value;


                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    continue;
                }

                ClientHandler client = new ClientHandler(username, password,pin);
                AGclients.Clients.Add(client);
                client.ConnectA(client);
               
            }
            refreshacclistview();
        }

        private void xmlbtn_Click(object sender, EventArgs e)
        {
            string xmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Accounts.xml");
            if (!File.Exists(xmlPath))
            {
                try
                {

                    XmlWriterSettings settings = new XmlWriterSettings();
                    settings.Indent = true;  

                    using (XmlWriter writer = XmlWriter.Create(xmlPath, settings))
                    {
                        writer.WriteStartDocument(); 
                        writer.WriteStartElement("users"); 
                        writer.WriteStartElement("user");
                        writer.WriteAttributeString("username", "testuser");
                        writer.WriteAttributeString("password", "testpass");
                        writer.WriteAttributeString("console", "1");
                        writer.WriteEndElement(); 
                        writer.WriteStartElement("user");
                        writer.WriteAttributeString("username", "username");
                        writer.WriteAttributeString("password", "password");
                        writer.WriteAttributeString("console", "0");
                        writer.WriteEndElement();  
                        writer.WriteEndElement();  
                        writer.WriteEndDocument();  
                    }
                    try
                    {
                        LoadAccounts();
                        Process.Start(xmlPath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error opening file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating XML file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                try
                {
                    Process.Start(xmlPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error opening file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void aabtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(userb.Text))
            {
                MessageBox.Show("Password is empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(passb.Text))
            {
                MessageBox.Show("Username is empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                string xmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Accounts.xml");
                XmlDocument doc = new XmlDocument();
                doc.Load(xmlPath);


                XmlElement userElement = doc.CreateElement("user");

                userElement.SetAttribute("username", userb.Text);
                userElement.SetAttribute("password", passb.Text);

                XmlNode root = doc.SelectSingleNode("/users");
                root.AppendChild(userElement);

                doc.Save(xmlPath);
                LoadAccounts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding account to XML file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            string xmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Accounts.xml");
            if (!File.Exists(xmlPath))
            {
                try
                {
                    XmlWriterSettings settings = new XmlWriterSettings();
                    settings.Indent = true;

                    using (XmlWriter writer = XmlWriter.Create(xmlPath, settings))
                    {
                        writer.WriteStartDocument();
                        writer.WriteStartElement("users");
                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                    }
                    try
                    {
                        LoadAccounts();
                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.Load(xmlPath);


                        XmlNode root = xmlDoc.DocumentElement;
                        root.RemoveAll();

                        xmlDoc.Save(xmlPath);
                        LoadAccounts();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error Removing accounts: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating XML file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                try
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(xmlPath);


                    XmlNode root = xmlDoc.DocumentElement;
                    root.RemoveAll();

                    xmlDoc.Save(xmlPath);
                    LoadAccounts();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Removing accounts: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void AGRunner_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (var process in System.Diagnostics.Process.GetProcesses())
            {
                if (process.ProcessName.Contains("AGRak"))
                {
                    process.Kill();
                }
            }
            Environment.Exit(0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                refreshacclistview();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erorr : {ex.Message}");
            }
        }
    }
}
