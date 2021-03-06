DROP DATABASE IF EXISTS DDS_TP_ANUAL;

CREATE DATABASE DDS_TP_ANUAL;

USE DDS_TP_ANUAL;

#USE db_a6c969_disenio;

CREATE TABLE IF NOT EXISTS usuario(
    usuario_id INT NOT NULL AUTO_INCREMENT,
    usuario_nombre varchar(50) NULL,
    usuario_contrasenia varchar(50) NULL,
    usuario_admin bool NULL,
    
    PRIMARY KEY(usuario_id)
)ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS egreso(
	id_egreso INT NOT NULL AUTO_INCREMENT,
    cant_presupuestos_requeridos INT NOT NULL,
    valor_total INT NOT NULL,
	descripcion VARCHAR(90) NULL,
	fecha DATETIME NOT NULL,
	id_prov INT NULL,
    id_presupuesto_elegido INT NULL,
    id_entidad_base INT NULL,
    id_entidad_juridica INT NULL,
    id_ingreso INT NULL,
    id_documento_comercial INT NULL,
    id_proyecto INT NULL,

    
    PRIMARY KEY(id_egreso)
)ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS ingreso(
	id_ingreso INT NOT NULL AUTO_INCREMENT,
    descripcion VARCHAR(90) NOT NULL,
	total INT NOT NULL,
    id_proyecto INT NULL,
    
    PRIMARY KEY(id_ingreso)
)ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS proveedor(
	id_prov INT NOT NULL AUTO_INCREMENT,
    CUIT INT NULL,
    razon_social VARCHAR(45) NULL,
    
    PRIMARY KEY(id_prov)
)ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS presupuesto(
	id_presupuesto INT NOT NULL AUTO_INCREMENT,
    valor_total INT NULL,
    id_prov INT NOT NULL,
    id_egreso INT NOT NULL,
    id_documento_comercial INT NULL,
    
    PRIMARY KEY(id_presupuesto)
)ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS documento_comercial(
	id_documento INT NOT NULL AUTO_INCREMENT,
    numero INT NOT NULL,
    tipo VARCHAR(45) NOT NULL,
	#id_egreso INT NULL,
    #id_presupuesto INT NULL,
    
    PRIMARY KEY(id_documento)
)ENGINE=INNODB;


#-----CREACION DE ORGANIZACION-----

CREATE TABLE IF NOT EXISTS tipo_organizacion(
	id_tipo INT NOT NULL AUTO_INCREMENT,
    tipo VARCHAR(90) NOT NULL,
    #tope_personal_por_actividad,
    #tope_ventas_por_actividad,
    categoria VARCHAR(45) NULL,
    discriminador VARCHAR(45) NOT NULL,
    
	PRIMARY KEY(id_tipo)
)ENGINE=INNODB;


CREATE TABLE IF NOT EXISTS entidad_juridica(
	id_juridica INT NOT NULL AUTO_INCREMENT,
    codigo_IGJ INT NULL,
    CUIT INT NULL,
    direccion_postal VARCHAR(45) NULL,
    razon_social VARCHAR(45) NOT NULL,

	actividad VARCHAR(90) NOT NULL,
    cant_personal INT NOT NULL,
    nombre_ficticio VARCHAR(45) NOT NULL,
    promedio_ventas_anuales FLOAT NOT NULL,
    id_tipo_organizacion INT NOT NULL,

    PRIMARY KEY(id_juridica)
)ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS entidad_base(
    id_base INT NOT NULL AUTO_INCREMENT,
    descripcion VARCHAR(90) NULL,
    id_juridica INT NULL,
    
	actividad VARCHAR(90) NOT NULL,
    cant_personal INT NOT NULL,
    nombre_ficticio VARCHAR(45) NOT NULL,
    promedio_ventas_anuales FLOAT NOT NULL,
	id_tipo_organizacion INT NOT NULL,

    PRIMARY KEY(id_base)
)ENGINE=INNODB;

#-----FIN ORGANIZACIONES-----

#-----CREACION ITEMS-----

CREATE TABLE IF NOT EXISTS item(
	id_item INT NOT NULL AUTO_INCREMENT,
    id_egreso INT NULL,
    id_proveedor INT NULL,
    id_presupuesto INT NULL,
    valor INT NULL,
    cantidad INT NULL,
    descripcion VARCHAR(90) NOT NULL,
    
    PRIMARY KEY(id_item)
)ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS criterio(
	id_criterio INT NOT NULL AUTO_INCREMENT,
    descripcion VARCHAR(90) NOT NULL,
    jerarquia INT NOT NULL,
    
    PRIMARY KEY(id_criterio)
)ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS categoria(
	id_categoria INT NOT NULL AUTO_INCREMENT,
    descripcion VARCHAR(90) NULL,
    id_criterio INT NULL,
    
    PRIMARY KEY(id_categoria)
)ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS criterio_categoria_por_item(
	id_criterio_categoria_por_item INT NOT NULL AUTO_INCREMENT,
    id_item INT NOT NULL,
    id_criterio INT NOT NULL,
    id_categoria INT NOT NULL,
    
    PRIMARY KEY(id_criterio_categoria_por_item)
)ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS proyecto_financiamiento(
	id_proyecto INT NOT NULL AUTO_INCREMENT,
    presupuestos_exigibles INT NULL,
    monto_total INT NULL,
    id_director INT NULL,
    
    PRIMARY KEY(id_proyecto)
)ENGINE=INNODB;
