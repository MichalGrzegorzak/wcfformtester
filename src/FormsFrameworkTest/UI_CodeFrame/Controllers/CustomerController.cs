using System;
using CODE.Framework.Wpf.Mvvm;
using WpfTestUI.Models.Customers;

namespace WpfTestUI.Controllers
{
    public class CustomerController : Controller
    {
        public ActionResult List()
        {
            var model = new ListViewModel();
            return View(model);
        }

        public ActionResult Search()
        {
            var model = new SearchViewModel();
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var model = EditViewModel.Create(id);
            //var model = new EditViewModel();
            //model.LoadData(id);
            return View(model);
        }
    }
}
