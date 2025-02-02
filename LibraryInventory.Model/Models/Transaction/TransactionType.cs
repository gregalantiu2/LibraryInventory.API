﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryInventory.Model.Models.Transaction
{
    public class TransactionType
    {
        private readonly int _transactionId;
        private string _transactionTypeName;

        public TransactionType(string transactionTypeName)
        {
            _transactionTypeName = transactionTypeName;
        }

        public int TransactionId
        {
            get { return _transactionId; }
        }

        public string TransactionTypeName
        {
            get { return _transactionTypeName; }
            set { _transactionTypeName = value; }
        }
    }
}
