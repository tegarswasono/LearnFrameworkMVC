CREATE TABLE Products(
	ProductId int not null primary key,
    ProductName varchar(50) not null,
    SupplierId int,
    CategoryId int,
    QuantityPerUnit varchar(50) not null,

	UnitPrice decimal,
    UnitsInStock int,
    UnitsOnOrder int,
    ReorderLevel int,
    Discontinued bit,

	DiscontinuedDate datetime2
)