using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientApp
{
    public partial class Form : System.Windows.Forms.Form
    {
        private int id = 0;
        private string login = string.Empty;

        private void UpdateList()
        {
            listBox2.Items.Clear();

            var help_function = new HelpFunction("http://185.86.78.146/helpmain.php", id);

            var list = help_function.GetDataBox();
            foreach (var item in list)
                listBox2.Items.Add(item.Name);
        }

        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://185.86.78.146/"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public Form(int id, string login)
        {
            InitializeComponent();
            this.id = id;
            this.login = login;

            UpdateList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                var localPath = listBox1.SelectedItem.ToString();
                SendFileServer(localPath);
                var helpfunction = new HelpFunction("http://185.86.78.146/main.php");
                try
                {
                    Task.Run(() =>
                    {
                        var file_name = localPath.Remove(0, localPath.LastIndexOf('\\') + 1);
                        MessageBox.Show(helpfunction.SendDataServer(file_name, id.ToString()).Result);
                        Task.Delay(1000);
                    });
                    UpdateList();
                }
                catch
                {
                    MessageBox.Show("Виникли проблеми перезапустіть клієнт!");
                }
            }
            else MessageBox.Show("Оберіть файл для завантаження!");
        }

        private void SendFileServer(string localPath)
        {
            var Client = new WebClient();
            Client.Headers.Add("Content-Type", "binary/octet-stream");

            var result = Client.UploadFile("http://185.86.78.146/1.php", "POST", localPath);
            var s = Encoding.UTF8.GetString(result, 0, result.Length);
        }

        private void listBox1_DragDrop_1(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (string file in files)
                listBox1.Items.Add(file);
        }

        private void listBox1_DragEnter_1(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
            Environment.Exit(0);
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckForInternetConnection())
                MessageBox.Show("З'єднання з хмариним сховищем добре!");
            else
                MessageBox.Show("Виникли проблеми перезапустіть клієнт!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var wc = new WebClient();
            var saveFileDialog1 = new SaveFileDialog();

            var url = string.Empty;
            var save_path = string.Empty;

            if (listBox2.SelectedItem != null)
            {
                var type = Path.GetExtension(listBox2.SelectedItem.ToString());
                if (type == ".png" || type == ".jpg" || type == ".gif" || type == ".jpeg" || type == ".bmp")
                {
                    url = "http://185.86.78.146/Ruler/" + listBox2.SelectedItem.ToString();
                    saveFileDialog1.Filter = "Bitmap Image (.bmp)|*.bmp|Gif Image (.gif)|*.gif |JPEG Image (.jpeg)|*.jpeg |Png Image (.png)|*.png |Tiff Image (.tiff)|*.tiff |Wmf Image (.wmf)|*.wmf";
                }
                else
                {
                    url = "http://185.86.78.146/photo/Ruler/" + listBox2.SelectedItem.ToString();
                    saveFileDialog1.Filter = "Execl files (*.xls)|*.xls |RichTextFormate | *.rtf |Text Files | *.txt |All Files| *.*";
                }

                saveFileDialog1.InitialDirectory = @"C:\";
                saveFileDialog1.Title = "Save text Files";

                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    save_path = saveFileDialog1.FileName;
                    try
                    {
                        wc.DownloadFile(url, save_path);
                        MessageBox.Show("Файл завантажений!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Файл невдалося завантажити!" + ex.Message);
                    }
                }
                else MessageBox.Show("Файл невдалося завантажити!");
            }
            else MessageBox.Show("Оберіть файл для скачування!");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                var frm = new FormSendFile(listBox2.SelectedItem.ToString(), login);
                frm.Show();
            }
            else MessageBox.Show("Оберіть файл для передачі!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                var item_name = listBox2.SelectedItem.ToString();
                var help_function = new HelpFunction("http://185.86.78.146/deletefile.php");
                try
                {
                    Task.Run(() =>
                    {
                        MessageBox.Show(help_function.DeleteFileServer(item_name, id.ToString()).Result);
                        Task.Delay(1000);
                    });
                    UpdateList();
                }
                catch
                {
                    MessageBox.Show("Виникли проблеми перезапустіть клієнт!");
                }
                
            }
            else MessageBox.Show("Оберіть файл для видалення!");
        }
    }
}
