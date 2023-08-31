create database LibraryDb
use LibraryDb
create table Books
(
BId int primary key,
BTitle nvarchar(50),
BAuthor nvarchar(50),
BGenre nvarchar(50),
BQty int)
insert into Books values(1,'The Earth','denver','12th',3)
insert into Books values(2,'Heros','kelvin','13th',4)
insert into Books values(3,'Catch me ','raj','14th',5)
insert into Books values(4,'If you Can','deven','15th',6)
insert into Books values(5,'Rose and the Beast','charlie','16th',7)
select * from Books
