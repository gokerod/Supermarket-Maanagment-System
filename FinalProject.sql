--create database finalProject
--use finalProject
create table ProductList (
	pid  int identity primary key not null
	,Pname varchar(50) not null
	,Discription varchar(100) null
	,Price float
)
select * from Supplier

	
create table Product(
	pid int references ProductList(pid)
	,ImportedDate date
	,ExpiryDate date null
	,DaystoExpire int
	,Quantity int not null
	,SupplierPhone varchar(13) not null references Supplier(PhoneNumber)
)
/*
drop function test
go
create or alter function test (@eid varchar(5))
returns table 
as 
return 
	select distinct ps.pid, ps.Quantity,ps.ImportedDate,Qunatity, t.eid,t.Status from Product as ps left outer join [Transaction] as t on ps.pid = t.pid where t.Status = 'pending' and t.eid = @eid and ps.Quantity > 0
go
select * from  dbo.test ('1')
select * from Product
exec InsertIntoProduct 6,'12-12-2000','12-12',40,'0912233456'*/

create or alter function test (@pid int)
returns table 
as 
return 
	select top 1 * from Product where pid = @pid and Quantity > 0 order by DaystoExpire asc
go

select * from dbo.test (6)

declare @num int = 50
go
create or alter proc DoSell @pid int, @quantity int
as
begin
	while @quantity > 0
	begin
		select * from dbo.test (@pid)
		if (select Quantity from dbo.test (@pid)) < @quantity
			begin 
			set @quantity = @quantity - (select Quantity from dbo.test (@pid))
			update [Product] set Quantity = 0 where pid = (select pid from dbo.test (@pid)) and ImportedDate = (select ImportedDate from dbo.test (@pid))
			end
		else 
			begin 
			update [Product] set Quantity = (select Quantity from dbo.test (@pid)) - @quantity where pid = (select pid from dbo.test (@pid)) and ImportedDate = (select ImportedDate from dbo.test (@pid))
			set @quantity = 0
			end
	end
end
select * from Product
exec DoSell 6,71
create table Supplier(
	PhoneNumber varchar(13) primary key not null
	,Name varchar(20)
	,Address varchar(50)
	,status varchar(10)
)
create table Employee(
	eid varchar(5) primary key not null
	,Name varchar(20) not null
	,Title varchar(20) not null
	,PhoneNumber varchar(13) unique not null
	,Password varchar(20) not null
	,status varchar(10)
)

create table [Transaction] (
	eid varchar(5) references Employee(eid)
	,pid int references ProductList(pid)
	,Qunatity int not null
	,DateIssued date
	,Status varchar (10)
)

go
create proc GetRole
@eid varchar(20), @password varchar(20)
as 
select Title
from Employee
where eid = @eid and [password] = @password
go

go
create proc GetPassword
@eid varchar(5)
as
select [Password] from Employee where eid = @eid;
go

go
create proc GetName
@eid varchar(20)
as 
select Name
from Employee
where eid = @eid 
go


/*-----------------------------Function ----------------------------------*/
go
create or alter function GetProductQuantity (@pid int)
returns int
as
begin
	declare @productID int
select @productID = sum( Quantity) from Product where pid = @pid
return @productID
end
go

select * from Employee

--PROCEDURES 
-------For Employee Table
go
	create proc InsertIntoEmployee 
		@eid varchar(5), @name varchar(20),@title varchar(20),@Phonenumber varchar(13), @password varchar(15), @status varchar(50)
		as
		begin
			insert into Employee values 
				(@eid,@name,@title,@Phonenumber,@password,@status)
		end 
go
go 

go
create proc UpdateEmployeePassword
@eid varchar(5), @password varchar(20)
as 
update Employee set [Password] = @password where eid = @eid
go

create proc UpdateEmployee 
@eid varchar (5),@name varchar(20)=null, @title varchar(20)=null, @phonenumber varchar(13)=null, @password varchar(20)=null, @status varchar(10)=null
as
begin 
	update Employee set Name = @name,Title = @title, PhoneNumber = @phonenumber, status = @status
	where eid = @eid;

end
go

go
create proc SelectEmployee  @name varchar(50) = null, @eid varchar(5)=null
as
begin
  select eid,Name,Title,PhoneNumber,status from Employee where Name like '%'+@name+'%' or eid = @eid

end
go


go
create proc DeleteEmployee  @eid varchar(5) 
as
begin
delete Employee where eid = 1
end
go 



-------For Product Table
go
	create or alter proc InsertIntoProduct 
		@pid int, @importeddate date, @expirydate date, @quantity int, @supplierphone varchar(13)
		as
		begin
			insert into Product values 
				(@pid,@importeddate,@expirydate,(DATEDIFF(DAY,cast(@expirydate as varchar(20)),GETDATE())),@quantity,@supplierphone)
		end
go
go
-- updateproduct (rowid, colname = newvalue)
create proc UpdateProduct @pid int, @importeddate date, @expirydate date = null, @quantity int= null, @supplierphone varchar(13)= null
as 
begin
	update Product set ExpiryDate = @expirydate, Quantity = @quantity, SupplierPhone=@supplierphone
	where pid=@pid and ImportedDate = @importeddate
end 
go
select * from Product
go
--exec SelectProduct 'list of the columns','filtering conditions'
create or alter proc SelectProduct  @pid int = null
as
begin
	if @pid is not null
	begin 
		select * from Product where pid = @pid
	end 
	else 
	begin 
		select * from Product
	end
end
select * from [Transaction]
go

go
--exec DeleteProduct 'filtering conditions'
create proc DeleteProduct  @pid int, @importeddate date
as
begin
 delete Product where pid = @pid and ImportedDate = @importeddate
end
go

delete ProductList where pid = 5
-------For ProductList Table 
select * from ProductList
go 
	create proc InsertIntoProductList
		@pname varchar(50), @discription varchar(100), @Price float
		as
		begin 
		insert into ProductList values 
			(@pname,@discription,@price)
		end
go

go 
-- updateProductlist (rowid, colname = newvalue)
create proc UpdateProductList @pid int, @pname varchar(50) = null, @discription varchar(100) = null, @price float
as
begin 
	update ProductList set Pname = @pname, Discription = @discription, Price=@price 
	where pid = @pid
end
go

go
--exec SelectProductList 'list of the columns','filtering conditions'
create or alter proc SelectProductList @pname varchar(50),@pid int = null
as
begin
 select pid,Pname,Discription,Price,dbo.GetProductQuantity(pid) as Quantity from ProductList where Pname like '%'+@pname+'%' and dbo.GetProductQuantity(pid) is not null
end
go
select pid,Pname,Discription,Price,dbo.GetProductQuantity(pid) as Quantity from ProductList where Pname like '%'+'pc'+'%'
go

create or alter proc SelectProductListOutOfStock @pname varchar(50),@pid int = null
as
begin
 select pid,Pname,Discription,Price,dbo.GetProductQuantity(pid) as Quantity from ProductList where Pname like '%'+@pname+'%' 
end
go
select pid,Pname,Discription,Price,dbo.GetProductQuantity(pid) as Quantity from ProductList where Pname like '%'+'pc'+'%'
go


exec SelectProductList
--exec DeleteProductList 'filtering conditions'
create proc DeleteProductList  @pid int
as
begin
	delete ProductList where pid = @pid
end
go

-------For Supplier Table
go
	create proc InsertIntoSupplier
		@phonenumber varchar(13), @name varchar(20), @address varchar(50), @status varchar(50)
		as
		begin 
		insert into Supplier values 
			(@phonenumber,@name,@address,@status)
		end
go


go
create proc UpdateSupplier 
		@phonenumber varchar(13), @name varchar(20), @address varchar(50), @status varchar(50)
as 
begin
	update Supplier set Name =@name, Address=@address, status=@status 
	where PhoneNumber=@PhoneNumber;
end 
go
go
--exec SelectSupplier 'list of the columns','filtering conditions'
create proc SelectSupplier  @name varchar(20), @phoneNumber varchar(13)
as
begin
 select * from Supplier where Name like '%'+@name+'%' or PhoneNumber = @phoneNumber
end
go

go
--exec DeleteSupplier 'filtering conditions'
create proc DeleteSupplier  @phoneNumber varchar(13) 
as
begin
 delete Supplier where PhoneNumber = @phoneNumber
end
go
exec DeleteSupplier '555'
select * from Supplier

-------For Transaction Table
go
	create proc InsertIntoTransaction
		@eid varchar(5), @pid int, @qunatity int
		as
		begin 
			insert into [Transaction] values(@eid,@pid,@qunatity,GETDATE(),'pending')
		end
go

go
create proc UpdateTransaction @eid varchar(5)
as
begin
	update [Transaction] set [Status] = 'Paid' 
	where eid = @eid and [Status] = 'pending'
end
go

go
--exec SelectTransaction 'list of the columns','filtering conditions'
create proc SelectTransaction @eid varchar(5)
as
begin
	 select pid,Qunatity,[Status]
	 from [Transaction]
	 where [Status] = 'pending' and eid = @eid
end
go

go
--exec DeleteTansaction 'filtering conditions'
create proc DeleteTansaction @eid varchar(5), @pid int, @quantity int
as
begin
	 delete [Transaction] where eid = @eid and pid = @pid and Qunatity = @quantity
end
go

--FUNCTIONS
go
create function GetProductToSubtract (@pid int)
returns date
as
begin
	declare @importeddate date
select top 1 @importeddate = ImportedDate
		from Product
		where pid = @pid and Quantity > 0
		order by DaystoExpire
return @importeddate
end
go

go
create function ReciptTable (@eid int)
returns table
as
return select p.pid,p.Pname, p.price, t.Qunatity
	from ProductList p join [Transaction] t on p.pid = t.pid 
	where t.eid = @eid and t.Status = 'Pending'
go

go
create function GetTitle (@eid int)
returns varchar(15)
as
begin
	declare @title varchar(15)
	select @title = Title from Employee where eid = @eid
	return @title 
end
go

go
create function GetProductDetailForManager (@pid int)
returns table 
return (select pl.pid,pl.Pname,pl.price,p.Quantity,pl.Discription,p.ImportedDate,p.DaystoExpire 
		from Product p join ProductList pl on p.pid = pl.pid 
		where p.pid = @pid
		)
go

go
create function GetProductDetailForSeller (@pid int)
returns table 
return (select pl.pid,pl.Pname,pl.price,p.DaystoExpire 
		from Product p join ProductList pl on p.pid = pl.pid 
		where p.pid = @pid
		)
go
select * from dbo.GetProductDetailForSeller(2)

--SPs
go
create proc login @id int = null, @password varchar(20) = null
as 
begin
	if(@id is null or @password is null) or (select count(*) from Employee where eid = @id) < 1 or (select [status] from Employee where eid = @id) = 'Deleted'
		begin 
			print 'Invalid Employee ID or Password'
			return 1
		end
	else
		begin
			if (select [Password] from Employee where eid = @id) = @password
			begin 
				print 'Login Successful'
				return 0
			end
			else 
			begin 
				print 'Incorrect Password'
				return 1
			end
		end
end
go

go
create proc logout @id int = null, @password varchar(20) = null 
as 
begin
	if(@id is null or @password is null) or (select count(*) from Employee where eid = @id) < 1 or (select [status] from Employee where eid = @id) = 'Deleted'
		begin 
			print 'Invalid Employee ID or Password'
			return 1
		end
	else
		begin
			if (select [Password] from Employee where eid = @id) = @password
			begin 
				print 'Logout Successful'
				return 0
			end
			else 
			begin 
				print 'Incorrect Password'
				return 1
			end
		end
end
go

go
create proc DeductProduct  @pid int,@amount int
as
begin
	while @amount > 0
	begin
	declare @importeddate date, @qunantityofproducts int--(with lower DaysToExpire value)
	set @importeddate = dbo.GetProductToSubtract(2)
	select @qunantityofproducts = Quantity from Product where ImportedDate = @importeddate and pid = @pid
	if @amount < @qunantityofproducts
		begin
			declare @newQunatity int = @qunantityofproducts - @amount
			exec UpdateProduct @pid,@importeddate, @quantity = @newQunatity
			set @amount = 0
		end
	else
		begin
			exec UpdateProduct @pid,@importeddate, @quantity = 0
			set @amount = @amount - @qunantityofproducts
		end

	print 'Stock deduction successful'

	end
end
go

go 
create proc sell @eid varchar(5), @pid int, @quantity int
as
begin 
	if ((select count(*) from ProductList where pid = @pid) < 0)
		print ('Invalid or Incorrect Product ID')
	else if (@quantity < 1)
		print ('Invalid Quantity')
	else
	begin 
		if ((select sum(Quantity) from Product where pid = @pid) < @quantity)
		print 'There is not enough Quantity of this product in stock'
		else 
			begin 
				exec InsertIntoTransaction @eid,@pid,@quantity 
			end
	end

end
go

go
create proc PrintRecipt @eid int
as
begin 
	declare @text varchar(max)
	declare @table table (  pid int,
							Pname varchar(20),
							Price float, 
							Quantity int 
							)
	insert into @table select * from dbo.ReciptTable (@eid)
	set @text = '-----------Recipt------------'+char(10)+char(10)+'Product		Price	 Quantity' + char(10)
	select @text += t.Pname +'			'+cast(t.Price as varchar(5))+'		'+cast(t.Quantity as varchar(5))+'		'+char(10)
	from @table t
	set @text += char(10)+'Total Price: ' + cast((select sum(Price*Quantity) from @table) as varchar(5))
	set @text += char(10)+'Date Issued: ' + cast(GETDATE() as varchar(11))
	print @text


	declare @pid int, @quantity int
	declare C cursor read_only for select pid,Quantity from @table
	open c
	fetch next from c into @pid,@quantity
	while @@FETCH_STATUS = 0
		begin 
			exec DeductProduct @pid,@quantity
			fetch next from c into @pid,@quantity
		end
	close c
	deallocate c
	exec UpdateTransaction @eid, @status='Paid'

end
go

go
create proc GetProductDetail @eid int, @pid int
as
begin 
	if ((select count(*) from Employee where eid = @eid) < 1) 
		print 'Invalid Employee ID '
	else if((select count(*) from ProductList where pid = @pid) < 1)
		print 'Invalid Product ID'
	else
	begin
		if(dbo.GetTitle(@eid)='Manager'or dbo.GetTitle(@eid)='Seller')
		begin 
			if (dbo.GetTitle(@eid)='Manager')
				select * from dbo.GetProductDetailForManager(@pid)
			else 
				select * from dbo.GetProductDetailForSeller(@pid)
		end
		else
			print 'Invalid employee title'
	end
end
go



--TRIGGERS

go
create trigger ChangeStatusOnDeleteForEmployee on Employee
instead of delete
as
begin
	declare @eid int
	select @eid = eid from deleted
	exec UpdateEmployee @eid, @status = 'Deleted'
end
go
drop trigger ChangeStatusOnDeleteForEmployee
go
create trigger ChangeStatusOnDeleteForSupplier on Supplier
instead of delete
as
begin
	declare @phone varchar(13)
	select @phone = PhoneNumber from deleted
	exec UpdateSupplier @phone, @status = 'Deleted'
end
go
drop trigger ChangeStatusOnDeleteForSupplier

go
create trigger ProtectTables on Database
for create_table, create_table, drop_table
as
begin
	print ('Unautorized Action')
	rollback
end
go

go
create trigger DuplicateItemRemover on productlist
for Insert, update 
as 
begin 
	if(select count(*) from ProductList where Pname = (select Pname from inserted)) > 0
		begin
			print 'This product is already on the list'
			rollback
		end
end
go
drop trigger DuplicateItemRemover


select * from Employee 
select * from Supplier
select * from ProductList
select * from Product
select * from [Transaction]

exec InsertIntoEmployee 1,'Berket Habtamu','Manager','0953224242'
exec InsertIntoEmployee 2,'Daniel Kidus','Seller','0956321412'

exec InsertIntoSupplier '0988765432','Yakob Birhanu','Addis Ababa'
exec InsertIntoSupplier '0912233456','Melat Mulugeta','Addis Ababa'

exec InsertIntoProductList 'Sunchips','Beef Flavour',15
exec InsertIntoProductList 'TV','Hisense 38 Inch',10500
exec InsertIntoProductList 'Mama Milk','300 ml',20
exec InsertIntoProductList 'Bag','Black Jym Bag',1500
exec InsertIntoProductList 'Toothpaste ','Sensodine Cold',140

exec InsertIntoProduct 49,'12-12-2022','01-02-2022',70,'0912233456'
exec InsertIntoProduct 49,'12-10-2022','01-04-2022',20,'0988765432'
exec InsertIntoProduct 50,'02-12-2022','01-02-2300',5,'0912233456'
exec InsertIntoProduct 51,'12-12-2022','01-01-2022',30,'0912233456'
exec InsertIntoProduct 52,'02-10-2022','01-02-2044',10,'0988765432'
exec InsertIntoProduct 53,'02-22-2022','01-02-2022',50,'0988765432'

exec sell '2',49,8
exec sell '2',53,2

exec sell '2',49,2
exec sell '2',51,1

exec PrintRecipt 2


--New Requirment 

--Backup the Database 
go
backup database Abadir
to disk = 'H:\Files\Hilcoe\I Term\DB Admin\FullBackup.bak'
go
--Creating Schema
go
create schema People
go
go
create schema Stock
go

alter schema Peopel transfer [dbo].[Employee]
alter schema Peopel transfer dbo.Supplier

alter schema Peopel transfer dbo.Employee
alter schema Peopel transfer dbo.Employee
alter schema Peopel transfer dbo.Employee

--Adding users and privilege 
--Seller 
create login Seller with password = 'seller',
default_database = Abadir
create user seller for login Seller

grant select on productList to seller
grant select, update on [Transaction] to seller
grant update(password) on Employee to seller

grant exec on dbo.SelectProductList to seller
grant exec on dbo.printrecipt to seller
grant exec on dbo.sell to seller
grant exec on dbo.login to seller 
grant exec on dbo.logout to seller 
grant exec on dbo.UpdateEmployee to seller

--Manager
create login Manager with password = 'manager',
default_database = Abadir
create user Manager for login Manager

grant select, insert, delete, update on employee to Manager
grant select, insert, delete, update on product to Manager
grant select, insert, delete, update on productList to Manager
grant select, insert, delete, update on supplier to Manager

grant exec on [dbo].[SelectEmployee] to Manager
grant exec on [dbo].[SelectProduct] to Manager
grant exec on [dbo].[SelectProductList] to Manager
grant exec on [dbo].[SelectSupplier] to Manager

grant exec on [dbo].[InsertIntoEmployee] to Manager
grant exec on [dbo].[InsertIntoProduct] to Manager
grant exec on [dbo].[InsertIntoProductList] to Manager
grant exec on [dbo].[InsertIntoSupplier] to Manager

grant exec on [dbo].[DeleteEmployee] to Manager
grant exec on [dbo].[DeleteProduct] to Manager
grant exec on [dbo].[DeleteProductList] to Manager
grant exec on [dbo].[DeleteSupplier] to Manager

grant exec on [dbo].[UpdateEmployee] to Manager
grant exec on [dbo].[UpdateProduct] to Manager
grant exec on [dbo].[UpdateProductList] to Manager
grant exec on [dbo].[UpdateSupplier] to Manager


/*C# Code*/
exec SelectProduct '*'


go
create proc GetAllProducts @id int, @name varchar(50)
as
begin
	declare @query varchar(max)
	set @qu
end
go

select * from Product join ProductList on Product.pid = ProductList.pid 

/****************************************/
select * from Employee