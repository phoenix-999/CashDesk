CREATE PROCEDURE GetProductTypes
AS
	select
		pt.Id,
		pt.TypeName,
		sd.Description
	from
		ProductTypes pt
		inner join StatusDescriptions sd on (pt.Status = sd.Id)