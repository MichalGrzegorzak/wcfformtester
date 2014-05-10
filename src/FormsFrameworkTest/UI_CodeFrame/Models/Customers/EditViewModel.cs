using System.Windows.Media;
using AutoMapper;
using CODE.Framework.Wpf.Mvvm;
using Core.DAL;
using Core.Entity;
using FormsFrameworkTest.Logic;
using Snippets;

namespace WpfTestUI.Models.Customers
{
    [SnippetPropertyINPC(field = "_firstName", property = "FirstName")]
    [SnippetPropertyINPC(field = "_borderColor", property = "BorderColor")]
    public partial class EditViewModel : ViewModel
    {
        private CustomerRepo _repo;
        public bool IsLoaded { get; set; }
        public string Title { get; set; }

        public EditViewModel()
        {
            Actions.Add(new ViewAction("Save", execute: (a, o) => Save(), category: "Customer"));
            Actions.Add(new CloseCurrentViewAction(this, beginGroup: true, category: "Customer"));
            
            _repo = new CustomerRepo();
            BorderColor = Colors.Green.ToString();
            Title = "HIHI";

            AttachingEvents();
        }

        private void AttachingEvents()
        {
            this.Opened += (sender, args) => IsLoaded = true;

            this.PropertyChanged += (sender, args) =>
            {
                if (!IsLoaded) return;
                BorderColor = Colors.Red.ToString();
            };
        }

        public void LoadData(int id)
        {
            var customer = _repo.GetById(id);
            //FirstName = "Markus";
            //LastName = "Egger";
            //Company = "EPS/CODE";
            //SearchName = "Markus Egger";

            //Web = "www.codemag.com";
            //Email = "info@codemag.com";
        }

        public void Save()
        {
            //MessageBox.Show("Prentending to saving...");
            Customer c = Mapper.Map<Customer>(this);
            _repo.AddOrUpdate(c);

            Mediator.Instance.NotifyColleagues(ViewModelMessages.DataChanged, c);
        }

        public int Id { get; set; }
        //public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string SearchName { get; set; }

        public string Web { get; set; }
        public string Email { get; set; }

        public string SomeOtherField1 { get; set; }
        public string SomeOtherField2 { get; set; }
        public string SomeOtherField3 { get; set; }
        public string SomeOtherField4 { get; set; }
        public string SomeOtherField5 { get; set; }

        public static EditViewModel Create(int id)
        {
            var repo = new CustomerRepo();
            var customer = repo.GetById(id);
            return Mapper.Map<EditViewModel>(customer);
        }
    }
}
