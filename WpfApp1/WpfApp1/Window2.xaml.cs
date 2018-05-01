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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Lógica interna para Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {


        List<User> user;


        public Window2()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            DataAccess db = new DataAccess();

            user = db.GetQuestion(CpfSearch.Text);

            if (user.Count > 0)
            {
                SecretQuestion.Content = user[0].pergunta;
                Answer.IsEnabled = true;
                Answer.Visibility = Visibility.Visible;
                AnswerButton.IsEnabled = true;
                AnswerButton.Visibility = Visibility.Visible;
                user[0].cpf = CpfSearch.Text;
                CpfNotRegistered.Visibility = Visibility.Hidden;
                SearchButton.IsDefault = false;
                AnswerButton.IsDefault = true;

            }
            else
            {
                CpfNotRegistered.Visibility = Visibility.Visible;
                CpfSearch.Text = "";
            }


        }

        private void AnswerButton_Click(object sender, RoutedEventArgs e)
        {
            var crypto = new SimpleCrypto.PBKDF2();

            String resposta = Answer.Text;

            if (user[0].resposta == crypto.Compute(resposta, user[0].respostasalt))
            {

                NovaSenhaLabel.Visibility = Visibility.Visible;
                NewPassword.IsEnabled = true;
                NewPassword.Visibility = Visibility.Visible;
                ChangeButton.IsEnabled = true;
                ChangeButton.Visibility = Visibility.Visible;
                user[0].resposta = resposta;
                IncorrectAnswer.Visibility = Visibility.Hidden;
                AnswerButton.IsDefault = false;
                ChangeButton.IsDefault = true;
            }
            else
            {
                IncorrectAnswer.Visibility = Visibility.Visible;
                Answer.Text = "";
            }

        }

        private void ExitNewPasswordButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            if (NewPassword.Password.Length >= 6)
            {
                DataAccess db = new DataAccess();

                user[0].senha = NewPassword.Password;

                db.ChangePassword(user[0]);

                this.Close();
            }

        }

        private void NewPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (NewPassword.Password.Length < 6)
            {
                InvalidPassword.Visibility = Visibility.Visible;
            }
            else
            {
                InvalidPassword.Visibility = Visibility.Hidden;
            }
        }
    }
}
