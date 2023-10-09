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
