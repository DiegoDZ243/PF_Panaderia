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

describe auditorias;
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
			set texto='ACTIVAR'; 
		ELSE 
			set texto='DESCONTINUAR';
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
join empleados e on e.idEmpleado=a.idEmpleado;  

INSERT INTO panes (nombre, descripcion, precio, stock, imagenPan, categoria)
VALUES
('Pan Blanco', 'Pan suave clásico', 15.50, 20, 'a', 'Trigo'),
('Pan Integral', 'Pan saludable de fibra', 18.00, 30, '0x00', 'Integral'),
('Pan Centeno', 'Pan más oscuro y denso', 22.00, 15, '0x00', 'Centeno');


insert into empleados(nombre,apellidos,usuario,contraseña,telefono)
values ('Diego','Diaz','DiegoDiaz',sha2('hola',256),445); 

INSERT INTO ordenes (fechaOrden, idEmpleado)
VALUES
('2025-01-10 10:15:00', 1),
('2025-01-10 12:30:00', 1),
('2025-01-11 09:45:00', 1),
('2025-01-11 17:20:00', 1);

INSERT INTO detalleOrden (idPan, idOrden, unidades, precio)
VALUES
(1, 1, 5, 12.50),
(2, 1, 2, 8.00),
(3, 2, 6, 10.00),
(1, 2, 3, 12.50),
(1, 3, 10, 5.00),
(2, 3, 1, 8.00),
(3, 4, 4, 10.00),
(1, 4, 2, 15.00);



select idEmpleado from empleados where idEmpleado=1 and contraseña=sha2('hola',256); 
 
call spLoginEmpleado("DiegoDiaz",sha2('hola',256)); 
update empleados set administrador=false where idEmpleado=1; 
call spEsAdmin(1); 
call spMostrarEmpleados; 
select * from detalleOrden; 
 
create user 'panes'@'localhost' identified by 'root'; 
grant all privileges on ventaspan.* to 'panes'@'localhost'; 

