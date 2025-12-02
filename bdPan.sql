drop database if exists ventasPan; 
create database ventasPan; 
use ventasPan; 

create table panes(
	idPan			int 			primary key 	auto_increment,
	nombre			varchar(60)		not null		unique,
	descripcion		text			null, 
    precio			decimal(10,2)	not null,
    stock			int				not null,
    imagenPan		varchar(255)	not null,
    categoria		enum('Trigo','Centeno','Integral','Avena')	not null,
    descontinuado	bool			not null 		default false
); 

create table empleados(
	idEmpleado		int				primary key		auto_increment,
    nombre			varchar(50)		not null,
    apellidos		varchar(50)		not null,
    usuario			varchar(50)		not null		unique, 
	contraseña		varchar(64)		not null, 
    telefono		varchar(13)		not null,
    activo			boolean			default		true,
    administrador	boolean			default		false
); 

create table ordenes(
	idOrden			int			primary key 	auto_increment,
    fechaOrden		datetime	not null 		default current_timestamp,
    idEmpleado		int 		not null,
    foreign key (idEmpleado)	references empleados(idEmpleado)
);

create table detalleOrden(
	idPan 			int				not null, 
    idOrden			int 			not null, 
	unidades		int				not null, 
    precio			decimal(10,2)	null	,
    primary key(idPan,idOrden),
    foreign key (idPan)		references panes(idPan),
    foreign key (idOrden)	references ordenes(idOrden)
); 

create table auditorias(
	idAuditoria		int				primary key 	auto_increment,
    tipoDeCambio	varchar(50)		not null,
	precioAnterior	decimal(10,2)	not null, 
	precioNuevo		decimal(10,2)	not null, 
    idEmpleado		int 			null, 
    idPan			int				not null, 
    fecha			datetime 		not null 		default 	current_timestamp,
    foreign key (idEmpleado)		references empleados(idEmpleado), 
    foreign key (idPan)				references panes(idPan)
); 


-- Stored Procedures
-- Muestra la información sobre los empleados 
delimiter $$
create procedure spMostrarEmpleados()
begin
	select idEmpleado, nombre, apellidos, usuario, telefono, administrador from empleados where activo=true; 
end $$
delimiter ; 

-- Desactiva un empleado para evitar eliminarlo de la base de datos
delimiter $$
create procedure spDesactivarEmpleado(pIdEmpleado	int)
begin 
	update empleados 
    set activo=false where idEmpleado=pIdEmpleado; 
end $$
delimiter ; 

-- Actualiza los datos del empleado
delimiter $$
create procedure spActualizarEmpleado(
	in pIdEmpleado		int,
    in pNombre			varchar(50),
    in pApellidos		varchar(50),
    in pUsuario			varchar(50), 
    in pTelefono		varchar(13), 
    in pAdministrador	bool
)
begin 
	update empleados 
		set nombre=pNombre, 
			apellidos=pApellidos,
			usuario=pUsuario,
			telefono=pTelefono,
            administrador=pAdministrador
        where idEmpleado=pIdEmpleado; 
end $$
delimiter ;


DELIMITER $$
DROP PROCEDURE IF EXISTS spRegistrarEmpleado$$

CREATE PROCEDURE spRegistrarEmpleado(
    IN pNombre          VARCHAR(50),
    IN pApellidos       VARCHAR(50),
    IN pUsuario         VARCHAR(50), 
    IN pContraseña      VARCHAR(64), 
    IN pTelefono        VARCHAR(13),
    IN pAdmin           BOOLEAN        
)
BEGIN 
    INSERT INTO empleados (nombre, apellidos, usuario, contraseña, telefono, administrador)
    VALUES (pNombre, pApellidos, pUsuario, pContraseña, pTelefono, pAdmin); 
END $$

DELIMITER ;                                                                                                                                                                            y este es el producer para validar si es admin                                                                                                                     DELIMITER $$

delimiter $$
CREATE PROCEDURE spEsAdmin(IN pIdEmpleado INT)
BEGIN
    SELECT administrador 
    FROM empleados 
    WHERE idEmpleado = pIdEmpleado;
END $$

DELIMITER ;

delimiter $$
create procedure spLoginEmpleado(pUsuario varchar (50), pContraseña	varchar(64))
begin
	select idEmpleado, nombre, administrador from empleados where usuario=pUsuario and contraseña=pContraseña; 
end $$
delimiter ; 

drop procedure if exists spReporteDeVenta; 
delimiter $$
create procedure spReporteDeVenta(fechaInicio datetime, fechaFinal datetime)
begin
	select p.idPan Clave,p.nombre Nombre, sum(do.unidades) Unidades, sum(do.unidades*do.precio) Monto
    from panes p join detalleOrden do on p.idPan=do.idPan
    join ordenes o on o.idOrden=do.idOrden
	where o.fechaOrden between fechaInicio and fechaFinal
    group by p.idPan
    order by Monto desc; 
end $$
delimiter ; 

delimiter $$
create procedure spReporteDeVentaMeses(fecha1 datetime, fecha2 datetime)
begin 
		select p.idPan Clave, p.nombre Nombre, p.precio Precio, 
			sum(case when year(o.fechaOrden)=year(fecha1) 
			and month(o.fechaOrden)=month(fecha1) then (do.unidades*do.precio) else 0 end) `Ventas Mes 1`,
            sum(case when year(o.fechaOrden)=year(fecha2) 
			and month(o.fechaOrden)=month(fecha2) then (do.unidades*do.precio) else 0 end) `Ventas Mes 2`
            from panes p join detalleOrden do on p.idPan=do.idPan
            join ordenes o on o.idOrden=do.idOrden
			group by Clave
			order by Precio desc; 
end $$
delimiter ; 

-- Actualiza la tabla de auditorias, tomando la clave primaria de la entrada más reciente de
-- auditorias, para guardar el id del empleado que realizó la operación.
delimiter $$
create procedure spEmpleado_Auditoria(
	in pIdEmpleado	int)
begin
	
	
    update auditorias 
		set idEmpleado=pIdEmpleado
        where idAuditoria=@lastin; 
end $$
delimiter ; 


-- Función que da de alta una nueva orden y retorna su id
delimiter $$
create function fnCrearOrden(pIdEmpleado int)
returns int
deterministic
begin 
	declare pIdOrden 	int;     
	
    insert into ordenes(idEmpleado) values (pIdEmpleado); 
    
	set pIdOrden=LAST_INSERT_ID();
    return pIdOrden; 
end $$
delimiter ; 

delimiter $$
create function fnLoginEmpleado(pUsuario varchar (50), pContraseña	varchar(64))
returns int
deterministic
begin
	declare pIdEmpleado int; 
	select idEmpleado from empleados where usuario=pUsuario and contraseña=pContraseña into pIdEmpleado; 
	return pIdEmpleado; 
end $$
delimiter ; 
-- -------Triggers ------
-- Verifica que haya la cantidad suficiente de panes para la orden en stock
delimiter $$
create trigger trVerificarStock before update on
panes for each row
begin 
	declare mensaje varchar(255); 
    set mensaje=CONCAT('Error: No hay suficiente stock para el producto ', new.nombre);
	if new.stock < 0 then
		SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = mensaje;
	end if; 
end $$
delimiter ; 

-- Actualiza el stock luego de registrar un detalle de venta
delimiter $$
create trigger trActualizaStock after insert on detalleOrden
for each row
begin
	update panes set stock=stock-new.unidades where idPan=new.idPan; 
end $$
delimiter ; 

-- Asigna el precio del pan en la orden. Se almacena el precio al que estaba el pan en ese momento
-- , es decir, este precio no cambiará si se actualiza en la tabla de "panes".
delimiter $$
create trigger trAsignarPrecioActual before insert on detalleOrden
for each row
begin
	declare pPrecioActual decimal(10,2); 
    select precio from panes where idPan=new.idPan into pPrecioActual; 
	set new.precio=pPrecioActual;
end $$
delimiter ; 


-- Trigger para Auditoria -> Registrar cualquier inserción en la tabla de panes
delimiter $$
create trigger trRegistrarInsertar after insert on panes
for each row
begin
	-- Los datos del empleado será recuperados del backend del programa
	insert into auditorias(tipoDeCambio,precioAnterior,precioNuevo,idPan)
    values('DAR DE ALTA',0,new.precio,new.idPan);
    set @lastIn=LAST_INSERT_ID();
end $$
delimiter ; 

-- Trigger para Auditoria -> Registrar cualquier actualización en la tabla de panes
delimiter $$
create trigger trRegistrarActualizar after update on panes
for each row
begin
	declare texto varchar(50); 
	-- Los datos del empleado será recuperados del backend del programa
    -- colocar if
    IF new.descontinuado=old.descontinuado AND new.precio!=old.precio then
		insert into auditorias(tipoDeCambio,precioAnterior,precioNuevo,idPan)
		values('ACTUALIZAR PRECIO',old.precio,new.precio,new.idPan);
        set @lastIn=LAST_INSERT_ID();
	ELSEIF new.descontinuado!=old.descontinuado AND new.precio=old.precio then
		IF new.descontinuado=true then
			set texto='DESCONTINUAR'; 
		ELSE 
			set texto='ACTIVAR';
        END IF; 
        insert into auditorias(tipoDeCambio,precioAnterior,precioNuevo,idPan)
		values(texto,old.precio,new.precio,new.idPan);
        set @lastIn=LAST_INSERT_ID();
    END IF; 
end $$
delimiter ; 



-- VIEWS
drop view if exists vwAuditorias; 
create view vwAuditorias as
select p.nombre `Producto` ,a.tipoDeCambio `Cambio`, concat(e.nombre,' ',e.apellidos) `Realizado por:`,
 a.precioAnterior `Precio Anterior`, a.precioNuevo `Precio nuevo`, 
date_format(a.fecha,'%d/%m/%y') `Fecha`from 
panes p join auditorias a on a.idPan=p.idPan
join empleados e on e.idEmpleado=a.idEmpleado order by Fecha desc;  


INSERT INTO panes (nombre, descripcion, precio, stock, imagenPan, categoria)
VALUES
('Pan Blanco', 'Pan suave clásico', 15.50, 100, 'Assorted_bread.jpg', 'Trigo'),
('Pan Integral', 'Pan saludable de fibra', 18.00, 100, 'panIntegral.png', 'Integral'),
('Pan Centeno', 'Pan más oscuro y denso', 22.00, 100, 'panCenteno.png', 'Centeno'),
('Pan Avena','Pan denso, saludable y rico en fibra',30.99,100,'panAvena.jpg','Avena'),
('Oreja','Pan hojaldrado típico de México',25.99,20,'oreja.jpg','Trigo'),
('Dona de Centeno','Es una dona normal hecha con harina de centeno',20.99,30,'donaCenteno.png','Centeno'),
('Concha de vainilla','Es una concha de vainilla',12.99,35,'concha.jpg','Trigo');


insert into empleados(nombre,apellidos,usuario,contraseña,telefono)
values ('Diego','Diaz','DiegoDiaz',sha2('hola',256),4451001000),
	   ('Hugo','Guzmán','Hugo',sha2('hola',256),4451001000),
       ('Salvador','Leyva','Salvador',sha2('hola',256),4451001001); 

INSERT INTO ordenes (fechaOrden, idEmpleado)
VALUES
('2025-02-10 10:15:00', 1),
('2025-02-10 12:30:00', 1),
('2025-01-11 09:45:00', 1),
('2025-01-11 17:20:00', 1),
('2023-03-15 08:30:00', 2),   -- 5
('2023-07-22 14:10:00', 3),   -- 6
('2023-12-01 17:45:00', 1),   -- 7
('2024-01-10 09:20:00', 2),   -- 8
('2024-04-05 18:55:00', 3),   -- 9
('2024-06-12 11:40:00', 1),   -- 10
('2024-09-28 16:30:00', 2),   -- 11
('2024-11-19 13:10:00', 1),   -- 12
('2025-01-02 10:00:00', 3),   -- 13
('2025-02-01 07:50:00', 2),   -- 14
('2025-03-03 19:00:00', 1),   -- 15
('2025-03-15 15:15:00', 3),   -- 16
('2025-04-21 08:10:00', 2),   -- 17
('2025-05-01 20:45:00', 1),   -- 18
('2025-05-29 12:25:00', 3),
('2023-01-12 09:10:00', 1),   -- 20
('2023-02-08 13:25:00', 2),   -- 21
('2023-05-19 18:40:00', 3),   -- 22
('2023-10-03 07:55:00', 1),   -- 23
('2024-02-14 10:05:00', 2),   -- 24
('2024-03-30 12:30:00', 3),   -- 25
('2024-07-18 16:20:00', 1),   -- 26
('2024-08-09 14:45:00', 3),   -- 27
('2024-12-22 09:15:00', 2),   -- 28
('2025-01-18 11:35:00', 1),   -- 29
('2025-02-27 19:50:00', 3),   -- 30
('2025-03-28 08:40:00', 2),   -- 31
('2025-04-10 17:00:00', 1),   -- 32
('2025-05-12 13:55:00', 3),   -- 33
('2025-06-04 09:25:00', 2);   -- 34

INSERT INTO detalleOrden (idPan, idOrden, unidades, precio)
VALUES
(1, 1, 5, 12.50),
(2, 1, 2, 8.00),
(3, 2, 6, 10.00),
(1, 2, 3, 12.50),
(1, 3, 10, 5.00),
(2, 3, 1, 8.00),
(3, 4, 4, 10.00),
(1, 4, 2, 15.00),
-- Orden 5
(1, 5, 3, 15.50),
(2, 5, 1, 18.00),

-- Orden 6
(3, 6, 2, 22.00),
(1, 6, 4, 15.50),

-- Orden 7
(2, 7, 5, 18.00),

-- Orden 8
(1, 8, 2, 15.50),
(3, 8, 1, 22.00),

-- Orden 9
(3, 9, 3, 22.00),
(2, 9, 2, 18.00),

-- Orden 10
(1, 10, 6, 15.50),

-- Orden 11
(2, 11, 4, 18.00),
(1, 11, 2, 15.50),

-- Orden 12
(3, 12, 5, 22.00),

-- Orden 13
(1, 13, 3, 15.50),
(2, 13, 3, 18.00),

-- Orden 14
(3, 14, 4, 22.00),

-- Orden 15
(1, 15, 10, 15.50),

-- Orden 16
(2, 16, 2, 18.00),
(3, 16, 1, 22.00),

-- Orden 17
(1, 17, 1, 15.50),
(2, 17, 2, 18.00),
(3, 17, 1, 22.00),

-- Orden 18
(3, 18, 6, 22.00),

-- Orden 19
(1, 19, 2, 15.50),
(3, 19, 2, 22.00),

-- Orden 20
(1, 20, 4, 15.50),
(4, 20, 1, 30.99),

-- Orden 21
(2, 21, 2, 18.00),
(7, 21, 3, 12.99),

-- Orden 22
(3, 22, 2, 22.00),
(6, 22, 2, 20.99),

-- Orden 23
(7, 23, 5, 12.99),

-- Orden 24
(4, 24, 2, 30.99),
(1, 24, 1, 15.50),

-- Orden 25
(6, 25, 4, 20.99),

-- Orden 26
(1, 26, 3, 15.50),
(5, 26, 2, 25.99),

-- Orden 27
(3, 27, 1, 22.00),
(2, 27, 2, 18.00),
(7, 27, 2, 12.99),

-- Orden 28
(4, 28, 3, 30.99),

-- Orden 29
(5, 29, 4, 25.99),
(1, 29, 2, 15.50),

-- Orden 30
(2, 30, 3, 18.00),
(6, 30, 1, 20.99),

-- Orden 31
(7, 31, 6, 12.99),

-- Orden 32
(3, 32, 3, 22.00),
(4, 32, 1, 30.99),

-- Orden 33
(1, 33, 5, 15.50),

-- Orden 34
(6, 34, 3, 20.99),
(2, 34, 1, 18.00);


update auditorias set idEmpleado=1 where idAuditoria between 1 and 7; 
update empleados set administrador=true where idEmpleado=1; 
update empleados set usuario='DiegoDiaz' where idEmpleado=1; 
create user 'panes'@'localhost' identified by 'root'; 
grant all privileges on ventaspan.* to 'panes'@'localhost'; 
