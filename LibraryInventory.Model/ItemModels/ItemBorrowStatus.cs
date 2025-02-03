namespace LibraryInventory.Model.ItemModels
{
    public class ItemBorrowStatus
    {
        private bool _isCheckedOut;
        private DateTime? _checkedOutDate;
        private DateTime? _dueBack;
        private int _renewedCount;

        public bool IsCheckedOut
        {
            get { return _isCheckedOut; }
            set { _isCheckedOut = value; }
        }

        public DateTime? CheckedOutDate
        {
            get { return _checkedOutDate; }
            set { _checkedOutDate = _isCheckedOut == false ? null : value; }
        }

        public DateTime? DueBack
        {
            get { return _dueBack; }
            set { _dueBack = value; }
        }

        public int RenewedCount
        {
            get { return _renewedCount; }
            set
            {
                _renewedCount = _isCheckedOut == false ? 0 : value;
            }
        }
    }
}
