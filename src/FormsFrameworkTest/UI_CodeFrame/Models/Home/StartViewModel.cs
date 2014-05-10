using System.Windows;
using CODE.Framework.Wpf.Mvvm;

namespace WpfTestUI.Models.Home
{
    public class StartViewModel : ViewModel
    {
        public static StartViewModel Current { get; set; }

        public StartViewModel()
        {
            Current = this;
        }

        public void LoadActions()
        {
            Actions.Clear();

            // TODO: The following list of actions is used to populate the application's main navigation area (such as a menu or a home screen)
            var customerAction = new ViewAction("All Customers", execute: (a, o) =>
                Controller.Action("Customer", "List")) { Significance = ViewActionSignificance.AboveNormal };

            Actions.Add(customerAction);

            Actions.Add(new ViewAction("Menu Item #1", execute: (a, o) => Controller.Message("Menu Item #1 clicked!")) { Significance = ViewActionSignificance.AboveNormal });
            Actions.Add(new ViewAction("Menu Item #2", execute: (a, o) => Controller.Message("Menu Item #2 clicked!")));
            Actions.Add(new ViewAction("Menu Item #3", execute: (a, o) => Controller.Message("Menu Item #3 clicked!")));

            Actions.Add(new SwitchThemeViewAction("Workplace", "Workplace (Office 2013) Theme", category: "View", categoryAccessKey: 'V', accessKey: 'W'));
            Actions.Add(new SwitchThemeViewAction("Metro", "Metro Theme", category: "View", categoryAccessKey: 'V', accessKey: 'M'));
            Actions.Add(new SwitchThemeViewAction("Battleship", "Windows 95 Theme", category: "View", categoryAccessKey: 'V', accessKey: 'W'));
            Actions.Add(new SwitchThemeViewAction("Vapor", "Vapor Theme", category: "View", categoryAccessKey: 'V', accessKey: 'V'));
            Actions.Add(new SwitchThemeViewAction("Geek", "Geek (Visual Studio) Theme", category: "View", categoryAccessKey: 'V', accessKey: 'G'));
            Actions.Add(new SwitchThemeViewAction("Wildcat", "Wildcat Theme", category: "View", categoryAccessKey: 'V', accessKey: 'I'));
        }
    }
}
