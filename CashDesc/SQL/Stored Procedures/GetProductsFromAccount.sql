CREATE PROCEDURE GetProductsFromAccount
	@accountNumber varchar(32)
AS
	select
		p.Id,
		p.ProductName
	from
		Actions acc
		inner join Products p on (acc.ProductId = p.Id)
	where
		acc.AccountNumber = @accountNumber