-- Nome: Arthur Lins Beluci
-- Nome: Diego Aparecido Armindo
-- Nome: Heiter Pagamin Malagoli
-- FATEC Rio Preto 		4ª ADS Tarde

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
	email			varchar(100) not null,
	endereco		varchar(150) null,
	check (estado in(0,1))
)
go

-- admin = 1 -> admin
CREATE TABLE tb_funcionarios(
	cod_usuario		int primary key references tb_usuarios,
	funcao			varchar(20) not null,
	admin			int not null
)
go

CREATE TABLE tb_gastos_brutos(
	id_gasto		int primary key identity not null,
	cod_usuario		int references tb_funcionarios not null,
	nome_gasto		varchar(100),
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
	cod_usuario		int references tb_funcionarios not null,
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
	cod_usuario		int references tb_funcionarios not null,
	categoria		varchar(50) not null,
	valor			float not null,
	nome			varchar(100) not null,
	descricao		varchar(150) not null,
	estado			int not null
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

INSERT INTO tb_usuarios VALUES ('Juliana Lins', 'juliana.lins', '123', '17992485735', 1, 'teste@teste.com.br', 'Rua teste')
go
INSERT INTO tb_usuarios VALUES ('Garçom Ferreira', 'garcom.ferreira', '321', '18995623564', 1, 'garcom@teste.com.br', 'Rua bla bla')
GO

INSERT INTO tb_funcionarios VALUES (1, 'Administrador', 1)
GO

select * from tb_funcionarios
GO

select * from tb_usuarios
GO

insert into tb_gastos_brutos values (1, 290.30, GETDATE(), '2021-11-05','Teste1') -- da certo
insert into tb_gastos_brutos values (1, 290.30, GETDATE(), '06/11/2021','Teste2') -- da certo tbm
GO

CREATE PROCEDURE ExcluiGasto
	@id_gasto int
AS
BEGIN
	DELETE FROM tb_gastos_brutos WHERE id_gasto = @id_gasto;
END;
GO

CREATE PROCEDURE AtualizaGasto
	@id_gasto int,
	@valor float,
	@data_pagamento date,
	@data_vencimento date,
	@nome  varchar(100)
AS
BEGIN
	UPDATE tb_gastos_brutos 
		SET valor_gasto = @valor, data_pagamento = @data_pagamento, data_vencimento = @data_vencimento, nome_gasto = @nome
		WHERE id_gasto = @id_gasto
END;
GO

CREATE VIEW VGastosBrutosAll
AS
   SELECT * FROM tb_gastos_brutos
GO

CREATE PROCEDURE CadastroGasto
(
	@cod_usuario int,
	@valor float, 
	@data_pagamento date,
	@data_vencimento date,
	@nome varchar(100)
)
AS
BEGIN
	INSERT INTO tb_gastos_brutos VALUES (@cod_usuario, @valor, @data_pagamento, @data_vencimento, @nome)
END
GO

--Cadastro de gastos pela procedure
EXEC CadastroGasto 1, 500, '03/10/2021', '08/11/2021'

--Views--
-- CREATE VIEW vLogin (@login varchar(20), @senha varchar(10)) as 
-- SELECT * 
-- from tb_usuarios 
-- WHERE login=@login and senha=@senha

--Heiter 05/11--
insert into tb_produtos 
values (1,'Bebida',8.30,'Aquele cara','tueummm',0)

insert into tb_produtos 
values (1,'Sushi',12.00,'Sushi especial da ju','Gostoso hmmm',1)
go
select * from tb_produtos

select * from tb_gastos_brutos

--Create--
insert into tb_produtos values (cod_usuario,'Bebida',8.30,'Aquele cara','tueummm',0)

--ReadAll--
select * from tb_produtos where estado!=0
--Read de 1 produto--
select * from tb_produtos where id_produto=@id_produto
--Update editar--
update tb_produtos 
set id_produto=@id_produto, cod_usuario=@cod_usuario, categoria=@categoria, valor=@valor, nome=@nome, descricao=@descricao, estado=1
--Update de desabilitar--
update tb_produtos 
set estado=0 where id=@id

