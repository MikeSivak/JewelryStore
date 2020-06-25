use JewerlyStore;

create table Roles	--Роли
(
	idRole int not null IDENTITY(1,1)  primary key,
	roleName nvarchar(10) not null
);

create table Users	--Все пользователи (Включая администратора и кассиров)
(
	idUser int not null IDENTITY(1,1) primary key,
	idRole int not null,
	email nvarchar(50) not null,
	password nvarchar(50) not null,
	first_name nvarchar(50) not null,
	last_name nvarchar(50) not null,
	phone_number int
);

create table Orders --Заказы
(
	idOrder int not null IDENTITY(1,1) primary key,
	idUser int not null,
	idProduct int not null,
	orderDate date not null,
	totalPrice int
);

create table OrdersHistory --История заказов
(
	idOrder int not null IDENTITY(1,1) primary key,
	idUser int not null,
	idProduct int not null,
	orderDate date not null,
	totalPrice int
);

create table Products	--Товары
(
	idProduct int not null IDENTITY(1,1) primary key,
	productPrice int not null,
	productQuantity int not null,
	idManufacturer int not null,
	idType int not null,
	idMaterial int not null
);

create table Manufacturers	--Производители
(
	idManufacturer int not null IDENTITY(1,1) primary key,
	nameManufacturer nvarchar(20) not null,
	idCountry int not null
);

create table Countries	--Страны производителей
(
	idCountry int not null IDENTITY(1,1) primary key,
	nameCountry nvarchar(30) not null
);

create table ProductsTypes	--Типы продуктов (Цепочка, браслет, серёжки и т.д.)
(
	idType int not null IDENTITY(1,1) primary key,
	nameType nvarchar(50) not null
);

create table ProductsMaterials	--Материал продуктов
(
	idMaterial int not null IDENTITY(1,1) primary key,
	nameMaterial nvarchar(50) not null
);

create table WorkTime --Время работы кассира
(
	idUser int,
	time int
);