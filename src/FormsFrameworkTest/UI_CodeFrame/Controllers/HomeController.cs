using CODE.Framework.Wpf.Mvvm;
using WpfTestUI.Models.Home;

namespace WpfTestUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Start()
        {
            return Shell(new StartViewModel(), "Business Application");
        }
    }
}
