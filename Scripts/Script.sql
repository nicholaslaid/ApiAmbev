DROP TABLE IF EXISTS logs;
DROP TABLE IF EXISTS bebidas;
DROP TABLE IF EXISTS cliente;
DROP TABLE IF EXISTS vendedor;
DROP TABLE IF EXISTS vendas;
DROP TABLE IF EXISTS produtos_vendidos;


SELECT * FROM logs;
SELECT * FROM bebidas;
SELECT * FROM cliente;
SELECT * FROM vendedor;
SELECT * FROM vendas;
SELECT * FROM produtos_vendidos;


CREATE TABLE IF NOT EXISTS logs(
	id BIGSERIAL PRIMARY KEY,
	creation_date TIMESTAMP,
	type VARCHAR(10),
	message TEXT
);
CREATE TABLE IF NOT EXISTS bebidas(
	id serial  PRIMARY KEY,
	nome VARCHAR(50),
	tipo VARCHAR(50),
	marca VARCHAR(50),
	frasco VARCHAR(50),
	volume real,
	deleted bool,
	data_registro time,
	valor_unitario real
);
CREATE TABLE IF NOT EXISTS cliente(
	id serial,
	nome VARCHAR(50) PRIMARY KEY,
	endereco VARCHAR(50),
	email VARCHAR(50),
	telefone VARCHAR(50)
	
);
CREATE TABLE IF NOT EXISTS vendedor(
	id serial,
	nome VARCHAR(50) PRIMARY KEY,
	cpf VARCHAR(50),
	cidade VARCHAR(50),
	estado VARCHAR(50)
	
);
CREATE TABLE IF NOT EXISTS vendas(
	id serial PRIMARY KEY,
	data date,
	nome_cliente varchar(50) references cliente,
	nome_vendedor varchar(50) references vendedor,
	qtd_produtos integer,
	valor_total real
	
);
CREATE TABLE IF NOT EXISTS produtos_vendidos(
	id serial,
	id_produto Integer REFERENCES bebidas,
	id_venda INTEGER,
	quantidade integer,
	subtotal real,
	valor_unitario real
);


select v.id, p.nome_produto, p.quantidade, p.valor_unitario, p.subtotal
from produtos_vendidos p, vendas v
where p.id_venda = v.id


INSERT INTO cliente(nome, endereco, email, telefone) Values('Luiz', 'rua barea 170', 'luiz@gmail.com', '2132131123');
INSERT INTO cliente(nome, endereco, email, telefone) Values('Joao', 'rua julio de castilhos 170', 'joao@gmail.com', '324324234');
INSERT INTO cliente(nome, endereco, email, telefone) Values('Felipe', 'rua os 18 do forte 170', 'felipe@gmail.com', '2132131123');

INSERT INTO vendedor(nome, cpf, cidade, estado) Values('Andre', '344234224', 'Caxias do sul', 'RS');
INSERT INTO vendedor(nome, cpf, cidade, estado) Values('Lorenzo', '1122121', 'Caxias do sul', 'RS');
INSERT INTO vendedor(nome, cpf, cidade, estado) Values('Otavio', '656565565', 'Caxias do sul', 'RS');


INSERT INTO vendas(data, nome_cliente, nome_vendedor, qtd_produtos, valor_total) Values('2023-09-28', 'Luiz', 'Andre', 2, 300 );
INSERT INTO vendas(data, nome_cliente, nome_vendedor, qtd_produtos, valor_total) Values('2023-09-28', 'Joao', 'Lorenzo', 3, 300 );
INSERT INTO vendas(data, nome_cliente, nome_vendedor, qtd_produtos, valor_total) Values('2023-09-28', 'Felipe', 'Otavio', 1, 100 );

INSERT INTO produtos_vendidos(id_produto, id_venda, quantidade, subtotal, valor_unitario) Values(1, 2, 1, 150, 150)
INSERT INTO produtos_vendidos(id_produto, id_venda, quantidade, subtotal, valor_unitario) Values(1, 2, 1, 150, 150)
INSERT INTO produtos_vendidos(id_produto, id_venda, quantidade, subtotal, valor_unitario) Values(2, 3, 2, 200, 200)
INSERT INTO produtos_vendidos(id_produto, id_venda, quantidade, subtotal, valor_unitario) Values(2, 3, 1, 100, 100)

INSERT INTO bebidas (nome, marca, tipo, volume, frasco, deleted, data_registro, valor_unitario)
VALUES ('Jack Daniels', 'Jack Daniels', 'Alcoolico', 1000 , 'vidro', 'false', '7:00:00', 300)
INSERT INTO bebidas (nome, marca, tipo, volume, frasco, deleted, data_registro, valor_unitario)
VALUES ('Coca-Cola', 'Coca-Cola', 'Refrigerante', 2000 , 'plastico', 'false', '9:00:00', 10)
INSERT INTO bebidas (nome, marca, tipo, volume, frasco, deleted, data_registro, valor_unitario)
VALUES ('Agua Mineral', 'Agua da Pedra', 'Agua', 1000 , 'plastico', 'false', '7:00:00', 300)


