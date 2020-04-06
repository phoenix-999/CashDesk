use CashDesc
create table Accounts(
Number varchar(32) not null primary key,
ActionTime datetime2(7) not null default getdate()
)