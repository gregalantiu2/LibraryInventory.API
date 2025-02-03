namespace LibraryInventory.Model.ItemModels
{
    public class ItemBorrowStatus
    {
        private bool _isCheckedOut;
        private DateTime? _checkedOutDate;
        private DateTime? _dueBack;
        private int _renewedCount;
        private decimal _fineAmountAccrued;

        public bool IsCheckedOut
        {
            get { return _isCheckedOut; }
            set 
            { 
                _isCheckedOut = value;
                if (_isCheckedOut == false)
                {
                    _checkedOutDate = null;
                    _dueBack = null;
                    _renewedCount = 0;
                    _fineAmountAccrued = 0M;
                }
            }
        }

        public DateTime? CheckedOutDate
        {
            get { return _checkedOutDate; }
            set { _checkedOutDate = value; }
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
                _renewedCount = value;
            }
        }

        public decimal FineAmountAccrued
        {
            get { return _fineAmountAccrued; }
            set { _fineAmountAccrued = value; }
        }
    }
}
