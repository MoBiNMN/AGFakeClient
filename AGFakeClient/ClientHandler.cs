using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;


namespace AGRunner
{
    public class ClientHandler
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Pin { get; set; }
        public bool Log { get; set; }
        public string Connectionstat { get; set; }
        public bool Connected { get; set; }
        public Process process;
        public Client outputForm;
        public Dialog DialogForm;
 
        public ClientHandler(string username, string password, string pin,bool log)
        {
            Username = username;
            Password = password;
            Pin = pin;
            Log = log;
        }

        public void ConnectA(ClientHandler client)
        {
            string lg = Log ? " --log" : "";
            Connectionstat = "Connecting...";
            if (outputForm == null)
            {
                outputForm = new Client(client.Username,client);
                outputForm.Show();
            }

            try
            {
                process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "AGRak.exe",
                        Arguments = $"--connect {client.Username} {client.Password} {client.Pin}{lg}",
                        RedirectStandardOutput = true,
                        RedirectStandardInput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    }
                };

                process.OutputDataReceived += (sender, args) =>
                {
                    if (args.Data != null)
                    {
                        if (args.Data.Contains("Your password doesn't correct."))
                        {

                            MessageBox.Show($"[{client.Username}] Your password doesn't correct.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                            client.process?.Kill();
                            client.outputForm?.Close();
                            Connectionstat = "Connection Failed Password incorrect";

                        }
                        else if(args.Data.Contains("Reconnecting in 12 seconds"))
                        {
                            Connectionstat = "Reconnecting...";
                        }
                        else if (Connectionstat != "Connected" && args.Data == "It appears that you're using RakSAMP." ||
    args.Data == "You will be automatically put to sleep and you cannot get out from asleep mode." ||
    args.Data.Contains("Welcome "))
                        {
                            Connectionstat = "Connected";
                        }
                        else if (args.Data.Contains("[DialogID") && args.Data.Contains("[DialogStyle"))
                        {

                                int dialogId = int.Parse(args.Data.Split(new string[] { "[DialogID:" }, StringSplitOptions.None)[1].Split(new string[] { "] [DialogStyle:" }, StringSplitOptions.None)[0]);
                                int dialogStyle = int.Parse(args.Data.Split(new string[] { "] [DialogStyle:" }, StringSplitOptions.None)[1].Split(new string[] { "] [DialogTitle:" }, StringSplitOptions.None)[0]);
                                string dialogTitle = args.Data.Split(new string[] { "] [DialogTitle: " }, StringSplitOptions.None)[1].Split(new string[] { "] [DialogInfo:" }, StringSplitOptions.None)[0];
                                string dialogInfo = args.Data.Split(new string[] { "] [DialogInfo:" }, StringSplitOptions.None)[1].Split(new string[] { "] [DialogBtn1:" }, StringSplitOptions.None)[0];
                                string dialogBtn1 = args.Data.Split(new string[] { "] [DialogBtn1:" }, StringSplitOptions.None)[1].Split(new string[] { "] [DialogBtn2:" }, StringSplitOptions.None)[0];
                                string dialogBtn2 = args.Data.Split(new string[] { "] [DialogBtn2:" }, StringSplitOptions.None)[1].Split(new string[] { "]" }, StringSplitOptions.None)[0];

                           
                            if (DialogForm == null)
                            {
                                Thread DialogFormThread = new Thread(() =>
                                {
                                    DialogForm = new Dialog(client, dialogInfo, dialogTitle, dialogStyle, dialogId, dialogBtn1, dialogBtn2);
                                    DialogForm.ShowDialog();
                                });

                                DialogFormThread.Start();

                            }

                        }
                        else
                        {
                            outputForm.AppendText(args.Data);
                        }

                    }
                };
                process.Start();
                process.BeginOutputReadLine();
                
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error in connecting: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void SendCommand(string command)
        {
            command += "\n";
            if (process != null && !process.HasExited)
            {
                StreamWriter sw = process.StandardInput;
                sw.WriteLine(command);
                sw.Flush();
            }

        }
    
}
    public class AGClients
    {
        public List<ClientHandler> Clients { get; set; } = new List<ClientHandler>();
    }
}
