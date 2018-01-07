using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MailServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SmtpClient mailclient = new SmtpClient("smtp.gmail.com", 587);
                mailclient.EnableSsl = true;
                mailclient.Credentials = new NetworkCredential(txtFrom.Text, txtPass.Text);

                MailMessage message = new MailMessage(txtFrom.Text, txtTo.Text);
                message.Subject = txtSubject.Text;
                message.Body = txtBody.Text;



                //Nếu có nhập Cc
                if (txtCc.Text != "")
                {
                    //Cắt chuỗi Cc bằng dấu ";"
                    string[] cc = txtCc.Text.Split(';');

                    foreach (var _cc in cc)
                    {
                        message.CC.Add(_cc.ToString());
                    }
                }

                //Nếu có nhập Bcc
                if (txtBcc.Text != "")
                {
                    //Cắt chuỗi Bcc bằng dấu ";"
                    string[] bcc = txtBcc.Text.Split(';');

                    foreach (var _bcc in bcc)
                    {
                        message.Bcc.Add(_bcc.ToString());
                    }
                }

                //Kiểm tra nếu có file trong listBox1
                if (listBox1.Items.Count > 0)
                {
                    foreach (var filename in listBox1.Items)
                    {
                        //Kiểm tra file có tồn tại trong ổ đĩa không
                        if (File.Exists(filename.ToString()))
                        {
                            //Thêm file đính kèm vào tin nhắn
                            message.Attachments.Add(new Attachment(filename.ToString()));
                        }
                    }
                }

                mailclient.Send(message);
                MessageBox.Show("Mail đã được gửi đi", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("eror"+ex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Cho phép chọn nhiều dòng trong OpenFileDialog
            openFileDialog1.Multiselect = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (var filename in openFileDialog1.FileNames)
                {
                    //Thêm các file đã chọn vào listBox1
                    listBox1.Items.Add(filename.ToString());
                }
            }
        }
    }
}
