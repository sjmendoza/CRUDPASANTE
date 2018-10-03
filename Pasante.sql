create database Prueba;
use Prueba;
create table Pasante(
Id integer not null identity(1,1),
Carnet varchar(9) not null primary key,
Nombres varchar(30) not null,
Apellidos varchar(30) not null,
Edad integer not null,
Salario decimal(18,2) not null
)
