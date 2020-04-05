

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