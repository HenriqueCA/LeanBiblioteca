using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using SimpleCrypto;

namespace WpfApp1
{
    public class DataAccess
    {


        public Boolean GetPassword(String login, String password)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.Cnnval("DataBase")))
            {
                var lista = connection.Query<User>("dbo.getByCpf @cpf", new { cpf = login }).ToList();

                var crypto = new SimpleCrypto.PBKDF2();

                Boolean validate = false;

                if (lista.Count > 0)
                {
                    if (lista[0].senha == crypto.Compute(password, lista[0].senhasalt))
                    {
                        validate = true;
                    }
                }

                return validate;

            }

        }

        public List<User> GetQuestion(String Cpf)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.Cnnval("DataBase")))
            {
                var lista = connection.Query<User>("dbo.getQuestion_Answer @cpf", new { cpf = Cpf }).ToList();
                return lista;

            }
        }

        public void InsertPerson(String Cpf, String Senha, String Nome, String Telefone, String Email, String Curso, String Matricula, String Pergunta, String Resposta)
        {
            var crypto = new SimpleCrypto.PBKDF2();
            var encryptPass = crypto.Compute(Senha);
            var encryptSalt = crypto.Salt;
            var encryptAnswer = crypto.Compute(Resposta);
            var respsalt = crypto.Salt;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.Cnnval("DataBase")))
            {

                User newUser = new User { cpf = Cpf, senha = encryptPass, senhasalt = encryptSalt, nome = Nome, telefone = Telefone, email = Email, curso = Curso, matricula = Matricula, pergunta = Pergunta, resposta = encryptAnswer, respostasalt = respsalt };
                var lista = connection.Query<User>("dbo.getByCpf @cpf", new { cpf = Cpf }).ToList();

                if (lista.Count == 0)
                {
                    connection.Execute("dbo.userRegister @Cpf, @Senha, @Senhasalt, @Nome, @Telefone, @Email, @Curso, @Matricula, @Pergunta, @Resposta, @Respostasalt", newUser);
                }
            }
        }

        public void ChangePassword(User user)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.Cnnval("DataBase")))
            {
                var crypto = new SimpleCrypto.PBKDF2();
                var encryptPass = crypto.Compute(user.senha);
                var encryptSalt = crypto.Salt;
                var encryptAnswer = crypto.Compute(user.resposta);
                var respsalt = crypto.Salt;
                user.senha = encryptPass;
                user.resposta = encryptAnswer;
                user.senhasalt = encryptSalt;
                user.respostasalt = respsalt;

                connection.Execute("dbo.updatePassword @Cpf, @Senha, @SenhaSalt, @Resposta, @Respostasalt", user);

            }
        }

        public User GetUserName(String cpf)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.Cnnval("DataBase")))
            {
                var lista = connection.Query<User>("dbo.getUser @Cpf", new { Cpf = cpf }).ToList();
                try
                {
                    return lista[0];
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public void SendLog()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.Cnnval("DataBase")))
            {
                connection.Execute("dbo.logRegister @nome, @email, @cpf, @logintime, @logouttime", new { LogTime.nome, LogTime.email, LogTime.cpf, LogTime.logintime, LogTime.logouttime });
            }
        }
    }
}
