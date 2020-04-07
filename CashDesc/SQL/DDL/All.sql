create database CashDesc collate Cyrillic_General_CI_AS
go

use CashDesc
create table Accounts(
Number int not null primary key identity(1,1),
ActionTime datetime2(7) not null default getdate()
)

go

use CashDesc
go

create table StatusDescriptions(
Id int not null primary key,
Description nvarchar(200) not null default ''
)

go

use CashDesc
create table ProductTypes(
Id int not null primary key identity(1,1),
TypeName nvarchar(200) not null,
Status int not null default 0,
constraint FK_ProductTypes_StatusDescriptions foreign key (Status) references StatusDescriptions(Id)
)

go

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

go

use CashDesc
create table Actions(
Id int not null primary key identity(1,1),
AccountNumber int not null,
ProductId int not null,
Discount money not null default 0,
constraint FK_Actions_Accounts foreign key (AccountNumber) references Accounts (Number),
constraint FK_Actions_Products foreign key (ProductId) references Products (Id)
)

go

create nonclustered index IX_Actions_AccountNumber_ProductId on Actions (AccountNumber, ProductId)

go