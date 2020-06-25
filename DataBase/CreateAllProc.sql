use JewerlyStore;

go
create procedure addRoles as
begin
	insert into Roles(roleName)
	values('admin'),
	('cashier'),
	('client')
end;

--execute addRoles;

go
create procedure addAdmin as
begin
	insert into Users(idRole, email, password, first_name, last_name, phone_number)
	values(1, 'noizemcnorm@gmail.com', '1999', 'Mike', 'Sivak', 7314004)
end;

--execute addAdmin;

go
create procedure addCashier	--Procedure for Admin
@email nvarchar(50),
@password nvarchar(50),
@first_name nvarchar(50),
@last_name nvarchar(50),
@phone_number int
as
begin
	insert into Users(idRole, email, password, first_name, last_name, phone_number)
	values(2, @email, @password, @first_name, @last_name, @phone_number)
end;

go
create procedure deleteCashier	--Procedure for Admin
@email nvarchar(50)
as
begin 
	delete from Users
		where email = @email;
end;
go 

create procedure addClient	--Procedure for Clients
@email nvarchar(50),
@password nvarchar(50),
@first_name nvarchar(50),
@last_name nvarchar(50),
@phone_number int
as
begin 
	insert into Users(idRole, email, password, first_name, last_name, phone_number)
	values(3, @email, @password, @first_name, @last_name, @phone_number)
end;
go

--insert into Users(idRole, email, password, first_name, last_name, phone_number)
--	values(3, 'fdgf@gmail.com', 'nnnn', 'Ярик', 'Водзила', 2347524),
--	(3, 'fgdfhdg@gmail.com', 'pppp', 'Наталья', 'Морская-Пехота', 9993394),
--	(3, 'gfdgf@gmail.com', 'dddd', 'Дверь', 'Запили', 4567893);

create procedure deleteClient	--Procedure for Admin
@email nvarchar(50)
as
begin
	delete from Users
		where email = @email;
end;
go

create procedure addCountry	--Procedure for Admin
@nameCountry nvarchar(30)
as 
begin 
	insert into Countries(nameCountry)
	values(@nameCountry);
end;

go
create procedure deleteCountry	--Procedure for Admin
@nameCountry nvarchar(30)
as 
begin
	delete from Countries
	where nameCountry = @nameCountry;
end;
--drop procedure deleteCountry;

go
create procedure addManufacturer	--Procedure for Admin
@nameManufacturer nvarchar(20),
@idCountry int
as
begin
	insert into Manufacturers(nameManufacturer, idCountry)
	values(@nameManufacturer,@idCountry)
end;

go
create procedure getManufacturers
as begin
	select nameManufacturer from Manufacturers;
end;
go

create procedure getCashiersEmails
as begin
	select email from Users where idRole = 2;
end;
go

create procedure getClientsEmails
as begin 
	select email from Users where idRole = 3;
end;
go

create procedure getCountryId
@nameCountry nvarchar(30),
@idCountry int out
as begin
	select @idCountry = idCountry from Countries where nameCountry = @nameCountry;
end;

go 
create procedure getMnftrByCntryName
@idCountry int,
@nameManufacturer nvarchar(20) out
as begin
	select @nameManufacturer = nameManufacturer from Manufacturers where idCountry = @idCountry;
end;
go

create procedure deleteManufacturer	--Procedure for Admin
@nameManufacturer nvarchar(20)
as begin 
	delete from Manufacturers
	where nameManufacturer = @nameManufacturer;
end;


go
create procedure addProduct --Procedure for Admin NEW PROCEDURE
@productPrice int,
@productQuantity int,
@idManufacturer int,
@idType int,
@idMaterial int
as begin
	insert into Products(productPrice, productQuantity, idManufacturer, idType, idMaterial)
	values(@productPrice, @productQuantity, @idManufacturer, @idType, @idMaterial)
end;
go
create procedure getManufacturerId
@nameManufacturer nvarchar(20),
@idManufacturer int out
as begin
	select @idManufacturer = idManufacturer from Manufacturers where nameManufacturer = @nameManufacturer;
end;
go

create procedure getQuantityProducts
as begin
	select COUNT(*) from Products;
end;
go

create procedure getTypeById
@idType int,
@nameType nvarchar(50) out
as begin
	select @nameType = nameType from ProductsTypes where idType = @idType;
end;

go
create procedure deleteProduct --Procedure for Admin NEW PROCEDURE
@idProduct int
as begin
	delete from Products
	where idProduct = @idProduct;
end;

go
create procedure addOrder --Procedure for Cashier NEW PROCEDURE
@idUser int,
@idProduct int,
@orderDate date,
@totalPrice int
as begin
	insert into Orders(idUser, idProduct, orderDate, totalPrice)
	values(@idUser, @idProduct, @orderDate, @totalPrice);
end;
go

create procedure addHistoryOrder
@idUser int,
@idProduct int,
@orderDate date,
@totalPrice int
as begin
	insert into OrdersHistory(idUser, idProduct, orderDate, totalPrice)
	values(@idUser, @idProduct, @orderDate, @totalPrice);
end;
go

create procedure getHistoryOrders
as begin
	select * from OrdersHistory order by totalPrice desc;
end;
go

go 
create procedure deleteOrder  --Procedure for Cashier NEW PROCEDURE
@idOrder int
as begin
	delete from Orders
	where idOrder = @idOrder;
end;

go
create procedure addMaterial
@nameMaterial nvarchar(50)
as begin
	insert into ProductsMaterials(nameMaterial)
	values(@nameMaterial);
end;
go
create procedure getMaterials
as begin
	select nameMaterial from ProductsMaterials;
end;
go 
create procedure getMaterialId
@nameMaterial nvarchar(50),
@idMaterial int out
as begin
	select @idMaterial = idMaterial from ProductsMaterials where nameMaterial = @nameMaterial;
end;

go 
create procedure deleteMaterial
@nameMaterial nvarchar(50)
as begin
	delete from ProductsMaterials
	where nameMaterial = @nameMaterial;
end;


go 
create procedure addType
@nameType nvarchar(50)
as begin
	insert into ProductsTypes(nameType)
	values(@nameType);
end;

go 
create procedure deleteType
@nameType nvarchar(50)
as begin
	delete from ProductsTypes
	where nameType = @nameType;
end;
go 
create procedure getTypes
as begin
	select nameType from ProductsTypes;
end;
go
create procedure getTypeId
@nameType nvarchar(50),
@idType int out
as begin
	select @idType = idType from ProductsTypes where nameType = @nameType;
end;



go 
--create procedure updateClient
--@idUser int,
--@email nvarchar(50),
--@password nvarchar(50),
--@first_name nvarchar(50),
--@last_name nvarchar(50),
--@phone_number int
--as begin
--	update Users 
--	set 
--		email = @email,
--		password = @password,
--		first_name = @first_name,
--		last_name = @last_name,
--		phone_number = @phone_number
--	where idUser = @idUser and idRole = 3;
--end;
--go


create procedure updateUser
@idUser int,
@email nvarchar(50),
@password nvarchar(50),
@first_name nvarchar(50),
@last_name nvarchar(50),
@phone_number int
as begin
	update Users 
	set 
		email = @email,
		password = @password,
		first_name = @first_name,
		last_name = @last_name,
		phone_number = @phone_number
	where idUser = @idUser;
end;

--go 
--create procedure updateCashier
--@idUser int,
--@email nvarchar(50),
--@password nvarchar(50),
--@first_name nvarchar(50),
--@last_name nvarchar(50),
--@phone_number int
--as begin
--	update Users 
--	set 
--		email = @email,
--		password = @password,
--		first_name = @first_name,
--		last_name = @last_name,
--		phone_number = @phone_number
--	where idUser = @idUser and idRole = 2;
--end;
--go


create procedure getCountries
as begin
	select nameCountry from Countries;
end;

--drop procedure getCountries;

go 
create procedure getAllUsers
as begin
	select * from Users;
end;
go

create procedure getCashiers
as begin
	select * from Users where idRole = 2;
end;
go

create procedure getClients
as begin
	select * from Users where idRole = 3;
end;
go

create procedure getProducts
as begin
	select * from Products;
end;
go

create procedure getAllMaterials
as begin
	select * from ProductsMaterials;
end;
go

create procedure getAllTypes
as begin
	select * from ProductsTypes;
end;
go

create procedure getAllCountries
as begin
	select * from Countries;
end;
go

create procedure getAllManufacturers
as begin
	select * from Manufacturers;
end;
go


create procedure getWorkTime
as begin
	select * from WorkTime;
end;
go

create procedure getMoney
as begin
	select totalPrice from OrdersHistory;
end;
go

create procedure getProductPrice
@idMaterial int,
@idType int,
@idManufacturer int,
@productPrice int out
as begin 
	select @productPrice = productPrice from Products where idMaterial = @idMaterial and idType = @idType and idManufacturer = @idManufacturer;
end;
go

create procedure getIdProduct
@idMaterial int,
@idType int,
@idManufacturer int,
@productPrice int,
@idProduct int out
as begin
	select @idProduct = idProduct from Products where idMaterial = @idMaterial and idType = @idType and idManufacturer = @idManufacturer and productPrice = @productPrice;
end;
go

create procedure getIdRole
@email nvarchar(50),
@password nvarchar(50),
@idRole int out
as begin
	select @idRole = idRole from Users where email = @email and password = @password;
end;
go

create procedure addWorkTime
@idUser int,
@time int
as begin
	insert into WorkTime(idUser, time)
	values(@idUser, @time);
end;
go

create procedure getAllOrders
as begin
	select * from Orders;
end;
go

create procedure getIdUser
@email nvarchar(50),
@password nvarchar(50),
@idUser int out
as begin
	select @idUser = idUser from Users where email = @email and password = @password;
end;
go

create procedure InfoUser
@email nvarchar(50) out,
@password nvarchar(50) out,
@first_name nvarchar(50) out,
@last_name nvarchar(50) out,
@phone_number int out,
@idUser int
as begin
	select @email = email, @password = password, @first_name = first_name, @last_name = last_name, @phone_number = phone_number from Users
		where idUser = @idUser;
end;
go


--select productPrice from Products
--create index productIndex on Products (productPrice);