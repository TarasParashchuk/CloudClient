using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientApp
{
    public partial class FormSendFile : System.Windows.Forms.Form
    {
        private string name_file = string.Empty;
        private string login = string.Empty;

        public FormSendFile(string name_file, string login)
        {
            InitializeComponent();

            this.name_file = name_file;
            this.login = login;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var help_function = new HelpFunction("http://185.86.78.146/sendfile.php");
            try
            {
                if (loginbox.Text == "" || passbox.Text == "" || (loginbox.Text == "" && passbox.Text == ""))
                {
                    MessageBox.Show("Заповніть поля Логін користувача або Статичний пароль");
                }
                else
                {
                    Task.Run(() =>
                    {
                        var loginclient = loginbox.Text;
                        var password = passbox.Text;
                        MessageBox.Show(help_function.SendFileServer(name_file, loginclient, login, password).Result);
                        Task.Delay(1000);
                    });
                }
            }
            catch
            {
                MessageBox.Show("Виникли проблеми перезапустіть клієнт!");
            }
        }
    }
}
