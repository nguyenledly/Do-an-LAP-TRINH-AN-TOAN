using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Client_02
{
    public partial class Form1 : Form
    {
        public string dateTimeIV=null;
        public int sec = 0;
        Socket client;
        IPEndPoint ipep = new IPEndPoint(IPAddress.Loopback, 1234);
        IPEndPoint ipc = new IPEndPoint(IPAddress.Loopback, 9050);
        EndPoint ep;
        byte[] nhanText, guiText, nhanPublicKey,_a,publicKeyC2;
        AES256 aes256 = new AES256();
        SHA256 sha256 = new SHA256();
        DiffieHellman02 hellman = new DiffieHellman02();
        Thread thr = null;

        
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                client.BeginConnect(ipep, new AsyncCallback(Connected), client);
            }
            catch (SocketException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        private void Connected(IAsyncResult i)
        {
            client = ((Socket)i.AsyncState);
            client.EndConnect(i);

            thr = new Thread(new ThreadStart(nhanDuLieu));
            thr.Start();
        }
        int AddPadding()
        {
            string Timestamp = new DateTimeOffset(DateTime.UtcNow).ToUniversalTime().ToString("yyyyMMddHHmmssffff");
            string MHtimeStamp = MD5.maHoaMd5(Timestamp);
            int soByteCuaChuoi = UTF8Encoding.UTF8.GetByteCount(txtText.Text);
            int i = 0;
            string tmpTime = string.Empty;
            if (soByteCuaChuoi % 16 != 0)
            {
                i = 1;
                int length = soByteCuaChuoi;
                while (length % 16 != 0)
                {
                    tmpTime = MHtimeStamp.Substring(0, i);
                    length = length + 1;
                    i = i + 1;
                }

            }
            txtText.Text = txtText.Text + tmpTime;
            //Trả về giá trị số padding cần thêm
            return i-1;
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy giá trị IV và giá trị ban đầu cho progressBar
                dateTimeIV = MD5.maHoaMd5(DateTime.Now.ToString());
                progressBar1.Value = 0;
                progressBar1.Maximum = 2;
                if ((txtText.Text == ""))
                    MessageBox.Show("Text or Key cannot be null!");
                else
                {
                    progressBar1.PerformStep();
                    int paddingValue = AddPadding();
                    string _paddingValue = paddingValue.ToString();
                    ///////////////////////////////////////////////////////////////////////
                    //Tạo publicKey cho Client-02
                    publicKeyC2 = hellman.generatePublicKey();
                    string _publicKey = Convert.ToBase64String(publicKeyC2);
                    //Thuật toán tạo Secret Key cho Client-02
                    byte[] secretKey02 = hellman.secretKey(nhanPublicKey);

                    ///////////////////////////////////////////////////////////////////////
                    //Hiển thị SKey và PKey Client-02
                    if (txtKey.Text == "")
                    {
                        txtKey.Text = sha256.SHA_256(Convert.ToBase64String(_a));
                        txtKey02.Text = Convert.ToBase64String(publicKeyC2);
                    }

                    //Gui di Client-02
                    guiText = new byte[1024 * 24];
                    string encryptedText = Encrypted(txtText.Text, txtKey.Text, dateTimeIV);
                    string md5EncryptedText = MD5.maHoaMd5(encryptedText);
                    txtEncrypted.Text = encryptedText;
                    richMessage.Text += "\nĐÃ GỬI: " + txtText.Text.Substring(0,txtText.TextLength-paddingValue);
                    txtText.Text = "";

                    string finalText = encryptedText + ";" + dateTimeIV + ";" + md5EncryptedText + ";" + _publicKey+";"+_paddingValue;
                    guiText = Encoding.UTF8.GetBytes(finalText);

                    client.BeginSend(guiText, 0, guiText.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                    txtText.Clear();

                    if (txtKey.Text == "")
                    {
                        txtKey.Text = sha256.SHA_256(Convert.ToBase64String(_a));
                        txtKey02.Text = Convert.ToBase64String(publicKeyC2);
                    }
                    
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        void nhanDuLieu()
        {
            while (true)
            {
                if (client.Poll(1000000, SelectMode.SelectRead))
                {

                    nhanText = new byte[1024 * 24];
                    client.BeginReceive(nhanText, 0, nhanText.Length, SocketFlags.None, new AsyncCallback(ReceivedData), client);
                }
            }
        }
        private void SendData(IAsyncResult iar)
        {
            client = (Socket)iar.AsyncState;
            int sent = client.EndSend(iar);

        }
        private void ReceivedData(IAsyncResult iar)
        {
            client = (Socket)iar.AsyncState;
            int recv = client.EndReceive(iar);
            string s = Encoding.ASCII.GetString(nhanText, 0, recv);
            string[] arrString = s.Split(';');
            string encryptedText = arrString[0];
            string iv = arrString[1];
            string md5EncryptedText = arrString[2];
            string publicKey = arrString[3];
            string a = arrString[4];
            string paddingValue = arrString[5];
            nhanPublicKey = Convert.FromBase64String(publicKey);
            _a = Convert.FromBase64String(a);
            txtKey.Invoke((MethodInvoker)delegate ()
            {
                if (txtKey.Text == "")
                    txtKey01.Text = publicKey;
            });

            string hashEncryptedText = MD5.maHoaMd5(encryptedText);

            if (md5EncryptedText == hashEncryptedText)
            {
                if (txtKey.Text == "")
                {
                    richMessage.Invoke((MethodInvoker)delegate ()
                    {
                        richMessage.Text += "\nĐÃ NHẬN: Exchange Key";
                    });
                }
                else
                {
                    string rawText = Decrypted(encryptedText, iv);
                    richMessage.Invoke((MethodInvoker)delegate ()
                    {
                        if (rawText == "")
                            richMessage.Text += "\nĐÃ NHẬN: Changed Key Success!";
                        else
                            richMessage.Text += "\nĐÃ NHẬN: " + rawText.Substring(0,rawText.Length-int.Parse(paddingValue));
                    });
                }
            }
            else
            {
                richMessage.Invoke((MethodInvoker)delegate ()
                {
                    richMessage.Text += "\nĐÃ NHẬN: Nội dung đã bị thay đổi";
                });
            }

        }
        public static string PhatSinhNgauNhienKyTu02()
        {
            char[] chars = "$%#@!*abcdefghijklmnopqrstuvwxyz1234567890?;:ABCDEFGHIJKLMNOPQRSTUVWXYZ^&".ToCharArray();
            Random r = new Random();
            int i = r.Next(chars.Length);
            return chars[i].ToString();
        }
        private void btnSend02_Click(object sender, EventArgs e)
        {
            try
            {
                dateTimeIV = MD5.maHoaMd5(DateTime.Now.ToString());
                progressBar1.Value = 0;
                progressBar1.Maximum = 2;
                if ((txtText.Text == "")) //|| (txtKey.Text == "")
                    MessageBox.Show("Text or Key cannot be null!");
                else
                {
                    progressBar1.PerformStep();
                    int paddingValue = AddPadding();
                    string _paddingValue = paddingValue.ToString();
                    ///////////////////////////////////////////////////////////////////////

                    publicKeyC2 = hellman.generatePublicKey();
                    string _publicKey = Convert.ToBase64String(publicKeyC2);
                    byte[] secretKey02 = hellman.secretKey(nhanPublicKey);

                    ///////////////////////////////////////////////////////////////////////
                    if (txtKey.Text == "")
                    {
                      
                        txtKey.Text = sha256.SHA_256(Convert.ToBase64String(_a));
                        txtKey02.Text = Convert.ToBase64String(publicKeyC2);
                    }

                    //Gui di Client-02
                    guiText = new byte[1024 * 24];
                    string encryptedText = Encrypted(txtText.Text, txtKey.Text, dateTimeIV);

                    string a = encryptedText;
                    int length = encryptedText.Length;
                    Random r = new Random();
                    int randomPos = r.Next(0, length + 1);
                    string stringDauDenRandomPos = a.Substring(0, randomPos);
                    string kyTuCuoiCuaText = a.Substring(randomPos);
                    string textChanged = stringDauDenRandomPos + PhatSinhNgauNhienKyTu02() + kyTuCuoiCuaText;

                    string md5EncryptedText = MD5.maHoaMd5(textChanged);

                    txtEncrypted.Text = encryptedText;

                    richMessage.Text += "\nĐÃ GỬI: " + txtText.Text.Substring(0, txtText.TextLength - paddingValue);
                    txtText.Text = "";

                    string finalText = encryptedText + ";" + dateTimeIV + ";" + md5EncryptedText + ";" + _publicKey+";"+_paddingValue;
                    guiText = Encoding.UTF8.GetBytes(finalText);

                    client.BeginSend(guiText, 0, guiText.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                    txtText.Clear();

                    if (txtKey.Text == "")
                    {
                        txtKey.Text = sha256.SHA_256(Convert.ToBase64String(_a));
                        txtKey02.Text = Convert.ToBase64String(publicKeyC2);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void richMessage_TextChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            sec = 0;
            KhoiTaoTimer();
        }




        public string Encrypted(string rawString, string keyText, string iv )
        {
            string rawText = rawString;
            string key = keyText;
            string encryptedText = aes256.Encrypt(key, rawText, iv);
            return encryptedText;
        }
        public string Decrypted(string TextMaHoa, string Time)
        {
            string encryptedText = TextMaHoa;
            string key = txtKey.Text;
            string rawText = aes256.Decrypt(key, encryptedText, Time);
            return rawText;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sec = sec + 1;
            if (sec == 20)
            {
                MessageBox.Show("Time Out. Change Key!!","CLIENT-02");

        
                txtKey.Text = sha256.SHA_256(Convert.ToBase64String(_a));
                txtKey02.Text = Convert.ToBase64String(publicKeyC2);
                txtKey01.Text = Convert.ToBase64String(nhanPublicKey);

                timer1.Stop();
                sec = 0;
                KhoiTaoTimer();
            }
        }
        public void KhoiTaoTimer()
        {
            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000;
            timer1.Start();
        }

        

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            client.Close();
        }
    }
}
