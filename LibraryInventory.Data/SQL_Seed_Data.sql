--Deletions
	DELETE FROM [LibraryInventory].[dbo].[Employee]
	DBCC CHECKIDENT ('[LibraryInventory].[dbo].[Employee]', RESEED, 0);
	DELETE FROM [LibraryInventory].[dbo].[Item]
	DBCC CHECKIDENT ('[LibraryInventory].[dbo].[Item]', RESEED, 0);
	DELETE FROM [LibraryInventory].[dbo].[ItemBorrowStatus]
	DBCC CHECKIDENT ('[LibraryInventory].[dbo].[ItemBorrowStatus]', RESEED, 0);
    DELETE FROM [LibraryInventory].[dbo].[ItemFineOccurenceType]
	DBCC CHECKIDENT ('[LibraryInventory].[dbo].[ItemFineOccurenceType]', RESEED, 0);
	DELETE FROM [LibraryInventory].[dbo].[ItemPolicy]
	DBCC CHECKIDENT ('[LibraryInventory].[dbo].[ItemPolicy]', RESEED, 0);
	DELETE FROM [LibraryInventory].[dbo].[ItemType]
	DBCC CHECKIDENT ('[LibraryInventory].[dbo].[ItemType]', RESEED, 0);
	DELETE FROM [LibraryInventory].[dbo].[Member]
	DBCC CHECKIDENT ('[LibraryInventory].[dbo].[Member]', RESEED, 0);
	DELETE FROM [LibraryInventory].[dbo].[Transaction]
	DBCC CHECKIDENT ('[LibraryInventory].[dbo].[Transaction]', RESEED, 0);
	DELETE FROM [LibraryInventory].[dbo].[TransactionPayment]
	DBCC CHECKIDENT ('[LibraryInventory].[dbo].[TransactionPayment]', RESEED, 0);
	DELETE FROM [LibraryInventory].[dbo].[TransactionPaymentType]
	DBCC CHECKIDENT ('[LibraryInventory].[dbo].[TransactionPaymentType]', RESEED, 0);
	DELETE FROM [LibraryInventory].[dbo].[TransactionType]
	DBCC CHECKIDENT ('[LibraryInventory].[dbo].[TransactionType]', RESEED, 0);
	DELETE FROM [LibraryInventory].[dbo].[ContactInfo]
	DBCC CHECKIDENT ('[LibraryInventory].[dbo].[ContactInfo]', RESEED, 0);
	DELETE FROM [LibraryInventory].[dbo].[EmployeeType]
DBCC CHECKIDENT ('[LibraryInventory].[dbo].[EmployeeType]', RESEED, 0);


--Transaction Type
INSERT INTO [LibraryInventory].[dbo].[TransactionType] 
      ([TransactionTypeName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate])
VALUES ('Payment', 'System', GETDATE(), 'System', GETDATE());

INSERT INTO [LibraryInventory].[dbo].[TransactionType] 
      ([TransactionTypeName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate])
VALUES ('Return', 'System', GETDATE(), 'System', GETDATE());

INSERT INTO [LibraryInventory].[dbo].[TransactionType] 
      ([TransactionTypeName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate])
VALUES ('Checkout', 'System', GETDATE(), 'System', GETDATE());

INSERT INTO [LibraryInventory].[dbo].[TransactionType] 
      ([TransactionTypeName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate])
VALUES ('Renew', 'System', GETDATE(), 'System', GETDATE());

--TransactionPaymentType
INSERT INTO [LibraryInventory].[dbo].[TransactionPaymentType] 
      ([TransactionPaymentTypeName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate])
VALUES ('Cash', 'System', GETDATE(), 'System', GETDATE());

INSERT INTO [LibraryInventory].[dbo].[TransactionPaymentType] 
      ([TransactionPaymentTypeName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate])
VALUES ('Credit', 'System', GETDATE(), 'System', GETDATE());

INSERT INTO [LibraryInventory].[dbo].[TransactionPaymentType] 
      ([TransactionPaymentTypeName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate])
VALUES ('Debit', 'System', GETDATE(), 'System', GETDATE());

INSERT INTO [LibraryInventory].[dbo].[TransactionPaymentType] 
      ([TransactionPaymentTypeName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate])
VALUES ('Check', 'System', GETDATE(), 'System', GETDATE());

--Item Types

INSERT INTO [LibraryInventory].[dbo].[ItemType] 
      ([ItemTypeName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate])
VALUES ('DVD', 'System', GETDATE(), 'System', GETDATE());

INSERT INTO [LibraryInventory].[dbo].[ItemType] 
      ([ItemTypeName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate])
VALUES ('Books', 'System', GETDATE(), 'System', GETDATE());

INSERT INTO [LibraryInventory].[dbo].[ItemType] 
      ([ItemTypeName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate])
VALUES ('Magazines', 'System', GETDATE(), 'System', GETDATE());

INSERT INTO [LibraryInventory].[dbo].[ItemType] 
      ([ItemTypeName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate])
VALUES ('Newspapers', 'System', GETDATE(), 'System', GETDATE());

INSERT INTO [LibraryInventory].[dbo].[ItemType] 
      ([ItemTypeName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate])
VALUES ('E-Books', 'System', GETDATE(), 'System', GETDATE());

INSERT INTO [LibraryInventory].[dbo].[ItemType] 
      ([ItemTypeName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate])
VALUES ('Audiobooks', 'System', GETDATE(), 'System', GETDATE());

--Fine Ocurrences
INSERT INTO [LibraryInventory].[dbo].[ItemFineOccurenceType] 
      ([ItemFineOccurenceTypeDescription], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate])
VALUES ('Daily', 'System', GETDATE(), 'System', GETDATE());

INSERT INTO [LibraryInventory].[dbo].[ItemFineOccurenceType] 
      ([ItemFineOccurenceTypeDescription], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate])
VALUES ('Monthly', 'System', GETDATE(), 'System', GETDATE());

INSERT INTO [LibraryInventory].[dbo].[ItemFineOccurenceType] 
      ([ItemFineOccurenceTypeDescription], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate])
VALUES ('Yearly', 'System', GETDATE(), 'System', GETDATE());

--Employee Type
INSERT INTO [LibraryInventory].[dbo].[EmployeeType] 
      ([EmployeeTypeName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate])
VALUES ('Full-Time', 'System', GETDATE(), 'System', GETDATE());

INSERT INTO [LibraryInventory].[dbo].[EmployeeType] 
      ([EmployeeTypeName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate])
VALUES ('Part-Time', 'System', GETDATE(), 'System', GETDATE());

INSERT INTO [LibraryInventory].[dbo].[EmployeeType] 
      ([EmployeeTypeName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate])
VALUES ('Volunteer', 'System', GETDATE(), 'System', GETDATE());

INSERT INTO [LibraryInventory].[dbo].[EmployeeType] 
      ([EmployeeTypeName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate])
VALUES ('Contractor', 'System', GETDATE(), 'System', GETDATE());


--Item Policy
INSERT INTO [LibraryInventory].[dbo].[ItemPolicy] 
      ([AllowedToCheckout], [MaxRenewalsAllowed], [CheckoutDays], [FineAmount], [ItemFineOccurenceTypeId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ItemPolicyName])
VALUES (1, 3, 14, 0.50, 1, 'System', GETDATE(), 'System', GETDATE(), 'New Arrival Policy');

INSERT INTO [LibraryInventory].[dbo].[ItemPolicy] 
      ([AllowedToCheckout], [MaxRenewalsAllowed], [CheckoutDays], [FineAmount], [ItemFineOccurenceTypeId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ItemPolicyName])
VALUES (1, 2, 21, 0.75, 2, 'System', GETDATE(), 'System', GETDATE(), 'Regular Checkout Policy');

INSERT INTO [LibraryInventory].[dbo].[ItemPolicy] 
      ([AllowedToCheckout], [MaxRenewalsAllowed], [CheckoutDays], [FineAmount], [ItemFineOccurenceTypeId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ItemPolicyName])
VALUES (1, 1, 7, 1.00, 1, 'System', GETDATE(), 'System', GETDATE(), 'Short-Term Loan Policy');

INSERT INTO [LibraryInventory].[dbo].[ItemPolicy] 
      ([AllowedToCheckout], [MaxRenewalsAllowed], [CheckoutDays], [FineAmount], [ItemFineOccurenceTypeId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ItemPolicyName])
VALUES (1, 4, 28, 0.50, 3, 'System', GETDATE(), 'System', GETDATE(), 'Monthly Loan Policy');

INSERT INTO [LibraryInventory].[dbo].[ItemPolicy] 
      ([AllowedToCheckout], [MaxRenewalsAllowed], [CheckoutDays], [FineAmount], [ItemFineOccurenceTypeId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ItemPolicyName])
VALUES (1, 5, 60, 0.25, 2, 'System', GETDATE(), 'System', GETDATE(), 'Extended Loan Policy');

INSERT INTO [LibraryInventory].[dbo].[ItemPolicy] 
      ([AllowedToCheckout], [MaxRenewalsAllowed], [CheckoutDays], [FineAmount], [ItemFineOccurenceTypeId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ItemPolicyName])
VALUES (1, 0, 1, 1.50, 1, 'System', GETDATE(), 'System', GETDATE(), 'Overnight Loan Policy');

INSERT INTO [LibraryInventory].[dbo].[ItemPolicy] 
      ([AllowedToCheckout], [MaxRenewalsAllowed], [CheckoutDays], [FineAmount], [ItemFineOccurenceTypeId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ItemPolicyName])
VALUES (1, 3, 30, 0.50, 3, 'System', GETDATE(), 'System', GETDATE(), 'General Loan Policy');
