CREATE DATABASE Universidad

USE Universidad

CREATE TABLE Alumnos(
IdAlumno int primary key identity, 
Nombre nvarchar(60), 
Apellido nvarchar(60),
DNI int, 
Codigo_Carrera nvarchar(2)
)