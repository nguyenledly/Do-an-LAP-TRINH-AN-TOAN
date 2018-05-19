using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_01
{
    public partial class Form1 : Form
    {

        public string dateTimeIV = null;
        public int sec = 0;
        AES256 aes256 = new AES256();
        SHA256 sha256 = new SHA256();
        DiffieHellman01 hellman01 = new DiffieHellman01();
        Socket client01;
        Socket client02;
        IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 1234);
        IPEndPoint ipc = new IPEndPoint(IPAddress.Loopback, 1234);
        byte[] nhanText, nhanPublicKey, guiText, secretKey01, publicKeyC1;
        Thread thr = null;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client01 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            client01.Bind(ipep);
            client01.Listen(4);
            //client02 = client01.Accept();
            client01.BeginAccept(new AsyncCallback(CallAccept), client01);
           
        }
        private void CallAccept(IAsyncResult i)
        {
            client02 = ((Socket)i.AsyncState).EndAccept(i);
            thr = new Thread(new ThreadStart(nhanDuLieu));
            thr.Start();
        }
        /// <summary>
        /// Tính số byte của message để thêm padding
        /// </summary>
        /// <returns></returns>
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
                    i++;
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

                if ((txtText.Text == "")) //|| (txtKey.Text == "")
                    MessageBox.Show("Text or Key cannot be null!");
                else
                {
                    progressBar1.PerformStep();
                    //Thực hiện padding chuỗi Message
                    int paddingValue =AddPadding();
                    string _paddingValue = paddingValue.ToString();

                    //Tạo publicKey cho Client-01
                    publicKeyC1 = hellman01.generatePublicKey();
                    string _publicKey = Convert.ToBase64String(publicKeyC1);

                    nhanPublicKey = publicKeyC1;
                    //Thuật toán tạo Secret Key cho Client-01

                    secretKey01 = hellman01.secretKey(nhanPublicKey);
                    string _a = Convert.ToBase64String(secretKey01);

                    ///////////////////////////////////////////////////////////////////////////
                    //////Phần này trao đổi Key Diffie Hellman
                    //Hiển thị SKey và PKey Client-01
                    if (txtKey.Text == "")
                    {
                        
                        txtKey.Text = sha256.SHA_256(Convert.ToBase64String(secretKey01));
                        txtKey01.Text = Convert.ToBase64String(publicKeyC1);
                    }

                    //Gui di Client-02
                    //Gửi Chuỗi text mã hóa, MD5 Chuỗi mã hóa và IV
                    guiText = new byte[1024 * 24];
                    string encryptedText = Encrypted(txtText.Text,txtKey.Text,dateTimeIV);
                    string md5EncryptedText = MD5.maHoaMd5(encryptedText);
                    txtEncrypted.Text = encryptedText;
                    
                    //Vì txtText (Message) đã bị chuyển hóa padding, nên phải cắt chuỗi lại để hiện thị đúng
                    richMessage.Text += "\nĐÃ GỬI: " + txtText.Text.Substring(0,txtText.TextLength - paddingValue);
                    txtText.Text = "";
                    //Gửi toàn bộ chuỗi ở trên
                    string finalText = encryptedText + ";" + dateTimeIV + ";" + md5EncryptedText + ";" + _publicKey + ";" + _a+";"+_paddingValue;
                    guiText = Encoding.UTF8.GetBytes(finalText);
                    //Bắt đầu gửi
                    client02.BeginSend(guiText, 0, guiText.Length, SocketFlags.None, new AsyncCallback(SendData), client02);
                    txtText.Clear();

                    if(txtKey.Text=="")
                    {
                        txtKey.Text = sha256.SHA_256(Convert.ToBase64String(secretKey01));
                        txtKey01.Text = Convert.ToBase64String(publicKeyC1);
                    }

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        /// <summary>
        /// Nhận dữ liệu liên tục
        /// </summary>
        void nhanDuLieu()
        {
            while (true)
            {
                if (client02.Poll(1000000, SelectMode.SelectRead))
                {

                    nhanText = new byte[1024*24];
                    client02.BeginReceive(nhanText, 0, nhanText.Length, SocketFlags.None, new AsyncCallback(ReceivedData), client02);
                }
            }
        }
        private void SendData(IAsyncResult iar)
        {
            client02 = (Socket)iar.AsyncState;
            int sent = client02.EndSend(iar);

        }
        private void ReceivedData(IAsyncResult iar)
        {
           
            {
                client02 = (Socket)iar.AsyncState;
                int recv = client02.EndReceive(iar);
                //Nhận dữ liệu bên Client-02 gửi
                string s = Encoding.ASCII.GetString(nhanText, 0, recv);
                //Tách mảng chuỗi theo dấu ';' : Chuỗi mã hóa, IV, MD5 Chuỗi mã hóa, PKey, Padding của Client-02
                string[] arrString = s.Split(';');
                string encryptedText = arrString[0];
                string iv = arrString[1];
                string md5EncryptedText = arrString[2];
                string publicKey = arrString[3];
                string paddingValue = arrString[4];
                nhanPublicKey = Convert.FromBase64String(publicKey);
                byte[] secretKey01 = hellman01.secretKey(nhanPublicKey);
                txtKey.Invoke((MethodInvoker)delegate ()
                {
                    if(txtKey02.Text== "Key Client-02")
                        txtKey02.Text = publicKey;
                });
                //So sánh chuỗi MD5 ĐÃ GỬI và chuỗi tự hash MD5 : Phát hiện có thay đổi gói tin trên đường truyền hay ko!
                string hashEncryptedText = MD5.maHoaMd5(encryptedText);

                if (md5EncryptedText == hashEncryptedText)
                {
                    string rawText = Decrypted(encryptedText, iv);
                    richMessage.Invoke((MethodInvoker)delegate ()
                    {
                        //Khi ĐÃ NHẬN rawMessage, cắt chuỗi theo số byte đã padding để hiện message 
                        richMessage.Text += "\nĐÃ NHẬN: " + rawText.Substring(0, rawText.Length - int.Parse(paddingValue));
                    });
                }
                else
                {
                    richMessage.Invoke((MethodInvoker)delegate ()
                    {
                        richMessage.Text += "\nĐÃ NHẬN: Nội dung đã bị thay đổi";
                    });
                }
            }
        }


        private void richMessage_TextChanged(object sender, EventArgs e)
        {
            //Khi Rich Message thay đổi sẽ reset lại thời gian : Session
            timer1.Stop();
            sec = 0;
            KhoiTaoTimer();
        }
        /// <summary>
        /// PHẦN DƯỚI ĐÂY GIỐNG NHƯ TRUYỀN DỮ LIỆU, NHƯNG CỐ TÌNH THAY ĐỔI BẢN TIN: SEND + NOISE
        /// </summary>
        /// <returns></returns>
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

                dateTimeIV = MD5.maHoaMd5( DateTime.Now.ToString());
                progressBar1.Value = 0;
                progressBar1.Maximum = 2;
                if ((txtText.Text == "")) //|| (txtKey.Text == "")
                    MessageBox.Show("Text or Key cannot be null!");
                else
                {
                    progressBar1.PerformStep();
                    int paddingValue = AddPadding();
                    string _paddingValue = paddingValue.ToString();
                    ///////////////////////////////////////////////////////////////////////////

                    publicKeyC1 = hellman01.generatePublicKey();
                    string _publicKey = Convert.ToBase64String(publicKeyC1);

                    nhanPublicKey = publicKeyC1;

                    secretKey01 = hellman01.secretKey(nhanPublicKey);
                    string _secretKey01 = Convert.ToBase64String(secretKey01);
                    string _a = _secretKey01;
                    ///////////////////////////////////////////////////////////////////////////
                    if (txtKey.Text == "")
                    {
                        
                        txtKey.Text = sha256.SHA_256(Convert.ToBase64String(secretKey01));
                        txtKey01.Text = Convert.ToBase64String(publicKeyC1);
                    }

                    //Gui di Client-02
                    
                    guiText = new byte[1024 * 24];

                    string encryptedText = Encrypted(txtText.Text, txtKey.Text, dateTimeIV);

                    string a = encryptedText;
                    int length = encryptedText.Length;
                    Random r = new Random();
                    int randomPos = r.Next(0, length + 1);
                    //Thêm vào bất kỳ 1 ký tự nào đó vào vị trí bất kỳ trong Chuỗi text đã mã hóa
                    string stringDauDenRandomPos = a.Substring(0, randomPos);
                    string kyTuCuoiCuaText = a.Substring(randomPos);
                    string textChanged = stringDauDenRandomPos + PhatSinhNgauNhienKyTu02() + kyTuCuoiCuaText;

                    string md5EncryptedText = MD5.maHoaMd5(textChanged);

                    txtEncrypted.Text = encryptedText;
                    richMessage.Text += "\nĐÃ GỬI: " + txtText.Text.Substring(0, txtText.TextLength - paddingValue);
                    txtText.Text = "";


                    string finalText = encryptedText + ";" + dateTimeIV + ";" + md5EncryptedText + ";" + _publicKey + ";" + _a+";"+_paddingValue;
                    guiText = Encoding.UTF8.GetBytes(finalText);

                    client02.BeginSend(guiText, 0, guiText.Length, SocketFlags.None, new AsyncCallback(SendData), client02);
                    txtText.Clear();

                    if (txtKey.Text == "")
                    {
                        txtKey.Text = sha256.SHA_256(Convert.ToBase64String(secretKey01));
                        txtKey01.Text = Convert.ToBase64String(publicKeyC1);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public string Encrypted(string rawString, string keyText, string iv)
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
                MessageBox.Show("Time Out. Change Key!!!","CLIENT-01");

           
                txtKey.Text = sha256.SHA_256(Convert.ToBase64String(secretKey01));
                txtKey01.Text = Convert.ToBase64String(publicKeyC1);
                txtKey02.Text = Convert.ToBase64String(nhanPublicKey);

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
            client01.Close();
        }
    }
}
