using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Interação lógica para App.xaml
    /// </summary>
    /// 

    public partial class App : Application
    {
        // Ao sair do windows, manda todas as informações do usuário para o servidor.
        private void App_SessionEnding(object sender, SessionEndingCancelEventArgs e)
        {
            DataAccess db = new DataAccess();
            LogTime.logouttime = DateTime.Now.ToString();
            db.SendLog();
        }
    }
}
