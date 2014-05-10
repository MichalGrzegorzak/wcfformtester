using CODE.Framework.Wpf.Mvvm;
using WpfTestUI.Models.User;

namespace WpfTestUI.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Login()
        {
            return ViewModal(new LoginViewModel(), ViewLevel.Popup);
        }
    }
}
