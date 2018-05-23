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
using System.Data.SqlClient;

namespace WpfApp1
{
    /// <summary>
    /// Lógica interna para Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        bool termos;
        bool password;
        bool name;
        bool cpf;
        bool email;
        bool pergunta;
        bool resposta;

        public Window1()
        {
            InitializeComponent();

        }
        // Sair da tela de cadastro
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        // Mostrar os termos de cadastro
        private void Termos_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Textão");
        }
        // Registrar-se. Caso tudo tenha sido preenchido, volta para a tela de login, caso não, mostra um aviso.
        private void Register_Click(object sender, RoutedEventArgs e)
        {
            if (password && name && cpf && email && pergunta && resposta && termos)
            {

                DataAccess db = new DataAccess();

                db.InsertPerson(Cpf.Text, Senha.Password, Nome.Text, Telefone.Text, Email.Text, Curso.Text, Matricula.Text, Pergunta.Text, Resposta.Text);

                this.Close();
            }
            else
            {
                MessageBox.Show("Alguns dados são obrigatórios!");
            }


        }
        // Aviso da senha
        private void Senha_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (Senha.Password.Length < 6)
            {
                SenhaInvalid.Visibility = Visibility.Visible;
                password = false;
            }
            else
            {
                SenhaInvalid.Visibility = Visibility.Hidden;
                password = true;
            }
        }
        // Aviso do nome
        private void Nome_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Nome.Text.Length < 1)
            {
                NameInvalid.Visibility = Visibility.Visible;
                name = false;
            }
            else
            {
                NameInvalid.Visibility = Visibility.Hidden;
                name = true;
            }
        }
        // Aviso do cpf; deve ter 11 digitos.
        private void Cpf_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Cpf.Text.Length != 11)
            {
                CpfInvalid.Visibility = Visibility.Visible;
                cpf = false;
            }
            else
            {
                CpfInvalid.Visibility = Visibility.Hidden;
                cpf = true;
            }

        }
        // Email válido.
        private void Email_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(Email.Text);
                if (addr.Address != Email.Text)
                {
                    EmailInvalid.Visibility = Visibility.Visible;
                    email = false;
                }
                else
                {
                    EmailInvalid.Visibility = Visibility.Hidden;
                    email = true;
                }
            }
            catch
            {
                EmailInvalid.Visibility = Visibility.Visible;
                email = false;
            }

        }

        // Pergunta secreta; maior que 5 caracteres
        private void Pergunta_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Pergunta.Text.Length < 5)
            {
                PerguntaInvalid.Visibility = Visibility.Visible;
                pergunta = false;
            }
            else
            {
                PerguntaInvalid.Visibility = Visibility.Hidden;
                pergunta = true;
            }

        }
        // Resposta maior que 1 caractere
        private void Resposta_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Resposta.Text.Length < 1)
            {
                RespostaInvalid.Visibility = Visibility.Visible;
                resposta = false;
            }
            else
            {
                RespostaInvalid.Visibility = Visibility.Hidden;
                resposta = true;
            }
        }
        // Concorda-se com os termos
        private void CheckTermos_Checked(object sender, RoutedEventArgs e)
        {
            termos = true;
        }
        // Discorda-se dos termos
        private void CheckTermos_Unchecked(object sender, RoutedEventArgs e)
        {
            termos = false;
        }
    }
}
