

CREATE PROCEDURE GetActionsFromAccount
	@accountNumber int
AS
	select
		acc.Id,
		acc.AccountNumber,
		acc.ProductId,
		p.ProductName,
		p.Price,
		acc.Discount,
		(p.Price - acc.Discount) as Amount
	from
		Actions acc
		inner join Products p on (acc.ProductId = p.Id)
	where
		acc.AccountNumber = @accountNumber