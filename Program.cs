using System;
using System.Windows.Forms;

namespace SEGUNDO_PARCIAL_PROGRAMACION_BASICA
{
    internal static class Program
    {
        // Aqui empieza el programa, solo abre el formulario
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new frmPedidos());
        }
    }
}
