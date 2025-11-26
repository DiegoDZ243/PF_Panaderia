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
    descontinuado	bool			default false
); 

create table empleados(
	idEmpleado		int				primary key		auto_increment,
    nombre			varchar(50)		not null,
    apellidos		varchar(50)		not null,
    usuario			varchar(50)		not null		unique, 
	contraseña		varchar(64)		not null, 
    telefono		varchar(13)		not null,
    activo			boolean			default		true
); 

create table admins(
	idAdmin			int		primary key		auto_increment,
    idEmpleado		int		not null		unique,
    foreign key (idEmpleado)	references empleados(idEmpleado)
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
    precio			decimal(10,2)	not null,
    foreign key (idPan)		references panes(idPan),
    foreign key (idOrden)	references ordenes(idOrden)
); 

create table auditoria(
	idAuditoria		int				primary key 	auto_increment,
    tipoDeCambio	varchar(20)		not null,
	precioAnterior	decimal(10,2)	not null, 
	precioNuevo		decimal(10,2)	not null, 
    idEmpleado		int 			not null, 
    idPan			int				not null, 
    foreign key (idEmpleado)		references empleados(idEmpleado), 
    foreign key (idPan)			references panes(idPan)
); 

-- Stored Procedures
-- Muestra la información sobre los empleados 
delimiter $$
create procedure spMostrarEmpleados()
begin
	select idEmpleado, nombre, apellidos, usuario, telefono from empleados where activo=true; 
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

-- Actualizar datos de empleado
delimiter $$
create procedure spRegistrarEmpleado(
	in pNombre			varchar(50)		,
    in pApellidos		varchar(50),
    in pUsuario			varchar(50), 
	in pContraseña		varchar(64), 
    in pTelefono		varchar(13)
)
begin 
	insert into empleados (nombre, apellidos, usuario, contraseña, telefono)
	values(pNombre,pApellidos,pUsuario,pContraseña,pTelefono); 
end $$
delimiter ; 

-- Actualiza los datos del empleado
delimiter $$
create procedure spActualizarEmpleado(
	in pIdEmpleado		int,
    in pNombre			varchar(50),
    in pApellidos		varchar(50),
    in pUsuario			varchar(50), 
    in pTelefono		varchar(13)
)
begin 
	update empleados 
		set nombre=pNombre, 
			apellidos=pApellidos,
			usuario=pUsuario,
			telefono=pTelefono
        where idEmpleado=pIdEmpleado; 
end $$
delimiter ;

delimiter $$
create procedure spLoginEmpleado(pUsuario varchar (50), pContraseña	varchar(64))
begin
	select idEmpleado, nombre from empleados where usuario=pUsuario and contraseña=pContraseña; 
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

INSERT INTO panes (nombre, descripcion, precio, stock, imagenPan, categoria)
VALUES
('Pan Blanco', 'Pan suave clásico', 15.50, 20, 'a', 'Trigo'),
('Pan Integral', 'Pan saludable de fibra', 18.00, 30, '0x00', 'Integral'),
('Pan Centeno', 'Pan más oscuro y denso', 22.00, 15, '0x00', 'Centeno');

insert into empleados(nombre,apellidos,usuario,contraseña,telefono)
values ('Diego','Diaz','DiegoDiaz',sha2('hola',256),445); 

select idEmpleado from empleados where idEmpleado=1 and contraseña=sha2('No sé',256); 

begin; 
select fnCrearOrden(1) into @id;
select @id;  
select * from ordenes; 
insert into detalleOrden (idPan,idOrden,unidades) values(1,@id,10); 
select * from detalleOrden; 
select * from panes; 
select * from empleados;
rollback; 


select * from detalleOrden; 

call spReporteDeVentaMeses('2025-11-10','2025-12-10'); 
select fnCrearOrden(1) into @id;
insert into ordenes(idOrden,fechaOrden,idEmpleado) values(9,'2025-11-10',1); 
insert into detalleOrden (idPan,idOrden,unidades) values(1,9,1); 
select * from mysql.user; 
create user 'panes'@'localhost' identified by 'root'; 
grant all privileges on ventaspan.* to 'panes'@'localhost'; 