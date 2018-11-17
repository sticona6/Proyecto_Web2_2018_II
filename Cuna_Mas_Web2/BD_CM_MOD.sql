CREATE TABLE Usuario (
  id      int identity primary key not null,
  usuario varchar(20)              not null,
  clave   varchar(100)             not null,
  --edad  int					   not null, --(de los usuarios)
  tipo    varchar(30)              not null,
  estado  nvarchar(1)              not null,
  imagen  varchar(100),
);

insert into Usuario(usuario, clave, tipo, estado, imagen)
values ('garcaya'  , 'e10adc3949ba59abbe56e057f20f883e','Madre Cuidadora','A','');

insert into Usuario(usuario, clave, tipo, estado, imagen)
values ('acondori'  , 'e10adc3949ba59abbe56e057f20f883e','Madre Cuidadora','A','');

insert into Usuario(usuario, clave, tipo, estado, imagen)
values ('ctapia'   , 'e10adc3949ba59abbe56e057f20f883e','Madre Guia','A','');

insert into Usuario(usuario, clave, tipo, estado, imagen)
values ('afaucheux', 'e10adc3949ba59abbe56e057f20f883e','Madre Jefa','A','');

insert into Usuario(usuario, clave, tipo, estado, imagen)
values ('svelarde' , 'e10adc3949ba59abbe56e057f20f883e','Madre Familia','A','');

insert into Usuario(usuario, clave, tipo, estado, imagen)
values ('pedro1'   , 'e10adc3949ba59abbe56e057f20f883e','Madre Familia','A','');

insert into Usuario(usuario, clave, tipo, estado, imagen)
values ('elopez'   , 'e10adc3949ba59abbe56e057f20f883e','Madre Familia','A','');

insert into Usuario(usuario, clave, tipo, estado, imagen)
values ('elanchipa', 'e10adc3949ba59abbe56e057f20f883e','Madre Familia','A','');

insert into Usuario(usuario, clave, tipo, estado, imagen)
values ('jorge1'   , 'e10adc3949ba59abbe56e057f20f883e','Madre Familia','A','');

CREATE TABLE MetodoAprendizaje
(
    id int PRIMARY KEY NOT NULL IDENTITY,
	--nombre varchar(30) NOT NULL,	(del metodo)--
    descripcion text NOT NULL,
    rango_edad varchar(15) NOT NULL,
    procedimiento text NOT NULL,
	--estado nvarchar(1) NOT NULL
);
INSERT INTO MetodoAprendizaje (descripcion, rango_edad, procedimiento) VALUES ('Descripcion XXX', '6-9 meses', 'Procedimineto XXX');
INSERT INTO MetodoAprendizaje (descripcion, rango_edad, procedimiento) VALUES ('Descripcion XXX', '10-12 meses', 'Procedimineto XXX');
INSERT INTO MetodoAprendizaje (descripcion, rango_edad, procedimiento) VALUES ('Descripcion XXX', '13-18 meses', 'Procedimineto XXX');
INSERT INTO MetodoAprendizaje (descripcion, rango_edad, procedimiento) VALUES ('Descripcion XXX', '19-24 meses', 'Procedimineto XXX');
INSERT INTO MetodoAprendizaje (descripcion, rango_edad, procedimiento) VALUES ('Descripcion XXX', '25-36 meses', 'Procedimineto XXX');

CREATE TABLE Madre
(
  id            int PRIMARY KEY NOT NULL IDENTITY,
  nombre varchar(30) not null,
  apellido varchar(30) not null,
  --horas int not null,--(de trabajo)
  --obserbaciones text not null --(mumero de insidentes)
  comite        varchar(20),
  estado nvarchar(1) not null,
  fk_id_usuario int             not null,
  foreign key (fk_id_usuario) references Usuario (id)
);
INSERT INTO Madre (nombre, apellido, comite, estado, fk_id_usuario) VALUES ('Graciela', 'Arcaya'   ,'Comite XXX', 'A', 1);
INSERT INTO Madre (nombre, apellido, comite, estado, fk_id_usuario) VALUES ('Ana'     , 'Condori'  ,'Comite XXX', 'A', 2);
INSERT INTO Madre (nombre, apellido, comite, estado, fk_id_usuario) VALUES ('Carolina', 'Tapia'    ,'Comite XXX', 'A', 3);
INSERT INTO Madre (nombre, apellido, comite, estado, fk_id_usuario) VALUES ('Andrea'  , 'Faucheux' ,''          , 'A', 4);
INSERT INTO Madre (nombre, apellido, comite, estado, fk_id_usuario) VALUES ('Sonia'   , 'Velarde'  ,'Comite XXX', 'A', 5);



CREATE TABLE Reunion
(
  id          int PRIMARY KEY NOT NULL IDENTITY,
  --nombre varchar (30) NOT NULL,(de la reunion)
  descripcion text            NOT NULL,
  --importancia varchar(30) NOT NULL, (de la reunion)
  --hora int NOT NULL,
  fecha       date            NOT NULL,
  estado      nvarchar(1)     NOT NULL,
  id_madre    int             NOT NULL,
  CONSTRAINT FK__Reunion__id_madr__3B75D760 FOREIGN KEY (id_madre) REFERENCES bd_proyecto_cuna_web2.dbo.Madre (id)
);
INSERT INTO Reunion (descripcion, fecha, estado, id_madre) VALUES ('Reunion 1', '2018-10-26', 'A', 1);
INSERT INTO Reunion (descripcion, fecha, estado, id_madre) VALUES ('Reunion 2', '2018-10-27', 'A', 2);

CREATE TABLE Padre
(
    id int PRIMARY KEY NOT NULL IDENTITY,
    nombrePadre varchar(30) NOT NULL,
    nombreMadre varchar(30) NOT NULL,
    apoderado varchar(30),
    telefono varchar(9) NOT NULL,
    direccion varchar(30) NOT NULL,
    estado nvarchar(1) NOT NULL,
    fk_id_usuario int NOT NULL,
    fk_id_madre int NOT NULL,
    fk_id_reunion int,
    FOREIGN KEY (fk_id_usuario) REFERENCES Usuario (id),
    FOREIGN KEY (fk_id_madre) REFERENCES Madre (id),
    FOREIGN KEY (fk_id_reunion) REFERENCES Reunion (id)
);
INSERT INTO Padre (nombrePadre, nombreMadre, apoderado, telefono, direccion, estado, fk_id_usuario, fk_id_madre, fk_id_reunion) VALUES ('Pedro',   'Elizabeth', 'Rosa', '987741254', 'Las dalias Mz43' ,'A',5, 1, 2);
INSERT INTO Padre (nombrePadre, nombreMadre, apoderado, telefono, direccion, estado, fk_id_usuario, fk_id_madre, fk_id_reunion) VALUES ('Elmer',   'Carmen',    'Juan', '987654321', 'Av. San Jose'    ,'A',6, 1, 2);
INSERT INTO Padre (nombrePadre, nombreMadre, apoderado, telefono, direccion, estado, fk_id_usuario, fk_id_madre, fk_id_reunion) VALUES ('Enrique', 'Jassy',     null,   '987654321', 'Av. San Jose'    ,'A',7, 2, 1);
INSERT INTO Padre (nombrePadre, nombreMadre, apoderado, telefono, direccion, estado, fk_id_usuario, fk_id_madre, fk_id_reunion) VALUES ('Jorge',   'Maria',     null,   '965523445', 'Las magnolias SN','A',8, 2, 1);


CREATE TABLE Ninio
(
    id int PRIMARY KEY NOT NULL IDENTITY,
    nombre varchar(30) NOT NULL,
    fecha_nacimiento date NOT NULL,
    estado nvarchar(1) NOT NULL,
    fk_id_cuidadora int NOT NULL,
    fk_id_padre int NOT NULL,
    fk_id_metodo int,
    CONSTRAINT FK__Ninio__fk_id_cui__44FF419A FOREIGN KEY (fk_id_cuidadora) REFERENCES bd_proyecto_cuna_web2.dbo.Madre (id),
    CONSTRAINT FK__Ninio__fk_id_pad__45F365D3 FOREIGN KEY (fk_id_padre) REFERENCES bd_proyecto_cuna_web2.dbo.Padre (id),
    CONSTRAINT FK__Ninio__fk_id_met__46E78A0C FOREIGN KEY (fk_id_metodo) REFERENCES bd_proyecto_cuna_web2.dbo.MetodoAprendizaje (id)
);
INSERT INTO Ninio (nombre, fecha_nacimiento, estado, fk_id_cuidadora, fk_id_padre, fk_id_metodo)
             VALUES ('Angel', '2017-06-07', 'A', 1, 1, 1);
INSERT INTO Ninio (nombre, fecha_nacimiento, estado, fk_id_cuidadora, fk_id_padre, fk_id_metodo)
             VALUES ('Jean', '2017-09-14', 'A', 1, 2, 2);
INSERT INTO Ninio (nombre, fecha_nacimiento, estado, fk_id_cuidadora, fk_id_padre, fk_id_metodo)
             VALUES ('Pedro', '2017-09-14', 'A', 2, 3, 3);
INSERT INTO Ninio (nombre, fecha_nacimiento, estado, fk_id_cuidadora, fk_id_padre, fk_id_metodo)
             VALUES ('Luis', '2017-09-14', 'A', 2, 4, 4);

CREATE TABLE DatosMedicos
(
    id int PRIMARY KEY NOT NULL IDENTITY,
	--nombre NOT NULL, (de la revision)
    altura decimal(5,2) NOT NULL,
    peso decimal(5,2) NOT NULL,
    indice_nutricion varchar(20) NOT NULL,
    fecha_revision date NOT NULL,
    fk_id_ninio int not null,
    FOREIGN KEY (fk_id_ninio) REFERENCES Ninio
);

INSERT INTO DatosMedicos (altura, peso, indice_nutricion, fecha_revision, fk_id_ninio) VALUES (50.30, 3.40, 'Nutrido', '2018-10-24', 1);
INSERT INTO DatosMedicos (altura, peso, indice_nutricion, fecha_revision, fk_id_ninio) VALUES (42.35, 2.96, 'Desnutrido', '2018-10-24', 2);
INSERT INTO DatosMedicos (altura, peso, indice_nutricion, fecha_revision, fk_id_ninio) VALUES (50.30, 3.40, 'Nutrido', '2018-10-24', 3);
INSERT INTO DatosMedicos (altura, peso, indice_nutricion, fecha_revision, fk_id_ninio) VALUES (50.30, 3.40, 'Nutrido', '2018-10-24', 4);

CREATE TABLE Racion
(
    id int PRIMARY KEY NOT NULL IDENTITY,
	--desayuno varchar(50) NOT NULL,	--(en vez de descripcion)
	--refrigerio varchar(50) NOT NULL, --(en vez de descripcion)
	--almuerzo varchar(50) NOT NULL, --(en vez de descripcion)
	--postre varchar(50) NOT NULL, --(en vez de descripcion)
    descripcion text NOT NULL,
    fecha date NOT NULL,
    estado nvarchar(1) NOT NULL,
    fk_id_ninio int NOT NULL,
    CONSTRAINT FK__Racion__fk_id_ni__49C3F6B7 FOREIGN KEY (fk_id_ninio) REFERENCES bd_proyecto_cuna_web2.dbo.Ninio (id)
);
INSERT INTO Racion (descripcion, fecha, estado, fk_id_ninio) VALUES ('Desayuno: quinua refrigerio: frutas almuerzo: pescado', '2018-10-24', 'A', 1);
INSERT INTO Racion (descripcion, fecha, estado, fk_id_ninio) VALUES ('Desayuno: quinua refrigerio: frutas almuerzo: pescado', '2018-10-25', 'A', 2);

CREATE TABLE DatosQR
(
    id int PRIMARY KEY NOT NULL IDENTITY,
    fk_id_racion int NOT NULL,
    CONSTRAINT FK__DatosQR__fk_id_r__4F7CD00D FOREIGN KEY (fk_id_racion) REFERENCES bd_proyecto_cuna_web2.dbo.Racion (id)
);


CREATE TABLE Observacion
(
    id int PRIMARY KEY NOT NULL IDENTITY,
    descripcion text NOT NULL,
    fecha date NOT NULL,
    fk_id_madre_cuidadora int NOT NULL,
    CONSTRAINT FK__Observaci__fk_id__4CA06362 FOREIGN KEY (fk_id_madre_cuidadora) REFERENCES bd_proyecto_cuna_web2.dbo.Madre (id)
);