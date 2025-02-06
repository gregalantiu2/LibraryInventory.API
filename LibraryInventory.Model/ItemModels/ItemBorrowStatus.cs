namespace LibraryInventory.Model.ItemModels
{
    public class ItemBorrowStatus
    {
        private readonly int? _itemBorrowStatusId;
        private bool _isCheckedOut;
        private DateTime? _checkedOutDate;
        private DateTime? _dueBack;
        private int _renewedCount;
        private decimal _fineAmountAccrued;

        public ItemBorrowStatus(bool isCheckedOut
                                ,DateTime? checkedOutDate
                                ,DateTime? dueBack
                                ,int renewedCount
                                ,decimal fineAmountAccrued
                                ,int? itemBorrowStatusId = null)
        {
            _itemBorrowStatusId = itemBorrowStatusId;
            _isCheckedOut = isCheckedOut;
            _checkedOutDate = checkedOutDate;
            _dueBack = dueBack;
            _renewedCount = renewedCount;
            _fineAmountAccrued = fineAmountAccrued;
        }

        public int? ItemBorrowStatusId
        {
            get { return _itemBorrowStatusId; }
        }

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
            set { _renewedCount = value; }
        }

        public decimal FineAmountAccrued
        {
            get { return _fineAmountAccrued; }
            set { _fineAmountAccrued = value; }
        }
    }
}
