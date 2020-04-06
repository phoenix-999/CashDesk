CREATE PROCEDURE DeleteProduct
	@id int
AS
	update Products
	set Deleted = 1
	where Id = @id
