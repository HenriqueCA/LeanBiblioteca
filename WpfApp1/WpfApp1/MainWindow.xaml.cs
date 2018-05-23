using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using Open.WinKeyboardHook;
using System.Diagnostics;

namespace WpfApp1
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly IKeyboardInterceptor _interceptor;
        [System.Runtime.InteropServices.DllImport("user32.dll")]

        public static extern int FindWindow(string lpClassName, string lpWindowName);

        [System.Runtime.InteropServices.DllImport("User32.dll")]

        public static extern Int32 SendMessage(

        int hWnd, // handle to destination window

        int Msg, // message

        int wParam, // first message parameter

        int lParam); // second message parameter

        public MainWindow()
        {
            InitializeComponent();
            _interceptor = new KeyboardInterceptor();
            _interceptor.KeyDown += _interceptor_KeyDown;
            _interceptor.StartCapturing();
            TaskManagerStop();

        }
        // Ao abrir o taskmanager, deixa-o escondido.
        private void TaskManagerStop()
        {
            Process p = new Process();

            GetTaskManager(p);

            p.StartInfo.CreateNoWindow = true;

            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            p.Start();

        }

        private void GetTaskManager(Process p)
        {

            p.StartInfo.WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.System);

            p.StartInfo.FileName = "taskmgr.exe";

        }
        // Permite o uso do taskmanager
        private void TaskManagerBack()
        {

            Process p = new Process();

            GetTaskManager(p);

            p.StartInfo.CreateNoWindow = false;

            p.StartInfo.WindowStyle = ProcessWindowStyle.Normal;

        }

        // Não permite o uso das teclas alt, ctrl, shift e tambéms as teclas windows
        private void _interceptor_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {

            if (e.Alt || e.Control || e.Shift)
            {
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == System.Windows.Forms.Keys.LWin || e.KeyCode == System.Windows.Forms.Keys.RWin)
            {
                e.SuppressKeyPress = true;
            }

        }
        // Ir para a tela de registro
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            Window1 regWindow = new Window1();

            LoginInvalid.Visibility = Visibility.Hidden;

            regWindow.Show();

        }
        // Logar-se, jogando fora os hooks
        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            String login = LoginBox.Text;
            String password = PasswordBox.Password;

            DataAccess db = new DataAccess();

            if (db.GetPassword(login, password))
            {
                TaskManagerBack();

                this.Hide();

                _interceptor.KeyDown -= _interceptor_KeyDown;

                _interceptor.StopCapturing();

                LogedUser(login, db);



            }
            else
            {
                LoginInvalid.Visibility = Visibility.Visible;
            }

            LoginBox.Text = "";
            PasswordBox.Password = "";
        }

        // Seta os dados do usuário que fez login
        private void LogedUser(String login, DataAccess db)
        {
            User logedUser = db.GetUserName(login);
            LogTime.nome = logedUser.nome;
            LogTime.curso = logedUser.curso;
            LogTime.matricula = logedUser.matricula;
            LogTime.cpf = logedUser.cpf;
            LogTime.logintime = DateTime.Now.ToString();
        }
        // Ir para a tela de mudar a senha
        private void ForgotButton_Click(object sender, RoutedEventArgs e)
        {
            Window2 newPasswordWindow = new Window2();

            LoginInvalid.Visibility = Visibility.Hidden;

            newPasswordWindow.Show();
        }

    }
}
