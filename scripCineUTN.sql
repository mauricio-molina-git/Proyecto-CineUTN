create database CineUTN
USE [CineUTN]
GO
/****** Object:  Table [dbo].[Genero]    Script Date: 10/07/2020 22:37:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Genero](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Activo] [bit] NULL,
 CONSTRAINT [PK_Genero] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Genero] ON
INSERT [dbo].[Genero] ([Id], [Nombre], [Activo]) VALUES (1, N'Acción', 1)
INSERT [dbo].[Genero] ([Id], [Nombre], [Activo]) VALUES (2, N'Terror', 1)
INSERT [dbo].[Genero] ([Id], [Nombre], [Activo]) VALUES (3, N'Suspenso', 1)
INSERT [dbo].[Genero] ([Id], [Nombre], [Activo]) VALUES (4, N'Ciencia ficción', 1)
INSERT [dbo].[Genero] ([Id], [Nombre], [Activo]) VALUES (5, N'Animación', 1)
INSERT [dbo].[Genero] ([Id], [Nombre], [Activo]) VALUES (6, N'Comedia', 1)
INSERT [dbo].[Genero] ([Id], [Nombre], [Activo]) VALUES (7, N'Documental', 1)
INSERT [dbo].[Genero] ([Id], [Nombre], [Activo]) VALUES (8, N'Drama', 1)
SET IDENTITY_INSERT [dbo].[Genero] OFF
/****** Object:  Table [dbo].[Usuario]    Script Date: 10/07/2020 22:37:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Genero] [varchar](15) NULL,
	[Nacimiento] [int] NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Telefono] [varchar](50) NULL,
	[Password] [varchar](50) NOT NULL,
	[Admin] [bit] NULL,
	[Activo] [bit] NOT NULL,
	[DNI] [int] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de nacimiento en formato AAAAMMDD' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Usuario', @level2type=N'COLUMN',@level2name=N'Nacimiento'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Dirección de e-mail única' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Usuario', @level2type=N'COLUMN',@level2name=N'Email'
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON
INSERT [dbo].[Usuario] ([Id], [Nombre], [Apellido], [Genero], [Nacimiento], [Email], [Telefono], [Password], [Admin], [Activo], [DNI]) VALUES (1, N'Mauricio', N'Molina', N'Masculino', 19970206, N'mauricio87cjs@gmail.com', N'1132724000', N'123456', 0, 1, 40184763)
INSERT [dbo].[Usuario] ([Id], [Nombre], [Apellido], [Genero], [Nacimiento], [Email], [Telefono], [Password], [Admin], [Activo], [DNI]) VALUES (2, N'Gonzalo', N'Alderete', N'Masculino', 19970207, N'gonzaalderete@gmail.com', N'1132724010', N'123456', 1, 1, 41402102)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
/****** Object:  Table [dbo].[Tarjetas]    Script Date: 10/07/2020 22:37:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tarjetas](
	[IdUsuario] [int] NULL,
	[NumTarjeta] [bigint] NULL,
	[MesVencimiento] [int] NULL,
	[AnioVencimiento] [int] NULL,
	[CodSeguridad] [int] NULL,
	[DniTitular] [int] NULL,
	[NombreTitular] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Tarjetas] ([IdUsuario], [NumTarjeta], [MesVencimiento], [AnioVencimiento], [CodSeguridad], [DniTitular], [NombreTitular]) VALUES (1, 4517660152181448, 2, 2026, 123, 40184763, N'Mauricio Molina')
/****** Object:  Table [dbo].[Sucursal]    Script Date: 10/07/2020 22:37:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sucursal](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Direccion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Sucursal] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Sucursal] ON
INSERT [dbo].[Sucursal] ([Id], [Nombre], [Direccion]) VALUES (1, N'Cine UTN - Pilar', N'Fatima 1309')
INSERT [dbo].[Sucursal] ([Id], [Nombre], [Direccion]) VALUES (2, N'Cine UTN - Pacheco', N'Av. Hipólito Yrigoyen 1001')
INSERT [dbo].[Sucursal] ([Id], [Nombre], [Direccion]) VALUES (3, N'Cine UTN José C Paz', N'Altube 1528')
SET IDENTITY_INSERT [dbo].[Sucursal] OFF
/****** Object:  Table [dbo].[Precio]    Script Date: 10/07/2020 22:37:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Precio](
	[Formato3D] [bit] NOT NULL,
	[Precio] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[Formato3D] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Precio] ([Formato3D], [Precio]) VALUES (0, 500)
INSERT [dbo].[Precio] ([Formato3D], [Precio]) VALUES (1, 800)
/****** Object:  Table [dbo].[Calificacion]    Script Date: 10/07/2020 22:37:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Calificacion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Activo] [bit] NULL,
 CONSTRAINT [PK_Calificacion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Calificacion] ON
INSERT [dbo].[Calificacion] ([Id], [Nombre], [Activo]) VALUES (1, N'ATP', 1)
INSERT [dbo].[Calificacion] ([Id], [Nombre], [Activo]) VALUES (2, N'+13', 1)
INSERT [dbo].[Calificacion] ([Id], [Nombre], [Activo]) VALUES (3, N'+16', 1)
INSERT [dbo].[Calificacion] ([Id], [Nombre], [Activo]) VALUES (4, N'+18', 1)
SET IDENTITY_INSERT [dbo].[Calificacion] OFF
/****** Object:  StoredProcedure [dbo].[AgregarUsuario]    Script Date: 10/07/2020 22:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AgregarUsuario]

@Nombre varchar(50),
@Apellido varchar(50),
@Dni int,
@Genero varchar(15),
@Nacimiento int,
@Email varchar(50),
@Telefono varchar(50),
@Password varchar(50),
@Admin bit,
@Activo bit
AS

INSERT INTO Usuario(Nombre, Apellido,Dni, Genero, Nacimiento, Email, Telefono, [Password], Admin, Activo)
VALUES(@Nombre, @Apellido,@Dni, @Genero, @Nacimiento, @Email, @Telefono, @Password, @Admin, @Activo)
GO
/****** Object:  StoredProcedure [dbo].[AgregarTarjeta]    Script Date: 10/07/2020 22:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[AgregarTarjeta]
@IdUsuario int,
@NumTarjeta bigint,
@MesVencimiento int, 
@AnioVencimiento int,
@CodSeguridad int,
@DniTitular int,
@NombreTitular varchar(50)
AS

insert into Tarjetas(IdUsuario, NumTarjeta, MesVencimiento, AnioVencimiento, CodSeguridad, DniTitular, NombreTitular)
values(@IdUsuario, @NumTarjeta, @MesVencimiento, @AnioVencimiento, @CodSeguridad, @DniTitular, @NombreTitular)
GO
/****** Object:  StoredProcedure [dbo].[AgregarGenero]    Script Date: 10/07/2020 22:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AgregarGenero]
@Nombre varchar(50),
@Activo bit
AS

INSERT INTO Genero(Nombre, Activo)
VALUES(@Nombre, @Activo)
GO
/****** Object:  StoredProcedure [dbo].[AgregarClasificacion]    Script Date: 10/07/2020 22:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AgregarClasificacion]
@Nombre varchar(50),
@Activo bit
AS

INSERT INTO Calificacion(Nombre, Activo)
VALUES(@Nombre, @Activo)
GO
/****** Object:  Table [dbo].[Pelicula]    Script Date: 10/07/2020 22:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Pelicula](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Imagen] [varchar](100) NULL,
	[Calificacion] [int] NOT NULL,
	[Formato3D] [bit] NOT NULL,
	[Duracion] [int] NOT NULL,
	[Genero] [int] NOT NULL,
	[Sinopsis] [varchar](800) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Pelicula] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'URL de la imagen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Pelicula', @level2type=N'COLUMN',@level2name=N'Imagen'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Duración en minutos' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Pelicula', @level2type=N'COLUMN',@level2name=N'Duracion'
GO
SET IDENTITY_INSERT [dbo].[Pelicula] ON
INSERT [dbo].[Pelicula] ([Id], [Nombre], [Imagen], [Calificacion], [Formato3D], [Duracion], [Genero], [Sinopsis], [Activo]) VALUES (1, N'Rápidos y Furiosos 9', N'~/ImagenesPeliculas/1.jpg', 2, 0, 142, 1, N'Instalados en su vida familiar, Dom y Letty viven en el campo con Brian, el hijo de Dom. Pero los problemas siguen tocando la puerta a la familia: Jakob, el hermano menor de Dom, se ha unido con Cipher para causar estragos y cumplir un deseo de venganza por parte de Cipher tras de los sucesos de The Fate of the Furious. El equipo se reunirá una vez más para mantener a la familia unida y deshacerse de los problemas de una vez por todas.', 1)
INSERT [dbo].[Pelicula] ([Id], [Nombre], [Imagen], [Calificacion], [Formato3D], [Duracion], [Genero], [Sinopsis], [Activo]) VALUES (2, N'Joker', N'~/ImagenesPeliculas/2.jpg', 3, 0, 122, 3, N'Arthur Fleck es un payaso con una extraña enfermedad mental. Responsable del cuidado de su madre enferma, sueña con su propio espectáculo de stand up comedy. La situación no es favorable. Tanto su condición mental como su oficio lo hacen blanco frecuente de agresiones en ciudad Gótica, ciudad sumida en una profunda tensión social. Fleck es atacado en el metro por tres jóvenes ebrios, pero esta vez, decide ser el victimario. El triple asesinato, divulgado en los medios de comunicación, genera la simpatía de los ciudadanos. ', 1)
INSERT [dbo].[Pelicula] ([Id], [Nombre], [Imagen], [Calificacion], [Formato3D], [Duracion], [Genero], [Sinopsis], [Activo]) VALUES (3, N'La odisea de los giles', N'~/ImagenesPeliculas/3.jpg', 2, 0, 116, 8, N'La trama de la historia se sitúa durante la crisis argentina del 2001. Cuenta la historia de un grupo de vecinos de un pequeño pueblo argentino (Alsina), y su intento de superar la crisis con un proyecto colectivo. Cuando sobreviene el "corralito" se ven envueltos en una estafa que los deja prácticamente en la ruina. Los vecinos pronto verán la oportunidad de vengarse mediante métodos sui generis, y conseguir así una merecida revancha.', 1)
INSERT [dbo].[Pelicula] ([Id], [Nombre], [Imagen], [Calificacion], [Formato3D], [Duracion], [Genero], [Sinopsis], [Activo]) VALUES (4, N'Tenet', N'~/ImagenesPeliculas/4.jpg', 3, 0, 150, 4, N'Armado con una sola palabra, Tenet, y luchando por la supervivencia del planeta, el protagonista viaja a un mundo crepuscular de espionaje internacional en una misión que supera los límites del tiempo real. No son realmente viajes sino inversión en el tiempo', 1)
INSERT [dbo].[Pelicula] ([Id], [Nombre], [Imagen], [Calificacion], [Formato3D], [Duracion], [Genero], [Sinopsis], [Activo]) VALUES (5, N'Wonder Woman 1984', N'~/ImagenesPeliculas/5.jpg', 2, 0, 151, 1, N'Diana Prince, conocida como Wonder Woman se enfrenta a Cheetah, una villana que posee fuerza y agilidad sobrehumanas. Al principio ella es la heroína que quiere ser, pero su lado “bestia” se vuelve inmanejable. La gente se vuelve contra ella por miedo, obligándola a convertirse en una villana. Solo Diana podrá detenerla.', 1)
INSERT [dbo].[Pelicula] ([Id], [Nombre], [Imagen], [Calificacion], [Formato3D], [Duracion], [Genero], [Sinopsis], [Activo]) VALUES (6, N'El robo del siglo', N'~/ImagenesPeliculas/6.jpg', 2, 0, 114, 6, N'La película está basada en una historia real, el robo de la sucursal del Banco Río de la localidad bonaerense de Acassuso el 13 de enero de 2006,? la cual fue asaltada por una banda de seis ladrones armados con armas de juguete. Tomaron 23 rehenes y se llevaron 15 millones de dólares de 147 cajas de seguridad, que abandonaron posteriormente tras la huida.', 1)
INSERT [dbo].[Pelicula] ([Id], [Nombre], [Imagen], [Calificacion], [Formato3D], [Duracion], [Genero], [Sinopsis], [Activo]) VALUES (7, N'Había una vez en Hollywood', N'~/ImagenesPeliculas/7.jpg', 4, 0, 160, 6, N'La película Había Una Vez ... En Hollywood de Quentin Tarantino nos lleva a la ciudad de Los Angeles en 1969 donde todo está cambiando, la estrella de la televisión, Rick Dalton (Leonardo DiCaprio), y su doble de acción Cliff Booth (Brad Pitt) buscan un camino en una industria que ya no reconocen - la novena película del guionista -director incluye un gran ensamble como elenco y múltiples historias en un tributo a los últimos momentos de la época dorada de Hollywood.', 1)
INSERT [dbo].[Pelicula] ([Id], [Nombre], [Imagen], [Calificacion], [Formato3D], [Duracion], [Genero], [Sinopsis], [Activo]) VALUES (8, N'Cosquin Rock XV', N'~/ImagenesPeliculas/8.jpg', 1, 0, 90, 7, N'Cuando Charly García todavía era flaco, cuando Papo estaba aún entre los mortales, cuando el Pelado Cordera estaba en la Bersuit, Ciro Pertusi en Attaque 77 o Ciro Martínez en Los Piojos, se gestó en Córdoba un festival de rock. Este documental narra los primeros 15 años del festival mas grande del país.', 1)
INSERT [dbo].[Pelicula] ([Id], [Nombre], [Imagen], [Calificacion], [Formato3D], [Duracion], [Genero], [Sinopsis], [Activo]) VALUES (9, N'Black Widow', N'~/ImagenesPeliculas/9.jpg', 2, 1, 101, 1, N'Situada 1 año después de los sucesos de Capitán América: Civil War y antes de Avengers: Infinity War, Natasha Romanoff se encuentra sola y obligada a enfrentar una peligrosa conspiración con lazos con su pasado mientras es buscada por la ley. Perseguida por una fuerza que no se detendrá ante nada para derribarla, Romanoff debe lidiar con su historia como espía y las relaciones rotas que dejó a su paso mucho antes de convertirse en Vengadora.', 1)
INSERT [dbo].[Pelicula] ([Id], [Nombre], [Imagen], [Calificacion], [Formato3D], [Duracion], [Genero], [Sinopsis], [Activo]) VALUES (10, N'Jurassic World: Dominion', N'~/ImagenesPeliculas/10.jpg', 2, 1, 127, 1, N'Claire y Owen, tratarán de localizar a todos los dinosaurios perdidos, pero la tarea no será fácil ni mucho menos. Aparte, tenemos otros dos frentes abiertos: uno es el posible reencuentro entre Owen y la velociraptor Blue. El segundo, la vuelta de los personajes de la trilogía original. Si ya pudimos ver a Ian Malcolm en la última, ¿no debería reaparecer Ellie Sattler y Alan Grant para poner un poco de orden?', 1)
INSERT [dbo].[Pelicula] ([Id], [Nombre], [Imagen], [Calificacion], [Formato3D], [Duracion], [Genero], [Sinopsis], [Activo]) VALUES (11, N'Avengers: Endgame', N'~/ImagenesPeliculas/11.jpg', 2, 1, 181, 1, N'El grave curso de los acontecimientos puesto en marcha por Thanos que destruyó la mitad del universo gracias al las Gemas del Infinito. Ha provocado que los Vengadores restantes deban tomar una última posición en la gran conclusión de Marvel Studios a veintidós películas.', 1)
INSERT [dbo].[Pelicula] ([Id], [Nombre], [Imagen], [Calificacion], [Formato3D], [Duracion], [Genero], [Sinopsis], [Activo]) VALUES (12, N'Mulan', N'~/ImagenesPeliculas/12.jpg', 1, 1, 115, 1, N'Narra la historia de Mulán, una intrépida joven lo arriesga todo por amor a su familia y a su país hasta convertirse en una de las mayores guerreras de la historia de China. Cuando el emperador de China decreta que un hombre de cada familia debe servir en el Ejército Imperial para defender al país de los invasores del norte, Hua Mulán, la hija mayor de un condecorado guerrero, decide ocupar el lugar de su padre enfermo. Haciéndose pasar por un hombre, Hua Jun, se enfrenta a constantes desafíos y deberá aprender a canalizar su fuerza interior y a aceptar su verdadero potencial. Un viaje épico que la convertirá en una reconocida guerrera y le permitirá ganarse el respeto de una nación agradecida... y de un padre orgulloso.', 1)
INSERT [dbo].[Pelicula] ([Id], [Nombre], [Imagen], [Calificacion], [Formato3D], [Duracion], [Genero], [Sinopsis], [Activo]) VALUES (13, N'¡Scooby!', N'~/ImagenesPeliculas/13.jpg', 1, 1, 94, 5, N'Shaggy y Scooby-Doo junto con sus amigos Fred, Daphne y Velma unen sus Shaggy Rogers es un niño solitario que se hace amigo y adopta un perro parlante sin hogar, a quien llama Scooby Dooby-Doo. En la noche de Halloween, Shaggy y Scooby se encuentran con Fred Jones, Daphne Blake y Velma Dinkley, y juntos se aventuran dentro de una casa embrujada. Los niños se encuentran con un fantasma que capturan y desenmascaran como el ladrón disfrazado Sr. Rigby. Los niños están inspirados para resolver misterios juntos de manera regular como Mystery Inc.', 1)
INSERT [dbo].[Pelicula] ([Id], [Nombre], [Imagen], [Calificacion], [Formato3D], [Duracion], [Genero], [Sinopsis], [Activo]) VALUES (14, N'Avatar 2', N'~/ImagenesPeliculas/14.jpg', 2, 1, 147, 4, N'Esta es la historia de la familia Sully y lo que hace una persona para mantener a su familia unida. Jake y Neytiri tienen una familia en esta película, son obligados a abandonar su hogar, así que salen al exterior y exploran diferentes regiones de Pandora, pasando un tiempo en el agua, alrededor del agua, sobre el agua... Creo que, la razón por la que la gente recurre al cine más que nunca hoy en día es porque quieren escapar, escapar del mundo en el que vivimos, escapar de las presiones que tienen en sus vidas', 1)
INSERT [dbo].[Pelicula] ([Id], [Nombre], [Imagen], [Calificacion], [Formato3D], [Duracion], [Genero], [Sinopsis], [Activo]) VALUES (15, N'My Bloody Valentine 3D', N'~/ImagenesPeliculas/15.jpg', 4, 1, 101, 2, N'Hace 10 años, una tragedia cambió al poblado de Harmony para siempre. Tom Hanniger, un inexperto minero, causó un accidente en los túneles atrapando y matando a cinco hombres y enviando al único sobreviviente, Harry Warden, a un coma permanente. Pero Harry Warden quiere vengarse. Exactamente un año después, en el día de San Valentín, él se despierta y asesina brutalmente a 22 personas con un pico de minero. Diez años después, Tom Hanniger regresa a Harmony en el día de San Valentín, aún es perseguido por las muertes que él causó.', 1)
INSERT [dbo].[Pelicula] ([Id], [Nombre], [Imagen], [Calificacion], [Formato3D], [Duracion], [Genero], [Sinopsis], [Activo]) VALUES (16, N'Green Book', N'~/ImagenesPeliculas/16.jpg', 2, 1, 130, 6, N'Un pianista afroamericano contrata a un rudo italoestadounidense para que sea su chófer y guardaespaldas durante una gira por el sur de Estados Unidos en el otoño de 1962, un viaje que los adentra en un territorio y una época subyugados al racismo. Nominada a los premios oscars.', 1)
SET IDENTITY_INSERT [dbo].[Pelicula] OFF
/****** Object:  StoredProcedure [dbo].[ModificarUsuario]    Script Date: 10/07/2020 22:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ModificarUsuario]

@Nombre varchar(50),
@Apellido varchar(50),
@Dni int,
@Telefono varchar(50),
@Nacimiento int,
@Email varchar(50)
AS
begin 

update Usuario SET
Nombre = @Nombre,
Apellido = @Apellido,
DNI = @Dni,
Telefono = @Telefono,
Nacimiento = @Nacimiento
where email = @Email

END
GO
/****** Object:  StoredProcedure [dbo].[ModificarUser]    Script Date: 10/07/2020 22:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ModificarUser]
@Id int,
@Nombre varchar(50),
@Apellido varchar(50),
@Dni int,
@Genero varchar(50),
@Nacimiento int,
@Email varchar(50),
@Telefono varchar(50),
@Password varchar(50),
@Admin bit,
@Activo bit

AS
update usuario set
Nombre = @Nombre,
Apellido = @Apellido,
Dni = @Dni,
Genero = @Genero,
Nacimiento = @Nacimiento,
Email = @Email,
Telefono = @Telefono,
Password = @Password,
Admin = @Admin,
Activo = @Activo
where Id= @Id
GO
/****** Object:  StoredProcedure [dbo].[ModificarPrecio]    Script Date: 10/07/2020 22:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ModificarPrecio]
@Formato3D bit,
@Precio float

AS


update Precio SET
Precio = @Precio
where Formato3D = @Formato3D
GO
/****** Object:  Table [dbo].[Sala]    Script Date: 10/07/2020 22:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sala](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Sucursal] [int] NOT NULL,
	[Filas] [int] NOT NULL,
	[Butacas] [int] NOT NULL,
 CONSTRAINT [PK_Sala] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Cantidad de filas' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sala', @level2type=N'COLUMN',@level2name=N'Filas'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Cantidad de butacas por fila' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sala', @level2type=N'COLUMN',@level2name=N'Butacas'
GO
SET IDENTITY_INSERT [dbo].[Sala] ON
INSERT [dbo].[Sala] ([Id], [Nombre], [Sucursal], [Filas], [Butacas]) VALUES (1, N'Sala 1 - Pilar', 1, 22, 18)
INSERT [dbo].[Sala] ([Id], [Nombre], [Sucursal], [Filas], [Butacas]) VALUES (2, N'Sala 2 - Pilar', 1, 22, 18)
INSERT [dbo].[Sala] ([Id], [Nombre], [Sucursal], [Filas], [Butacas]) VALUES (3, N'Sala 1 - Pacheco', 2, 22, 18)
INSERT [dbo].[Sala] ([Id], [Nombre], [Sucursal], [Filas], [Butacas]) VALUES (4, N'Sala 2 - Pacheco', 2, 22, 18)
INSERT [dbo].[Sala] ([Id], [Nombre], [Sucursal], [Filas], [Butacas]) VALUES (5, N'Sala 1 - José C Paz', 3, 22, 18)
INSERT [dbo].[Sala] ([Id], [Nombre], [Sucursal], [Filas], [Butacas]) VALUES (6, N'Sala 2 - José C Paz', 3, 22, 18)
SET IDENTITY_INSERT [dbo].[Sala] OFF
/****** Object:  StoredProcedure [dbo].[ModificarGenero]    Script Date: 10/07/2020 22:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ModificarGenero]
@Id int,
@Nombre varchar(50),
@Activo bit
AS
begin 

update Genero SET
Nombre = @Nombre,
Activo = @Activo
where Id = @Id


END
GO
/****** Object:  StoredProcedure [dbo].[ModificarClasificacion]    Script Date: 10/07/2020 22:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ModificarClasificacion]

@Id int,
@Nombre varchar(50),
@Activo bit
AS
begin 

update Calificacion SET
Nombre = @Nombre,
Activo = @Activo
where Id = @Id

END
GO
/****** Object:  Table [dbo].[Funcion]    Script Date: 10/07/2020 22:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Funcion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Pelicula] [int] NOT NULL,
	[Sala] [int] NOT NULL,
	[Fecha] [int] NOT NULL,
	[Hora] [int] NOT NULL,
 CONSTRAINT [PK_Funcion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de la función en formato AAMMDD' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Funcion', @level2type=N'COLUMN',@level2name=N'Fecha'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Hora de inicio de la función en formato HHMM' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Funcion', @level2type=N'COLUMN',@level2name=N'Hora'
GO
SET IDENTITY_INSERT [dbo].[Funcion] ON
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (1, 1, 1, 20201013, 2115)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (2, 1, 2, 20201014, 2355)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (3, 1, 3, 20201013, 1900)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (4, 1, 4, 20201014, 2230)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (5, 1, 5, 20201013, 1120)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (6, 1, 6, 20201014, 1740)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (7, 2, 1, 20201013, 2100)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (8, 2, 2, 20201014, 2315)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (9, 2, 3, 20201013, 2350)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (10, 2, 4, 20201014, 2250)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (11, 2, 5, 20201013, 1935)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (12, 2, 6, 20201014, 1220)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (13, 3, 1, 20201015, 2215)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (14, 3, 2, 20201016, 2355)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (15, 3, 3, 20201015, 1600)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (16, 3, 4, 20201016, 2000)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (17, 3, 5, 20201015, 2310)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (18, 3, 6, 20201016, 2350)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (19, 4, 1, 20201016, 1150)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (20, 4, 2, 20201017, 1855)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (21, 4, 3, 20201016, 2300)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (22, 4, 4, 20201017, 2400)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (23, 4, 5, 20201016, 1910)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (24, 4, 6, 20201017, 2135)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (25, 5, 1, 20201017, 1400)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (26, 5, 2, 20201018, 2310)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (27, 5, 3, 20201017, 2200)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (28, 5, 4, 20201018, 2205)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (29, 5, 5, 20201017, 2140)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (30, 5, 6, 20201018, 2220)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (31, 6, 1, 20201018, 1500)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (32, 6, 2, 20201019, 2100)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (33, 6, 3, 20201018, 2300)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (34, 6, 4, 20201019, 2355)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (35, 6, 5, 20201018, 1900)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (36, 6, 6, 20201019, 2100)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (37, 7, 1, 20201019, 2300)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (38, 7, 2, 20201020, 2400)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (39, 7, 3, 20201019, 2240)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (40, 7, 4, 20201020, 2345)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (41, 7, 5, 20201019, 2110)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (42, 7, 6, 20201020, 2305)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (43, 8, 1, 20201020, 1200)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (44, 8, 2, 20201021, 1500)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (45, 8, 3, 20201020, 1600)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (46, 8, 4, 20201021, 1900)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (47, 8, 5, 20201020, 1900)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (48, 8, 6, 20201021, 2100)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (49, 9, 1, 20201021, 1800)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (50, 9, 2, 20201022, 2010)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (51, 9, 3, 20201021, 1500)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (52, 9, 4, 20201022, 1800)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (53, 9, 5, 20201021, 2200)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (54, 9, 6, 20201022, 2350)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (55, 10, 1, 20201022, 2010)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (56, 10, 2, 20201023, 2230)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (57, 10, 3, 20201022, 1900)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (58, 10, 4, 20201023, 2115)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (59, 10, 5, 20201022, 1620)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (60, 10, 6, 20201023, 2005)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (61, 11, 1, 20201023, 1500)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (62, 11, 2, 20201024, 1900)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (63, 11, 3, 20201023, 1710)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (64, 11, 4, 20201024, 2200)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (65, 11, 5, 20201023, 1855)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (66, 11, 6, 20201024, 2055)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (67, 12, 1, 20201024, 2100)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (68, 12, 2, 20201025, 2300)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (69, 12, 3, 20201024, 2000)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (70, 12, 4, 20201025, 2210)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (71, 12, 5, 20201024, 1810)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (72, 12, 6, 20201025, 2200)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (73, 13, 1, 20201025, 1600)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (74, 13, 2, 20201026, 1900)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (75, 13, 3, 20201025, 1400)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (76, 13, 4, 20201026, 1650)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (77, 13, 5, 20201025, 1900)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (78, 13, 6, 20201026, 2100)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (79, 14, 1, 20201026, 1200)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (80, 14, 2, 20201027, 1400)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (81, 14, 3, 20201026, 1500)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (82, 14, 4, 20201027, 1900)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (83, 14, 5, 20201026, 1610)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (84, 14, 6, 20201027, 1900)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (85, 15, 1, 20201027, 2000)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (86, 15, 2, 20201028, 2200)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (87, 15, 3, 20201027, 2100)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (88, 15, 4, 20201028, 2300)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (89, 15, 5, 20201027, 1855)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (90, 15, 6, 20201028, 2230)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (91, 16, 1, 20201028, 2355)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (92, 16, 2, 20201029, 2400)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (93, 16, 3, 20201028, 2250)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (94, 16, 4, 20201029, 2355)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (95, 16, 5, 20201028, 2310)
INSERT [dbo].[Funcion] ([Id], [Pelicula], [Sala], [Fecha], [Hora]) VALUES (96, 16, 6, 20201029, 2340)
SET IDENTITY_INSERT [dbo].[Funcion] OFF
/****** Object:  StoredProcedure [dbo].[ModificarPelicula]    Script Date: 10/07/2020 22:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ModificarPelicula]

@Id int,
@Nombre varchar(50),
@Imagen varchar(100),
@Calificacion varchar(50),
@Formato3D bit,
@Duracion int,
@Genero int,
@Sinopsis varchar(800),
@Activo bit
AS
begin 

update Pelicula SET
Nombre = @Nombre,
Imagen = @Imagen,
Calificacion = @Calificacion,
Formato3D = @Formato3D,
Duracion = @Duracion,
Genero = @Genero,
Sinopsis = @Sinopsis,
Activo = @Activo
where Id = @Id

END
GO
/****** Object:  StoredProcedure [dbo].[AgregarPelicula]    Script Date: 10/07/2020 22:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AgregarPelicula]

@Nombre varchar(50),
@Imagen varchar(100),
@Calificacion int,
@Formato3D bit,
@Duracion int,
@Genero int,
@Sinopsis varchar(100),
@Activo bit
AS

INSERT INTO Pelicula(Nombre, Imagen, Calificacion, Formato3D, Duracion, Genero, Sinopsis, Activo)
VALUES(@Nombre, @Imagen, @Calificacion, @Formato3D, @Duracion, @Genero, @Sinopsis, @Activo)
GO
/****** Object:  StoredProcedure [dbo].[AgregarFuncion]    Script Date: 10/07/2020 22:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AgregarFuncion]

@Pelicula int,
@Sala int,
@Fecha int,
@Hora int

AS

INSERT INTO Funcion(Pelicula, Sala, Fecha, Hora)
VALUES(@Pelicula, @Sala, @Fecha, @Hora)
GO
/****** Object:  Table [dbo].[Reserva]    Script Date: 10/07/2020 22:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reserva](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [int] NOT NULL,
	[Funcion] [int] NOT NULL,
 CONSTRAINT [PK_Reserva] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Reserva] ON
INSERT [dbo].[Reserva] ([Id], [Usuario], [Funcion]) VALUES (1, 1, 1)
INSERT [dbo].[Reserva] ([Id], [Usuario], [Funcion]) VALUES (2, 1, 51)
SET IDENTITY_INSERT [dbo].[Reserva] OFF
/****** Object:  StoredProcedure [dbo].[AgregarReserva]    Script Date: 10/07/2020 22:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AgregarReserva]

@Usuario int,
@Funcion int

AS

INSERT INTO Reserva(Usuario, Funcion)
VALUES(@Usuario, @Funcion)
GO
/****** Object:  Table [dbo].[Reservada]    Script Date: 10/07/2020 22:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservada](
	[Reserva] [int] NOT NULL,
	[Fila] [int] NOT NULL,
	[Butaca] [int] NOT NULL,
 CONSTRAINT [PK_Reservada] PRIMARY KEY CLUSTERED 
(
	[Reserva] ASC,
	[Fila] ASC,
	[Butaca] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Reservada] ([Reserva], [Fila], [Butaca]) VALUES (1, 1, 1)
INSERT [dbo].[Reservada] ([Reserva], [Fila], [Butaca]) VALUES (2, 1, 1)
INSERT [dbo].[Reservada] ([Reserva], [Fila], [Butaca]) VALUES (2, 1, 2)
/****** Object:  StoredProcedure [dbo].[AgregarReservada]    Script Date: 10/07/2020 22:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AgregarReservada]

@Reserva int,
@Fila int,
@Butaca int

AS

INSERT INTO Reservada(Reserva, Fila, Butaca)
VALUES(@Reserva, @Fila, @Butaca)
GO
/****** Object:  Default [DF_Usuario_Activo]    Script Date: 10/07/2020 22:37:34 ******/
ALTER TABLE [dbo].[Usuario] ADD  CONSTRAINT [DF_Usuario_Activo]  DEFAULT ((1)) FOR [Activo]
GO
/****** Object:  Default [DF_Pelicula_Imagen]    Script Date: 10/07/2020 22:37:35 ******/
ALTER TABLE [dbo].[Pelicula] ADD  CONSTRAINT [DF_Pelicula_Imagen]  DEFAULT (NULL) FOR [Imagen]
GO
/****** Object:  Default [DF_Pelicula_Formato3D]    Script Date: 10/07/2020 22:37:35 ******/
ALTER TABLE [dbo].[Pelicula] ADD  CONSTRAINT [DF_Pelicula_Formato3D]  DEFAULT ((0)) FOR [Formato3D]
GO
/****** Object:  Default [DF_Pelicula_Duracion]    Script Date: 10/07/2020 22:37:35 ******/
ALTER TABLE [dbo].[Pelicula] ADD  CONSTRAINT [DF_Pelicula_Duracion]  DEFAULT ((0)) FOR [Duracion]
GO
/****** Object:  Default [DF_Pelicula_Activo]    Script Date: 10/07/2020 22:37:35 ******/
ALTER TABLE [dbo].[Pelicula] ADD  CONSTRAINT [DF_Pelicula_Activo]  DEFAULT ((1)) FOR [Activo]
GO
/****** Object:  ForeignKey [FK_Pelicula_Calificacion]    Script Date: 10/07/2020 22:37:35 ******/
ALTER TABLE [dbo].[Pelicula]  WITH CHECK ADD  CONSTRAINT [FK_Pelicula_Calificacion] FOREIGN KEY([Calificacion])
REFERENCES [dbo].[Calificacion] ([Id])
GO
ALTER TABLE [dbo].[Pelicula] CHECK CONSTRAINT [FK_Pelicula_Calificacion]
GO
/****** Object:  ForeignKey [FK_Pelicula_Genero]    Script Date: 10/07/2020 22:37:35 ******/
ALTER TABLE [dbo].[Pelicula]  WITH CHECK ADD  CONSTRAINT [FK_Pelicula_Genero] FOREIGN KEY([Genero])
REFERENCES [dbo].[Genero] ([Id])
GO
ALTER TABLE [dbo].[Pelicula] CHECK CONSTRAINT [FK_Pelicula_Genero]
GO
/****** Object:  ForeignKey [fk_Precio]    Script Date: 10/07/2020 22:37:35 ******/
ALTER TABLE [dbo].[Pelicula]  WITH CHECK ADD  CONSTRAINT [fk_Precio] FOREIGN KEY([Formato3D])
REFERENCES [dbo].[Precio] ([Formato3D])
GO
ALTER TABLE [dbo].[Pelicula] CHECK CONSTRAINT [fk_Precio]
GO
/****** Object:  ForeignKey [FK_Sala_Sucursal]    Script Date: 10/07/2020 22:37:35 ******/
ALTER TABLE [dbo].[Sala]  WITH CHECK ADD  CONSTRAINT [FK_Sala_Sucursal] FOREIGN KEY([Sucursal])
REFERENCES [dbo].[Sucursal] ([Id])
GO
ALTER TABLE [dbo].[Sala] CHECK CONSTRAINT [FK_Sala_Sucursal]
GO
/****** Object:  ForeignKey [FK_Funcion_Pelicula]    Script Date: 10/07/2020 22:37:35 ******/
ALTER TABLE [dbo].[Funcion]  WITH CHECK ADD  CONSTRAINT [FK_Funcion_Pelicula] FOREIGN KEY([Pelicula])
REFERENCES [dbo].[Pelicula] ([Id])
GO
ALTER TABLE [dbo].[Funcion] CHECK CONSTRAINT [FK_Funcion_Pelicula]
GO
/****** Object:  ForeignKey [FK_Funcion_Sala]    Script Date: 10/07/2020 22:37:35 ******/
ALTER TABLE [dbo].[Funcion]  WITH CHECK ADD  CONSTRAINT [FK_Funcion_Sala] FOREIGN KEY([Sala])
REFERENCES [dbo].[Sala] ([Id])
GO
ALTER TABLE [dbo].[Funcion] CHECK CONSTRAINT [FK_Funcion_Sala]
GO
/****** Object:  ForeignKey [FK_Reserva_Funcion]    Script Date: 10/07/2020 22:37:35 ******/
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_Funcion] FOREIGN KEY([Funcion])
REFERENCES [dbo].[Funcion] ([Id])
GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [FK_Reserva_Funcion]
GO
/****** Object:  ForeignKey [FK_Reserva_Usuario]    Script Date: 10/07/2020 22:37:35 ******/
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_Usuario] FOREIGN KEY([Usuario])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [FK_Reserva_Usuario]
GO
/****** Object:  ForeignKey [FK_Reservada_Reserva]    Script Date: 10/07/2020 22:37:35 ******/
ALTER TABLE [dbo].[Reservada]  WITH CHECK ADD  CONSTRAINT [FK_Reservada_Reserva] FOREIGN KEY([Reserva])
REFERENCES [dbo].[Reserva] ([Id])
GO
ALTER TABLE [dbo].[Reservada] CHECK CONSTRAINT [FK_Reservada_Reserva]
GO
