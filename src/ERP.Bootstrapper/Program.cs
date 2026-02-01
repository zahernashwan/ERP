using ERP.Bootstrapper;
using ERP.Presentation.WinForms;
using ERP.Presentation.WinForms.Navigation;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Forms;

ApplicationConfiguration.Initialize();

var serviceProvider = ContainerConfiguration.Configure();

using var scope = serviceProvider.CreateScope();

var mainForm = scope.ServiceProvider.GetRequiredService<MainForm>();
var navigation = scope.ServiceProvider.GetRequiredService<INavigationController>();

navigation.Initialize(mainForm);
navigation.ShowJournals();

Application.Run(mainForm);

