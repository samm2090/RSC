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
	enLinea int default 0 null,
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
	hijos_interes char(2) not null check (hijos_interes in('Si','No')),
	ing_interes char(2) not null check(ing_interes in('Si','No')),

	Constraint pk_cod_usu_inter primary key (cod_usu),
	Constraint fk_cod_usu_inter foreign key (cod_usu) references tb_Usuario(cod_usu),
	Constraint fk_cod_talla_ran foreign key (cod_talla_ran) references tb_Talla_Rango(cod_talla_ran),
	Constraint fk_cod_rasgo2 foreign key (cod_rasgo) references tb_Rasgo(cod_rasgo),
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
    mensaje text not null,
    fecha_mens datetime default getDate(),

    Constraint pK_cod_mens primary key (cod_mens),
	Constraint fk_cod_usu1_mens foreign key (cod_usu1) references tb_usuario(cod_usu),
	Constraint fk_cod_usu2_mens foreign key (cod_usu2) references tb_usuario(cod_usu)
)
go

Create Table tb_Foto(
	cod_usu int not null,
	cod_foto int not null,
	ruta varchar(100) not null,

	Constraint pk_Foto primary key(cod_usu,cod_foto),
	Constraint fk_cod_usu_foto foreign key(cod_usu) references tb_usuario(cod_usu)
)
go

Create table tb_Favorito(
	cod_usu1 int not null references tb_Usuario(cod_usu),
	cod_usu2 int not null references tb_Usuario(cod_usu),
	favorito int not null default 0,
	primary key(cod_usu1,cod_usu2)
)
go



create table tb_Compatibilidad(
	cod_usu1 int not null references tb_Usuario(cod_usu),
	cod_usu2 int not null references tb_Usuario(cod_usu),
	porcentaje decimal(5,2) not null,
	primary key(cod_usu1,cod_usu2)
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

Insert into tb_Actividad(desc_act) values ('Salir con amigos');
Insert into tb_Actividad(desc_act) values ('Salir a bailar');
Insert into tb_Actividad(desc_act) values ('Ver películas');
Insert into tb_Actividad(desc_act) values ('Escuchar música');
Insert into tb_Actividad(desc_act) values ('Probar nuevas comidas');
Insert into tb_Actividad(desc_act) values ('Ir de paseo');
Insert into tb_Actividad(desc_act) values ('Hacer deporte');

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

Insert into tb_Rasgo (desc_rasgo) values ('Afrodescendciente');
Insert into tb_Rasgo (desc_rasgo) values ('Andino');
Insert into tb_Rasgo (desc_rasgo) values ('Asiático');
Insert into tb_Rasgo (desc_rasgo) values ('Caucásico');
Insert into tb_Rasgo (desc_rasgo) values ('Mestizo');
Insert into tb_Rasgo (desc_rasgo) values ('Selvático');

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
      ('Susana','Calderon','Del Rio','1977-12-23','susana23@gmail.com','12345','F'),
      ('Maria','Del Solar','Aguila','1988-07-02','maria2@gmail.com','12345','F'),
	  ('Miriam','Zavala','Mier','1994-11-04','miriam22@gmail.com','12345','F')
GO


INSERT INTO tb_Informacion_Usuario(cod_usu,cod_talla,cod_estCiv,cod_rasgo,cod_contex,cod_ing,cod_act,hijos_usu)
VALUES(1,1,1,1,1,1,1,1),
	  (2,2,2,2,2,2,2,2),
	  (3,3,3,3,3,3,3,3),
	  (4,4,4,4,4,4,4,4),
	  (5,2,2,2,2,2,2,2),
	  (6,1,2,3,4,2,1,1)
GO

INSERT INTO tb_Intereses(cod_usu,cod_talla_ran,cod_rasgo,cod_contex,hijos_interes,ing_interes)
Values	(1,1,3,2,'SI','NO'),
		(2,2,2,3,'NO','SI'),
		(3,3,4,2,'SI','SI'),
		(4,4,3,2,'SI','NO'),
		(5,3,4,1,'NO','NO'),
		(6,7,2,3,'SI','SI')
		GO


INSERT INTO tb_Cualidades_Usuario(cod_usu,cod_cua)
VALUES		(1,2),
			(1,3),
			(1,4),
			(2,2),
			(3,3),
			(4,1),
			(4,3),
			(4,5),
			(5,6),
			(6,4)
GO

INSERT INTO tb_Cualidades_Interes(cod_usu,cod_cua)
VALUES		(1,3),
			(2,2),
			(3,3),
			(4,1),
			(5,6),
			(6,4)
GO

INSERT INTO tb_Mensaje(cod_usu1,cod_usu2,mensaje)
VALUES		(1,2,'Hola'),
			(2,1,'¿Como estás?'),
			(1,2,'¿Donde vives?'),
			(2,1,'Chau'),
			(3,1,'Holaa'),
			(3,1,'Te quiero'),
			(1,3,'¿Tienes hijos?'),
			(4,1,'Hi')
go

INSERT INTO tb_Foto(cod_usu,cod_foto,ruta)
VALUES (1,1,'usuario1.jpg'),
	   (2,1,'usuario2.jpg'),
	   (3,1,'usuario3.jpg'),
	   (4,1,'usuario4.jpg'),
	   (5,1,'usuario5.jpg'),
	   (6,1,'usuario6.jpg')
GO

select * from tb_Mensaje 
where cod_usu1=1 and cod_usu2=2 or cod_usu1=2 and cod_usu2=1
order by fecha_mens
go

Create procedure pr_listarMensajes
@cod_usu1 int,
@cod_usu2 int
AS
BEGIN
	select  * from tb_Mensaje 
	where cod_usu1=@cod_usu1 and cod_usu2=@cod_usu2 or cod_usu1=@cod_usu2 and cod_usu2=@cod_usu1
	order by fecha_mens ASC
END
GO

exec pr_listarMensajes 7,4
SELECT * FROM tb_Foto
GO


SELECT * FROM tb_Usuario
go
SELECT * FROM tb_Cualidades_Interes
GO

SELECT *  FROM tb_Informacion_Usuario

SELECT desc_cua  FROM tb_Cualidad i join tb_Cualidades_Usuario t
on i.cod_cua = t.cod_cua
where cod_usu=1;
GO
SELECT * FROM tb_Intereses
GO

Create procedure pr_listarUsuariosFilto
@cod_usu int
as
BEGIN
	SELECT u.*,c.*,f.ruta,
	Case when
	(select favorito from tb_Favorito where cod_usu2=c.cod_usu2 and cod_usu1=@cod_usu) = 1 then 1
	else 0
	end as favorito 
	FROM tb_Usuario u join tb_Compatibilidad c 
	on c.cod_usu2=u.cod_usu join tb_Foto f 
	on f.cod_usu=c.cod_usu2
	WHERE c.cod_usu1=@cod_usu
	ORDER BY porcentaje DESC
END
GO

SELECT * from tb_Usuario

select * from tb_Compatibilidad
GO

select * from tb_Favorito where cod_usu1=7
go

CREATE PROCEDURE pr_insertarCompatibilidad
	@cod_usu int
	AS
	BEGIN
		DECLARE @codigo int,@sexo_usu char(2)

		SELECT @sexo_usu=sexo_usu FROM tb_Usuario WHERE cod_usu=@cod_usu

		DECLARE usuarios CURSOR LOCAL STATIC READ_ONLY FORWARD_ONLY FOR  
		SELECT cod_usu
		FROM tb_Usuario
		WHERE sexo_usu<>@sexo_usu

		--Elimina tabla para volver a llenarla-------------------------------------------
		DELETE FROM tb_Compatibilidad where cod_usu1=@cod_usu;
		--------------------------------------------------------------------------------

		DECLARE @cod_talla_ran1 int,@cod_rasgo1 int,@cod_contex1 int, @cod_act1 int,
				@hijos_interes1 char(2), @ing_interes1 char(2), @cod_ing1 int

		SELECT @cod_talla_ran1=cod_talla_ran, @cod_rasgo1=cod_rasgo, @cod_contex1=cod_contex,
		@hijos_interes1=hijos_interes, @ing_interes1=ing_interes 
		FROM tb_Intereses
		WHERE cod_usu=@cod_usu

		SELECT @cod_ing1=cod_ing, @cod_act1=cod_act
		FROM tb_Informacion_Usuario 
		WHERE  cod_usu=@cod_usu


		OPEN usuarios
		FETCH NEXT FROM usuarios INTO @codigo
		WHILE @@FETCH_STATUS = 0
			BEGIN 

			--Variables para el bucle--------------------------------------------------------
				DECLARE @porcentaje decimal(5,2)

				DECLARE @cod_talla2 int,@cod_estCiv2 int,@cod_rasgo2 int, @cod_talla_ran2 int,
						@cod_contex2 int, @cod_ing2 int, @cod_act2 int, @hijos_usu2 int 
				
				DECLARE @puntaje int
				SET @puntaje =1
			--------------------------------------------------------------------------------
				
															
				SELECT @cod_talla2=cod_talla, @cod_estCiv2=cod_estCiv, @cod_rasgo2=cod_rasgo,
				@cod_contex2=cod_contex, @cod_ing2=cod_ing, @cod_act2=cod_act,@hijos_usu2=hijos_usu
				FROM tb_Informacion_Usuario
				WHERE cod_usu=@codigo

				SELECT @cod_talla_ran2=cod_talla_ran FROM tb_Talla WHERE cod_talla=@cod_talla2

				IF @cod_talla_ran1=@cod_talla_ran2
				SET @puntaje = @puntaje + 1

				IF @cod_estCiv2 <> 2
				SET @puntaje = @puntaje + 1

				IF @cod_rasgo1 = @cod_rasgo2
				SET @puntaje = @puntaje + 1

				IF @cod_contex1 = @cod_contex2
				SET @puntaje = @puntaje + 1

				IF @cod_ing1<=@cod_ing2 or @ing_interes1='No'
				SET @puntaje = @puntaje +1

				IF @cod_act1=@cod_act2
				SET  @puntaje = @puntaje + 2

				IF @hijos_usu2 = 0 or @hijos_interes1 ='Si'
				SET @puntaje = @puntaje + 1

				SET @porcentaje = (@puntaje*100)/9.0

				INSERT INTO tb_Compatibilidad(cod_usu1,cod_usu2,porcentaje)
				VALUES (@cod_usu,@codigo,@porcentaje)

				FETCH NEXT FROM usuarios INTO @codigo
			END
		CLOSE usuarios
		DEALLOCATE usuarios
	END
GO

exec pr_insertarCompatibilidad 1
exec pr_insertarCompatibilidad 2
exec pr_insertarCompatibilidad 3
exec pr_insertarCompatibilidad 4
exec pr_insertarCompatibilidad 5
exec pr_insertarCompatibilidad 6
go
