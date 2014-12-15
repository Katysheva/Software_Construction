using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScrabbleWinForm
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var model = new ScrabbleModel();


            var view = new FormMain();
            
            var controller = new ScrabbleController(model, view);

            controller.RenderView();
            Application.Run(view);
        }
    }
}
