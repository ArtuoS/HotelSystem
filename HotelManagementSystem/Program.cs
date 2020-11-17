using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementSystem
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()

        {
            Application.EnableVisualStyles();

            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FormProduto());
            //Application.Run(new FormRegistroProdutos());
            //Application.Run(new FormFuncionario());
            Application.Run(new FormLogin());
        }
    }
}
