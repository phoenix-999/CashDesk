CREATE PROCEDURE GetProducts
	@name nvarchar(200) = null,
	@type nvarchar(200) = null,
	@priceFrom money = null,
	@priceTo money = null
AS
	SELECT
		p.Id,
		p.ProductName,
		p.Description,
		p.Price,
		p.TypeId,
		pt.TypeName
	from
		Products p
		inner join ProductTypes pt on (p.TypeId = pt.Id)
	where
		(@name is null or p.ProductName like @name)
		and (@type is null or pt.TypeName like @type)
		and (@priceFrom is null or p.Price >= @priceFrom)
		and (@priceTo is null or p.Price <= @priceTo)
		and p.Deleted = 0


go


CREATE PROCEDURE GetProductTypes
AS
	select
		pt.Id,
		pt.TypeName,
		sd.Description
	from
		ProductTypes pt
		inner join StatusDescriptions sd on (pt.Status = sd.Id)


go


CREATE PROCEDURE GetActionsFromAccount
	@accountNumber int
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

go


CREATE PROCEDURE GetAccounts
	@number int = null,
	@productName nvarchar(200) = null,
	@accountDate datetime2(7) = null,
	@sumFrom money = null,
	@sumTo money = null
AS

	select
		*
	from
		(
		select
			acc.Number,
			acc.ActionTime,
			sum(act.Amount) as AccountSum
		from
			Accounts acc
			left join Actions act on (acc.Number = act.AccountNumber)
			left join Products p on (act.ProductId = p.Id)
		where
			(@number is null or acc.Number = @number)
			and (@productName is null or p.ProductName like @productName)
			and (@accountDate is null or cast(@accountDate as date) = cast(acc.ActionTime as date))
		group by
			acc.Number,
			acc.ActionTime
		) as acc
	where
		(@sumFrom is null or acc.AccountSum >= @sumFrom)
		and (@sumTo is null or acc.AccountSum <= @sumTo)


go


CREATE PROCEDURE DeleteProduct
	@id int
AS
	update Products
	set Deleted = 1
	where Id = @id

go