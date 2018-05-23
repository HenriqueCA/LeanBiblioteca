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

        // Procura o cpf dado
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            DataAccess db = new DataAccess();

            user = db.GetQuestion(CpfSearch.Text);

            if (user.Count > 0)
            {
                SecretQuestion.Content = user[0].pergunta;
                user[0].cpf = CpfSearch.Text;

                ChangeInterface(Answer, AnswerButton, CpfNotRegistered);

                SearchButton.IsEnabled = false;
                SearchButton.IsDefault = false;
                AnswerButton.IsDefault = true;

            }
            else
            {
                CpfNotRegistered.Visibility = Visibility.Visible;
                CpfSearch.Text = "";
            }


        }

        // Mudar a interface
        private void ChangeInterface(UIElement box, UIElement button, UIElement labelIncorrect)
        {
            box.IsEnabled = true;
            box.Visibility = Visibility.Visible;
            button.IsEnabled = true;
            button.Visibility = Visibility.Visible;
            labelIncorrect.Visibility = Visibility.Hidden;
        }
        // Ao clicar no butao de resposta, checa se a resposta está valida
        private void AnswerButton_Click(object sender, RoutedEventArgs e)
        {
            var crypto = new SimpleCrypto.PBKDF2();

            String resposta = Answer.Text;

            if (user[0].resposta == crypto.Compute(resposta, user[0].respostasalt))
            {

                NovaSenhaLabel.Visibility = Visibility.Visible;

                ChangeInterface(NewPassword, ChangeButton, IncorrectAnswer);

                AnswerButton.IsEnabled = false;
                AnswerButton.IsDefault = false;
                ChangeButton.IsDefault = true;
            }
            else
            {
                IncorrectAnswer.Visibility = Visibility.Visible;
                Answer.Text = "";
            }

        }
        // Voltar para a tela de login
        private void ExitNewPasswordButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        // Mudar a senha
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
        // Aviso se a senha é valida
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
