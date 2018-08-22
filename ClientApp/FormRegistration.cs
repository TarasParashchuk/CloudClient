using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientApp
{
    public partial class FormRegistration : System.Windows.Forms.Form
    {
        public bool flag = false;
        public FormRegistration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var help_function = new HelpFunction("http://185.86.78.146/registration.php");
            try
            {
                if (Log_text.Text == "" || Pass_text.Text == "" || (Log_text.Text == "" && Pass_text.Text == ""))
                {
                    MessageBox.Show("Заповніть поля Логін або Пароль");
                }
                else
                {
                    Task.Run(() =>
                    {
                        var flag = Convert.ToBoolean(help_function.SendDataServer(Log_text.Text, Pass_text.Text).Result);
                        Task.Delay(1000);
                        if (flag)
                        {
                            MessageBox.Show("Користувач успішно зареєстрований!");
                            Environment.Exit(0);
                        }
                        else MessageBox.Show("Користувач уже існує!");
                    });
                }                
            }
            catch
            {
                MessageBox.Show("Виникли проблеми перезапустіть клієнт!");
            }
        }

        private void FormRegistration_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
            Environment.Exit(0);
        }
    }
}
