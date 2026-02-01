using System;

namespace ERP.Presentation.WinForms;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        System.Windows.Forms.Application.Run(new MainForm());
    }
}
