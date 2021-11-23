-- Nome: Arthur Lins Beluci
-- Nome: Diego Aparecido Armindo
-- Nome: Heiter Paganin Malagoli
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
	nome_gasto		varchar(100) not null,
	valor_gasto		decimal(10,2) not null,
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
	nome_cliente	varchar(max),
	tel_cliente		varchar(max),
	hora_entrada	time not null,
	hora_saida		time,
	data_entrada	date not null,
	status			int not null,
	tipo_pedido		int not null,
	check(tipo_pedido in (0,1)),
	check(status in (0,1))
)
go

CREATE TABLE tb_produtos(
	id_produto		int primary key identity not null,
	cod_usuario		int references tb_funcionarios not null,
	nome			varchar(100) not null,
	categoria		varchar(50) not null,
	descricao		varchar(150),
	valor			decimal(10,2) not null,
	estado			int not null,
	CHECK(estado in (0,1))
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

--Procedures Gastos--

CREATE PROCEDURE ExcluiGasto
	@id_gasto int
AS
BEGIN
	DELETE FROM tb_gastos_brutos WHERE id_gasto = @id_gasto;
END;
GO

CREATE PROCEDURE AtualizaGasto
	@id_gasto int,
	@nome  varchar(100),
	@valor decimal(10,2),
	@data_pagamento date='',
	@data_vencimento date=''
AS
BEGIN
	UPDATE tb_gastos_brutos 
		SET nome_gasto = @nome, valor_gasto = @valor, data_pagamento = @data_pagamento, data_vencimento = @data_vencimento 
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
	@nome varchar(100),
	@valor decimal(10,2), 
	@data_pagamento date='',
	@data_vencimento date=''
)
AS
BEGIN
	INSERT INTO tb_gastos_brutos VALUES (@cod_usuario,@nome, @valor, @data_pagamento, @data_vencimento)
END
GO

--Procedures Produtos--
CREATE view VProdutosAll
AS
	SELECT * FROM tb_produtos 
	WHERE estado!=0
GO

CREATE PROCEDURE CadastroProduto
(
	@cod_usuario int, 
	@nome varchar(100),
	@categoria varchar(50),
	@descricao varchar(150)='',
	@valor decimal(10,2),
	@estado int
)
AS
BEGIN
	INSERT INTO tb_produtos VALUES (@cod_usuario, @nome, @categoria, @descricao, @valor, @estado)
END
GO

CREATE PROCEDURE UpdateProduto
(
	@id_produto int,
	@nome varchar(100),
	@categoria varchar(50),
	@descricao varchar(150)='',
	@valor decimal(10,2),
	@estado int
)
AS
BEGIN
	UPDATE tb_produtos 
	SET nome=@nome, categoria=@categoria, descricao=@descricao,valor=@valor, estado=1
	WHERE id_produto=@id_produto
END
GO

CREATE PROCEDURE DesabilitaProduto
(
	@id_produto int
)
AS
BEGIN
	UPDATE tb_produtos 
	SET estado=0 
	WHERE id_produto=@id_produto
END
GO

-- Procedures e Views Pedidos --

CREATE VIEW VPedidosAll
AS 
	SELECT * FROM tb_pedidos
GO

CREATE PROCEDURE FinalizaPedido
(
	@id_pedido int
)
AS
BEGIN
	UPDATE tb_pedidos 
	SET status=1, hora_saida = GETDATE()
	WHERE id_pedido=@id_pedido
END
GO
--View Top4 Produtos mais vendidos
CREATE VIEW Vtop10produto AS
SELECT TOP 10 c.nome,b.valor_unitario,sum(b.valor_total) as Valor_total,sum(b.qtde)as qtde
	FROM tb_pedidos a
	INNER JOIN tb_itens_pedidos b ON a.id_pedido=b.cod_pedido
	INNER JOIN tb_produtos c ON b.cod_produto=c.id_produto
	WHERE a.data_entrada=convert(DATE,GETDATE())
	GROUP BY c.nome,b.valor_unitario
	ORDER BY valor_total desc
GO

--View Media Pedidos do dia
CREATE VIEW Vmediadiaped AS
 select sum( b.Valor_total) / ( select count(1) from tb_pedidos where data_entrada = convert(DATE,GETDATE()) ) as Media
	from tb_pedidos a
	inner join tb_itens_pedidos b on a.id_pedido = b.cod_pedido
	WHERE a.data_entrada=convert(DATE,GETDATE()) 
GO

--View monstruosa de Despesas X Receitas--
CREATE VIEW VReceitaXDespesas 
AS
	SELECT SUM(a.valor_gasto) AS valor_gasto, SUM(b.valor_total) AS total_pedidos
		FROM tb_gastos_brutos a
		FULL OUTER JOIN tb_itens_pedidos b 
		ON(a.id_gasto=b.cod_pedido)
		WHERE a.id_gasto IS NULL OR b.cod_pedido IS NULL
GO