﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using SimpleCrypto;

namespace WpfApp1
{
    /// <summary>
    /// Classe feita para acesso do banco de dados. Todos os acessos sao feitos por meio de procedures no banco de dados MSSQL.
    /// A criptografia nao e otimizada. PBKDF2, feita pelo SimpleCrypto.
    /// A conexao e auxiliada pelo Dapper.
    /// </summary>
    public class DataAccess
    {

        /// <summary>
        /// Verifica se a senha passada é a mesma cadastrada no banco de dados.
        /// </summary>
        /// <param name="login"> login a ser procurado no banco de dados</param>
        /// <param name="password">senha a ser verificada</param>
        /// <returns>True caso seja a mesma senha, falso caso nao</returns>
        public Boolean GetPassword(String login, String password)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.Cnnval("DataBase")))
            {
                var lista = connection.Query<User>("dbo.getUser @cpf", new { cpf = login }).ToList();

                var crypto = new SimpleCrypto.PBKDF2(); // Criptografia

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
        /// <summary>
        /// Retorna do banco de dados a pergunta feita na hora do cadastro.
        /// </summary>
        /// <param name="Cpf">cpf/login a ser procurado no banco de dados</param>
        /// <returns>uma lista com a pergunta e a resposta da pergunta</returns>
        public List<User> GetQuestion(String Cpf)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.Cnnval("DataBase")))
            {
                var lista = connection.Query<User>("dbo.getQuestion_Answer @cpf", new { cpf = Cpf }).ToList();
                return lista;

            }
        }

        /// <summary>
        /// Cadastra uma pessoa no banco de dados, dada as informacoes.
        /// </summary>
        /// <param name="Cpf">cpf/login da pessoa</param>
        /// <param name="Senha">senha do usuario</param>
        /// <param name="Nome">nome da pessoa</param>
        /// <param name="Telefone">telefone da pessoa</param>
        /// <param name="Email">email da pessoa</param>
        /// <param name="Curso">curso da pessoa</param>
        /// <param name="Matricula">matricula da pessoa</param>
        /// <param name="Pergunta">pergunta a ser feita caso esqueca a senha</param>
        /// <param name="Resposta">resposta da pergunta</param>
        public void InsertPerson(String Cpf, String Senha, String Nome, String Telefone, String Email, String Curso, String Matricula, String Pergunta, String Resposta)
        {
            var crypto = new SimpleCrypto.PBKDF2(); // Criptografia
            var encryptPass = crypto.Compute(Senha); // Senha criptografada
            var encryptSalt = crypto.Salt; // Salt da senha
            var encryptAnswer = crypto.Compute(Resposta); // Resposta criptografada
            var respsalt = crypto.Salt; // Salt da resposta

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.Cnnval("DataBase")))
            {

                User newUser = new User { cpf = Cpf, senha = encryptPass, senhasalt = encryptSalt, nome = Nome, telefone = Telefone, email = Email, curso = Curso, matricula = Matricula, pergunta = Pergunta, resposta = encryptAnswer, respostasalt = respsalt };

                var lista = connection.Query<User>("dbo.getUser @cpf", new { cpf = Cpf }).ToList();

                if (lista.Count == 0) // Se nao houver nenhum usuario cadastrado com o cpf, realiza o cadastro.
                {
                    connection.Execute("dbo.userRegister @Cpf, @Senha, @Senhasalt, @Nome, @Telefone, @Email, @Curso, @Matricula, @Pergunta, @Resposta, @Respostasalt", newUser);
                }
            }
        }
        /// <summary>
        /// Muda a senha de um determinado usuario
        /// </summary>
        /// <param name="user">um Usuario</param>
        public void ChangePassword(User user)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.Cnnval("DataBase")))
            {
                var crypto = new PBKDF2(); // Criptografia
                var encryptPass = crypto.Compute(user.senha); // Senha criptografada
                var encryptSalt = crypto.Salt; // Salt da senha
                user.senha = encryptPass; // Update na senha do objeto User
                user.senhasalt = encryptSalt; // Update na senhasalt do objeto User

                connection.Execute("dbo.updatePassword @Cpf, @Senha, @SenhaSalt", user);

            }
        }
        /// <summary>
        /// Retorna um usuario cadastrado no banco de dados
        /// </summary>
        /// <param name="cpf">cpf/login do usuario</param>
        /// <returns>um objeto User</returns>
        public User GetUserName(String cpf)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.Cnnval("DataBase")))
            {
                var lista = connection.Query<User>("dbo.getUser @Cpf", new { Cpf = cpf }).ToList();

                return lista[0];

            }
        }

        /// <summary>
        /// Envia o log do usuario, com a hora que ele se logou e a hora que ele saiu.
        /// </summary>
        public void SendLog()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.Cnnval("DataBase")))
            {
                connection.Execute("dbo.logRegister @nome, @curso, @matricula, @cpf, @logintime, @logouttime", new { LogTime.nome, LogTime.curso, LogTime.matricula, LogTime.cpf, LogTime.logintime, LogTime.logouttime });
            }
        }
    }
}
