create database Day7Db
use Day7Db
create table Customer
(Id int primary key,
Name nvarchar(50) not null,
ODLimit float not null,
SStartDate date not null,
SEndDate date not null)

insert into Customer values (1,'Sam',598000,'12/12/2019','12/12/2023')
insert into Customer values (2,'Sravs',898000,'02/20/2022','12/12/2024')
insert into Customer values (3,'Swapna',998000,'12/12/2019','12/12/2022')

select * from Customer