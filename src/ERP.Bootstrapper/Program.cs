using ERP.Bootstrapper;
using ERP.Presentation.WinForms;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Forms;

ApplicationConfiguration.Initialize();

var serviceProvider = ContainerConfiguration.Configure();

using (var scope = serviceProvider.CreateScope())
{
    var mainForm = scope.ServiceProvider.GetRequiredService<MainForm>();
    Application.Run(mainForm);
}

