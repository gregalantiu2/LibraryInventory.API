namespace LibraryInventory.Model.SharedModels
{
    public class ContactInfo
    {
        public ContactInfo(string phoneNumber
                            ,string email
                            ,string street
                            ,string city
                            ,string state
                            ,string zipCode,
                             string country)
        {
            _phoneNumber = phoneNumber;
            _email = email;
            _street = street;
            _city = city;
            _state = state;
            _zipCode = zipCode;
            _country = country;
        }

        private string _phoneNumber;
        private string _email;
        private string _street;
        private string _city;
        private string _state;
        private string _zipCode;
        private string _country;

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Street
        {
            get { return _street; }
            set { _street = value; }
        }
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }
        public string State
        {
            get { return _state; }
            set { _state = value; }
        }
        public string ZipCode
        {
            get { return _zipCode; }
            set { _zipCode = value; }
        }
        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        public string Address
        {
            get
            {
                return $"{_street} {_city}, {_state} {_zipCode} {_country}";
            }
        }
    }
}
