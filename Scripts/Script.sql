SELECT * FROM logs;
DROP TABLE IF EXISTS logs;
CREATE TABLE IF NOT EXISTS logs(
	id BIGSERIAL PRIMARY KEY,
	creation_date TIMESTAMP,
	type VARCHAR(10),
	message TEXT
);
SELECT * FROM bebidas;
DROP TABLE IF EXISTS bebidas;
CREATE TABLE IF NOT EXISTS bebidas(
	id serial PRIMARY KEY,
	nome VARCHAR(50),
	tipo VARCHAR(50),
	marca VARCHAR(50),
	frasco VARCHAR(50),
	volume real,
	deleted bool,
	data_registro time,
	valor_unitario real
);
SELECT * FROM cliente;
DROP TABLE IF EXISTS cliente;
CREATE TABLE IF NOT EXISTS cliente(
	id serial,
	nome VARCHAR(50) PRIMARY KEY,
	endereco VARCHAR(50),
	email VARCHAR(50),
	telefone VARCHAR(50)
	
);
SELECT * FROM vendedor;
DROP TABLE IF EXISTS vendedor;
CREATE TABLE IF NOT EXISTS vendedor(
	id serial,
	nome VARCHAR(50) PRIMARY KEY,
	cpf VARCHAR(50),
	cidade VARCHAR(50),
	estado VARCHAR(50)
	
);
SELECT * FROM vendas;
DROP TABLE IF EXISTS vendas;
CREATE TABLE IF NOT EXISTS vendas(
	id serial PRIMARY KEY,
	data time,
	nome_cliente varchar(50) references cliente,
	nome_vendedor varchar(50) references vendedor,
	nome_produto varchar(50) references produtos_vendidos,
	valor_total real
	
);
SELECT * FROM produtos_vendidos;
DROP TABLE IF EXISTS produtos_vendidos;
CREATE TABLE IF NOT EXISTS produtos_vendidos(
	id serial,
	nome VARCHAR(50) PRIMARY KEY,
	quantidade integer,
	subtotal real,
	valor_unitario real
	
);





