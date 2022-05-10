create database ex
use Ex

create table Admin
(
AdminID int identity(500,1) primary key,
AdminName varchar(20) not null,
Password varchar(20) not null
)

create table Registration(
UserID int identity(10,1) primary key,
UserName varchar(30) null,
Password varchar(20),
Address varchar(100),
Email varchar(20) not null, 
Phone varchar(20) null
)



create table Category(
CategoryId int identity(1000,1) primary key,
CategoryName varchar(50)
)

create table Products(
ProductID int identity(100,1) primary key,
productName varchar(30),
CategoryId int foreign key references Category(CategoryId) on delete cascade,
price float,
weight float,
stock int,
Description varchar(300)
)

create table ImageTable(
ImgId varchar(10) primary key,
[image name] nvarchar(100),
 [image] varbinary(max),
 ProductID int foreign key references Products(ProductID) on delete cascade
)

create table Event
(
EventID int identity(200,1) primary key,
EventName varchar(50) not null,
StartDate date not null,
EndDate date not null
)

create table Coupon
(
CouponID int identity(1500,1) primary key,
CouponName varchar(30) not null,
Discount float not null,
CategoryID int foreign key references Category(CategoryID) on delete cascade,
EventID int foreign key references Event(EventID) on delete cascade,
)

create table Cart(
CartId int identity(100,1) primary key ,
UserID int foreign key references Registration(UserID) on delete cascade,
ProductID int foreign key references Products(ProductID) on delete cascade
)

