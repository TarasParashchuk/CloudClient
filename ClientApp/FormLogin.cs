using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientApp
{
    public partial class FormLogin : System.Windows.Forms.Form
    {
        private delegate DialogResult ShowMainFormInvoker();

        public FormLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var help_function = new HelpFunction("http://185.86.78.146/login.php");
            if (Log_text.Text == "" || Pass_text.Text == "" || (Log_text.Text == "" && Pass_text.Text == ""))
            {
                MessageBox.Show("Заповніть поля Логін або Пароль");
            }
            else
            {
                Task.Run(() =>
                {
                    var id = 0;
                    try
                    {
                        id = Convert.ToInt16(help_function.SendDataServer(Log_text.Text, Pass_text.Text).Result);
                    }
                    catch
                    {
                        id = 0;
                    }
                    Task.Delay(1000);
                    if (id != 0)
                    {
                        Action MainForm = () =>
                        {
                            var frm = new Form(id, Log_text.Text);
                            frm.Show();
                            this.Hide();
                        };
                        if (InvokeRequired)
                        {
                            Invoke(MainForm);
                        }
                        else
                        {
                            MainForm();
                        }
                    }
                    else MessageBox.Show("Логін або пароль не правильні!");
                });
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var frm = new FormRegistration();
            frm.Show();
            this.Hide();
        }
    }
}
