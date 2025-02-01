using LibraryInventory.Model.Models.Shared;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryInventory.Model.Models.Person
{
    public abstract class Person
    {
        private string _firstName;
        private string? _middleName;
        private string _lastName;
        private ContactInfo _contactinfo;

        public Person(string firstName, string lastName, ContactInfo contactinfo, string? middeleName = null)
        {
            _firstName = firstName;
            _middleName = middeleName;
            _lastName = lastName;
            _contactinfo = contactinfo;
        }
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        public string? MiddleName
        {
            get { return _middleName; }
            set { _middleName = value; }
        }
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        public ContactInfo ContactInfo
        {
            get { return _contactinfo; }
            set { _contactinfo = value; }
        }
    }
}
