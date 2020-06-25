go
Create procedure insertUsers
as
declare @num int,
@role int,
@email nvarchar(50),
@password int,
@first_name nvarchar(50),
@last_name nvarchar(50),
@phone_number int;
set @num =13;
set @password = RAND(1);

while @num<=100000
begin
if (@num % 100)=0
set @role = 1
else if (@num % 100)=1
set @role = 2
else set @role = 3 

set @email = 'user' + cast(@num as nvarchar(8))+'@gmail.com';
set @password = CEILING(rand()*3000);
set @first_name = 'firstname' + cast(@num as nvarchar(8));
set @last_name = 'lastname' + cast(@num as nvarchar(8));
set @phone_number = 1000000+@num;
insert into Users(idRole,email,password,first_name,last_name, phone_number)
values(@role,@email,@password,@first_name,@last_name,@phone_number)
set @num=@num+1;
end;

exec insertUsers;

create index emailIndex on Users (email);
select email from Users

create procedure deleteUsers
as
declare @number int
set @number = 18

while @number<=100005
begin
delete from Users where idUser = @number
set @number = @number + 1;
end;

exec deleteUsers

