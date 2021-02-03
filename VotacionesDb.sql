create database VotacionesDb
GO
use VotacionesDb
GO
create table Candidatos
(
    CandidatoId int primary key identity(1,1),
    Nombres varchar(100) not null,
    Apellidos varchar(100) not null,
    FechaNacimiento datetime,
    Email varchar(150) not null,
    TipoIdentificacion varchar(3) not null,
    NumeroIdentificacion varchar(20),
    Descripcion varchar(max),
    Foto varchar(max)
)

GO

create table Votantes
(
    VotanteId int primary key identity(1,1),
    Nombres varchar(100) not null,
    Apellidos varchar(100) not null,
    Sexo varchar(1),
    FechaNacimiento datetime,
    Email varchar(150) not null,
    TipoIdentificacion varchar(3),
    NumeroIdentificacion varchar(20)
)

GO

create table Usuarios
(
    UsuarioId int identity(1,1) primary key,
    NomUsuario varchar(15) not null,
    Contrasena varchar(30) not null,
    EsInterno bit default 0
)

GO

create table Elecciones
(
    EleccionId int primary key identity(1,1),
    Nombre varchar(150),
    FechaInicio datetime,
    FechaFinal datetime,
    Activa bit default 1
)

go

create table EleccionesCandidatos
(
    Id int primary key identity(1, 1),
    EleccionId int,
    CandidatoId int,
    FOREIGN KEY (EleccionId) references Elecciones(EleccionId),
    FOREIGN KEY (CandidatoId) references Candidatos(CandidatoId)
)

GO
create table ResultadosElecciones
(
    Id int primary key identity(1, 1),
    EleccionId int,
    CandidatoId int,
    VotanteId int,
    FOREIGN KEY (EleccionId) references Elecciones(EleccionId),
    FOREIGN KEY (CandidatoId) references Candidatos(CandidatoId),
    FOREIGN KEY (VotanteId) references Votantes(VotanteId)
)

GO

INSERT INTO [dbo].[Candidatos]
VALUES
( 
 'Juan', 'Perez', '1980-12-01', 'jperez@domain.com', 'CC', '12345678', 'Propuestas de Juan Perez', NULL
),
( 
 'Pepita', 'Perez', '1981-01-25', 'pperez@domain.com', 'CC', '87654321', 'Propuestas de Pepita Perez Perez', NULL
)
GO

INSERT INTO [dbo].[Votantes]
VALUES
( 
 'Camilo', 'Alvarez', 'M', '1997-06-01', 'calvarez@domain.com', 'CC', '80123456'
)
GO

INSERT INTO [dbo].[Usuarios]
VALUES
( 
 'admin', 'Abc.123456', 1
),
( 
 'calvarez', 'Abc.123456', 0
)
GO

INSERT INTO [dbo].[Elecciones]
VALUES
( 
 'Eleccion 1', '2021-02-01', '2021-02-01', 1
),
( 
 'Eleccion 2', '2021-02-02', '2021-02-02', 1
),
( 
 'Eleccion 3', '2021-03-01', '2021-03-01', 0
)
GO
INSERT [dbo].[EleccionesCandidatos] ([EleccionId], [CandidatoId]) VALUES (1, 1)
GO
INSERT [dbo].[EleccionesCandidatos] ([EleccionId], [CandidatoId]) VALUES (1, 2)
GO
INSERT [dbo].[EleccionesCandidatos] ([EleccionId], [CandidatoId]) VALUES (2, 1)
GO
INSERT [dbo].[EleccionesCandidatos] ([EleccionId], [CandidatoId]) VALUES (2, 2)
GO
INSERT [dbo].[EleccionesCandidatos] ([EleccionId], [CandidatoId]) VALUES (3, 1)
GO