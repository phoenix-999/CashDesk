

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
			sum(p.Price - act.Discount) as AccountSum
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
	order by
		acc.ActionTime desc