using System;

namespace Core.Entity
{
    public class Customer
    {
        public Int64 Id { get; set; }

        public string FirstName { get; set; }
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
    }
}
