use CashDesc
insert into ProductTypes(TypeName) values 
('Тип 1'),
('Тип 2'),
('Тип 3')

go

use CashDesc
insert into Products (ProductName, Price, TypeId ) values
('Продукт 1', 100, 1),
('Продукт 2', 200, 2),
('Продукт 3', 300, 3)

go

use CashDesc
insert into Accounts (Number, ActionTime) values
('AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA', GETDATE()),
('BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB', GETDATE())

go

use CashDesc
insert into Actions(AccountNumber, ProductId, Amount) values
('AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA', 1, 100),
('BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB', 2, 200),
('BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB', 3, 300)

go