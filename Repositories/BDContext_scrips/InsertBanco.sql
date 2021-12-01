--Usuarios:
INSERT INTO tb_usuarios VALUES ('Juliana Lins', 'juliana.lins', '123', '17992485735', 1, 'teste@teste.com.br', 'Rua teste')
go
INSERT INTO tb_usuarios VALUES ('Garçom Ferreira', 'garcom.ferreira', '321', '18995623564', 1, 'garcom@teste.com.br', 'Rua bla bla')
GO
INSERT INTO tb_usuarios VALUES ('Terceiro usuario', 'usurio3', 1234, '18995523564', 0, 'usuario3@teste.com.br', 'Rua bla bla bla')

--Funcionarios:
INSERT INTO tb_funcionarios VALUES (1, 'Administrador', 1)
GO
INSERT INTO tb_funcionarios VALUES (2, 'Garçom', 0)
GO
INSERT INTO tb_funcionarios VALUES (3, 'Usuario3', 1)
GO

--Gastos Brutos:
INSERT INTO tb_gastos_brutos
VALUES (1,'Cadeira',30, GETDATE(),GETDATE())
GO
INSERT INTO tb_gastos_brutos
VALUES(2,'Mesa',50,'03/11/2021','04/11/2021')
GO

INSERT INTO tb_gastos_brutos
VALUES(1,'Porta',100,'05/11/2021','06/11/2021')
GO

--Pedidos:
INSERT INTO tb_pedidos
VALUES (1,'Mesa 2','179888888','13:00','14:00', GETDATE(),1,0)
GO

INSERT INTO tb_pedidos
VALUES (2,'Pedro','17232323','14:00','15:00','08/11/2021',1,0)
GO

INSERT INTO tb_pedidos
VALUES (1,'Marcelo','174444444','16:00','17:00','09/11/2021',0,0)
GO

INSERT INTO tb_pedidos
VALUES (1,'Mesa 3','179888887','13:00','14:00', GETDATE(),1,0)
GO

INSERT INTO tb_pedidos
VALUES (1,'Mesa 4','179888886','13:00','14:00', GETDATE(),1,0)
GO

--Produtos:
INSERT INTO tb_produtos
VALUES (1,'Sushi da ju 1','Sushis','Um delicioso sushi um',30.55,1)
GO
INSERT INTO tb_produtos
VALUES (1, 'Pãozinho da ju','Pãozinho','Uma porção de pãezinhos gostosos',10.56,1)
GO
INSERT INTO tb_produtos
VALUES (2, 'Garçons foods','Foods','So para dar 3 inserts',5.52,1)
GO

--Itens Pedido
INSERT INTO tb_itens_pedidos
VALUES (1,1,10,30.55,10*30.55)
GO

INSERT INTO tb_itens_pedidos
VALUES (2,1,5,30.55,5*30.55)
GO

INSERT INTO tb_itens_pedidos
VALUES (2,2,6,10.56,6*10.56)
GO

INSERT INTO tb_itens_pedidos
VALUES (5,1,5,30.55,5*30.55)
GO

INSERT INTO tb_itens_pedidos
VALUES (4,2,6,10.56,6*10.56)
GO