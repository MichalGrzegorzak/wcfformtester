using System.Windows;
using CODE.Framework.Wpf.Mvvm;
using CODE.Framework.Wpf.Mvvm.Tools;
using Core.Entity;
using WpfTestUI.Models.Customers;
using WpfTestUI.Models.Home;

namespace WpfTestUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public App()
        {
            Startup += ApplicationStartup;
        }

        /// <summary>
        /// This method is where all the application startup code should go
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ApplicationStartup(object sender, StartupEventArgs e)
        {
#if DEBUG
            var viewVisualizer = new ViewVisualizer();
            viewVisualizer.Show();
            Controller.RegisterViewHandler(viewVisualizer);
#endif

            AutomapperInit();

            // Launching a main form ('shell') and showing a login screen right away
            Controller.Action("Home", "Start");
            //Controller.Action("User", "Login");

            StartViewModel.Current.LoadActions();
            StartViewModel.Current.Actions[0].Execute(null);
            //Controller.Action("Customer", "List");
            
        }

        private void AutomapperInit()
        {
            AutoMapper.Mapper.CreateMap<Customer, CustomerInformation>();
            AutoMapper.Mapper.CreateMap<Customer, EditViewModel>().ReverseMap();
            
        }
    }
}
