CREATE PROCEDURE CreateAccount
	@outNumber int output
AS
begin
	insert into Accounts default values
	set @outNumber = SCOPE_IDENTITY()
end
