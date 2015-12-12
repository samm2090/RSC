Use master

if exists(select name from sys.databases where name='bd_rsc')
	drop database bd_rsc;
go

Create Database bd_rsc;
go

use bd_rsc;
go


/*---------------------------------------------------------------------------------------------*/
--CREACION DE TABLAS Y CONSTRAINTS

Create Table tb_Estado_Cuenta(
	cod_estCue int not null identity(1,1),
	desc_estCue varchar(25),
	 
	Constraint pk_cod_estCue primary key(cod_estCue)
)
go

Create Table tb_Talla_Rango(
	cod_talla_ran int not null identity(1,1),
	desc_talla_ran varchar(25) not null,

	Constraint pk_cod_talla_ran primary key (cod_talla_ran)
)
go

Create Table tb_Talla(
	cod_talla int not null identity(1,1),
	desc_talla varchar(15) not null,
	cod_talla_ran int not null,
	Constraint pk_cod_talla primary key (cod_talla),
	Constraint fk_cod_tall_ran foreign key(cod_talla_ran) references tb_Talla_Rango(cod_talla_ran)
)
go

Create Table tb_EstadoCivil(
	cod_estCiv int not null identity(1,1),
	desc_estCiv varchar(25) not null,

	Constraint pk_cod_estCiv primary key (cod_estCiv)
)
go

Create Table tb_Rasgo(
	cod_rasgo int not null identity(1,1),
	desc_rasgo varchar(30) not null,

	Constraint pk_cod_rasgo primary key (cod_rasgo)
)
go

Create Table tb_Contextura(
	cod_contex int not null identity(1,1),
	desc_contex varchar(25) not null,

	Constraint pk_cod_contex primary key (cod_contex)	
)
go

Create Table tb_Cualidad(
	cod_cua int not null identity(1,1),
	desc_cua varchar(30) not null,

	Constraint pk_cod_cua primary key (cod_cua)
)
go

Create Table tb_Ingresos(
	cod_ing int not null identity(1,1),
	desc_ing varchar(50) not null,
	Constraint pk_cod_ing primary key (cod_ing)
)
go

Create Table tb_Actividad(
	cod_act int not null identity(1,1),
	desc_act varchar(50) not null,
	Constraint pk_cod_act primary key (cod_act)
)
go

Create table tb_Usuario(
	cod_usu int not null identity(1,1), 
    nom_usu varchar(50) not null,
    apePat_usu varchar(50) not null,
    apeMat_usu varchar(50) not null,
    fecReg_usu date not null default getDate(),
    fecNac_usu date not null,
    email_usu varchar(50) not null unique,
    contr_usu varchar(25) not null,
    sexo_usu char(1) not null check (sexo_usu in('M','F')),
    cod_estCue int not null default 1,

	Constraint pk_cod_usu primary key (cod_usu),
	Constraint fk_estCue foreign key (cod_estCue) references tb_Estado_Cuenta(cod_estCue)
);

Create table tb_Informacion_Usuario(
	cod_usu int not null,
	cod_talla int not null,
	cod_estCiv int not null,
	cod_rasgo int not null,
	cod_contex int not null,
	cod_ing int not null,
	cod_act int not null,
	hijos_usu int not null,
	
	Constraint pk_cod_usu_info primary key (cod_usu),
	Constraint fk_cod_usu_info foreign key (cod_usu) references tb_Usuario(cod_usu),
	Constraint fk_cod_talla foreign key (cod_talla) references tb_Talla(cod_talla),
	Constraint fk_cod_estCiv foreign key (cod_estCiv) references tb_EstadoCivil(cod_estCiv),
	Constraint fk_cod_rasgo foreign key (cod_rasgo) references tb_Rasgo(cod_rasgo),
	Constraint fk_cod_contex foreign key (cod_contex) references tb_Contextura(cod_contex),
	Constraint fk_cod_ing foreign key (cod_ing) references tb_Ingresos(cod_ing),
	Constraint fk_cod_act foreign key (cod_act) references tb_Actividad(cod_act)
)
go

Create Table tb_Intereses(
	cod_usu int not null,
	cod_talla_ran int not null,
	cod_rasgo int not null,
	cod_contex int not null,
	cod_ing int not null,
	hijos_interes char(2) not null check (hijos_interes in('Si','No')),
	ing_interes char(2) not null check(ing_interes in('Si','No')),

	Constraint pk_cod_usu_inter primary key (cod_usu),
	Constraint fk_cod_usu_inter foreign key (cod_usu) references tb_Usuario(cod_usu),
	Constraint fk_cod_talla_ran foreign key (cod_talla_ran) references tb_Talla_Rango(cod_talla_ran),
	Constraint fk_cod_rasgo2 foreign key (cod_rasgo) references tb_Rasgo(cod_rasgo),
	Constraint fk_cod_contex2 foreign key (cod_contex) references tb_Contextura(cod_contex),
	Constraint fk_cod_ing2 foreign key (cod_ing) references tb_Ingresos(cod_ing),
)
go

Create Table tb_Cualidades_Usuario(
	cod_usu int not null,
	cod_cua int not null,

	Constraint pk_Cualidades_Usuario primary key (cod_usu,cod_cua),
	Constraint fk_cod_usu_CuaUsu foreign key (cod_usu) references tb_Usuario(cod_usu),
	Constraint fk_cod_cua foreign key (cod_cua) references tb_Cualidad(cod_cua)
)
go

Create Table tb_Cualidades_Interes(
	cod_usu int not null,
	cod_cua int not null,

	Constraint pk_Cualidades_Interes primary key (cod_usu,cod_cua),
	Constraint fk_cod_usu_cuaInt foreign key (cod_usu) references tb_Usuario(cod_usu),
	Constraint fk_cod_cua2 foreign key (cod_cua) references tb_Cualidad(cod_cua)
)
go

Create Table tb_Mensaje(
	cod_mens int not null identity(1,1),
    cod_usu1 int not null,
    cod_usu2 int not null,
    cod_usu3 int not null,
    mensaje text not null,
    fecha_mens datetime default getDate(),

    Constraint pK_cod_mens primary key (cod_mens),
	Constraint fk_cod_usu1_mens foreign key (cod_usu1) references tb_usuario(cod_usu),
	Constraint fk_cod_usu2_mens foreign key (cod_usu2) references tb_usuario(cod_usu),
	Constraint fk_cod_usu3_mens foreign key (cod_usu3) references tb_usuario(cod_usu)
)
go

Create Table tb_Foto(
	cod_usu int not null,
	cod_foto int not null identity(1,1),
	foto varbinary(max) not null,

	Constraint pk_Foto primary key(cod_usu,cod_foto),
	Constraint fk_cod_usu_foto foreign key(cod_usu) references tb_usuario(cod_usu)
)
go

/*---------------------------------------------------------------------------------------------*/
--INSERT A LAS TABLAS

Insert into tb_Estado_Cuenta(desc_estCue) values('Inactiva');
Insert into tb_Estado_Cuenta(desc_estCue) values('Activa');
Insert into tb_Estado_Cuenta(desc_estCue) values('Bloqueada');

Insert into tb_Talla_Rango(desc_talla_ran) values ('1.40 a 1.50 m');
Insert into tb_Talla_Rango(desc_talla_ran) values ('1.50 a 1.60 m');
Insert into tb_Talla_Rango(desc_talla_ran) values ('1.60 a 1.70 m');
Insert into tb_Talla_Rango(desc_talla_ran) values ('1.70 a 1.80 m');
Insert into tb_Talla_Rango(desc_talla_ran) values ('1.80 a 1.90 m');
Insert into tb_Talla_Rango(desc_talla_ran) values ('1.90 a 2.00 m');
Insert into tb_Talla_Rango(desc_talla_ran) values ('2.01 a más m');

Insert into tb_Actividad(desc_act) values ('Salir con Amigos');
Insert into tb_Actividad(desc_act) values ('Salir a Bailar');
Insert into tb_Actividad(desc_act) values ('Ver Películas');
Insert into tb_Actividad(desc_act) values ('Escuchar Música');
Insert into tb_Actividad(desc_act) values ('Tener Sexo');
Insert into tb_Actividad(desc_act) values ('Ir a la Playa');
Insert into tb_Actividad(desc_act) values ('Hacer Deporte');

Insert into tb_Ingresos (desc_ing) values ('S/.0 - 750');
Insert into tb_Ingresos (desc_ing) values ('S/.750 - 1500');
Insert into tb_Ingresos (desc_ing) values ('S/.1500 - 2500');
Insert into tb_Ingresos (desc_ing) values ('S/.2500 - 5000');
Insert into tb_Ingresos (desc_ing) values ('S/.5000 a más');

Insert into tb_Cualidad(desc_cua) values ('Sensual');
Insert into tb_Cualidad(desc_cua) values ('Afectuoso');
Insert into tb_Cualidad(desc_cua) values ('Desinteresado');
Insert into tb_Cualidad(desc_cua) values ('Leal');
Insert into tb_Cualidad(desc_cua) values ('Luchador');
Insert into tb_Cualidad(desc_cua) values ('Valiente');
Insert into tb_Cualidad(desc_cua) values ('Reponsable');
Insert into tb_Cualidad(desc_cua) values ('Ambicioso');
Insert into tb_Cualidad(desc_cua) values ('Competitivo');
Insert into tb_Cualidad(desc_cua) values ('Social');

Insert into tb_EstadoCivil (desc_estCiv) values ('Casado');
Insert into tb_EstadoCivil (desc_estCiv) values ('Divorciado');
Insert into tb_EstadoCivil (desc_estCiv) values ('Soltero');
Insert into tb_EstadoCivil (desc_estCiv) values ('Viudo');

Insert into tb_Contextura (desc_contex) values ('Flaco (a)');
Insert into tb_Contextura (desc_contex) values ('Gordo (a)');
Insert into tb_Contextura (desc_contex) values ('Atlético (a)');
Insert into tb_Contextura (desc_contex) values ('Promedio');

Insert into tb_Rasgo (desc_rasgo) values ('Mestizo');
Insert into tb_Rasgo (desc_rasgo) values ('Asiático');
Insert into tb_Rasgo (desc_rasgo) values ('Caucásico');
Insert into tb_Rasgo (desc_rasgo) values ('Andino');
Insert into tb_Rasgo (desc_rasgo) values ('Selvático');
Insert into tb_Rasgo (desc_rasgo) values ('Negro - Afrodescendciente');

Insert into tb_Talla (desc_talla,cod_talla_ran) values ('1.40 a menos',1);
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('1.41',1);
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('1.42',1);
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('1.43',1);
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('1.44',1);
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('1.45',1);
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('1.46',1);
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('1.47',1);
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('1.48',1);
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('1.49',1);
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('1.50',1);
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('1.51',2);
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('1.52',2);
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('1.53',2);
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('1.54',2);
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('1.55',2);
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('1.56',2);
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('1.57',2);
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('1.58',2);
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('1.59',2);
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('1.60',2);
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('1.61',3);
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('1.62',3);
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('1.63',3);
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('1.64',3);
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('1.65',3);
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('1.66',3);
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('1.67',3);
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('1.68',3);
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('1.69',3);
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('1.70',3);
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('1.71',4);
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('1.72',4);
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('1.73',4);
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('1.74',4);
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('1.75',4);
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('1.76',4);
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('1.77',4);
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('1.78',4);
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('1.79',4)
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('1.80',4);
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('1.81',5);
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('1.82',5);
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('1.83',5);
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('1.84',5);
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('1.85',5);
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('1.86',5);
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('1.87',5);
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('1.88',5);
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('1.89',5)
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('1.90',5);
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('1.91',6);
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('1.92',6);
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('1.93',6);
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('1.94',6);
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('1.95',6);
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('1.96',6);
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('1.97',6);
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('1.98',6);
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('1.99',6);
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('2.00',6);
Insert into tb_Talla (desc_talla,cod_talla_ran) values ('2.01 a más',7);
GO

INSERT INTO tb_Usuario (nom_usu,apePat_usu,apeMat_usu,fecNac_usu,email_usu,contr_usu,sexo_usu) 
VALUES('Carlos','Perez','Zapata','1990-05-23','carlos123@gmail.com','12345','M'),
      ('Miguel','Torres','Jauregui','1990-02-12','miguel123@gmail.com','12345','M'),
      ('Pablo','Cornelio','Vilchez','1984-12-12','pablo123@gmail.com','12345','M'),
      ('Susana','Calderon','Del Rio','1977-12-23','susana23@gmail.com','12345','M'),
      ('Maria','Del Solar','Aguila','1988-07-02','maria2@gmail.com','12345','M'),
	  ('Miriam','Zavala','Mier','1994-11-04','miriam22@gmail.com','12345','M')
GO

INSERT INTO tb_Informacion_Usuario(cod_usu,cod_talla,cod_estCiv,cod_rasgo,cod_contex,cod_ing,cod_act,hijos_usu)
VALUES(1,5,2,3,2,3,4,2),
	  (2,5,2,3,2,3,4,2),
	  (3,5,2,3,2,3,4,2),
	  (4,5,2,3,2,3,4,2),
	  (5,5,2,3,2,3,4,2),
	  (6,5,2,3,2,3,4,2)
GO

SELECT * FROM tb_Usuario
GO

