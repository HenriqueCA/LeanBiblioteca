using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    /// <summary>
    /// Classe que armazena o tempo de login de um determinado usuario.
    /// So e requisitado algumas informacoes de um usuario, como o nome, curso, matricula e cpf.
    /// Salva o tempo que entrou e o tempo que saiu.
    /// </summary>
    public static class LogTime
    {
        public static String nome { get; set; }

        public static String curso { get; set; }

        public static String matricula { get; set; }

        public static String cpf { get; set; }

        public static String logintime { get; set; }

        public static String logouttime { get; set; }


    }
}
