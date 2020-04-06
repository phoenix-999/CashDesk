use CashDesc
go

create table StatusDescriptions(
Id int not null primary key,
Description nvarchar(200) not null default ''
)