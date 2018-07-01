using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    /// <summary>
    /// Classe auxiliador com o intuito apenas de retornar a string de conexao ao banco de dados.
    /// Caso seja necessario multiplas conexoes, essa classe se tornara muito util.
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// Retorna a string de conexao ao banco de dados com base no nome passado.
        /// </summary>
        /// <param name="name">nome do banco de dados a ser procurado</param>
        /// <returns></returns>
        public static String Cnnval(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

    }
}
