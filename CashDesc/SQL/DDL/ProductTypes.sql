use CashDesc
create table ProductTypes(
Id int not null primary key identity(1,1),
TypeName nvarchar(200) not null,
Status int not null default 0

)