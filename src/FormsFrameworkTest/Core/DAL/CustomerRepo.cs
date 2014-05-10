using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entity;
using FizzWare.NBuilder;

namespace Core.DAL
{
    public abstract class BaseRepo<T> where T : class
    {
        public abstract List<T> GetAll();
        public abstract T GetById(int id);
        public abstract void AddOrUpdate(T item);
        public abstract bool Delete(T item);
    }

    public class CustomerRepo : BaseRepo<Customer>
    {
        static List<Customer> allCustomers = new List<Customer>();

        public CustomerRepo()
        {
            
        }
        static CustomerRepo()
        {
            allCustomers = Builder<Customer>.CreateListOfSize(10).All()
                .With(x => x.Company = "some company")
                .Build()
                .ToList();
        }

        public override List<Customer> GetAll()
        {
            return allCustomers;
        }

        public override Customer GetById(int id)
        {
            return allCustomers.Where(x=> x.Id == id).FirstOrDefault();
        }

        public override void AddOrUpdate(Customer c)
        {
            var found = allCustomers.Where(x => x.Id == c.Id).FirstOrDefault();
            if (found == null)
            {
                allCustomers.Add(c);
            }
            else
            {
                int idx = allCustomers.IndexOf(found);
                allCustomers[idx] = c;
            }
        }

        public override bool Delete(Customer c)
        {
            return allCustomers.Remove(c);
        }
    }
}
