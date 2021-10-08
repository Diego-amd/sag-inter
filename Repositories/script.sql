CREATE DATABASE db_sag
GO

USE db_sag
GO

-- estado = 0 => inativo
-- estado = 1 => ativo
CREATE TABLE tb_usuarios (
	id_usuario		int primary key identity not null,
	nome			varchar(150) not null,
	login			varchar(20) not null,
	senha			varchar(10)	not null,
	telefone		varchar(15) null,
	estado			int not null,
	check (estado in(0,1))
)
go

CREATE TABLE tb_funcionarios(
	cod_usuario		int primary key references tb_usuarios,
	funcao			varchar(20) not null,
	endereco		varchar(150) null,
)
go

CREATE TABLE tb_admin(
	cod_usuario		int primary key references tb_usuarios,
	email			varchar(100) not null
)
go

CREATE TABLE tb_gastos_brutos(
	id_gasto		int primary key identity not null,
	cod_usuario		int references tb_admin not null,
	valor_gasto		float not null,
	data_pagamento	date,
	data_vencimento	date
)
go

-- tipo_pedido = 0 => presencial
-- tipo_pedido = 1 => online
-- status = 0 => andamento
-- status = 1 => finalizado
CREATE TABLE tb_pedidos(
	id_pedido		int primary key identity not null,
	cod_usuario		int references tb_usuarios not null,
	hora_entrada	time not null,
	hora_saida		time not null,
	data_entrada	date not null,
	data_saida		date not null,
	status			int not null,
	tipo_pedido		int not null,
	check(tipo_pedido in (0,1)),
	check(status in (0,1))
)
go

CREATE TABLE tb_produtos(
	id_produto		int primary key identity not null,
	categoria		int not null,
	valor			float not null,
	nome			varchar(100) not null,
	descricao		varchar(150) not null
)
go

CREATE TABLE tb_itens_pedidos(
	cod_pedido		int references tb_pedidos not null,
	cod_produto		int references tb_produtos not null,
	qtde			int not null,
	valor_unitario	decimal(10,2) not null,
	valor_total		decimal(10,2) not null,
	primary key (cod_pedido, cod_produto)
)
go

INSERT INTO tb_usuarios VALUES ('Juliana Lins', 'juliana.lins', '123', '17992485735', 1)
INSERT INTO tb_usuarios VALUES ('Garçom Ferreira', 'garcom.ferreira', '321', '18995623564', 1)

INSERT INTO tb_funcionarios VALUES (2, 'Garçom', 'R. Teste cadastro, 3505, Jd. Conceição')

INSERT INTO tb_admin VALUES (1, 'juliana.lins@gmail.com')

