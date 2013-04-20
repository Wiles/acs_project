using System;
using System.Net;
using System.Windows.Forms;

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
            if (e.KeyChar != (char) 13 || string.IsNullOrWhiteSpace(tb_message.Text) || _connection == null)
            {
                return;
            }

            Message msg;
            if(string.IsNullOrWhiteSpace(tb_key.Text))
            {
                msg = new Message(tb_name.Text, false, tb_message.Text);
                
            }
            else
            {
                var time = Environment.TickCount;
                var fish = new BlowFish(tb_key.Text);

                time = Environment.TickCount - time;
                tb_console.Invoke(new Action(() => tb_console.AppendText(string.Format(@"Encrytion time: {0}{1}ms{0}", Environment.NewLine, time))));
                msg = new Message(tb_name.Text, true, fish.Encrypt_CBC(tb_message.Text));
            }
            _connection.Send(msg);
            tb_console.Invoke(new Action(() => tb_console.AppendText(string.Format(@"Sent: {0}{1}{0}", Environment.NewLine, JsonHelper.Serialize(msg)))));
            tb_messages.Invoke(new Action(() => tb_messages.AppendText(string.Format(@"{0}:{1} {2}", msg.User, tb_message.Text, Environment.NewLine))));
            tb_message.Clear();
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
            
            string text = msg.Text;
            tb_console.Invoke(new Action(() => tb_console.AppendText(string.Format(@"Received: {0}{1}{0}", Environment.NewLine, JsonHelper.Serialize(msg)))));
            if(msg.Encrypted)
            {
                var fish = new BlowFish(tb_key.Text);
                var time = Environment.TickCount;
                text = fish.Decrypt_CBC(text);
                time = Environment.TickCount - time;
                tb_console.Invoke(new Action(() => tb_console.AppendText(string.Format(@"Decrytion time: {0}{1}ms{0}", Environment.NewLine, time))));
            }
            tb_messages.Invoke(new Action(() => tb_messages.AppendText(string.Format(@"{0}:{1} {2}", msg.User, text, Environment.NewLine))));
        }

        private void HandleError(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
}