use CashDesc
create table Products(
Id int not null primary key identity(1,1),
ProductName nvarchar(200) not null,
Price money not null default 0,
Description nvarchar(max) null,
Deleted bit not null default 0,
TypeId int not null,
constraint FK_Products_ProductTypes foreign key (TypeId) references ProductTypes (Id)
)