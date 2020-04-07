use CashDesc
go

insert into StatusDescriptions (Id, Description) values
(0, 'В наличии'),
(1, 'В ожидании доставки')

go

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
insert into Accounts default values

go

use CashDesc
insert into Accounts default values

go

use CashDesc
insert into Actions(AccountNumber, ProductId, Amount) values
(1, 1, 100),
(2, 2, 200),
(2, 3, 300)