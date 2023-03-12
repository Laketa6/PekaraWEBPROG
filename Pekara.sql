create database Pekara
use Pekara

create table pecivo
(
	Id int Primary Key Identity(1, 1),
	Naziv nvarchar(100),
	Ukus nvarchar (100),
	Cena decimal(12, 2)
)

SELECT * FROM pecivo