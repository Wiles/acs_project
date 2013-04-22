using System;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;
using System.Text;

namespace Blowfish
{
    public partial class Form1 : Form
    {
        private IAsyncSocket _connection;

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_server_Click(object sender, EventArgs e)
        {
            try{
                btn_client.Enabled = false;
                btn_server.Enabled = false;
                var ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                var ipAddress = ipHostInfo.AddressList[0];
                _connection = new AsyncServer(new IPEndPoint(ipAddress, int.Parse(tb_port.Text)), Update, HandleError);
            }
            catch(Exception ex)
            {
                HandleError(ex);
            }
        }

        private void tb_message_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar != (char)13 || string.IsNullOrWhiteSpace(tb_message.Text) || _connection == null)
                {
                    return;
                }

                Message msg;
                if (string.IsNullOrWhiteSpace(tb_key.Text))
                {
                    msg = new Message(tb_name.Text, false, tb_message.Text);
                }
                else
                {
                    var fish = new BlowFish(Encoding.UTF8.GetBytes(tb_key.Text));

                    var sw = new Stopwatch();
                    sw.Start();
                    var text = fish.Encrypt_CBC(tb_message.Text);
                    sw.Stop();
                    tb_console.Invoke(new Action(() => tb_console.AppendText(string.Format(@"Encrytion time: {0}{1} ticks{0}", Environment.NewLine, sw.ElapsedTicks))));
                    msg = new Message(tb_name.Text, true, text);
                }
                _connection.Send(msg);
                tb_console.Invoke(new Action(() => tb_console.AppendText(string.Format(@"Sent: {0}{1}{0}", Environment.NewLine, JsonHelper.Serialize(msg)))));
                tb_messages.Invoke(new Action(() => tb_messages.AppendText(string.Format(@"{0}:{1} {2}", msg.User, tb_message.Text, Environment.NewLine))));
                tb_message.Clear();
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }

        private void btn_client_Click(object sender, EventArgs e)
        {
            try
            {
                btn_client.Enabled = false;
                btn_server.Enabled = false;
                var ipHostInfo = Dns.GetHostEntry(tb_ip.Text);
                var ipAddress = ipHostInfo.AddressList[0];
                _connection = new AsyncClient(new IPEndPoint(ipAddress, int.Parse(tb_port.Text)),
                                              Update, HandleError);
            }
            catch(Exception ex)
            {
                HandleError(ex);
            }
        }

        private void Update(Message msg)
        {
            try
            {
                string text = msg.Text;
                tb_console.Invoke(new Action(() => tb_console.AppendText(string.Format(@"Received: {0}{1}{0}", Environment.NewLine, JsonHelper.Serialize(msg)))));

                if (msg.Encrypted)
                {
                    var fish = new BlowFish(Encoding.UTF8.GetBytes(tb_key.Text));

                    var sw = new Stopwatch();
                    sw.Start();
                    text = fish.Decrypt_CBC(text);
                    sw.Stop();
                    tb_console.Invoke(new Action(() => tb_console.AppendText(string.Format(@"Decrytion time: {0}{1} ticks{0}", Environment.NewLine, sw.ElapsedTicks))));
                }
                tb_messages.Invoke(new Action(() => tb_messages.AppendText(string.Format(@"{0}:{1} {2}", msg.User, text, Environment.NewLine))));
            }
            catch (Exception e)
            {
                HandleError(e);
            }
        }

        private void HandleError(Exception ex)
        {
            MessageBox.Show(ex.Message);
            if(_connection != null)
            {
                _connection.close();
            }
            Environment.Exit(-1);
        }
    }
}