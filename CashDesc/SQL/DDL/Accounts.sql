use CashDesc
create table Accounts(
Number int not null primary key identity(1,1),
ActionTime datetime2(7) not null default getdate()
)