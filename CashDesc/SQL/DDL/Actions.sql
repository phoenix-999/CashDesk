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