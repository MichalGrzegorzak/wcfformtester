using System.Collections.ObjectModel;
using System.Linq;
using AutoMapper;
using CODE.Framework.Wpf.Mvvm;
using Core.DAL;
using FormsFrameworkTest.Logic;

namespace WpfTestUI.Models.Customers
{
public class SearchViewModel : ListViewModel
{
    public SearchViewModel() : base(false)
    {
        SearchCustomers = new ViewAction("Search", execute: (a,o) => Search());

        
    }

    public IViewAction SearchCustomers { get; set; }

    public void Search()
    {
        // TODO: Perform actual search here... but for now we just load the fake data
        LoadCustomers();
    }

    // Example search terms
    public string SearchTerm1 { get; set; }
    public string SearchTerm2 { get; set; }
    public string SearchTerm3 { get; set; }
    public string SearchTerm4 { get; set; }
    public string SearchTerm5 { get; set; }
}

    public class ListViewModel : ViewModel
    {
        private CustomerRepo _repo;

        public ListViewModel(bool loadCustomers = true)
        {
            _repo = new CustomerRepo();
            Customers = new ObservableCollection<CustomerInformation>();

            if (loadCustomers)
                LoadCustomers();

            Actions.Add(new CloseCurrentViewAction(this, beginGroup: true));
            EditCustomer = new ViewAction("Edit", execute: (a,o) => 
                LaunchEdit(o as CustomerInformation));

            Mediator.Instance.Register(o => LoadCustomers(), ViewModelMessages.DataChanged);
        }

        public IViewAction EditCustomer { get; set; }

        public ObservableCollection<CustomerInformation> Customers { get; set; }

        public void LoadCustomers()
        {
            var allCustomers = _repo.GetAll().Select(x => CustomerInformation.Create(x));
            Customers.Clear();
            Customers.AddRange(allCustomers);
        }

        public void LaunchEdit(CustomerInformation customer)
        {
            // Pretending to load a specific customer
            Controller.Action("Customer", "Edit", new { id = customer.Id });
            Controller.LoadView("Edit", "Customer");
        }
    }

    public class CustomerInformation
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }

        public static CustomerInformation Create(Core.Entity.Customer c)
        {
            return Mapper.Map<CustomerInformation>(c);
        }
    }
}
