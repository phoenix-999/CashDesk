use CashDesc
create table ProductTypes(
Id int not null primary key identity(1,1),
TypeName nvarchar(200) not null,
Status int not null default 0,
constraint FK_ProductTypes_StatusDescriptions foreign key (Status) references StatusDescriptions(Id)
)