using LibraryInventory.Model.SharedModels;

namespace LibraryInventory.Model.PersonModels
{
    public abstract class Person
    {
        private string _firstName;
        private string? _middleName;
        private string _lastName;
        private ContactInfo _contactinfo;
        private bool _active;

        public Person(string firstName
                        ,string lastName
                        ,ContactInfo contactinfo
                        ,string? middeleName = null)
        {
            _firstName = firstName;
            _middleName = middeleName;
            _lastName = lastName;
            _contactinfo = contactinfo;
            _active = true;
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

        public bool Active
        {
            get { return _active; }
            set { _active = value; }
        }
    }
}
