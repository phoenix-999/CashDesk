CREATE PROCEDURE GetActionsFromAccount
	@accountNumber varchar(32)
AS
	select
		acc.Id,
		acc.AccountNumber,
		acc.ProductId,
		p.ProductName,
		acc.Amount
	from
		Actions acc
		inner join Products p on (acc.ProductId = p.Id)
	where
		acc.AccountNumber = @accountNumber